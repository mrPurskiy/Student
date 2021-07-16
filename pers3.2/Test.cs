using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pers3._2
{
    class Test
    {
        public string discipline { get; set; }
        public bool pass { get; set; }

        public Test()
        {
            this.discipline = "some_discipline";
            this.pass = false;

        }
        public Test(string discipline, bool pass)
        {
            this.discipline = discipline;
            this.pass = pass;
        }

        override public string ToString()
        {
            string str = "name: " + this.discipline + " pass:  " + this.pass;
            Console.WriteLine(str);
            return str;
        }
    }
}
