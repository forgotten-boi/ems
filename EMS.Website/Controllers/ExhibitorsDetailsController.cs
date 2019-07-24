using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMS.DataAccess;
using EMS.Entity.Entities;
using EMS.Entity.DtoModel;
using EMS.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using EMS.Infrastructure.Extensions;

namespace EMS.Website.Controllers
{
    [Authorize(Roles = "Admin,Exhibitor")]
    public class ExhibitorsDetailsController : Controller
    {
       
        private readonly IExhibitorsDetailService _exhibitorService;
        private readonly ProjectDbContext _projectDbContext;
        private readonly IMapper _mapper;

        public ExhibitorsDetailsController(ProjectDbContext context, IExhibitorsDetailService exhibitorService, IMapper mapper)
        {
            _projectDbContext = context;
            _exhibitorService = exhibitorService;
            _mapper = mapper;
         
        }
        [AllowAnonymous]
        public async Task<IEnumerable<ExhibitorDto>> GetAllExhibitors()
        {
            var exhibitorList = await _exhibitorService.GetAllAsync();
            var exhibitorDtoList = _mapper.Map<IEnumerable<ExhibitorsDetail>, IEnumerable<ExhibitorDto>>(exhibitorList);
            return exhibitorDtoList;
        }
        // GET: ExhibitorsDetails
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                var exhibitorList = await _exhibitorService.GetAllAsync();
                var exhibitorDtoList = _mapper.Map<IEnumerable<ExhibitorsDetail>, IEnumerable<ExhibitorDto>>(exhibitorList);

