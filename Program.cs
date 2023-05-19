using LabbTwoADotNet.Models;
using LabbTwoADotNet.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace LabbTwoADotNet
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            using(var context = new AppDbContext())
            {
                //var C1 = new Course { CourseName = "SUT20" };
                //var C2 = new Course { CourseName = "SUT21" };
                //var C3 = new Course { CourseName = "SUT22" };

                //var SU1 = new Subject { subjectName = "Programming 1" };
                //var SU2 = new Subject { subjectName = "Math" };
                //var SU3 = new Subject { subjectName = "OOP" };

                //var T1 = new Teacher { TeacherName = "Anas", SubjectId = 1 };
                //var T2 = new Teacher { TeacherName = "Reidar", SubjectId = 2 };
                //var T3 = new Teacher { TeacherName = "Tobias", SubjectId = 3 };

                //var ST1 = new Student { StudentName = "Dennis", CourseId = 1, TeacherId = 1 };
                //var ST2 = new Student { StudentName = "John", CourseId = 2, TeacherId = 2 };
                //var ST3 = new Student { StudentName = "Thomas", CourseId = 3, TeacherId = 3  };
                //var ST4 = new Student { StudentName = "Igor", CourseId = 1, TeacherId = 1 };
                //var ST5 = new Student { StudentName = "Affe", CourseId = 2, TeacherId = 2  };
                //var ST6 = new Student { StudentName = "Simon", CourseId = 3, TeacherId = 3 };

                //context.Add(C1);
                //context.Add(C2);
                //context.Add(C3);

                //context.Add(T1);
                //context.Add(T2);
                //context.Add(T3);

                //context.Add(SU1);
                //context.Add(SU2);
                //context.Add(SU3);

                //context.Add(ST1);
                //context.Add(ST2);
                //context.Add(ST3);
                //context.Add(ST4);
                //context.Add(ST5);
                //context.Add(ST6);

                //context.SaveChanges();


                bool start = true;

                while (start)
                {
                    Console.Clear();
                    Console.WriteLine("1. Get Math Teacher");
                    Console.WriteLine("2. Get Teacher with Students");
                    Console.WriteLine("3. Check if table contains Programming 1");
                    Console.WriteLine("4. Change Subject from programming 1 to OOP");
                    Console.WriteLine("5. Assign new Teacher to student");
                    Console.WriteLine("[Any Key]: Exit Application");

                    string input = Console.ReadLine();
                    Console.Clear();

                    switch (input)
                    {
                        case "1":
                            Console.WriteLine("***************** Hämta alla lärare som undervisar matte ************************");
                            Console.WriteLine();
                            var teachers = context.Subjects.Where(x => x.subjectName == "Math").SelectMany(t => t.Teacher).ToList();
                            foreach (var t in teachers)
                            {
                                Console.WriteLine($"Teacher's Name: {t.TeacherName}");
                                Console.ReadKey();
                            }
                            
                            break;

                        case "2": //Testing QUERY synthax
                            Console.WriteLine("***************** Hämta alla elever med sina lärare ************************");
                            Console.WriteLine();
                            var studentTeachers = (from student in context.Students //Selects student Collection
                                                   join teacher in context.Teachers on student.TeacherId equals teacher.TeacherId //Joins the two tables based on matching ID
                                                   where student.ID == student.ID //Filters based on Student ID
                                                   select new
                                                   {
                                                       studentName = student.StudentName, //Chooses the studentName/TeacherName
                                                       teacherName = teacher.TeacherName
                                                   }).Distinct(); //Removes duplicates

                            foreach (var item in studentTeachers)
                            {
                                
                                Console.WriteLine("Studen Name: {0} : Teacher Name: {1}", item.studentName, item.teacherName);
                            }
                            Console.ReadKey();
                            break;

                        case "3":
                            Console.WriteLine("***************** Kolla om ämnen tabell Contains programmering1 eller inte ************************");
                            Console.WriteLine();
                            //***************** Kolla om ämnen tabell Contains programmering1 eller inte ************************
                            //.Any check if there is any object that meets the condition of Programming 1
                            bool Subject = context.Subjects.Any(x => x.subjectName == "Programming 1");
                            if (Subject != null)
                            {
                                Console.WriteLine($"Does it contain programming 1? Answer: {Subject}");
                            }
                            else
                            {
                                Console.WriteLine("It doesn't contain the listed subject");
                            }
                            Console.ReadKey();
                            break;

                        case "4":
                            Console.WriteLine("***************** Editera en Ämne från programmering2 till OOP ************************");
                            Console.WriteLine("The subject is changing... ");

                            var ChangeSubject = context.Subjects
                                .FirstOrDefault(x => x.subjectName == "Programming 1"); //Change from Programming
                            if (ChangeSubject != null)
                            {
                                ChangeSubject.subjectName = "OOP";                      //OOP
                                Console.WriteLine("Subject was updated!");
                                context.SaveChanges();
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Subject was not found in the subject table");
                                Console.ReadKey();
                            }
                            break;

                        case "5":
                            Console.WriteLine("***************** Uppdatera en student record om sin lärare är Anas till Reidar ************************");
                            // 1 = Anas, 2 = Reidar
                            var exchangeTeacher = context.Students.Where(x => x.TeacherId == 1).ToList();
                            var newTeacher = context.Teachers.FirstOrDefault(x => x.TeacherId == 2);
                            if (newTeacher != null)
                            {
                                Console.WriteLine("Waiting for Database response...");
                                foreach (var stu in exchangeTeacher)
                                {
                                    stu.TeacherId = newTeacher.TeacherId;
                                    context.SaveChanges();                                    
                                    Console.ReadKey();
                                }
                                Console.WriteLine("New teacher as been assigned!");
                            }
                            else
                            {
                                Console.WriteLine("Teacher with that ID does not excist");
                                Console.ReadKey();
                            }


                            break;
                        default:
                            Console.WriteLine("Exiting program...");
                            Environment.Exit(0);
                            start = false;
                            break;
                    }
                }
            }                   
        }
    }
}