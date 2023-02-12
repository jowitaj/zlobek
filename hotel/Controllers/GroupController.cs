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
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;


        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        
        }

        [HttpGet]
        public async Task<IActionResult> GroupList()
        {
            var group = await _groupService.GetGroups();
            return View(group);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Groups group)
        {
            if (ModelState.IsValid)
            {
                await _groupService.CreateGroups(group);

                return View(group);
            }
            return BadRequest();



        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Groups group)
        {

            group.GroupId = int.Parse(Request.Form["GroupId"]);

            var result = await _groupService.UpdateGroups(group.GroupId, group);



            return View(group);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Groups group)
        {

            group.GroupId = int.Parse(Request.Form["GroupId"]);
            var result = await _groupService.DeleteGroups(group.GroupId);

            return View();
        }
    }
}
