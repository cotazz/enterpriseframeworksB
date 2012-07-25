using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using CavanGaelsCarRentals.Models;

namespace CavanGaelsCarRentals.Ingestion
{
     public class CSVParser : IDataparser
     {
          private String supportedFormat = "csv";
          private StreamReader reader;

          List<Car> IDataparser.parseCars()
          {
               List<Car> ret = new List<Car>();
               CsvReader csv = new CsvReader(reader, true);
               int fieldCount = csv.FieldCount;

               String[] headers = csv.GetFieldHeaders();

               while (csv.ReadNextRecord())
               {
                    Car carObj = new Car();

                    for (int i = 0; i < fieldCount; i++)
                    {
                         if (headers[i].Equals("car_reg"))
                         {
                              carObj.car_reg= csv[i];
                         }
                         else if (headers[i].Equals("cost_per_day"))
                         {
                              carObj.cost_per_day = Convert.ToDecimal(csv[i]);
                         }
                         else if (headers[i].Equals("location"))
                         {
                              carObj.location = csv[i];

                         }
                         ret.Add(carObj);
                    }
               }

               return ret;

          }

          void IDataparser.setStreamSource(System.IO.StreamReader reader)
          {
               this.reader = reader;
          }

          bool IDataparser.supportsType(string format)
          {
               if (format.Equals(supportedFormat))
               {
                    return true;
               }
               return false;
          }



     }
}