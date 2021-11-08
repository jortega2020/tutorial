using SomeRandomService.Extension;
using SomeRandomService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SomeRandomService
{
    public class ExtensionMethodService
    {
        public ExtensionMethodService()
        {

        }

        public void IsGreaterThan()
        {
            int i = 10;

            var result = i.SumTwoNumbers(5);


            Console.WriteLine(result);
        }

        public void ConvertDateToString()
        {
            Console.WriteLine("Extension Method for Convert Date to String");
            var result = ImStaticClass.GetCurrentDate();
            Console.WriteLine(result);
        }

        public void ChunkList()
        {
            List<int> bigList = ImStaticClass.GenerateRandomlists(10000);
            int chunkCount = 0;
            List<List<int>> getChunks = bigList.ChunkBy(100);

            Console.WriteLine($"There are {getChunks.Count} chunks");

            foreach (var chunk in getChunks)
            {
                chunkCount++;
                Console.WriteLine($"This Chunk {chunkCount}, containts {chunk.Count}");
            }
        }

        public void Average()
        {
            List<int> bigList = ImStaticClass.GenerateRandomlists(10);
            double result = bigList.Average();
            Console.WriteLine($"The average of the biglist is {result}");
        }

        public void ObjectExamples()
        {
            Person person = new Person 
            {
                Curp = Guid.NewGuid(),
                Name = "Jesus",
                LastName = "Ortega",
                BirthDay = DateTime.Parse("05-08-1989")
            };

            string fullName = person.GetFullName();
            int age = person.CalculateAge();
            string euaFormat = person.EUADateFormat();
            Console.WriteLine($"Hi!, I'm {fullName} and I'm {euaFormat} years old..");
        }

    }


    public static class ImStaticClass
    {
        public static void StaticMethod()
        {
            Console.WriteLine("Hey man! I'm static method");
        }

        public static string GetCurrentDate()
        {
            var current = DateTime.UtcNow;
            return $"Today is {current.DayOfWeek}, {current.ToString("MMMM")} {current.Day}, {current.Year}";
        }

        public static List<int> GenerateRandomlists(int range)
        {
            Random rand = new Random();
            var bigIntList = Enumerable.Range(0, range)
                                         .Select(i => new Tuple<int, int>(rand.Next(range), i))
                                         .OrderBy(i => i.Item1)
                                         .Select(i => i.Item2)
                                         .ToList();
            return bigIntList;
        }
    }
}
