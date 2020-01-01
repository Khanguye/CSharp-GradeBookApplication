using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            var numStdIn20 = (int)Math.Ceiling(Students.Count * 0.2);
            var stdSortAvgGrades = Students.OrderByDescending(s => s.AverageGrade).Select(g => g.AverageGrade).ToList();

            if (stdSortAvgGrades.Skip(numStdIn20 - 1).Take(1).First() <= averageGrade)
            {
                return 'A';
            }
            else if (stdSortAvgGrades.Skip(numStdIn20 * 2 - 1).Take(1).First() <= averageGrade)
            {
                return 'B';
            }
            else if (stdSortAvgGrades.Skip(numStdIn20 * 3 - 1).Take(1).First() <= averageGrade)
            {
                return 'C';
            }
            else if (stdSortAvgGrades.Skip(numStdIn20 * 4 - 1).Take(1).First() <= averageGrade)
            {
                return 'D';
            }

            return 'F';

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
                base.CalculateStudentStatistics();
            }
        }
    }
}