                return View(exhibitorDtoList);
            }
                var exhibitor = await _exhibitorService.GetFilteredAsync(p => p.CreatedBy.Equals(User.Identity.Name));
                if (exhibitor != null && exhibitor.ToList().Count > 0)
                    return RedirectToAction("Edit", new { id = exhibitor.FirstOrDefault().ID });
                else
                    return RedirectToAction("Create");

            }

        // GET: ExhibitorsDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibitorsDetail = await _exhibitorService
                .FindByIdAsync(m => m.ID == id);
            if (exhibitorsDetail == null)
            {
                return NotFound();
            }
            var exhibitor = _mapper.Map<ExhibitorsDetail, ExhibitorDto>(exhibitorsDetail);

            return View(exhibitor);
        }

        // GET: ExhibitorsDetails/Create
        public IActionResult Create()
        {
            var provincesDetail = _projectDbContext.Province.Include(x => x.Districts).ToList();
            ViewBag.ProvincesDetail = provincesDetail;
            return View();
        }

        // POST: ExhibitorsDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExhibitorDto model)
        {
            if (ModelState.IsValid)
            {
                var hallPermissionDoc = await FileHelper.FileUploadDataAsync(model.HallPermissionDoc, "HallPermissionDoc");
                var companyRegDoc = await FileHelper.FileUploadDataAsync(model.CompanyRegDoc, "CompanyRegDoc");
                var checkcommitteeDoc = await FileHelper.FileUploadDataAsync(model.CheckcommitteeDoc, "CheckcommitteeDoc");
                var exhibPermissionDoc = await FileHelper.FileUploadDataAsync(model.ExhibPermissionDoc, "ExhibPermissionDoc");
                var incomeTaxDoc = await FileHelper.FileUploadDataAsync(model.IncomeTaxDoc, "IncomeTaxDoc");
                var localBodyDoc = await FileHelper.FileUploadDataAsync(model.LocalBodyDoc, "SensorDoc");
                var regDocPath = await FileHelper.FileUploadDataAsync(model.RegDoc, "RegDoc");

                var exhibitorsDetail = _mapper.Map<ExhibitorDto, ExhibitorsDetail>(model);

                exhibitorsDetail.CheckcommitteeDoc = checkcommitteeDoc;
                exhibitorsDetail.HallPermissionDoc = hallPermissionDoc;
                exhibitorsDetail.ExhibPermissionDoc = exhibPermissionDoc;
                exhibitorsDetail.ExhibPermissionDoc = exhibPermissionDoc;
                exhibitorsDetail.IncomeTaxDoc = incomeTaxDoc;
                exhibitorsDetail.LocalBodyDoc = localBodyDoc;
                exhibitorsDetail.RegDoc = regDocPath;

                await _exhibitorService.AddAsync(exhibitorsDetail);
                return RedirectToAction(nameof(Index));
            }
            var provincesDetail = _projectDbContext.Province.Include(x => x.Districts).ToList();
            ViewBag.ProvincesDetail = provincesDetail;
            return View(model);
        }

        // GET: ExhibitorsDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibitorsDetail = await _exhibitorService
                .FindByIdAsync(m => m.ID == id);
            if (exhibitorsDetail == null)
            {
                return NotFound();
            }
            var exhibitor = _mapper.Map<ExhibitorsDetail, ExhibitorDto>(exhibitorsDetail);

            var provincesDetail = _projectDbContext.Province.Include(x => x.Districts).ToList();
            ViewBag.ProvincesDetail = provincesDetail;

            return View(exhibitor);
        }

        // POST: ExhibitorsDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ExhibitorDto model)
        {
            if (id != model.ExhibitorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var hallPermissionDoc = await FileHelper.FileUploadDataAsync(model.HallPermissionDoc, "HallPermissionDoc");
                    var companyRegDoc = await FileHelper.FileUploadDataAsync(model.CompanyRegDoc, "CompanyRegDoc");
                    var checkcommitteeDoc = await FileHelper.FileUploadDataAsync(model.CheckcommitteeDoc, "CheckcommitteeDoc");
                    var exhibPermissionDoc = await FileHelper.FileUploadDataAsync(model.ExhibPermissionDoc, "ExhibPermissionDoc");
                    var incomeTaxDoc = await FileHelper.FileUploadDataAsync(model.IncomeTaxDoc, "IncomeTaxDoc");
                    var localBodyDoc = await FileHelper.FileUploadDataAsync(model.LocalBodyDoc, "SensorDoc");
                    var regDocPath = await FileHelper.FileUploadDataAsync(model.RegDoc, "RegDoc");

                    var exhibitorsDetail = _mapper.Map<ExhibitorDto, ExhibitorsDetail>(model);

                    exhibitorsDetail.CheckcommitteeDoc = checkcommitteeDoc;
                    exhibitorsDetail.HallPermissionDoc = hallPermissionDoc;
                    exhibitorsDetail.ExhibPermissionDoc = exhibPermissionDoc;
                    exhibitorsDetail.ExhibPermissionDoc = exhibPermissionDoc;
                    exhibitorsDetail.IncomeTaxDoc = incomeTaxDoc;
                    exhibitorsDetail.LocalBodyDoc = localBodyDoc;
                    exhibitorsDetail.RegDoc = regDocPath;

                    await _exhibitorService.UpdateAsync(exhibitorsDetail);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool ifExist = await ExhibitorsDetailExists(model.ExhibitorId);
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
            var provincesDetail = _projectDbContext.Province.Include(x => x.Districts).ToList();
            ViewBag.ProvincesDetail = provincesDetail;
            return View(model);
        }

        // GET: ExhibitorsDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibitorsDetail = await _exhibitorService
                .FindByIdAsync(m => m.ID == id);
            if (exhibitorsDetail == null)
            {
                return NotFound();
            }

            return View(exhibitorsDetail);
        }

        // POST: ExhibitorsDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exhibitorsDetail = await _exhibitorService.GetByIDAsync(id);
            if (exhibitorsDetail != null)
                await _exhibitorService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ExhibitorsDetailExists(int id)
        {
            var exhibitor = await _exhibitorService.FindByIdAsync(e => e.ID == id);
            var exhibitors = await _exhibitorService.GetFilteredAsync(e => e.CreatedBy == "" || string.IsNullOrEmpty(e.CreatedBy));
            return exhibitor != null;
        }
    }
}
