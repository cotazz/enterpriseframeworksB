using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CavanGaelsCarRentals.Models;
using System.IO;

namespace CavanGaelsCarRentals.Ingestion
{
    interface IDataparser
    {
        List<Car> parseCars();
        void setStreamSource(StreamReader reader);
        Boolean supportsType(String format);
    }
}
