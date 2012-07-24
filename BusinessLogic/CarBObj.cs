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
          private int _carId;


          public CarBObj(SupplierBObj supplier)
          {
               _supplier = supplier;
          }

         public void setId(int id)
         {
             _carId = id;
         }

         public int getId()
         {
             return _carId;
         }

          public SupplierBObj getSupplier()
          {
               return this._supplier;
          }
          public Decimal dailyRate()
          {
               return _dailyRate;
          }

          public void setDailyRate(decimal rate)
          {
              _dailyRate = rate;
          }
     }
         
}
