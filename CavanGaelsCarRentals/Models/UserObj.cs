using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CavanGaelsCarRentals.Models
{
     public class UserObj
     {
          public bool Customer { get; set; }
          public bool Supplier { get; set; }
          private int customer_id { get; set; }
          private int supplier_id { get; set; }
          public string email { get; set; }

          public UserObj() 
          { 
               Customer = false; 
               Supplier = false;
               customer_id = 0;
               supplier_id = 0;
          }

          public UserObj(bool isSupplier)
          {
               Customer = !isSupplier;
               Supplier = isSupplier;
          }

          public void setId(int id)
          {
               if (Customer)
                    customer_id = id;
               else
                    supplier_id = id;
          }

          public int Id()
          {
               if (Customer)
                    return customer_id;
               else
                    return supplier_id;
          }
     }
}