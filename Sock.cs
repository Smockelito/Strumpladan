using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strumplådan3
{
    internal class Sock
    {
        public int Size { get; set; }
        public string Color { get; set; } = "";

        private int grade;
        public int Grade
        {
            get 
            { 
                return grade; 
            }
            set 
            { 
                if (value < 0)
                {
                    grade = 0;
                }
                else if (value > 5)
                {
                    grade = 5;
                }
                else
                {
                    grade = value;
                }
            }
        }

    }
}
