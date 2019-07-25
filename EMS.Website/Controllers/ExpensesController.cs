﻿using System;
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
using EMS.Services.IServices;

namespace EMS.Website.Controllers
{
    [Authorize(Roles = "Admin,Employee,TeamLead")]
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
        public async Task<IActionResult> Details(int? id)
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
                var recieptDoc = await FileHelper.FileUploadDataAsync(travelModel.RecieptFile, "RecieptDoc");

                var travelInfo = _mapper.Map<TravelDto, TravelInfo>(travelModel);
                travelInfo.RecieptDoc = recieptDoc;
                travelInfo.Date = DateTime.Now;
                await _travelService.AddAsync(travelInfo);

                var user = await _userManager.GetUserAsync(User);

                var teamLead =  _userManager.Users.FirstOrDefault(p=> p.Id == user.TeamLeadId);
               
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
                    var recieptPath = await FileHelper.FileUploadDataAsync(travelModel.RecieptFile, "RecieptDoc");
                


                    var travelInfo = _mapper.Map<TravelDto, TravelInfo>(travelModel);
                    travelInfo.RecieptDoc = recieptPath;
                    travelInfo.Date = DateTime.Now;

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
        public async Task<JsonResult> Delete(int id)
        {
            var travelInfo = await _travelService.GetByIDAsync(id);
            if (travelInfo != null)
                await _travelService.DeleteAsync(id);
            else
                return Json(new
                {
                    message = $"Movie not found"
                });

            return Json(new
            {
                message = $"The travel expenses with purpose {travelInfo.Purpose}'s status has been deleted"
            });
        }

        private async Task<bool> TravelExpenseExists(int id)
        {
            var travelInfo = await _travelService.FindByIdAsync(e => e.ID == id);
            return travelInfo != null;
        }

        [Authorize(Roles = "Admin,TeamLead")]
        public async Task<JsonResult> Approval(int? id, bool status, string comment)
        {
            if (id == null)
            {
                return Json(new
                {
                    message = $"Reciept not found"
                });
            }

            var travelInfo = await _travelService
                .FindByIdAsync(m => m.ID == id);
            if (travelInfo == null)
            {
                return Json(new
                {
                    message = $"Reciept not found"
                });
            }
            travelInfo.IsApproved = status;

            await Task.Run(async () => {


                var approvalInfo = await _approvalInfoService.FindByIdAsync(m => m.TravelID == id);
                if (approvalInfo != null)
                {
                    approvalInfo.IsApproved = status;
                    approvalInfo.ApprovedDate = DateTime.Now;
                    approvalInfo.Comment = comment;
                    approvalInfo.ApprovedBy = User.Identity.Name;
                    await _approvalInfoService.UpdateAsync(approvalInfo);
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

                if (status)
                {
                    var financeUsers = await _userManager.GetUsersInRoleAsync("Finance");
                    var financeUser = financeUsers.FirstOrDefault();


                    var callbackUrl = Url.Content("~/" + travelInfo.RecieptDoc);
                    await _emailSender.SendEmailAsync(financeUser.Email, "Approve/Reject Travel Expenses",
                     $"A employe name, {User.Identity.Name} has submitted travel expenses. Prease review: <a href='{callbackUrl}'>link</a>");
                }
            });

            return Json(new
            {
                message = $"The travel expenses with purpose {travelInfo.Purpose}'s status has Updated"
            });
        }
    }
}