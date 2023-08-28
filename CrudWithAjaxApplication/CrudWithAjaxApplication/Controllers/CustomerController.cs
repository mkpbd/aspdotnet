﻿using CrudWithAjaxApplication.GenericInterfaces;
using CrudWithAjaxApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudWithAjaxApplication.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ILogger<CustomerController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(ILogger<CustomerController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> OnGetRecord()
        {
            var customers = await _unitOfWork.Customer.GetAll();
            return new JsonResult(customers);
        }
        public async Task<JsonResult> OnPostAdd(Customer customer)
        {
            if (customer.Id > 0)
            {
                var cus = _unitOfWork.Customer.Update(customer);
                await _unitOfWork.CompletedAsync();
                return new JsonResult(cus);
            }
            else
            {
                await _unitOfWork.Customer.Add(customer);
                await _unitOfWork.CompletedAsync();
            }

            return new JsonResult("Add Successful");
        }

        public async Task<JsonResult> OnPostDelete(string id)
        {
            await _unitOfWork.Customer.Remove(int.Parse(id));
            await _unitOfWork.CompletedAsync();

            return new JsonResult("Delete Successful");
        }

        public async Task<JsonResult> OnGetById(string Id)
        {
            var customer = await _unitOfWork.Customer.GetById(int.Parse(Id));

            return new JsonResult(customer);
        }

    }
}
