using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentDemo;

namespace StudentDemo.Yo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.setAge(30);

            Console.WriteLine(p.toString());
            Console.ReadLine();
             // Brian test
            // Laks Test 22:11 30/05/2012
            // Exercises:
            // 1. Add back in our constructor which takes name and age
            // 2. Create an array of Person called people and then create 
            //    some staff and students to add to that array
            //    Write a for loop to iterate through the array and call the toString method
            // 3. Create a unit test for our toString class
            // 4. Add a list of modules to a student  (dynamic array)
            // 5. Create a method that lets a course be added to a student
            // 6. For bonus points create a method that can remove a module from a student

        }
    }
}
