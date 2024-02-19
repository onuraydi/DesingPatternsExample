using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            Teacher teacher = new Teacher(mediator);
            Student student = new Student(mediator);
            Student student2 = new Student(mediator);

            teacher.Name = "Onur";
            mediator.Teacher = teacher;

            student.Name = "Ali";
            student2.Name = "Ayse";
            mediator.Students = new List<Student> { student,student2};

            teacher.SendNewImageUrl("slide1.jpg");
            
            teacher.RecieveQuestion("is it true?",student); 

            Console.ReadLine();
                    }
    }
    abstract class CourseMember
    {
        protected Mediator Mediator;

        public CourseMember (Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public Teacher(Mediator mediator) : base(mediator)
        {

        }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved a question from {0}, {1}",student.Name,question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide: {0}", url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer,Student student)
        {
            Console.WriteLine("Teacher answered question from {0}, {1}",student.Name, answer);
        }
        public string Name { get; set; }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {

        }

        public void RecieveImage(string url)
        {
            Console.WriteLine("{1} recieved image : {0}", url,Name);
        }

        public void RecieveAnswer(string answer)
        {
            Console.WriteLine("Student recived answer {0}", answer);    
        }

        public string Name { get; set; }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question,Student student) 
        {
            Teacher.RecieveQuestion(question,student);
        }

        public void SendAnswwer(string answer,Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
}
