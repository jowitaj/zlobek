﻿using System;
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
            if (ModelState.IsValid)
            {
                await _childService.CreateChild(child);

                return View(child);
            }
            return BadRequest();



        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(Child child)
        {
           
                child.ChildID = int.Parse(Request.Form["ChildId"]);
            
            var result = await _childService.UpdateChild(child.ChildID, child);

            

            return View(child);
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
