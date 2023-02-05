namespace EasyJection.Tests.EditMode
{
    using Console = UnityEngine.Debug;

    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Management.Instrumentation;
    using EasyJection.Hooking;
    using EasyJection.Binding.Extensions;

    [TestFixture]
    public class ExtensionTests
    {
        [Test]
        public void TestExtension_FindMethodByName()
        {
            var method = typeof(OriginalMethod).FindMethodByName("MethodWithoutArguments");
            Assert.IsNotNull(method);
        }

        [Test]
        public void TestExtension_FindMethodByNameWithArguments()
        {
            var method = typeof(OriginalMethod).FindMethodByNameWithArguments<int, string>("Method_1");
            Assert.IsNotNull(method);
        }

        [Test]
        public void TestExtension_FindDefaultConstructor()
        {
            var ctor = typeof(OriginalMethod).FindDefaultConstructor();
            Assert.IsNotNull(ctor);
        }

        [Test]
        public void TestExtension_FindConstructorWithArguments()
        {
            var ctor = typeof(OriginalMethod).FindConstructorWithArguments<string, int>();
            Assert.IsNotNull(ctor);
        }

        [Test]
        public void TestExtension_FindMethodResultByName()
        {
            var ctor = typeof(OriginalMethod).FindMethodResultByName<int>("MethodWithoutArguments");
            Assert.IsNotNull(ctor);
        }

        [Test]
        public void TestExtension_FindMethodResultByNameWithArguments()
        {
            var ctor = typeof(OriginalMethod).FindMethodResultByNameWithArguments<int, int>("GetNumber");
            Assert.IsNotNull(ctor);
        }
    }
}
