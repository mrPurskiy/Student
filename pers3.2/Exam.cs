using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pers3._2
{
    class Exam : Interfacedateandcopy
    {
        private string lesson;
        public int mark { get; set; }
        public DateTime date { get; set; }
        public Exam()

        {
            this.lesson = "nolesson";
            this.mark = 0;
            this.date = DateTime.Now;

        }
        public Exam(string lesson, int mark, DateTime date)
        {
            this.lesson = lesson;
            this.mark = mark;
            this.date = date;
        }

        public DateTime Date { get; set; }
        public string Lesson { get; set; }
        
        override public string ToString()
        {
            string str = "lesson " + this.Lesson + "  mark: " + this.mark + "  date: " + this.Date;
            Console.WriteLine(str);
            return str;
        }
       

        public object DeepCopy()
        {
            Exam st = new Exam();
            st.lesson = this.lesson;
            st.mark = this.mark;
            st.Date = this.date;
            return st;
        }
    }
}
