using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Tests.Core
{
    [TestClass]
    public class SemanticVersionParserTests
    {
        [TestMethod]
        public void Parse_WhenInputIsValid_ReturnsSemanticVersion()
        {
            var sut = new SemanticVersionParser();
            var actual = sut.Parse("1.2.3");
            
            actual.Major.ShouldBe(1);
            actual.Minor.ShouldBe(2);
            actual.Patch.ShouldBe(3);
        }

        [TestMethod]
        public void Parse_WhenInputIsInvalid_ReturnsNull()
        {
            var sut = new SemanticVersionParser();
            var actual = sut.Parse(string.Empty);
            
            actual.ShouldBeNull();
        }
        
        [DataRow(null)]
        [DataRow("")]
        [DataRow("   ")]
        [TestMethod]
        public void TryParse_WhenInputIsNullOrEmptyOrWhitespace_ReturnsFalse(string input)
        {
            var sut = new SemanticVersionParser();
            var actual = sut.TryParse(input, out var semanticVersion);
            
            actual.ShouldBeFalse();
            semanticVersion.ShouldBeNull();
        }
        
        [TestMethod]
        public void TryParse_WhenInputContainsTooManhParts_ReturnsFalse()
        {
            var sut = new SemanticVersionParser();
            var actual = sut.TryParse("1.2.3.4", out var semanticVersion);
            
            actual.ShouldBeFalse();
            semanticVersion.ShouldBeNull();
        }

        [DataRow("1")]
        [DataRow("1.")]
        [TestMethod]
        public void TryParse_WhenOnlyMajorVersionPresent_ReturnsTrueAndParsesInput(string input)
        {
            var sut = new SemanticVersionParser();
            var actual = sut.TryParse(input, out var semanticVersion);
            
            actual.ShouldBeTrue();
            semanticVersion.Major.ShouldBe(1);
            semanticVersion.Minor.ShouldBeNull();
            semanticVersion.Patch.ShouldBeNull();
        }
        
        [DataRow("1.2")]
        [DataRow("1.2.")]
        [TestMethod]
        public void TryParse_WhenMinorVersionPresent_ReturnsTrueAndParsesInput(string input)
        {
            var sut = new SemanticVersionParser();
            var actual = sut.TryParse(input, out var semanticVersion);
            
            actual.ShouldBeTrue();
            semanticVersion.Major.ShouldBe(1);
            semanticVersion.Minor.ShouldBe(2);
            semanticVersion.Patch.ShouldBeNull();
        }
        
        [TestMethod]
        public void TryParse_WhenPatchVersionPresent_ReturnsTrueAndParsesInput()
        {
            var sut = new SemanticVersionParser();
            var actual = sut.TryParse("1.2.3", out var semanticVersion);
            
            actual.ShouldBeTrue();
            semanticVersion.Major.ShouldBe(1);
            semanticVersion.Minor.ShouldBe(2);
            semanticVersion.Patch.ShouldBe(3);
        }
    }
}