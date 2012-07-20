using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
     public class CarBObj
     {
          private SupplierBObj _supplier = null;
          private Decimal _dailyRate = 50;

          public CarBObj(SupplierBObj supplier)
          {
               _supplier = supplier;
          }

          public SupplierBObj getSupplier()
          {
               return this._supplier;
          }
          public Decimal dailyRate()
          {
               return _dailyRate;
          }

     }
}
