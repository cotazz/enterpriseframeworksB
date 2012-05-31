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
        private Array modules;

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
             this.modules.SetValue(course, this.modules.Length);
        }
    }
}
