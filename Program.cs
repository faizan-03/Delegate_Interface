using System;
using System.Collections.Generic;

namespace Delegate_Interface
{

    public class CourseDetail
    {
        public string course_name { get; set; }
        public string course_code { get; set; }
        public int credits { get; set; }
        public int Id { get; set; }

        public CourseDetail()
        {
            course_code = string.Empty;
            credits = 0;
            Id = 0;
            course_name = string.Empty;
        }
    }

    public delegate void Chandler(string message);
    interface Courseedit
    {
        void ADDcourse(CourseDetail course);
        void DELETEcourse(int dlt);
    }
    interface CDisplay
    {
        void DISPLAY();
    }
    public class COURSE_MANAG : Courseedit, CDisplay
    {
        List<CourseDetail> courseDetails = new List<CourseDetail>();
        public Chandler handler;

        public void ADDcourse(CourseDetail course)
        {
            courseDetails.Add(course);
            handler.Invoke($"{course.course_code} added to list ");
        }

        public void DELETEcourse(int idd)
        {

            CourseDetail c = courseDetails.Find(ccc => ccc.Id == idd);
            if (c != null)
            {
                courseDetails.Remove(c);
                handler.Invoke($" Course {idd} is removed");
            }
            else
            {
                handler.Invoke($" Course {idd} not found");
            }
        }


        public void DISPLAY()
        {
            foreach (CourseDetail detail in courseDetails)
            {
                Console.WriteLine($"ID: {detail.Id} , Course Name: {detail.course_name} , Course Code: {detail.course_code}, Credit Hours: {detail.credits}");

            }
            handler.Invoke("COURSE DISPLAYED");
        }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            COURSE_MANAG c = new COURSE_MANAG();
            c.handler = notify;
            while (true)
            {
                Console.WriteLine("Press 1 TO Add COURSE");
                Console.WriteLine("Press 2 TO Delete COURSE");
                Console.WriteLine("Press 3 TO Show COURSE");
                Console.WriteLine("Press 4 TO Exit COURSE");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {

                    Console.WriteLine("ENTER COURSE CODE ");
                    string code = Console.ReadLine();
                    Console.WriteLine("ENTER COURSE NAME");
                    string name = Console.ReadLine();
                    Console.WriteLine("ENTER THE CREDITS");
                    int cr = int.Parse(Console.ReadLine());
                    Console.WriteLine("ENTER Id");
                    int id = int.Parse(Console.ReadLine());
                    CourseDetail cd = new CourseDetail { course_name = name, course_code = code, credits = cr, Id = id };
                    c.ADDcourse(cd);
                }

                else if (choice == 2)
                {

                    Console.WriteLine("ENTER THE ID WHERE YOU WANT TO DELETE ");
                    int id = int.Parse(Console.ReadLine());
                    c.DELETEcourse(id);

                }

                else if (choice == 3)
                {

                    c.DISPLAY();

                }

                else if (choice == 4)
                {
                    break;
                }

                else
                {
                    Console.WriteLine("ENTER VALID INPUT");
                }
            }


            void notify(string message)
            {
                Console.WriteLine(message);
            }

        }
    }
}
