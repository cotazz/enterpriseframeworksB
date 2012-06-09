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

        public Person(string name, int age)
        {
             setAge(age);
             setName(name);
        }
         public Person () {}

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
