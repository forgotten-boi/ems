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
using EMS.Services.Interface;
using EMS.Entity.DtoModel;
using Microsoft.AspNetCore.Authorization;
using EMS.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using EMS.Website.Models;
using System.Threading;

namespace EMS.Website.Controllers
{
    [Authorize(Roles ="Admin,Producer")]
    public class MovieInfoController : Controller
    {
        private readonly ProjectDbContext _context;
        public IArtistInfoService _artistService { get; set; }
        public IApprovalInfoService _approvalInfoService { get; set; }
        private readonly IMovieInfoService _movieService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public MovieInfoController(ProjectDbContext context, IArtistInfoService artistInfoService,
                IMovieInfoService movieService, IApprovalInfoService approvalInfoService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _artistService = artistInfoService;
            _movieService = movieService;
            _approvalInfoService = approvalInfoService;
            _mapper = mapper;
            _userManager = userManager;
        }

        // GET: MovieInfo
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            ViewBag.UserFullName = user.FirstName + " " + user.LastName;
            var movieList = await _movieService.GetAllAsync();
            var movieDtoList = _mapper.Map<IEnumerable<MovieInfo>, IEnumerable<MovieDto>>(movieList);
            return View(movieDtoList);
        }
        [AllowAnonymous]
        public async Task<IEnumerable<MovieDto>> GetAllMovies()
        {
            var movieList = await _movieService.GetFilteredAsync(p=> true);
            var movieDtoList = _mapper.Map<IEnumerable<MovieInfo>, IEnumerable<MovieDto>>(movieList);
            return movieDtoList;
        }

        // GET: MovieInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieInfo = await _movieService
                .FindByIdAsync(m => m.ID == id);
            if (movieInfo == null)
            {
                return NotFound();
            }
            var movieDto = _mapper.Map<MovieInfo, MovieDto>(movieInfo);

