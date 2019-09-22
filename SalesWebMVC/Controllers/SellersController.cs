using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _SellerService;

        public SellersController(SellerService SellerService)
        {
            _SellerService = SellerService;
        }

        public IActionResult Index()
        {
            var list = _SellerService.FindAll();
            return View(list);
        }
    }
}