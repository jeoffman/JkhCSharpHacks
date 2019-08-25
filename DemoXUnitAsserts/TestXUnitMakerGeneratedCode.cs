using JkhXUnitAssertGenerator;
using System;
using System.Diagnostics;
using Xunit;

namespace DemoTests
{
    public class TestXUnitMakerGeneratedCode
    {
        [Fact]
        public void MakeSomeXUnitCode()
        {
            var thingToWriteTestsFor = PocoMakerHelper.GenerateTestSubject();
            string cSharpSourceCode = JeoffsAwfulXUnitHacks.GenerateXUnitAssertsForPoco(nameof(thingToWriteTestsFor), thingToWriteTestsFor);
            Debug.Write(cSharpSourceCode);
        }

        [Fact]
        public void GeneratedCodeTest()
        {
            var thingToWriteTestsFor = PocoMakerHelper.GenerateTestSubject();

            //note: I used the output from the test MakeSomeXUnitCode and generated this :
            Assert.Equal(5070, thingToWriteTestsFor.Number);
            Assert.Equal("Some string", thingToWriteTestsFor.Text);
            Assert.Null(thingToWriteTestsFor.TextNull);
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

            Assert.True(thingToWriteTestsFor.ArrayOfBools[0]);
            Assert.False(thingToWriteTestsFor.ArrayOfBools[1]);
            Assert.Equal(0, thingToWriteTestsFor.SimpleChildPocos[0].Number);
            Assert.Equal("Marie", thingToWriteTestsFor.SimpleChildPocos[0].Text);
            Assert.Null(thingToWriteTestsFor.SimpleChildPocos[0].TextNull);
            Assert.False(thingToWriteTestsFor.SimpleChildPocos[0].Boolean);
            Assert.Equal(102.3, thingToWriteTestsFor.SimpleChildPocos[0].Float);
            Assert.Equal(DateTime.Parse("2019-08-03T15:56:09.6523099-05:00"), thingToWriteTestsFor.SimpleChildPocos[0].Timestamp);

            Assert.Equal("child1", thingToWriteTestsFor.SimpleChildPocos[0].ListOfText[0]);
            Assert.Equal("child2", thingToWriteTestsFor.SimpleChildPocos[0].ListOfText[1]);
            Assert.Null(thingToWriteTestsFor.SimpleChildPocos[0].ListOfText[2]);
            Assert.Equal(0U, thingToWriteTestsFor.SimpleChildPocos[0].UnsignedThing);
            Assert.Null(thingToWriteTestsFor.SimpleChildPocos[0].NullString);

            Assert.Equal(0, thingToWriteTestsFor.SimpleChildPocos[1].Number);
            Assert.Equal("Charlie", thingToWriteTestsFor.SimpleChildPocos[1].Text);
            Assert.Null(thingToWriteTestsFor.SimpleChildPocos[1].TextNull);
            Assert.True(thingToWriteTestsFor.SimpleChildPocos[1].Boolean);
            Assert.Equal(0, thingToWriteTestsFor.SimpleChildPocos[1].Float);
            Assert.Equal(DateTime.Parse("2019-08-03T15:56:09.6523570-05:00"), thingToWriteTestsFor.SimpleChildPocos[1].Timestamp);
            Assert.Equal(0U, thingToWriteTestsFor.SimpleChildPocos[1].UnsignedThing);
            Assert.Null(thingToWriteTestsFor.SimpleChildPocos[1].NullString);

            Assert.Equal(42, thingToWriteTestsFor.SimpleChildPocos[2].Number);
            Assert.Equal("Marie", thingToWriteTestsFor.SimpleChildPocos[2].Text);
            Assert.Null(thingToWriteTestsFor.SimpleChildPocos[2].TextNull);
            Assert.True(thingToWriteTestsFor.SimpleChildPocos[2].Boolean);
            Assert.Equal(95.1, thingToWriteTestsFor.SimpleChildPocos[2].Float);
            Assert.Equal("127.0.0.1", thingToWriteTestsFor.SimpleChildPocos[2].IPAddress.ToString());
            Assert.Equal(DateTime.Parse("9999-12-31T23:59:59.9999999"), thingToWriteTestsFor.SimpleChildPocos[2].Timestamp);

            Assert.Equal(" A", thingToWriteTestsFor.SimpleChildPocos[2].ListOfText[0]);
            Assert.Equal("B", thingToWriteTestsFor.SimpleChildPocos[2].ListOfText[1]);
            Assert.Equal("C", thingToWriteTestsFor.SimpleChildPocos[2].ListOfText[2]);

            Assert.Equal(100, thingToWriteTestsFor.SimpleChildPocos[2].ListOfNumbers[0]);
            Assert.Equal(101, thingToWriteTestsFor.SimpleChildPocos[2].ListOfNumbers[1]);
            Assert.Equal(102, thingToWriteTestsFor.SimpleChildPocos[2].ListOfNumbers[2]);

            Assert.Equal('z', thingToWriteTestsFor.SimpleChildPocos[2].ListOfChars[0]);
            Assert.Equal('x', thingToWriteTestsFor.SimpleChildPocos[2].ListOfChars[1]);

            Assert.False(thingToWriteTestsFor.SimpleChildPocos[2].ListOfBools[0]);
            Assert.True(thingToWriteTestsFor.SimpleChildPocos[2].ListOfBools[1]);
            Assert.False(thingToWriteTestsFor.SimpleChildPocos[2].ListOfBools[2]);
            Assert.Equal(22U, thingToWriteTestsFor.SimpleChildPocos[2].UnsignedThing);
            Assert.Null(thingToWriteTestsFor.SimpleChildPocos[2].NullString);

            Assert.Equal(EnumThing.One, thingToWriteTestsFor.EnumThing);
            Assert.Equal(19U, thingToWriteTestsFor.UnsignedAndUnsung);
            Assert.Null(thingToWriteTestsFor.NullString);
        }
    }
}