            return View(movieDto);
        }

        // GET: MovieInfo/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Languages = await _context.Language.ToListAsync();
            return View();
        }

        // POST: MovieInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieDto model)
        {
            if (ModelState.IsValid)
            {
                var contractPath = await FileHelper.FileUploadDataAsync(model.ContractDoc, "ContractDoc");
                var permissionPath = await FileHelper.FileUploadDataAsync(model.PermissionDoc, "PermissionDoc");
                var scriptDocPath = await FileHelper.FileUploadDataAsync(model.ScriptDoc, "ScriptDoc");
                var songDocPath = await FileHelper.FileUploadDataAsync(model.SongDoc, "SongDoc");
                var postProdDocPath = await FileHelper.FileUploadDataAsync(model.PostProdDoc, "PostProdDoc");
                var sensorDocPath = await FileHelper.FileUploadDataAsync(model.SensorDoc, "SensorDoc");
                var regDocPath = await FileHelper.FileUploadDataAsync(model.RegDoc, "RegDoc");
                var movieBannerDocPath = await FileHelper.FileUploadDataAsync(model.MovieBannerDoc, "MovieBannerDoc");

                var movieInfo = _mapper.Map<MovieDto, MovieInfo>(model);

                movieInfo.ContractDoc = contractPath;
                movieInfo.PermissionDoc = permissionPath;
                movieInfo.ScriptDoc = scriptDocPath;
                movieInfo.SongDoc = songDocPath;
                movieInfo.PostProdDoc = postProdDocPath;
                movieInfo.SensorDoc = sensorDocPath;
                movieInfo.RegDoc = regDocPath;
                movieInfo.MovieBanner = movieBannerDocPath;
                movieInfo.MovieName = model.EnglishName;                

                await _movieService.AddAsync(movieInfo);
                
                //Run in different threads
                await SaveArtist(movieInfo.ArtistNameEng);
                await SaveArtist(movieInfo.ArtistNameNep);

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Languages = await _context.Language.ToListAsync();

            return View(model);
        }

        // GET: MovieInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieInfo = await _movieService
                  .FindByIdAsync(m => m.ID == id);
            if (movieInfo == null)
            {
                return NotFound();
            }
            var movieDto = _mapper.Map<MovieInfo, MovieDto>(movieInfo);
            ViewBag.Languages = await _context.Language.ToListAsync();

            return View(movieDto);

        }

        // POST: MovieInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MovieDto model, IFormFile RegDoc)
        {
            if (id != model.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var contractPath = await FileHelper.FileUploadDataAsync(model.ContractDoc, "ContractDoc");
                    var permissionPath = await FileHelper.FileUploadDataAsync(model.PermissionDoc, "PermissionDoc");
                    var scriptDocPath = await FileHelper.FileUploadDataAsync(model.ScriptDoc, "ScriptDoc");
                    var songDocPath = await FileHelper.FileUploadDataAsync(model.SongDoc, "SongDoc");
                    var postProdDocPath = await FileHelper.FileUploadDataAsync(model.PostProdDoc, "PostProdDoc");
                    var sensorDocPath = await FileHelper.FileUploadDataAsync(model.SensorDoc, "SensorDoc");
                    var regDocPath = await FileHelper.FileUploadDataAsync(model.RegDoc, "RegDoc");
                    var movieBannerDocPath = await FileHelper.FileUploadDataAsync(model.MovieBannerDoc, "MovieBannerDoc");

                    var movieInfo = _mapper.Map<MovieDto, MovieInfo>(model);

                    movieInfo.ContractDoc = contractPath;
                    movieInfo.PermissionDoc = permissionPath;
                    movieInfo.ScriptDoc = scriptDocPath;
                    movieInfo.SongDoc = songDocPath;
                    movieInfo.PostProdDoc = postProdDocPath;
                    movieInfo.SensorDoc = sensorDocPath;
                    movieInfo.RegDoc = regDocPath;
                    movieInfo.MovieBanner = movieBannerDocPath;

                    movieInfo.MovieName = model.EnglishName;


                    await _movieService.UpdateAsync(movieInfo);

                    await SaveArtist(movieInfo.ArtistNameEng);
                    await SaveArtist(movieInfo.ArtistNameNep);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool ifExist = await MovieInfoExists(model.MovieId);
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
            ViewBag.Languages = await _context.Language.ToListAsync();

            return View(model);
        }

        // GET: MovieInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieInfo = await _movieService
                  .FindByIdAsync(m => m.ID == id);
            if (movieInfo == null)
            {
                return NotFound();
            }

            return View(movieInfo);
        }

        // POST: MovieInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieInfo = await _movieService
                 .FindByIdAsync(m => m.ID == id);
            if(movieInfo != null)
                await _movieService.DeleteAsync(id);
          
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> MovieInfoExists(int id)
        {
            var movieInfo = await _movieService.FindByIdAsync(e => e.ID == id);
            return movieInfo != null;
        }

        public async Task<IEnumerable<ArtistInfo>> GetArtistByName(string name = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                return await _artistService.GetAllAsync();
            }

            var artistInfo = await _artistService.GetFilteredAsync(m => m.FullName.Contains(name));
            if (artistInfo == null)
            {
                return null;
            }

            return artistInfo;
        }

        private async Task<bool> SaveArtist(string artistName)
        {
            if(!string.IsNullOrEmpty(artistName))
            {
                var artistList = artistName?.Split(',');
                foreach (var artist in artistList)
                {
                    var artistInfo = new ArtistInfo
                    {
                        FullName = artist.Trim(),
                        //CreatedBy = User.Identity.Name,
                        CreatedDate = DateTime.Now
                    };
                    var filteredArtist = await _artistService.GetFilteredAsync(p => p.FullName.ToLower().Equals(artistInfo.FullName.ToLower()));
                    if (filteredArtist == null || filteredArtist.Count() == 0)
                        await _artistService.AddAsync(artistInfo);
                }
            }
            return true;
        }
        [Authorize(Roles ="Admin")]
        public async Task<JsonResult> Approval(int? id, bool status, string comment)
        {
            if (id == null)
            {
                return Json(new
                {
                    message = $"Movie not found"
                });
            }

            var movieInfo = await _movieService
                .FindByIdAsync(m => m.ID == id);
            if (movieInfo == null)
            {
                return Json(new
                {
                    message = $"Movie not found"
                });
            }
            movieInfo.IsApproved = status;
            //await _movieService.UpdateAsync(movieInfo);

             await Task.Run(async () => {

               
                var movieApproval = await _approvalInfoService.FindByIdAsync(m => m.MovieID == id);
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
                            MovieID = id ?? default(int),
                            Comment = comment,
                            ApprovedDate = DateTime.Now
                        };
                        
                        await _approvalInfoService.AddAsync(approveMovie);
                    }
                });
        
            return Json(new {
                message = $"The movie with name {movieInfo.EnglishName}'s status has Updated"
            }); 
        }
    }
}
