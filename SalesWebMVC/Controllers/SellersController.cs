using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _SellerService;
        private readonly DepartmentService _DepartmentService;

        public SellersController(SellerService SellerService, DepartmentService DepartmentService)
        {
            _SellerService = SellerService;
            _DepartmentService = DepartmentService;
        }

        public IActionResult Index()
        {
            var list = _SellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _DepartmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _SellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}