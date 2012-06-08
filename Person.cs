using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentDemo
{
     class SingletonPerson
     {
          private int age;
          private string name;

          // Important: Define one object that will be the Singleton:
          private static SingletonPerson me = null;

          // Make the Person constructor private so it can be controlled only by this class:
          private SingletonPerson(string name, int age)
          {
               setAge(age);
               setName(name);
          }
          private SingletonPerson() { }

          // Create a public method to create the object using internal private constructor
          // Static keyword attaches method to Person class instead of each created object
          public static SingletonPerson createMe(int age, string name) 
          { // If exists return it:
               if (me != null)
                    return me;
               else // Otherwise create it
               {
                    me = new SingletonPerson(name, age);
                    return me;
               }
          }

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

          
     }

     class Person
     {
          private int age;
          private string name;

          public Person(string name, int age)
          {
               setAge(age);
               setName(name);
          }
          public Person() { }

          public Person(int age)
               : this("", age) { }

          public Person(string name)
               : this(name, 0) { }

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


     }
}
