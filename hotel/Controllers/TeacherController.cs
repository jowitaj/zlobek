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
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;


        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;

        }

        [HttpGet]
        public async Task<IActionResult> TeacherList()
        {
            var teacher = await _teacherService.GetTeacher();
            return View(teacher);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                await _teacherService.CreateTeacher(teacher);

                return View(teacher);
            }
            return BadRequest();



        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Teacher teacher)
        {

            teacher.TeacherID = int.Parse(Request.Form["TeacherId"]);

            var result = await _teacherService.UpdateTeacher(teacher.TeacherID, teacher);



            return View(teacher);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Teacher teacher)
        {

            teacher.TeacherID = int.Parse(Request.Form["TeacherId"]);
            var result = await _teacherService.DeleteTeacher(teacher.TeacherID);

            return View();
        }
    }
}
