using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CavanGaelsCarRentals.Models;

namespace CavanGaelsCarRentals.DataAccess
{
     public class UserRepository
     {
          private Db db = new Db();

          public void createCustomer(string email)
          {
               Customer c = new Customer();
               c.email = email;
               c.booking_count = 0;
               db.Customers.Add(c);
               db.SaveChanges();
          }

          public void createSupplier(string email)
          {
               Supplier s = new Supplier();
               s.email = email;
               s.location = "Ireland";
               db.Suppliers.Add(s);
               db.SaveChanges();
          }

          public int findCustomerId(string email)
          {
               var user = db.Customers.Where(c => c.email.Equals(email)).FirstOrDefault();
               if (user != null)
               {
                    return user.Id;
               }
               return 0;
          }

          public int findSupplierId(string email)
          {
               var user = db.Suppliers.Where(c => c.email.Equals(email)).FirstOrDefault();
               if (user != null)
               {
                    return user.Id;
               }
               return 0;
          }
     }
}