﻿using MediaShopLibary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsPUiMediaShop.Controllers.MediaShop
{
    public class HomeController : Controller
    {
        private static int customerId;
        private CustomerController custcontrol;


        public HomeController()
        {
            this.custcontrol = new CustomerController(new ModelMediaShopData());
            
        }
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Login()
        {

            return View();
        }

        public PartialViewResult LoginMethod(string _name, string _password)
        {
            if (Request.IsAjaxRequest())
            {
                List<Customer> custlist = custcontrol.GetAllCustomers();
                List<Customer> checkList = new List<Customer>();
                foreach (Customer cust in custlist)
                {
                    if (cust.name == _name && cust.password == _password)
                    {
                        checkList.Add(cust);
                    }
                }

                if (checkList.Count() != 0)
                {
                    customerId = checkList.First().id;
                    return PartialView("LogingDonePartialView", null);
                }

                else
                {
                    custcontrol.AddCustomer(new Customer { name = _name, password = _password });
                    return PartialView("LoginCreatePartialView", null);
                }
            }
            return PartialView("LoginPartialView", null);
        }

    }
}