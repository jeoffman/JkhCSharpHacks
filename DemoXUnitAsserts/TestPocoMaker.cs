using JkhXUnitAssertGenerator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using Xunit;


namespace DemoTests
{
    public class TestPocoMaker
    {
        [Fact]
        public void MakeObjectSourceTest()
        {
            SimpleChildPoco thingToWriteTestsFor = PocoMakerHelper.GenerateSimpleTestSubject();
            var sourceCode = JeoffsTeriblePocoHacks.GenerateCsPoco(new List<SimpleChildPoco> { thingToWriteTestsFor });
            Debug.Write(sourceCode);
            Assert.NotEmpty(sourceCode);
        }

        [Fact]
        public void SomeSourceMadeByGenerateSimpleTestSubjectTest()
        {
            //pasted from variable   "sourceCode"   generated above
            var x = new SimpleChildPoco { Number = 42, Text = "Marie", TextNull = null, Boolean = true, Float = 95.1, IPAddress = IPAddress.Parse("127.0.0.1"), Timestamp = DateTime.Parse("9999-12-31T23:59:59.9999999"), ListOfText = new List<string> { " A", "B", "C" }, ListOfNumbers = new List<int> { 100, 101, 102 }, ListOfChars = new List<char> { 'z', 'x' }, ListOfBools = new bool[] { false, true, false }, UnsignedThing = 22U, };

            Assert.True(true);
        }
    }
}
