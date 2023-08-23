using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelsF.Models;
using ModelsF.ModelsVM;
namespace MVCAnri.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var objProductList = _unitOfWork.Product.Query().Include(x => x.Category).ToList();
            return View(objProductList);
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            var categoryList = _unitOfWork.Category.Query().ToList().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });
            if (id == null)
            {
                return View(new ProductVM()
                {
                    Product = new Product(),
                    CategoryList = categoryList
                });
            }
            else
            {
                return View(new ProductVM()
                {
                    Product = await _unitOfWork.Product.GetSingleOrDefaultAsync(id.Value),
                    CategoryList = categoryList
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Upsert(ProductVM obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file is not null)
                {
                    if (!String.IsNullOrEmpty(obj.Product.ImageUrl))
                    {
                        var oldPath = Path.Combine(wwwRootPath, obj.Product.ImageUrl.Trim('\\'));
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productpath = Path.Combine(wwwRootPath, @"images\product");
                    using (var filestream = new FileStream(Path.Combine(productpath, filename), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    obj.Product.ImageUrl = @"\images\product\" + filename;

                }
                if (obj.Product.Id == 0)
                {
                    await _unitOfWork.Product.AddAsync(obj.Product);

                }
                else
                {
                    await _unitOfWork.Product.UpdateAsync(obj.Product);
                }
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                obj.CategoryList = _unitOfWork.Category.Query().ToList().Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
                return View(obj);
            }

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
