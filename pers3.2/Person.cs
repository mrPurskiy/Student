using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace pers3._2
{
    internal class Person: Interfacedateandcopy
    {
        protected string name;
        protected string sec_name;
        public DateTime date { get; set; }

        public Person(string name, string sec_name, DateTime date)
        {
            this.name = name;
            this.sec_name = sec_name;
            this.date = date;
        }
        public Person()
        {
            this.name = "noname";
            this.sec_name = "noname";
            this.date = DateTime.Now;
        }

        public string Name { get; set; }
        public string Sec_name { get; set; }
        public DateTime Date { get; set; }
        

        override public string ToString()
        {
            string str = "name " + this.Name + "  " + this.Sec_name + "  " + this.Date;
            Console.WriteLine(str);
            return str;
        }
        virtual public string ToShortString()
        {
            string str = "name " + this.Name + "  " + this.Sec_name;
            Console.WriteLine(str);
            return str;

        }

        override public bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Person p = (Person)obj;
                return (this.Date == p.Date) && (this.Name == p.Name) && (this.Sec_name == p.Sec_name);
            }
        }
        public override int GetHashCode()
        {
             int hash = 111;
           
            hash = hash * (int)this.name[0].GetHashCode();
            return hash;
        }

        public object DeepCopy()
        {
            Person st = new Person();
            st.Name = this.name;
            st.Sec_name = this.sec_name;
            st.Date = this.date;
            return st;
        }

        public static bool operator ==(Person obj, Person obj2)
        {
            if ((obj.Date == obj2.Date) && (obj.Name == obj2.Name) && (obj.Sec_name == obj2.Sec_name))
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Person obj, Person obj2)
        {

            if ((obj.Date == obj2.Date) && (obj.Name == obj2.Name) && (obj.Sec_name == obj2.Sec_name))
            {
                return false;
            }
            return true;
        }


    }
    public enum Education
    {
        Specialist, Bachelor, SecondEducation
    };
}
