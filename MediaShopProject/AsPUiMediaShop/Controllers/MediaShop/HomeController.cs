using AsPUiMediaShop.Models;
using MediaShopLibary;
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
        private ItemController itemcontrol;
        private QuantityControler quantcontrol;



        public HomeController()
        {
            this.custcontrol = new CustomerController(new ModelMediaShopData());
            this.itemcontrol = new ItemController(new ModelMediaShopData());
            this.quantcontrol = new QuantityControler(new ModelMediaShopData());
        }
        // GET: Home
        public ActionResult Index()
        {
            indexModel model = new indexModel(); 
           model.booklist = itemcontrol.GetAllBooks();

            return View(model);
        }

        public ActionResult DVD()
        {
            dvdModel model = new dvdModel();
            model.dvdlist = itemcontrol.GetAllDVDs();
            return View(model);

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

        public  PartialViewResult BuyBookMethod(int _id)
        {
            if (Request.IsAjaxRequest() && customerId > 0)
            {
                ViewBag.bookprice = quantcontrol.OrderBook(_id, customerId);
                return PartialView("BookPriceView", null);
            }

            else { return PartialView("failView", null); }
        }

        public PartialViewResult BuydvdMethod(int _id)
        {
            if (Request.IsAjaxRequest() && customerId > 0)
            {
                ViewBag.dvdprice = quantcontrol.OrderDvd(_id, customerId); 
                return PartialView("dvdpriceView", null);
            }

            else { return PartialView("failView", null); }
        }

        //public PartialViewResult booklistMethod()
        //{
        //    List<Books> booklist = itemcontrol.GetAllBooks();

        //}

    }
}