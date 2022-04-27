using System;
using System.Collections.Generic;
using System.Text;

namespace Student4
{
    class Student_Pie : Student, IScills, ISmart
    {
        public Student_Pie(string ln, string fn, string gr, double ex, double cw) : base(ln, fn, gr, ex, cw)
        { }

        public string my_Scills()
        {
            return (" I like programming");
        }

        public string my_smart()
        {
            return ("I smart student");
        }
    }
}
