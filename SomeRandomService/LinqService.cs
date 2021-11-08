using SomeRandomService.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SomeRandomService
{
    public class LinqService
    {
        public LinqService()
        {

        }


        public void JoinLinqQuery()
        {
            #region mockData
            var magnus = new Owner { FirstName = "Magnus", LastName = "Hedlund" };
            var terry = new Owner { FirstName = "Terry", LastName = "Adams" };
            var charlotte = new Owner { FirstName = "Charlotte", LastName = "Weiss" };
            var arlene = new Owner { FirstName = "Arlene", LastName = "Huff" };
            var rui = new Owner { FirstName = "Rui", LastName = "Raposo" };

            var barley = new Pet { Name = "Barley", Owner = terry };
            var boots = new Pet { Name = "Boots", Owner = terry };
            var whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            var bluemoon = new Pet { Name = "Blue Moon", Owner = rui };
            var daisy = new Pet { Name = "Daisy", Owner = magnus };
            #endregion
            List<Owner> people = new List<Owner> { magnus, terry, charlotte, arlene, rui };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            var query = from person in people
                        join pet in pets on person equals pet.Owner
                        select new ReportOwners { OwnerName = person.FirstName, PetName = pet.Name };

            foreach (var ownerAndPet in query)
            {
                Console.WriteLine($"\"{ownerAndPet.PetName}\" is owned by {ownerAndPet.OwnerName}");
            }
        }

        public void JoinLinqMethod()
        {
            var magnus = new Owner { FirstName = "Magnus", LastName = "Hedlund" };
            var terry = new Owner { FirstName = "Terry", LastName = "Adams" };
            var charlotte = new Owner { FirstName = "Charlotte", LastName = "Weiss" };
            var arlene = new Owner { FirstName = "Arlene", LastName = "Huff" };
            var rui = new Owner { FirstName = "Rui", LastName = "Raposo" };

            var barley = new Pet { Name = "Barley", Owner = terry };
            var boots = new Pet { Name = "Boots", Owner = terry };
            var whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            var bluemoon = new Pet { Name = "Blue Moon", Owner = rui };
            var daisy = new Pet { Name = "Daisy", Owner = magnus };

            List<Owner> people = new List<Owner> { magnus, terry, charlotte, arlene, rui };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            var query = people.Join(
                pets,
                owner => owner,
                pet => pet.Owner,
                (owner, pet) => new ReportOwners { OwnerName = owner.FirstName, PetName = pet.Name }
            );

            foreach (var ownerAndPet in query)
            {
                Console.WriteLine($"\"{ownerAndPet.PetName}\" is owned by {ownerAndPet.OwnerName}");
            }
        }

        public void GroupByLinqQuery()
        {
            var queryLastNames =
                from student in students
                    group student by student.LastName into newGroup
                    orderby newGroup.Key
                select newGroup;

            foreach (var nameGroup in queryLastNames)
            {
                Console.WriteLine($"Key: {nameGroup.Key}");
                foreach (var student in nameGroup)
                {
                    Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
                }
            }
        }

        public void GroupByLinqMethod()
        {
            var queryLastNames = students.GroupBy(el => el.LastName).OrderBy(x => x.Key);

            foreach (var nameGroup in queryLastNames)
            {
                Console.WriteLine($"Key: {nameGroup.Key}");
                foreach (var student in nameGroup)
                {
                    Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
                }
            }
        }



        #region DataMock
        private  List<Student> students = new List<Student>
        {
            new Student {FirstName = "Terry", LastName = "Adams", ID = 120,
                Year = GradeLevel.SecondYear,
                ExamScores = new List<int>{ 99, 82, 81, 79}},
            new Student {FirstName = "Fadi", LastName = "Fakhouri", ID = 116,
                Year = GradeLevel.ThirdYear,
                ExamScores = new List<int>{ 99, 86, 90, 94}},
            new Student {FirstName = "Hanying", LastName = "Feng", ID = 117,
                Year = GradeLevel.FirstYear,
                ExamScores = new List<int>{ 93, 92, 80, 87}},
            new Student {FirstName = "Cesar", LastName = "Garcia", ID = 114,
                Year = GradeLevel.FourthYear,
                ExamScores = new List<int>{ 97, 89, 85, 82}},
            new Student {FirstName = "Debra", LastName = "Garcia", ID = 115,
                Year = GradeLevel.ThirdYear,
                ExamScores = new List<int>{ 35, 72, 91, 70}},
            new Student {FirstName = "Hugo", LastName = "Garcia", ID = 118,
                Year = GradeLevel.SecondYear,
                ExamScores = new List<int>{ 92, 90, 83, 78}},
            new Student {FirstName = "Sven", LastName = "Mortensen", ID = 113,
                Year = GradeLevel.FirstYear,
                ExamScores = new List<int>{ 88, 94, 65, 91}},
            new Student {FirstName = "Claire", LastName = "O'Donnell", ID = 112,
                Year = GradeLevel.FourthYear,
                ExamScores = new List<int>{ 75, 84, 91, 39}},
            new Student {FirstName = "Svetlana", LastName = "Omelchenko", ID = 111,
                Year = GradeLevel.SecondYear,
                ExamScores = new List<int>{ 97, 92, 81, 60}},
            new Student {FirstName = "Lance", LastName = "Tucker", ID = 119,
                Year = GradeLevel.ThirdYear,
                ExamScores = new List<int>{ 68, 79, 88, 92}},
            new Student {FirstName = "Michael", LastName = "Tucker", ID = 122,
                Year = GradeLevel.FirstYear,
                ExamScores = new List<int>{ 94, 92, 91, 91}},
            new Student {FirstName = "Eugene", LastName = "Zabokritski", ID = 121,
                Year = GradeLevel.FourthYear,
                ExamScores = new List<int>{ 96, 85, 91, 60}}
        };
        #endregion
    }
}
