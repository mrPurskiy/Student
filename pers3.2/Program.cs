using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace pers3._2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //1
            Person person1 = new Person("Mary", "Autwil", DateTime.Now);
            Person person2 = new Person("Mary", "Autwil", DateTime.Now);
            if (person1 == person2)
            {
                Console.WriteLine("objects are equal");
            }
            Console.WriteLine("person1 hash - "+ person1.GetHashCode());
            Console.WriteLine("person2 hash - "+ person2.GetHashCode());
            Console.WriteLine("-----------------------------------------------------------------------");


            //2,3
            Student student1 = new Student();
            student1.personGS("Joe", "Rogan", DateTime.Now);
            student1.eduGS = Education.Specialist;
            student1.SetnGroup = 12;
            student1.AddExams("maths", 85, DateTime.Now);
            student1.AddExams("english", 91, DateTime.Now);
            Test t = new Test("physics", true);
            student1.SetTest(t);

            student1.ToShortString();
            Console.WriteLine("-----------------------------------------------------------------------");



            //4
            student1.ToShortString();
            Student newone = new Student();
            newone = (Student)student1.DeepCopy();
            newone.Name = "Gorge";
            newone.ToShortString();

            //5
            newone.SetnGroup = 5;

            //6
            Console.WriteLine("-------------------------------------------------------------");
            foreach (Exam el in student1.GetExamIterator(0))
            {
                el.ToString();
            }
            foreach (Test el in student1.GetTestIterator())
            {
                el.ToString();
            }
            //7
            Console.WriteLine("-------------------------------------------------------------");

            string writePath = @"C:\Users\user\source\repos\pers3.2\writefile.txt";
            string readPath = @"C:\Users\user\source\repos\pers3.2\readfile.txt";
            student1.Save(writePath);

            student1.Load(readPath);
            student1.ToShortString();

            //Console.WriteLine("-----------------------------------------------------------------------");
            //Console.WriteLine("-----------------------------------------------------------------------");
           
            Console.ReadLine();

        }

        
    }
}
