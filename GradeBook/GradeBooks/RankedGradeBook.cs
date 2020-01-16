using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(String name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            Char retGrade = 'F';

            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            Double interval = Students.Count * .2;
            int myPosition = Students.Where(m => m.AverageGrade > averageGrade).Count() + 1;

            if (myPosition <= Math.Round(interval * 1))
            {
                retGrade = 'A';
            }
            else if (myPosition <= Math.Round(interval * 2))
            {
                retGrade = 'B';
            }
            else if (myPosition <= Math.Round(interval * 3))
            {
                retGrade = 'C';
            }
            else if (myPosition <= Math.Round(interval * 4))
            {
                retGrade = 'D';
            }

            return retGrade;
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
