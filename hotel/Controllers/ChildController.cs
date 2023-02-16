using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using zlobek.Entities;
using zlobek.Services;

namespace zlobek.Controllers
{
    public class ChildController : Controller
    {
        private readonly IChildService _childService;

        public ChildController(IChildService childService)
        {
            _childService = childService;
        }

        [HttpGet]

        public async Task<IActionResult> ChildList()
        {
            var children = await _childService.GetChildren();
            return View(children);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin,Teacher")]

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Teacher")]
        [HttpPost]
        public async Task<IActionResult> Edit(Child child)
        {

            child.ChildID = int.Parse(Request.Form["ChildId"]);

            var result = await _childService.UpdateChild(child.ChildID, child);



            return View(child);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(Child child)
        {

            child.ChildID = int.Parse(Request.Form["ChildId"]);
            var result = await _childService.DeleteChild(child.ChildID);

            return View();
        }
    }
}