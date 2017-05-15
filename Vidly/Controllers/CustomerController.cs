﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        //public ActionResult Index()
        //{
        //    var customers = new List<Customer>() {
        //        new Customer {Name = "John Smith", Id = 1},
        //        new Customer {Name = "Mary Williams", Id = 2}
        //    };

        //    var viewModel = new CustomerViewModel()
        //    {
        //        Customers = customers
        //    };           
        //    return View(viewModel);
        //}

        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList(); // Holt von der DB die customers aber included die in  Membershipstypes aus einem anderen Table, die er aber inder Klasse customer abspeichert.
           
            return View(customers);
        }

        public ActionResult New()
        {
            return View();
        }


        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c=>c.Id==id);
            if ( customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //private IEnumerable<Customer> GetCustomers() => new List <Customer> {new Customer { Name = "John Smith", Id = 1 },new Customer { Name = "Mary Williams", Id = 2 }};
    }
}