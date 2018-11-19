using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAssignment1
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Person p1 = new Student("ramesh",78.45);
            Student_Result(p1.isOutStanding());
            
            Console.WriteLine("**************************");
            Person p2 = new Student("suresh", 86.45);
            Student_Result(p2.isOutStanding());
            Console.WriteLine("**************************");
            Person p3 = new Student("senthil", 94.5);
            Student_Result(p3.isOutStanding());
            Console.WriteLine("**************************");
            Person p4 = new Professor("Bala", 7);
            Professor_Result(p4.isOutStanding());
            Console.WriteLine("**************************");
            Person p5 = new Professor("Murugan", 4);
            Professor_Result(p5.isOutStanding());
            Console.WriteLine("**************************");
            Console.ReadLine();
        }

        static void Student_Result(bool result)
        {
            if (result)
                Console.WriteLine("This Student is secured more than 85 and he is outstanding!..");
            else
                Console.WriteLine("This Student is did not secured more than 85 and he is not outstanding!..");
        }

        static void Professor_Result(bool result)
        {
            if (result)
                Console.WriteLine("This Professor is published  more than 4 and he is outstanding!..");
            else
                Console.WriteLine("This Professor is did not published more than 4 and he is not outstanding!..");
        }

    }

    public  class Person
    {
        public string name
        {
            get;
            set;
        }
        public Person() { }
        public Person(string name)
        {
            this.name = name;
        }

        virtual public bool isOutStanding() { return true; }

        
       
    }
    public class Professor : Person
    {

        public Professor(string name, int booksPublished)
        {
            this.name = name;
            this.booksPublished = booksPublished;
          
        }
        public int booksPublished { get; set; }

        public override bool isOutStanding()
        {
            Console.WriteLine( Display());
            return booksPublished > 4;
        }

        public string Display()
        {
            return "Professor " + this.name + " has Published " + Convert.ToString(booksPublished) + " number of books !..";
        }
    }
    public class Student : Person
    {
        public Student(string name, double percentage)
        {
            this.name = name;
            this.percentage = percentage;
           
        }
        public double percentage { get; set; }

        public override bool isOutStanding()
        {
            Console.WriteLine(print());
            return percentage > 85;
        }

        public string print()
        {
            return "Student " + this.name + " secured percentage :" + Convert.ToString(percentage) + " !..";
        }
    }
}
