using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ciberte_Practica2.Model;
using Ciberte_Practica2.Repository;

namespace Ciberte_Practica2.Areas.Customers.Controllers
{
    public class CustomerController : CustomerBaseController<Customer>
    {
        // GET: Customer

        //private CustomerRepository _repo = new CustomerRepository();
        public ActionResult Index()
        {
            return View(_repository.GetList().Take(90));
        }

        //create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);
            _repository.Add(customer);
            return RedirectToAction("Index");
        }

        //Edit
        public ActionResult Edit(int id)
        {
            var person = _repository.GetById(x => x.CustomerId == id);
            if (person == null) return RedirectToAction("Index");
            return View(person);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);
            _repository.Update(customer);
            return RedirectToAction("Index");
        }
        //Detail
        public ActionResult Details(int id)
        {
            var customer = _repository.GetById(x => x.CustomerId == id);
            if (customer == null) return RedirectToAction("Index");
            return View(customer);
        }

        public ActionResult Delete(int id)
        {
            var customer = _repository.GetById(x => x.CustomerId == id);
            if (customer == null) return RedirectToAction("Index");
            _repository.Delete(customer);
            return View();
            //return RedirectToAction("Index");
        }
    }
}