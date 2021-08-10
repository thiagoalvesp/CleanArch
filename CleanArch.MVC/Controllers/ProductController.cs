using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.MVC.Controllers
{

    

    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

     
        public async Task<ActionResult> Index() => View(await _productService.GetProducts());
        public ActionResult Create() => View();
        public async Task<ActionResult> Edit(int id) => View(await _productService.GetById(id));
        public async Task<ActionResult> Details(int id) => View(await _productService.GetById(id));
        public async Task<ActionResult> Delete(int id) => View(await _productService.GetById(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel productVM)
        {
            try
            {                
                if (!ModelState.IsValid)
                {
                    return View(productVM);
                }

                _productService.Add(productVM);


                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {

                return View(productVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel productVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(productVM);
                }

                _productService.Update(productVM);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(productVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductViewModel productVM)
        {
            try
            {
                _productService.Remove(productVM);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(productVM);
            }
        }
    }
}
