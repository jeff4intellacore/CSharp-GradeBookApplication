using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(String name) : base(name)
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
    }
}
