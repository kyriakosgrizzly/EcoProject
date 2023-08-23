using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelsF.Models;

namespace MVCAnri.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var objCategoryList = _unitOfWork.Category.Query().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
          
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category obj)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _unitOfWork.Category.AddAsync(obj);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();

            }
            var Category = await _unitOfWork.Category.GetSingleOrDefaultAsync(id.Value);
            if (Category is null) return NotFound();

            return View(Category);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();

            }
            var Category = await _unitOfWork.Category.GetSingleOrDefaultAsync(id.Value);
            if (Category is null) return NotFound();
            await _unitOfWork.Category.DeleteAsync(Category.Id);
            _unitOfWork.SaveChanges();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();

            }
            var Category = await _unitOfWork.Category.GetSingleOrDefaultAsync(id.Value);
            if (Category is null) return NotFound();

            return View(Category);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category obj)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _unitOfWork.Category.UpdateAsync(obj);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
