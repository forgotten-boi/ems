using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMS.DataAccess;
using EMS.Entity.Entities;
using EMS.Services.Interface;

namespace EMS.Website.Controllers
{
    [Authorize]
    public class ArtistInfoController : Controller
    {
        //private readonly ProjectDbContext _context;
        private readonly IMapper _mapper;
        public IArtistInfoService _artistService { get; set; }

        public ArtistInfoController(IArtistInfoService artistInfoService, IMapper mapper)
        {
            this._artistService = artistInfoService;
            _mapper = mapper;
        }
        [AllowAnonymous]
        public async Task<IEnumerable<string>> GetAllArtists()
        {
            var artistInfo = await _artistService.GetAllAsync();

            return artistInfo.Select(p => p.FullName).Distinct();
        }
        // GET: ArtistInfoes
        public async Task<IActionResult> Index()
        {
            var artistList = await _artistService.GetAllAsync();

            return View(artistList);
        }

        // GET: ArtistInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artistInfo = await _artistService.FindByIdAsync(m => m.ID == id);
            if (artistInfo == null)
            {
                return NotFound();
            }

            return View(artistInfo);
        }
     

        // GET: ArtistInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArtistInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArtistInfo artistInfo)
        {
            if (ModelState.IsValid)
            {
                artistInfo.CreatedDate = DateTime.Now;
                await _artistService.AddAsync(artistInfo);
               
                return RedirectToAction(nameof(Index));
            }
            return View(artistInfo);
        }

        // GET: ArtistInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artistInfo = await _artistService.FindByIdAsync(p=>p.ID == id);
            if (artistInfo == null)
            {
                return NotFound();
            }
            return View(artistInfo);
        }

        // POST: ArtistInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ArtistInfo artistInfo)
        {
            if (id != artistInfo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _artistService.UpdateAsync(artistInfo);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistInfoExists(artistInfo.ID))
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
            return View(artistInfo);
        }

        // GET: ArtistInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artistInfo = await _artistService.FindByIdAsync(m => m.ID == id);
            if (artistInfo == null)
            {
                return NotFound();
            }

            return View(artistInfo);
        }

        // POST: ArtistInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _artistService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistInfoExists(int id)
        {
            return _artistService.GetByIDAsync(id)!=null;
        }

        public async Task<IEnumerable<string>> GetArtistByName(string name)
        {
            //if (string.IsNullOrEmpty(name))
            //{
            //    return null;
            //}

            //var artistInfo = await _artistService.GetFilteredAsync(m => m.FullName.Contains(name));
            //if (artistInfo == null)
            //{
            //    return null;
            //}
            var artistInfo = await _artistService.GetAllAsync();

            return artistInfo.Select(p=>p.FullName).Distinct();
        }
    }
}
