using System;
using System.Linq;
using Xunit;

namespace StringExtensions.Test
{
    public class StringUtilityTest
    {
        [Theory]
        [InlineData("Nemish","nEMISH")]
        [InlineData("Nemish Sheth", "nEMISH sHETH")]
        [InlineData("Nemish @#$ Sheth", "nEMISH @#$ sHETH")]
        public void TetsCaseConversion( string inpStr,string expected)
        {
            Assert.Equal(expected, inpStr.CaseConversion());
        }
        [Theory]
        [InlineData("Nemish", "Nemish")]
        [InlineData("Nemish ShEth", "Nemish Sheth")]
        [InlineData("neMISh @#$ SHETH", "Nemish @#$ SHETH")]
        public void TetstTitleCase(string inpStr, string expected)
        {
            Assert.Equal(expected, inpStr.TitleCase());
        }

        [Theory]
        [InlineData("Nemish", false)]
        [InlineData("Nemish ShEth", false)]
        [InlineData("nemish nemish", true)]
        public void TestIsLower(string inpStr, bool expected)
        {
            Assert.Equal(expected, inpStr.IsLower());
        }

        [Theory]
        [InlineData("Nemish", "Nemish")]
        [InlineData("Nemish ShEth", "Nemish Sheth")]
        [InlineData(" neMISh @#$ SHETH", " Nemish @#$ Sheth")]
        public void TestCapitalCase(string inpStr, string expected)
        {
            Assert.Equal(expected, inpStr.CapitalCase());
        }
        [Theory]
        [InlineData("NEMISH", true)]
        [InlineData("Nemish ShEth", false)]
        [InlineData("NEMISH SHETH", true)]
        public void TestIsUpper(string inpStr, bool expected)
        {
            Assert.Equal(expected, inpStr.IsUpper());
        }

        [Theory]
        [InlineData("4232",true)]
        [InlineData("87890", true)]
        [InlineData("13da33", false)]
        public void TestIsDigit(string inpStr, bool expected)
        {
            Assert.Equal(expected, inpStr.ToDigitPossible());
        }

        [Theory]
        [InlineData("Nemish", "Nemis")]
        [InlineData("Nemish ShEth  ", "Nemish ShEth ")]
        [InlineData("neMISh @#$", "neMISh @#")]
        public void TestRemoveLastChar(string inpStr, string expected)
        {
            Assert.Equal(expected, inpStr.RemoveLastChar());
        }

        [Theory]
        [InlineData("ab bc cd", 3)]
        [InlineData("aa bb cc d d", 5)]
        [InlineData("neMISh @#$", 2)]
        public void TestWordCount(string inpStr, int expected)
        {
            Assert.Equal(expected, inpStr.CountWord());
        }

        [Theory]
        [InlineData("4232", 4232)]
        [InlineData("87890", 87890)]
        public void TestToInt(string inpStr, int expected)
        {
            Assert.Equal(expected, inpStr.ToInt());
        }
    }
}
