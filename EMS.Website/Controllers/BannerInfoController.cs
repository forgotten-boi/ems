using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMS.DataAccess;
using EMS.Entity.Entities;

using EMS.Entity.DtoModel;
using EMS.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using EMS.Infrastructure.Extensions;

namespace EMS.Website.Controllers
{
    [Authorize(Roles = "Admin,Distributer,Producer")]
    public class BannerInfoController : Controller
    {
        private readonly IBannerInfoService _bannerService;
        private readonly IMapper _mapper;

        public BannerInfoController(IBannerInfoService bannerService, IMapper mapper)
        {
            _bannerService = bannerService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        public async Task<IEnumerable<BannerDto>> GetAllBanners()
        {
            var bannerList = await _bannerService.GetAllAsync();
            var bannerDtoList = _mapper.Map<IEnumerable<BannerInfo>, IEnumerable<BannerDto>>(bannerList);
            return bannerDtoList;
        }

        // GET: BannerInfo
        public async Task<IActionResult> Index()
        {
            var bannerList = await _bannerService.GetAllAsync();
            var bannerDtoList = _mapper.Map<IEnumerable<BannerInfo>, IEnumerable<BannerDto>>(bannerList);

            return View(bannerDtoList);
        }

        // GET: BannerInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bannerInfo = await _bannerService
               .FindByIdAsync(m => m.ID == id);
            if (bannerInfo == null)
            {
                return NotFound();
            }
            var bannerDto = _mapper.Map<BannerInfo, BannerDto>(bannerInfo);

            return View(bannerDto);
        }

        // GET: BannerInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BannerInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BannerDto model)
        {
            if (ModelState.IsValid)
            {
                var taxPath = await FileHelper.FileUploadDataAsync(model.TaxRegDoc, "TaxRegDoc");
                var FormRegDoc = await FileHelper.FileUploadDataAsync(model.FormRegDoc, "FormRegDoc");


                var bannerInfo = _mapper.Map<BannerDto, BannerInfo>(model);
                bannerInfo.TaxRegDoc = taxPath;
                bannerInfo.FormRegDoc = FormRegDoc;
                await _bannerService.AddAsync(bannerInfo);
                return RedirectToAction(nameof(Index));
                
            }
            return View(model);
        }

        // GET: BannerInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bannerInfo = await _bannerService
                .FindByIdAsync(m => m.ID == id); 
            if (bannerInfo == null)
            {
                return NotFound();
            }
            var banner = _mapper.Map<BannerInfo, BannerDto>(bannerInfo);

            return View(banner);
        }

        // POST: BannerInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BannerDto model)
        {
            if (id != model.BannerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var taxPath = await FileHelper.FileUploadDataAsync(model.TaxRegDoc, "TaxRegDoc");
                    var FormRegDoc = await FileHelper.FileUploadDataAsync(model.FormRegDoc, "FormRegDoc");


                    var bannerInfo = _mapper.Map<BannerDto, BannerInfo>(model);
                    bannerInfo.TaxRegDoc = taxPath;
                    bannerInfo.FormRegDoc = FormRegDoc;

                    await _bannerService.UpdateAsync(bannerInfo);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool ifExist = await BannerInfoExists(model.BannerId);
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
            return View(model);
        }

        // GET: BannerInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bannerInfo = await _bannerService
                .FindByIdAsync(m => m.ID == id);
            if (bannerInfo == null)
            {
                return NotFound();
            }

            return View(bannerInfo);
        }

        // POST: BannerInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bannerInfo = await _bannerService.GetByIDAsync(id);
            if (bannerInfo != null)
                await _bannerService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> BannerInfoExists(int id)
        {
            var bannerInfo = await _bannerService.FindByIdAsync(e => e.ID == id);
            return bannerInfo != null;
        }
    }
}
