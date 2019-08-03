using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;

namespace DemoXUnitAsserts
{
    /// <summary>Just making a semi-complex POCO to test my XUnit assert maker with</summary>
    public class PocoMakerHelper
    {
        /// <summary>Generate a common, reproducible object for both generating asserts as well as testing the generated code</summary>
        public static SimplePocoForAssertGeneration GenerateTestSubject()
        {
            SimplePocoForAssertGeneration testSubject = new SimplePocoForAssertGeneration
            {
                ListOfText = new List<string> { "a", "bb", "ccc" },
                ListOfNumbers = new List<int> { 1, 2, 3 },
                ListOfChars = new List<char> { 'y', 'z' },
                ListOfBools = new bool[] { true, false },
                Float = 1.234,
                Number = 5070,
                Text = "Some string",
                Boolean = true,
                IPAddress = IPAddress.Any,
                Timestamp = DateTime.MinValue,
                SimpleChildPocos = new ReadOnlyCollection<SimpleChildPoco>(new List<SimpleChildPoco>
                {
                    new SimpleChildPoco { Name = "Marie", Timestamp = DateTime.Parse("2019-08-03T20:56:09.6523099Z"), ListOfText = new List<string> { "child1", "child2" } }, //UTC time
                    new SimpleChildPoco { Name = "Charlie", Timestamp = DateTime.Parse("2019-08-03T15:56:09.6523570-05:00"), TrueFalse = true },  //local time
                }),
            };
            return testSubject;
        }

        /// <summary>Probably needs more complex types here</summary>
        public class SimplePocoForAssertGeneration
        {
            public int Number { get; set; }
            public string Text { get; set; }
            public bool Boolean { get; set; }
            public double Float { get; set; }
            public IPAddress IPAddress { get; set; }

            public DateTime Timestamp { get; set; }

            public IList<string> ListOfText { get; set; }
            public IList<int> ListOfNumbers { get; set; }
            public IList<char> ListOfChars { get; set; }
            public bool[] ListOfBools { get; set; }
            public ReadOnlyCollection<SimpleChildPoco> SimpleChildPocos { get; set; }
        }

        public class SimpleChildPoco
        {
            public string Name { get; set; }
            public DateTime Timestamp { get; set; }
            public bool TrueFalse { get; set; }
            public IList<string> ListOfText { get; set; }
        }
    }
}
