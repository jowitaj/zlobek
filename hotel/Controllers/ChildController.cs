using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "admin,teacher")]
        [HttpGet]
        public async Task<IActionResult> ChildList()
        {
            var children = await _childService.GetChildren();
            return View(children);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(Child child)
        {
           
                child.ChildID = int.Parse(Request.Form["ChildId"]);
            
            var result = await _childService.UpdateChild(child.ChildID, child);

            

            return View(child);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(Child child)
        {

            child.ChildID = int.Parse(Request.Form["ChildId"]);
            var result = await _childService.DeleteChild(child.ChildID);

           return View();
        }
    }
}
