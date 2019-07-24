using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EMS.DataAccess;
using EMS.Entity.Entities;

using EMS.Entity.DtoModel;
using EMS.Services.Interface;
using AutoMapper;

using EMS.Infrastructure.Extensions;
using EMS.Website.Services;
using Microsoft.AspNetCore.Identity;
using EMS.Website.Models;
using Microsoft.Extensions.Logging;

namespace EMS.Website.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class ExpensesController : Controller
    {
        private readonly ITravelInfoService _travelService;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AccountController> _logger;
        public IApprovalInfoService _approvalInfoService { get; set; }

        public ExpensesController(ITravelInfoService travelService, IMapper mapper, IEmailSender emailSender,
                   UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IApprovalInfoService approvalInfoService,
            ILogger<AccountController> logger)
        {
            _travelService = travelService;
            _mapper = mapper;
            _emailSender = emailSender;
            _userManager = userManager;
            _roleManager = roleManager;
            _approvalInfoService = approvalInfoService;
            _logger = logger;
        }


        // GET: Expenses
        public async Task<IActionResult> Index()
        {
            var travelList = await _travelService.GetAllAsync();
            var travelDtoList = _mapper.Map<IEnumerable<TravelInfo>, IEnumerable<TravelDto>>(travelList);

            return View(travelDtoList);
        }

        // GET: Expenses/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelInfo = await _travelService
               .FindByIdAsync(m => m.ID == id);
            if (travelInfo == null)
            {
                return NotFound();
            }
            var bannerDto = _mapper.Map < TravelInfo, TravelDto>(travelInfo);

            return View(bannerDto);
        }

        // GET: Expenses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Expenses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TravelDto travelModel)
        {
            if (ModelState.IsValid)
            {
                var recieptDoc = await FileHelper.FileUploadDataAsync(travelModel.RecieptDoc, "TaxRegDoc");

                var travelInfo = _mapper.Map<TravelDto, TravelInfo>(travelModel);
                travelInfo.RecieptDoc = recieptDoc;

                await _travelService.AddAsync(travelInfo);

                var teamLeads = await _userManager.GetUsersInRoleAsync("TeamLead");
                var teamLead = teamLeads.FirstOrDefault();
                var callbackUrl = Url.Action("Index");
                await _emailSender.SendEmailAsync(teamLead.Email, "Approve/Reject Travel Expenses",
                 $"A employe name, {User.Identity.Name} has submitted travel expenses. Prease review: <a href='{callbackUrl}'>link</a>");

                return RedirectToAction(nameof(Index));

            }
            return View(travelModel);


        }

        // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelInfo = await _travelService
                .FindByIdAsync(m => m.ID == id);
            if (travelInfo == null)
            {
                return NotFound();
            }
            var  travelDto = _mapper.Map<TravelInfo, TravelDto>(travelInfo);

            return View(travelDto);
        }

        // POST: Expenses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TravelDto travelModel)
        {
            if (id != travelModel.TravelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var recieptPath = await FileHelper.FileUploadDataAsync(travelModel.RecieptDoc, "TaxRegDoc");
                


                    var travelInfo = _mapper.Map<TravelDto, TravelInfo>(travelModel);
                    travelInfo.RecieptDoc = recieptPath;
             

                    await _travelService.UpdateAsync(travelInfo);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool ifExist = await TravelExpenseExists(travelModel.TravelId);
                    if (!ifExist)
                    {
                        return NotFound();
                    }

                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(travelModel);
        }

        // GET: Expenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelInfo = await _travelService
                .FindByIdAsync(m => m.ID == id);
            if (travelInfo == null)
            {
                return NotFound();
            }

            return View(travelInfo);
        }

        // POST: Expenses/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var travelInfo = await _travelService.GetByIDAsync(id);
            if (travelInfo != null)
                await _travelService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TravelExpenseExists(int id)
        {
            var travelInfo = await _travelService.FindByIdAsync(e => e.ID == id);
            return travelInfo != null;
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> Approval(int? id, bool status, string comment)
        {
            if (id == null)
            {
                return Json(new
                {
                    message = $"Movie not found"
                });
            }

            var travelInfo = await _travelService
                .FindByIdAsync(m => m.ID == id);
            if (travelInfo == null)
            {
                return Json(new
                {
                    message = $"Movie not found"
                });
            }
            travelInfo.IsApproved = status;
            //await _movieService.UpdateAsync(movieInfo);

            await Task.Run(async () => {


                var movieApproval = await _approvalInfoService.FindByIdAsync(m => m.TravelID == id);
                if (movieApproval != null)
                {
                    movieApproval.IsApproved = status;
                    movieApproval.ApprovedDate = DateTime.Now;
                    movieApproval.Comment = comment;
                    movieApproval.ApprovedBy = User.Identity.Name;
                    await _approvalInfoService.UpdateAsync(movieApproval);
                }
                else
                {
                    var approveMovie = new ApprovalInfo
                    {
                        IsApproved = status,
                        ApprovedBy = User.Identity.Name,
                        TravelID = id ?? default(int),
                        Comment = comment,
                        ApprovedDate = DateTime.Now
                    };

                    await _approvalInfoService.AddAsync(approveMovie);
                }
            });

            return Json(new
            {
                message = $"The travel expenses with purpose {travelInfo.Purpose}'s status has Updated"
            });
        }
    }
}