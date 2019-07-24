using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMS.DataAccess;
using EMS.Entity.Entities;
using EMS.Services.Interface;

namespace EMS.Website.Controllers
{
    [Authorize(Roles = "Admin,Producer")]

    public class ProducerProfileController : Controller
    {
        private readonly ProjectDbContext _context;
        public IArtistInfoService _artistService { get; set; }

        public ProducerProfileController(ProjectDbContext context, IArtistInfoService artistInfoService)
        {
            _context = context;
            _artistService = artistInfoService;
        }

        // GET: ProducerProfile
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProducerDetail.ToListAsync());
        }

        // GET: ProducerProfile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producerDetail = await _context.ProducerDetail
                .FirstOrDefaultAsync(m => m.ID == id);
            if (producerDetail == null)
            {
                return NotFound();
            }

            return View(producerDetail);
        }

        // GET: ProducerProfile/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProducerProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReleaseDate,MovieName,ArtistsInMovies,ID,CreatedBy,CreatedDate,ModifiedDate,ModifiedBy")] ProducerDetail producerDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producerDetail);
                await _context.SaveChangesAsync();
                var artistList = producerDetail?.ArtistsInMovies?.Split(',');
                foreach (var artist in artistList)
                {
                    var artistInfo = new ArtistInfo
                    {
                        FullName = artist,
                        CreatedBy = User.Identity.Name,
                        CreatedDate = DateTime.Now
                    };
                    await _artistService.AddAsync(artistInfo);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(producerDetail);
        }

        // GET: ProducerProfile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producerDetail = await _context.ProducerDetail.FindAsync(id);
            if (producerDetail == null)
            {
                return NotFound();
            }
            return View(producerDetail);
        }

        // POST: ProducerProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReleaseDate,MovieName,ArtistsInMovies,ID,CreatedBy,CreatedDate,ModifiedDate,ModifiedBy")] ProducerDetail producerDetail)
        {
            if (id != producerDetail.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producerDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducerDetailExists(producerDetail.ID))
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
            return View(producerDetail);
        }

        // GET: ProducerProfile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producerDetail = await _context.ProducerDetail
                .FirstOrDefaultAsync(m => m.ID == id);
            if (producerDetail == null)
            {
                return NotFound();
            }

            return View(producerDetail);
        }

        // POST: ProducerProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetail = await _context.ProducerDetail.FindAsync(id);
            _context.ProducerDetail.Remove(producerDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProducerDetailExists(int id)
        {
            return _context.ProducerDetail.Any(e => e.ID == id);
        }
    }
}
