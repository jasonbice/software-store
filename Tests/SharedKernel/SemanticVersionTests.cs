using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedKernel;
using Shouldly;

namespace Tests.SharedKernel
{
    [TestClass]
    public class SemanticVersionTests
    {
        [DataRow(1, 1, 2, 1, 1, 1)]
        [DataRow(1, 2, 1, 1, 1, 1)]
        [DataRow(2, 1, 1, 1, 1, 1)]
        [DataRow(1, 1, 1, 1, 1, null)]
        [DataRow(1, 1, 1, 1, null, 1)]
        [TestMethod]
        public void Operator_WhenAIsGreaterThanB_AIsGreaterThanBReturnsTrue_And_BIsGreaterThanAReturnsFalse(
            int? firstMajor,
            int? firstMinor,
            int? firstPatch,
            int? secondMajor,
            int? secondMinor,
            int? secondPatch)
        {
            var a = new SemanticVersion {Major = firstMajor, Minor = firstMinor, Patch = firstPatch};
            var b = new SemanticVersion {Major = secondMajor, Minor = secondMinor, Patch = secondPatch};

            (a > b).ShouldBeTrue();
            (b > a).ShouldBeFalse();
        }

        [DataRow(1, 1, 1, 1, 1, 2)]
        [DataRow(1, 1, 1, 1, 2, 1)]
        [DataRow(1, 1, 1, 2, 1, 1)]
        [DataRow(1, 1, 1, 1, 2, null)]
        [DataRow(1, 1, null, 2, 1, 1)]
        [TestMethod]
        public void Operator_WhenAIsLessThanB_AIsLessThanBReturnsTrue_And_BIsLessThanAReturnsFalse(
            int? firstMajor,
            int? firstMinor,
            int? firstPatch,
            int? secondMajor,
            int? secondMinor,
            int? secondPatch)
        {
            var a = new SemanticVersion {Major = firstMajor, Minor = firstMinor, Patch = firstPatch};
            var b = new SemanticVersion {Major = secondMajor, Minor = secondMinor, Patch = secondPatch};

            (a < b).ShouldBeTrue();
            (b < a).ShouldBeFalse();
        }
    }
}