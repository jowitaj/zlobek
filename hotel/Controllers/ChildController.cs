using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using zlobek.Entities;
using zlobek.Services;

namespace zlobek.Controllers
{
    public class ChildController : Controller
    {
        private readonly IChildService _childService;

    
        private readonly ILogger<ChildController> _logger;

        public ChildController(IChildService childService, ILogger<ChildController> logger)
        {
            _childService = childService;
            _logger = logger;
        }


        public async Task<IActionResult> Index()
        {
            var children = await _childService.GetChildren();
            return View(children);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Child child)
        {
      
                await _childService.CreateChild(child);
            
            return Ok();
           
         



        }

        public async Task<IActionResult> Edit(int id)
        {
            var child = await _childService.GetChild(id);

            if (child == null)
            {
                return NotFound();
            }

            return View(child);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Child child)
        {
            if (id != child.ChildID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(child);
            }

            var result = await _childService.UpdateChild(id, child);

            if (!result)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _childService.DeleteChild(id);

            if (!result)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
