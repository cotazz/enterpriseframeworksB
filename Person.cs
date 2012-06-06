using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentDemo.Yo
{
    class Person
    {
        private int age;
        private string name;

         // Important: Define one object that will be the Singleton:
        private static Person me = null;

         // Make the Person constructor private so it can be controlled only by this class:
        private Person(string name, int age)
        {
             setAge(age);
             setName(name);
        }
         private Person () {}

 

        public int getAge()
        {
            return this.age;
        }
        public void setAge(int age)
        {
            this.age = age;
        }

        public void setName(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return this.name;
        }

        public String toString()
        {
            return "The age of " + name + " is " + age;
        }

         // Create an interface to create the object using the private constructor:
         public static Person createMe(int age, string name)
         { // If exists return it:
              if (me != null)
                   return me;
              else // Otherwise create it
              {
                   me = new Person(name, age);
                   return me;
               }
          }
    }
}
