using AutoMapper;
using Inventory_App.Data;
using Inventory_App.DTOs;
using Inventory_App.Models;
using Inventory_App.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Inventory_App.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        public InventoryController(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Inventory()
        {
            ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            var products = await _productsRepository.GetAll();
            var productsDTO = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return View(productsDTO);
        }


        // Crear Producto
        public IActionResult CreateProduct()
        {
            ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<ProductModel>(productDTO);
                await _productsRepository.Create(product);
               
                return RedirectToAction("Inventory", "Inventory");
            }

            return View();
        }

        // Actualizar Producto
        public async Task<IActionResult> UpdateProductVw(int id)
        {
            var product = await _productsRepository.GetById(id);

            var productDTO = _mapper.Map<ProductDTO>(product);

            ViewBag.Id = id;
            return View(productDTO);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(int id, ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                var productToUpdate = _mapper.Map<ProductModel>(productDTO);
                productToUpdate.Id = id;
                await _productsRepository.Update(productToUpdate);

                return RedirectToAction("Inventory", "Inventory");
            }


            return View("UpdateProductVw");
        }

        public async Task<IActionResult> DeleteProductVw(int id)
        {
            ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            var product = await _productsRepository.GetById(id);
            var productDTO = _mapper.Map<ProductDTO>(product);
            return View(productDTO);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {

            await _productsRepository.Delete(id);

            return RedirectToAction("Inventory", "Inventory");
        }
    }
}
