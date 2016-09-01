using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ciberte_Practica2.Repository;

namespace Ciberte_Practica2.Areas.Customers.Controllers
{
    public class CustomerBaseController<T> : Controller
        where T : class
    {
        protected IRepository<T> _repository;
        public CustomerBaseController()
        {
            _repository = new BaseRepository<T>();
        }

    }
}