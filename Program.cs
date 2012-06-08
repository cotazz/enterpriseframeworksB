using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentDemo;
using System.Collections;

namespace StudentDemo.Yo
{
    class Program
    {
        static void Main(string[] args)
        {
            // working with IComparable interface on University objects:

             University ucd = new University(10000, "UCD");
             University dcu = new University(5000, "DCU");
             University nui = new University(5000, "NUI");
             
             // This will not work because IComparable is not directly available:
             // Console.WriteLine("Is nui == to dcu? {0}", nui.CompareTo(dcu)); // Doesn't work

             // The IComparable is hidden untill the university is 'cast' to IComparable:
             IComparable ucd1 = (IComparable)ucd;
             Console.WriteLine("Is ucd greater (1), equal (0), less than (-1) dcu? {0}", ucd1.CompareTo(dcu)); // Works

             University[] uni_array = { dcu,ucd , nui };
             Console.WriteLine("order before sort: {0}, {1}, {2}", uni_array[0], uni_array[1], uni_array[2]);
             Array.Sort(uni_array); // Sort avails of the IComparable interface defined in University class
             Console.WriteLine("order after sort: {0}, {1}, {2}", uni_array[0], uni_array[1], uni_array[2]);
            Console.ReadLine(); // pause the output window
        }

        
    }
}
