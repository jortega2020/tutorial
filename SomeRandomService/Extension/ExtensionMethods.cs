using SomeRandomService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SomeRandomService.Extension
{
    public static class ExtensionMethods
    {
        public static bool IsGreaterThan(this int i, int value)
        {
            return i > value;
        }

        public static double SumTwoNumbers(this int i, int value)
        {
            return i + value;
        }

        public static string DateToString(this DateTime value)
        {
            return value.ToString("MMMM dd, yyyy");
        }

        public static List<List<int>> ChunkBy(this List<int> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }

        public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }

        public static string GetFullName(this Person person)
        {
            return $"{person.Name} {person.LastName}";
        }

        public static int CalculateAge(this Person person)
        {
            int age = DateTime.Now.Year - person.BirthDay.Year;
            if (DateTime.Now.DayOfYear < person.BirthDay.DayOfYear)
            {
                age = age - 1;
            }
            return age;
        }

        public static string EUADateFormat(this Person person)
        {
            return person.BirthDay.ToString("MMMM-dd-yyyy");
        }

        public static double Average(this List<int> list)
        {
            return list.Sum() / list.Count;
        }
    }
}
