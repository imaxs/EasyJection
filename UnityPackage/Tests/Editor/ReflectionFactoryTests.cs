namespace EasyJection.Tests.EditMode
{
    using Console = UnityEngine.Debug;

    using System;
    using NUnit.Framework;
    using EasyJection.Reflection;
    using FluentAssertions;
    using System.Diagnostics;

    public class ReflectionFactoryTests
    {
        [Test]
        public void TestCreation()
        {
            var factory = new ReflectionFactory();
            var reflectedClass = factory.Create(typeof(MockClass));

            Assert.NotNull(reflectedClass);
        }

        [Test]
        public void TestDefaultConstructorWhenItNotDeclared()
        {
            var factory = new ReflectionFactory();
            var reflectedData = factory.Create(typeof(MockClass));

            Assert.NotNull(reflectedData.ConstructorsData);

            Assert.AreEqual(1, reflectedData.ConstructorsData.ConstructorsInfo.Length);
            Assert.AreEqual(null, reflectedData.ConstructorsData.ConstructorsParsInfo[0]);
        }

        [Test]
        public void TestConstructorWhenItDeclared()
        {
            var factory = new ReflectionFactory();
            var reflectedData = factory.Create(typeof(HeirMockClass));

            Assert.NotNull(reflectedData.ConstructorsData);

            Assert.AreEqual(3, reflectedData.ConstructorsData.ConstructorsInfo.Length);

            Assert.AreEqual(null, reflectedData.ConstructorsData.ConstructorsParsInfo[0]);

            Assert.AreEqual(1, reflectedData.ConstructorsData.ConstructorsParsInfo[1].Length);

            Assert.AreEqual(2, reflectedData.ConstructorsData.ConstructorsParsInfo[2].Length);
        }

        [Test]
        public void TestFields()
        {
            var factory = new ReflectionFactory();
            var reflectedData = factory.Create(typeof(MockClass));

            Assert.NotNull(reflectedData.FieldsInfo);

            Assert.AreEqual(3, reflectedData.FieldsInfo.Length);
        }

        [Test]
        public void TestProperties()
        {
            var factory = new ReflectionFactory();
            var reflectedData = factory.Create(typeof(MockClass));

            Assert.NotNull(reflectedData.PropertiesInfo);

            Assert.AreEqual(3, reflectedData.PropertiesInfo.Length);
        }

        [Test]
        public void TestMethods()
        {
            var factory = new ReflectionFactory();
            var reflectedData = factory.Create(typeof(MockClass));

            Assert.NotNull(reflectedData.MethodsData);
            
            Assert.AreEqual(4, reflectedData.MethodsData.MethodsInfo.Length);
            Assert.AreEqual(null, reflectedData.MethodsData.MethodsParsInfo[0]);
            Assert.AreEqual(null, reflectedData.MethodsData.MethodsParsInfo[1]);
            Assert.AreEqual(null, reflectedData.MethodsData.MethodsParsInfo[2]);
            Assert.AreEqual(null, reflectedData.MethodsData.MethodsParsInfo[3]);
        }
    }
}
