using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
     public class CustomerBObj
     {
         private int _customerId;

         public void setId(int id)
         {
             _customerId = id;
         }
         public int getId()
         {
             return _customerId;
         }

     }
}
