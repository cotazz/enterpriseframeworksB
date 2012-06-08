using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentDemo;
using System.Collections;

namespace StudentDemo
{
    class Program
    {
        static void Main(string[] args)
        {
             Person p = new Person("Random Person");
             p.setAge(30);

             Console.WriteLine(p.toString());



             // 1. Add back in our constructor which takes name and age
             //   (See Person class, Student implements base constructor)
             Student s = new Student();
             s.setName("Student");
             s.setAge(24);

             // 2. Create an array of Person called people and then create 
             //    some staff and students to add to that array
             //    Write a for loop to iterate through the array and call the toString method
             ArrayList people = new ArrayList();
             people.Add(s);
             people.Add(p);
             foreach (Person x in people)
             {
                  Console.WriteLine(x.toString());
             }
             // 3. Create a unit test for our toString class
             // 4. Add a list of modules to a student  (dynamic array)
             // 5. Create a method that lets a course be added to a student
             s.addCourse("Enterprise Frameworks");
             // 6. For bonus points create a method that can remove a module from a student


             Console.WriteLine("\nCreating a Singleton Person:");
             // Singleton class should only create one person object 
             // using custom constructor method createMe
             // This class is defined inside Person.cs
             SingletonPerson dean = SingletonPerson.createMe(40, "President");
             Console.WriteLine(dean.toString());


            // working with IComparable interface on University objects:
             University ucd = new University(10000, "UCD");
             University dcu = new University(5000, "DCU");
             University nui = new University(5000, "NUI");
             
             // This will not work because IComparable is not directly available:
             // Console.WriteLine("Is nui == to dcu? {0}", nui.CompareTo(dcu)); // Doesn't work

             // The IComparable is hidden untill the university is 'cast' to IComparable:
             IComparable ucd1 = (IComparable)ucd;
             Console.WriteLine("Is ucd greater (1), equal (0), less than (-1) dcu? {0}", ucd1.CompareTo(dcu)); // Works

             Console.WriteLine("\nSorting objects using IComparable Interface:");
             University[] uni_array = { dcu,ucd , nui };
             Console.WriteLine("order before sort: \n{0}, \n{1}, \n{2}", uni_array[0], uni_array[1], uni_array[2]);
             Array.Sort(uni_array); // Sort avails of the IComparable interface defined in University class
             Console.WriteLine("\norder after sort: \n{0}, \n{1}, \n{2}", uni_array[0], uni_array[1], uni_array[2]);
            Console.ReadLine(); // pause the output window
        }

        
    }
}
