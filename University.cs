using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentDemo
{
     class University : IComparable // IComparable Interface requires implementation of CompareTo method
     {
          public int StudentNumber { get; set; }
          public string Name { get; set; }

          public University(int students, string name)
          {
               StudentNumber = students;
               Name = name;
          }

          //int IComparable.CompareTo(object obj)
          //{
          //     University temp = obj as University;
          //     if (temp != null)
          //     {
          //          if (this.StudentNumber > temp.StudentNumber)
          //               return 1; // this item comes after the object in sort order
          //          if (this.StudentNumber < temp.StudentNumber)
          //               return -1; // this item must come before the object in the sort order
          //          else
          //               return 0; // this instances student number is equal to the objects
          //     }
          //     else
          //          throw new ArgumentException("Paramater is not a University!!");
          //}

          // Can also implement above logic using Integer's built in CompareTo method
          int IComparable.CompareTo(object obj)
          {
               University temp = obj as University;
               if (temp != null)
                    return this.StudentNumber.CompareTo(temp.StudentNumber);
               else
                    throw new ArgumentException("Paramater is not a University!!");
          }


          public override string ToString()
          {
               return this.Name;
          }

     }
}
