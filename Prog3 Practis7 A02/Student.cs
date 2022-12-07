using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Prog3_Practis7_A02
{
    public class Student
    {
        public string Name { get; set; }   

        public int Matricular { get; set; }

        public string FieldOfStudy { get; set; }

        public int Age { get; set; }

        public Student(string name, int matricular, string fieldOfStudy, int age)
        {
            Name = name;
            Matricular = matricular;
            FieldOfStudy = fieldOfStudy;
            Age = age;
        }
    }
}
