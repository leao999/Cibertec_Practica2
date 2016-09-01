using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciberte_Practica2.Model;
using System.Data.Entity;

namespace Ciberte_Practica2.Repository
{
    public class CustomerRepository: BaseRepository<Customer>
    {
        public Customer GetById(int id)
        {
            using (var db = new WebContextDB())
            {
                return db.Customer.FirstOrDefault(p => p.CustomerId == id);
            }
        }
        public List<Customer>GetListBySize(int size)
        {
            using (var db = new WebContextDB())
            {
                return db.Customer
                    .OrderByDescending(p => p.LastName)
                    .Take(size).ToList();
            }
        }
        public Customer GetCompleteCustomerById(int id)
        {
            using (var db = new WebContextDB())
            {
                return db.Customer
                    .Include(p => p.CustomerId)
                    .FirstOrDefault(p => p.CustomerId == id);
            }
        }
    }
}
