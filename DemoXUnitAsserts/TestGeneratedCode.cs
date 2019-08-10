using JkhXUnitAssertGenerator;
using System;
using Xunit;

namespace DemoXUnitAsserts
{
    public class TestGeneratedCode
    {
        [Fact]
        public void MakeSomeXUnitCode()
        {
            var thingToWriteTestsFor = PocoMakerHelper.GenerateTestSubject();
            string cSharpSourceCode = JeoffsAwfulXUnitHacks.GenerateXUnitAssertsForPoco(nameof(thingToWriteTestsFor), thingToWriteTestsFor);
            Console.Write(cSharpSourceCode);
        }

        [Fact]
        public void GeneratedCodeTest()
        {
            var thingToWriteTestsFor = PocoMakerHelper.GenerateTestSubject();

            //note: I used the output from the test MakeSomeXUnitCode and generated this :
            Assert.Equal(5070, thingToWriteTestsFor.Number);
            Assert.Equal("Some string", thingToWriteTestsFor.Text);
            Assert.True(thingToWriteTestsFor.Boolean);
            Assert.Equal(1.234, thingToWriteTestsFor.Float);
            Assert.Equal("0.0.0.0", thingToWriteTestsFor.IPAddress.ToString());
            Assert.Equal(DateTime.Parse("0001-01-01T00:00:00.0000000"), thingToWriteTestsFor.Timestamp);

            Assert.Equal("a", thingToWriteTestsFor.ListOfText[0]);

            Assert.Equal("bb", thingToWriteTestsFor.ListOfText[1]);

            Assert.Equal("ccc", thingToWriteTestsFor.ListOfText[2]);

            Assert.Equal(1, thingToWriteTestsFor.ListOfNumbers[0]);

            Assert.Equal(2, thingToWriteTestsFor.ListOfNumbers[1]);

            Assert.Equal(3, thingToWriteTestsFor.ListOfNumbers[2]);

            Assert.Equal('y', thingToWriteTestsFor.ListOfChars[0]);

            Assert.Equal('z', thingToWriteTestsFor.ListOfChars[1]);

            Assert.True(thingToWriteTestsFor.ListOfBools[0]);

            Assert.False(thingToWriteTestsFor.ListOfBools[1]);

            Assert.Equal("Marie", thingToWriteTestsFor.SimpleChildPocos[0].Name);
            Assert.Equal(DateTime.Parse("2019-08-03T15:56:09.6523099-05:00"), thingToWriteTestsFor.SimpleChildPocos[0].Timestamp);
            Assert.False(thingToWriteTestsFor.SimpleChildPocos[0].TrueFalse);

            Assert.Equal("child1", thingToWriteTestsFor.SimpleChildPocos[0].ListOfText[0]);

            Assert.Equal("child2", thingToWriteTestsFor.SimpleChildPocos[0].ListOfText[1]);

            Assert.Equal("Charlie", thingToWriteTestsFor.SimpleChildPocos[1].Name);
            Assert.Equal(DateTime.Parse("2019-08-03T15:56:09.6523570-05:00"), thingToWriteTestsFor.SimpleChildPocos[1].Timestamp);
            Assert.True(thingToWriteTestsFor.SimpleChildPocos[1].TrueFalse);
        }
    }
}
