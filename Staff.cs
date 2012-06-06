using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentDemo.Yo
{
    class Staff : Person
    {
        int officeNum;

        public int getOfficeNum()
        {
            return this.officeNum;
        }

        public void setOfficeNum(int officeNum)
        {
            this.officeNum = officeNum;
        }
    }
}
