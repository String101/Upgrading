using Microsoft.AspNetCore.Mvc;
using Upgrading.Interface;
using Upgrading.Models;

namespace Upgrading.Controllers
{
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
            var products=_unitOfWork.Product.GetAll();
            return View(products);
        }
        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Products products)
        {
            ModelState.Remove("ImageUrl");
            if (ModelState.IsValid)
            {
                if (products.Image != null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(products.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\productsImages");

                    using var fileStream = new FileStream(Path.Combine(imagePath, filename), FileMode.Create);
                    products.Image.CopyTo(fileStream);

                    products.ImageUrl = @"\images\productsImages\" + filename;
                }
                _unitOfWork.Product.Add(products);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(products);
            }
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Products? product=_unitOfWork.Product.Get(u=>u.Id == id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Products products)
        {
            _unitOfWork.Product.Update(products);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Products? product = _unitOfWork.Product.Get(u => u.Id == id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(Products products)
        {
            Products? objFromDb = _unitOfWork.Product.Get(u => u.Id == products.Id);
            if (objFromDb is not null)
            {
                if (!string.IsNullOrEmpty(objFromDb.ImageUrl))
                {
                    var oldIDPath = Path.Combine(_webHostEnvironment.WebRootPath, objFromDb.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldIDPath))
                    {
                        System.IO.File.Delete(oldIDPath);
                    }
                    _unitOfWork.Product.Remove(objFromDb);
                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }


            }
            else
            {
                return NotFound();
            }
        }
    }
}
