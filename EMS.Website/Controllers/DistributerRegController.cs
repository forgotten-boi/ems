using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMS.DataAccess;
using EMS.Entity.DtoModel;
using EMS.Entity.Entities;
using EMS.Infrastructure.Extensions;
using EMS.Services.Interface;

namespace EMS.Website.Controllers
{
    [Authorize(Roles = "Admin,Distributer")]
    public class DistributerRegController : Controller
    {
        private readonly IDistributersDetailService _distributerService;
        private readonly IMapper _mapper;
        private readonly ProjectDbContext _projectDbContext;
        public DistributerRegController(ProjectDbContext projectDbContext, IDistributersDetailService distributerService, IMapper mapper)
        {
            _distributerService = distributerService;
            _mapper = mapper;
            _projectDbContext = projectDbContext;
        }

        // GET: DistributerReg

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                var distributerList = await _distributerService.GetAllAsync();
                var distributerDtoList = _mapper.Map<IEnumerable<DistributersDetail>, IEnumerable<DistributerDto>>(distributerList);

                return View(distributerDtoList);
            }
            else
                return await CheckAndSendToEditAsync();

        }

        [AllowAnonymous]
        public async Task<IEnumerable<DistributerDto>> GetAllDistributers()
        {
            var distributerList = await _distributerService.GetAllAsync();
            var distributerDtoList = _mapper.Map<IEnumerable<DistributersDetail>, IEnumerable<DistributerDto>>(distributerList);
            return distributerDtoList;
        }

        public async Task<IActionResult> CheckAndSendToEditAsync()
        {
            var distributer = await _distributerService.GetFilteredAsync(p => p.CreatedBy.Equals(User.Identity.Name));
            if (distributer != null && distributer.ToList().Count > 0)
                return RedirectToAction("Edit", new { id = distributer.FirstOrDefault().ID });
            else
                return RedirectToAction("Create");
        }

        // GET: DistributerReg/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _distributerService.FindByIdAsync(m => m.ID == id);

            if (model == null)
            {
                return NotFound();
            }
            var distributersDetail = _mapper.Map<DistributersDetail, DistributerDto> (model);

            return View(distributersDetail);
        }

        // GET: DistributerReg/Create
        public async Task<IActionResult> Create()
        {

            if (User.IsInRole("Admin"))
            {
                var provincesDetail = _projectDbContext.Province.Include(x => x.Districts).ToList();
                ViewBag.ProvincesDetail = provincesDetail;
                return View();
            }
            else
            {
                return await CheckAndSendToEditAsync();
            }
        }

        // POST: DistributerReg/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DistributerDto model)
        {
            if (ModelState.IsValid)
            {

                var regPath = await FileHelper.FileUploadDataAsync(model.RegDoc, "RegisterDoc");
                var distrPath = await FileHelper.FileUploadDataAsync(model.DistributionRightDoc, "DistributionRightDoc");
                var incomeTaxPath = await FileHelper.FileUploadDataAsync(model.IncomeTaxDoc, "IncomeTaxDoc");
                var compRegPath = await FileHelper.FileUploadDataAsync(model.CompanyRegDoc, "CompanyRegDoc");
                
          
                var distributersDetail = _mapper.Map<DistributerDto, DistributersDetail>(model);
                distributersDetail.RegDoc = regPath;
                distributersDetail.DistributionRightDoc = distrPath;
                distributersDetail.IncomeTaxDoc = incomeTaxPath;
                distributersDetail.CompanyRegDoc = compRegPath;
              
                await _distributerService.AddAsync(distributersDetail);
                return RedirectToAction(nameof(Index));
            }
            var provincesDetail = _projectDbContext.Province.Include(x => x.Districts).ToList();
            ViewBag.ProvincesDetail = provincesDetail;
            return View(model);
        }

       

        // GET: DistributerReg/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _distributerService.FindByIdAsync(p => p.ID == id);
            var distributersDetail = _mapper.Map<DistributersDetail, DistributerDto>(model);
            if (distributersDetail == null)
            {
                return NotFound();
            }

            var provincesDetail = _projectDbContext.Province.Include(x => x.Districts).ToList();
            ViewBag.ProvincesDetail = provincesDetail;
            return View(distributersDetail);
        }

        // POST: DistributerReg/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DistributerDto model)
        {
            if (id != model.DistributerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var regPath = await FileHelper.FileUploadDataAsync(model.RegDoc, "RegisterDoc");
                    var distrPath = await FileHelper.FileUploadDataAsync(model.DistributionRightDoc, "DistributionRightDoc");
                    var incomeTaxPath = await FileHelper.FileUploadDataAsync(model.IncomeTaxDoc, "IncomeTaxDoc");
                    var compRegPath = await FileHelper.FileUploadDataAsync(model.CompanyRegDoc, "CompanyRegDoc");


                    var distributersDetail = _mapper.Map<DistributerDto, DistributersDetail>(model);
                    distributersDetail.RegDoc = regPath;
                    distributersDetail.DistributionRightDoc = distrPath;
                    distributersDetail.IncomeTaxDoc = incomeTaxPath;
                    distributersDetail.CompanyRegDoc = compRegPath;

                 
                    await _distributerService.UpdateAsync(distributersDetail);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool ifExist = await DistributersDetailExists(model.DistributerId);
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

        // GET: DistributerReg/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distributersDetail = await _distributerService
                .FindByIdAsync(m => m.ID == id);
            if (distributersDetail == null)
            {
                return NotFound();
            }

            return View(distributersDetail);
        }

        // POST: DistributerReg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var distributersDetail = await _distributerService.GetByIDAsync(id);
            if(distributersDetail != null)
                await _distributerService.DeleteAsync(id);
        
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> DistributersDetailExists(int id)
        {
            var distributersDetail = await _distributerService.FindByIdAsync(e => e.ID == id);
            return distributersDetail != null;
        }
    }
}
