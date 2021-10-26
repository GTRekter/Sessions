using GettingStartedWithASPNETCore.DependencyInjection.Interfaces;
using GettingStartedWithASPNETCore.DependencyInjection.Models;
using GettingStartedWithASPNETCore.DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GettingStartedWithASPNETCore.DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOperationTransient _operationTransient;
        private readonly IOperationScoped _operationScoped;
        private readonly IOperationSingleton _operationSingleton;
        private readonly OperationService _operationService;

        public HomeController(IOperationTransient operationTransient, 
            IOperationScoped operationScoped, 
            IOperationSingleton operationSingleton,
            OperationService operationService)
        {
            _operationTransient = operationTransient;
            _operationScoped = operationScoped;
            _operationSingleton = operationSingleton;
            _operationService = operationService;
        }
        public IActionResult Index()
        {
            ViewBag.OperationTransient = _operationTransient.OperationId;
            ViewBag.OperationScoped = _operationScoped.OperationId;
            ViewBag.OperationSingleton = _operationSingleton.OperationId;

            ViewBag.ServiceOperationTransient = _operationService.TransientOperation.OperationId;
            ViewBag.ServiceOperationScoped = _operationService.ScopedOperation.OperationId;
            ViewBag.ServiceOperationSingleton = _operationService.SingletonOperation.OperationId;
            return View();
        }
    }
}
