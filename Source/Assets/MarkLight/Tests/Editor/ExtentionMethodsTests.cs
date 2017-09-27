using System;
using NUnit.Framework;
using MarkLight;
using UnityEngine;
using UnityEngine.TestTools;

// ReSharper disable once CheckNamespace
namespace MarkLight.Tests {
    [Category("Core.Extentions")]
    [TestFixture]
    public class ExtentionMethodsTests {
        #region Enum#HasFlag Extention Method Test

        [Test]
        public void TestHasFlagExMethod1() {
            var dwarf = Dwarfs.Balin;
            var hasFlag = dwarf.HasFlag(Dwarfs.Balin);
            Assert.IsTrue(hasFlag);
            hasFlag = dwarf.HasFlag(Dwarfs.Dori);
            Assert.IsFalse(hasFlag);

        }
        [Test]
        public void TestHasFlagExMethod2() {
            var dwarf = Dwarfs.Balin;
            var hasFlag = dwarf.HasFlag(Hobbits.Frodo);
            Assert.IsFalse(hasFlag);
            LogAssert.Expect(LogType.Error, "[MarkLight] The checked flag is not from the same type as the checked variable.");
        }

        [Test]
        public void TestHasFlagExMethod3() {
            Assert.Throws(typeof(ArgumentNullException), RaiseError);
        }

        #endregion

        #region Private Methods
        private void RaiseError() {
            var dwarf = Dwarfs.Balin;
            dwarf.HasFlag(null);
        }

        #endregion

        #region Test Enums

        enum Dwarfs {
            Thorin, Fili, Kili, Balin, Dwalin, Oin, Gloin, Dori, Nori, Ori, Bifur, Bofur, Bombur
        }

        enum Hobbits {
            Frodo, Samwise, Meriadoc, Peregrin, Bilbo
        }

        #endregion

    }
}
