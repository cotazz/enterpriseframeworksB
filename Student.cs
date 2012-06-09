using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentDemo.Yo
{
    class Student : Person
    {
        // Alternative way to specify setter / getter
        private int idNum;
        List<string> modules = new List<string>(); // Arrays are not dynamic, Lists are (i.e. can add stuff on to lists)

        public int IdNum
        {
            set
            {
                idNum = value;
            }
            get
            {
                return idNum;
            }
        }
        public void addCourse(String course)
        {
             modules.Add(course);
        }
    }
}
