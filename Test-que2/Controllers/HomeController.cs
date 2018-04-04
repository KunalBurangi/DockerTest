using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_que2.Models;

namespace Test_que2.Controllers
{
    public class HomeController : Controller
    {
        static List<Customer> customers;
        static HomeController()
        {

            customers = new List<Customer>
        {
            new Customer { Id = 1,Name="Joe",Email="Joe@email.com",Address="flat no 103, Poonam Apt, Nehru Nagar, Nandanwan,Nagpur , Maharashtra",Phone_No = "8793342757",Bill_no = " ABX23",Payment_Done="2000rs" },
            new Customer { Id = 2,Name="Chandler",Email="Chandler@email.com",Address="flat no 104, Pushma Kamal Apt, Nehru Nagar, Nandanwan,Nagpur , Maharashtra",Phone_No = "8793342757",Bill_no = " ABX24",Payment_Done="2000rs"  },
            new Customer { Id = 3,Name="Ross",Email="Ross@email.com",Address="flat no 104, Poonam Apt, Nehru Nagar, Nandanwan,Nagpur , Maharashtra" ,Phone_No = "8793342757",Bill_no = " ABX25",Payment_Done="2000rs"}
        };
        }
        // GET: Home
        public ActionResult Index()
        {
            return View(customers);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customers.Add(customer);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(Customer customer, int id)
        {

            var itemToRemove = customers.Single(r => r.Id == id);
            customers.Remove(itemToRemove);
            return RedirectToAction("Index");

        }


        public ActionResult Details(Int32 id)
        {
            var cust = customers.Where(c => c.Id == id).FirstOrDefault();

            return View(cust);
        }
        [HttpGet]
        public ActionResult Edit(Int32 id)
        {

            var cust = customers.Where(c => c.Id == id).FirstOrDefault();

            return View(cust);

        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customers[customer.Id - 1].Name = customer.Name;
                customers[customer.Id - 1].Email = customer.Email;
                customers[customer.Id - 1].Address = customer.Address;
                customers[customer.Id - 1].Bill_no = customer.Bill_no;
                customers[customer.Id - 1].Phone_No = customer.Phone_No;
                customers[customer.Id - 1].Payment_Done = customer.Payment_Done;
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Email(Int32 id)
        {
            var cust = customers.Where(c => c.Id == id).FirstOrDefault();

            return View(cust);
        }
      
        public ActionResult Email()
        {
            return View();
        }
    }
}