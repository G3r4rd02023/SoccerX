using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoccerX.Data;
using SoccerX.Data.Entities;
using SoccerX.Helpers;
using SoccerX.Models;

namespace SoccerX.Controllers
{
    public class TeamsController : Controller
    {
        private readonly DataContext _context;
        private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;


        public TeamsController(DataContext context, IImageHelper imageHelper,
            IConverterHelper converterHelper)
        {          
            _context = context;
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teams.OrderBy(t => t.Name).ToListAsync());
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.Id == id);

            if (team == null)
            {
                return NotFound();
            }           

            return View(team);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( TeamViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var path = string.Empty;

                    if (model.LogoFile != null)
                    {
                        path = await _imageHelper.UploadImageAsync(model.LogoFile, "Teams");
                    }

                    var team = _converterHelper.ToTeamEntity(model, path, true);

                    _context.Add(team);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un equipo con este nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }              
            }
            return View(model);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Team team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            TeamViewModel model = _converterHelper.ToTeamViewModel(team);
            return View(model);

        }

        // POST: Teams/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TeamViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    var path = model.LogoPath;

                    if (model.LogoFile != null)
                    {
                        path = await _imageHelper.UploadImageAsync(model.LogoFile, "Teams");
                    }

                    Team team = _converterHelper.ToTeamEntity(model, path, false);
                    _context.Update(team);

                    try
                    {
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        if (ex.InnerException.Message.Contains("duplicate"))
                        {
                            ModelState.AddModelError(string.Empty, "Ya existe un equipo con ese nombre .");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                        }
                    }
                }
            }
            return View(model);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}
