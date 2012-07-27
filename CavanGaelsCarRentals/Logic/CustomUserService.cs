using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CavanGaelsCarRentals.DataAccess;
using CavanGaelsCarRentals.Models;

namespace CavanGaelsCarRentals.Logic
{
     public class CustomUserService
     {
          private static UserRepository db = new UserRepository();


          
          public static void CreateCustomer(string email)
          {
               db.createCustomer(email);
               
          }

          public static void CreateSupplier(string email)
          {
               db.createSupplier(email);
          }

          public static UserObj loadUser(string email)
          {

               int id = db.findSupplierId(email);
               if (id > 0)
               {
                    UserObj u = new UserObj(true); // true setsuser as a supplier
                    u.setId(id);
                    return u; // return supplier user
               }

               id = db.findCustomerId(email);
               if (id > 0)
               {
                    UserObj u = new UserObj(false); // false sets User as non supplier
                    u.setId(id);
                    return u; // return customer user
               }


               return new UserObj(); // else return empty user
               
          
          }
                    
     }
}