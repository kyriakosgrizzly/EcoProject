using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using MVCAnri.Controllers.Data;
using ModelsF.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCAnri.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ScheduleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ScheduleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var objScheduleList = _unitOfWork.Schedule.Query().ToList();
            return View(objScheduleList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Schedule obj)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _unitOfWork.Schedule.AddAsync(obj);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();

            }
            var Schedule = await _unitOfWork.Schedule.GetSingleOrDefaultAsync(id.Value);
            if (Schedule is null) return NotFound();

            return View(Schedule);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();

            }
            var Schedule = await _unitOfWork.Schedule.GetSingleOrDefaultAsync(id.Value);
            if (Schedule is null) return NotFound();
            await _unitOfWork.Schedule.DeleteAsync(Schedule.Id);
            _unitOfWork.SaveChanges();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();

            }
            var Schedule = await _unitOfWork.Schedule.GetSingleOrDefaultAsync(id.Value);
            if (Schedule is null) return NotFound();

            return View(Schedule);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Schedule obj)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _unitOfWork.Schedule.UpdateAsync(obj);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
