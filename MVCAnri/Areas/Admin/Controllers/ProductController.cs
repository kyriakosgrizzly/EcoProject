using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using ModelsF.Models;

namespace MVCAnri.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var objProductList = _unitOfWork.Product.Query().ToList();
            return View(objProductList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product obj)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _unitOfWork.Product.AddAsync(obj);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();

            }
            var Product = await _unitOfWork.Product.GetSingleOrDefaultAsync(id.Value);
            if (Product is null) return NotFound();

            return View(Product);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();

            }
            var Product = await _unitOfWork.Product.GetSingleOrDefaultAsync(id.Value);
            if (Product is null) return NotFound();
            await _unitOfWork.Product.DeleteAsync(Product.Id);
            _unitOfWork.SaveChanges();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();

            }
            var product = await _unitOfWork.Product.GetSingleOrDefaultAsync(id.Value);
            if (product is null) return NotFound();

            return View(product);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product obj)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _unitOfWork.Product.UpdateAsync(obj);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
