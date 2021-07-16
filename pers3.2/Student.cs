using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pers3._2
{
    internal class Student : Person, Interfacedateandcopy
    {
        private Person person;
        private Education edu;
        private int nGroup;

        private List<Test> tests = new List<Test>();
        private List<Exam> exams = new List<Exam>();
        public Student()
        {
            person = new Person();
            edu = 0;
            nGroup = 0;
            exams.Add(new Exam("history", 100, DateTime.Today));
            tests.Add(new Test("maths", false));
        }
        public Student(Person person, Education edu, int nGroup, List<Exam> exams, List<Test> tests)
        {
            this.person = person;
            this.edu = edu;
            this.nGroup = nGroup;
            this.exams = exams;
            this.tests = tests;
        }


        public void personGS(string v1, string v2, DateTime now)
        {
            this.Name = v1;
            this.Sec_name = v2;
            this.Date = now;
        }
        public Education eduGS {
            get
            {
                return this.edu;
            }
            set 
            {
                Education ed;
               ed = value;
            }
                }
        public int GetnGroup => this.nGroup;
        public int SetnGroup
        {
            set
            {
                try
                {


                    if (value < 10 || value > 69)
                    {
                        throw new Exception("less 10 or more 69");
                    }
                    else { this.nGroup = value; }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"error: {e.Message}");
                }
                finally
                {
                    this.nGroup = 11;
                }

                
   
            }
        }
        public  List<Exam> GetExam()
        {
            return this.exams;
        }
        public void SetExam(Exam ex)
        {
            this.exams.Add(ex);
        }
        public List<Test> GetTest()
        {
            return this.tests;
        }
        public void SetTest(Test ex)
        {
            this.tests.Add(ex);
        }
        


        public double AverageMark
        {
            get
            {

                double d = 0;
                int n = this.exams.Count;
                for (int i = 0; i < n; i++)
                {
                    d += this.exams[i].mark;
                }
                return d / n;
            }
         
        }
        public void AddExams(string name, int mark, DateTime date)
        {
            int n = exams.Count;
            Exam add = new Exam(name, mark, date);
            this.exams.Add(add);
        }
        public string PrintExamsName()
        {
            int n = exams.Count;
            string str = "";
            for (int i = 0; i < n; i++)
            {
                str += exams[i].Lesson + " ";
            }
            return str;
        }
        override public string ToString()
        {

            string str = "name " + this.Name + "  " + this.Sec_name + "  " + this.Date +
            "\n education " + eduGS + "\n num of group " + GetnGroup + " \n exams: " + PrintExamsName();
            Console.WriteLine(str);
            return str;


        }
        public override string ToShortString()
        {

            string str = "name " + this.Name + "  " + this.Sec_name + "  " + this.Date +
            "\n education " + eduGS + "\n num of group " + GetnGroup + " \n AverageMark: " + AverageMark;
            Console.WriteLine(str);
            return str;

        }

       

        public override int GetHashCode()
        {
            int hash = 111;
            hash = hash * 11 + this.nGroup.GetHashCode();
            hash = hash * (int)this.Name[0].GetHashCode();
            return hash;
        }

        //public Student DeepCopy(Student st)
        //{

        //    this.name = st.Name;
        //    this.sec_name = st.Sec_name;
        //    this.date = st.Date;
        //    this.person = st.person;
        //    this.edu = st.eduGS;
        //    this.nGroup = st.GetnGroup;

        //    foreach (Exam el in st.exams)
        //    {
        //        this.exams.Add(el);
        //    }

        //    return this;
        //}
        public new object DeepCopy()
        {
            Student st = new Student();
            st.Name = this.Name;
            st.Sec_name = this.Sec_name;
            st.Date = this.Date;
            st.person = this.person;
            st.eduGS = this.edu;
            st.nGroup = this.nGroup;
            st.exams = this.exams;
            return st;
        }
        public bool this[Education index]
        {
            get
            {
                if (this.edu == index)
                {
                    return true;
                }
                else { return false; }
            }

        }


        public bool Load(string readPath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(readPath))
                {

                    string line = sr.ReadToEnd();
                    string[] words = line.Split(new char[] { ' ' });

                    this.Name = words[0];
                    this.Sec_name = words[1];
                    DateTime d;
                    DateTime.TryParse(words[2] + words[3], out d );
                    this.Date = d;
                    Education hi = this.edu;
                    Enum.TryParse(words[4],out this.edu);
                    Int32.TryParse(words[5], out this.nGroup);

                    Console.WriteLine();
                    



                    return true;
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public bool Save(string writePath)
        {
            
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    string str = "name " + this.Name + "  " + this.Sec_name + "\n" + this.Date +
           "\neducation" + eduGS + "\nnum of group " + GetnGroup;
                   
                    sw.WriteLine(str);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

        
        public IEnumerable GetExamIterator(int max)
        {
            for (int i = 0; i < this.exams.Count; i++)
            {
                if (i == this.exams.Count)
                {
                    yield break;
                }
                else
                {
                    if (this.exams[i].mark >= max)
                    {
                        yield return this.exams[i];
                    }
                    
                }
            }
        }
        public IEnumerable GetTestIterator()
        {
            for (int i = 0; i < this.tests.Count; i++)
            {
                if (i == this.tests.Count)
                {
                    yield break;
                }
                else
                {
                    
                    yield return this.tests[i];
                
                }
            }
        }
    


    
    }
}


