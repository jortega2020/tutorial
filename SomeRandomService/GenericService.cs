using SomeRandomService.Extension;
using SomeRandomService.Generic;
using SomeRandomService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SomeRandomService
{
    public class GenericService
    {
        public GenericService()
        {

        }

        public void SimpleGenerics()
        {
            DataStore<string> myGeneric = new DataStore<string>();
            myGeneric.Data = "Hello world!!";
            myGeneric.Print();

            DataStore<int> myGenericInt = new DataStore<int>();
            myGenericInt.Data = 200;
            myGenericInt.Print();
        }

        public void SimpleInterfaceGenerics()
        {
            Printer1Report printer = new Printer1Report();
            var person = new Person() { Name = "Jesus", LastName = "Ortega" };
            printer.Add(person);
            printer.Print();
            printer.Delete(person);
            printer.Print();
        }

        public void GenericMethod()
        {
            var students = LinqService.students;

            List<List<Student>> chunks = students.ChunkBy<Student>(5);
            int chunkCount = 0;
            Console.WriteLine($"There are {chunks.Count} chunks");

            foreach (var chunk in chunks)
            {
                chunkCount++;
                Console.WriteLine($"This Chunk {chunkCount}, containts {chunk.Count}");
                foreach (var item in chunk)
                {
                    Console.WriteLine($"the person name is {item.FirstName} {item.LastName}");
                }
            }
        }

        public void TextFileProcessor()
        {
            List<Person> people = new List<Person>();
            List<LogEntry> logs = new List<LogEntry>();

            string peopleFile = @"C:\Tutorial\people.csv";
            string logFile = @"C:\Tutorial\logs.csv";

            PopulateLists(people, logs);

            /* New way of doing things - generics */
            GenericTextFileProcessor.SaveToTextFile<Person>(people, peopleFile);
            GenericTextFileProcessor.SaveToTextFile<LogEntry>(logs, logFile);

            var newPeople = GenericTextFileProcessor.LoadFromTextFile<Person>(peopleFile);

            foreach (var p in newPeople)
            {
                Console.WriteLine($"{ p.Name } { p.LastName }");
            }

            var newLogs = GenericTextFileProcessor.LoadFromTextFile<LogEntry>(logFile);

            foreach (var log in newLogs)
            {
                Console.WriteLine($"{ log.ErrorCode }: { log.Message } at { log.TimeOfEvent.ToShortTimeString() }");
            }
        }

        private static void PopulateLists(List<Person> people, List<LogEntry> logs)
        {
            people.Add(new Person { Name = "Tim", LastName = "Corey" });
            people.Add(new Person { Name = "Sue", LastName = "Storm" });
            people.Add(new Person { Name = "Greg", LastName = "Olsen" });

            logs.Add(new LogEntry { Message = "I blew up", ErrorCode = 9999 });
            logs.Add(new LogEntry { Message = "I'm too awesome", ErrorCode = 1337 });
            logs.Add(new LogEntry { Message = "I was tired", ErrorCode = 2222 });
        }
    }


    public class Printer1Report : IPrinter<Person>
    {
        List<Person> _globalData = new List<Person>();

        public void Add(Person entity)
        {
            _globalData.Add(entity);
        }

        public void Delete(Person entity)
        {
            _globalData.Remove(entity);
        }

        public void Print()
        {
            foreach(var item in _globalData)
            {
                Console.WriteLine(item);
            }
        }
    }
}
