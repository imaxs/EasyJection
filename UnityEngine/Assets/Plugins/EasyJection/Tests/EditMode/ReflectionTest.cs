namespace EasyJection.Tests.EditMode
{
    using Console = UnityEngine.Debug;

    using System;
    using NUnit.Framework;
    using FluentAssertions;

    [TestFixture]
    public class ReflectionTest
    {
        #region Additional
            private void Print(ReflectedData data)
            {
                Console.Log("\n\r# Parent Id: " + data.ParentId);
                Console.Log("# TypeName: " + data.TypeName);
                Console.Log("# Ctors: " + data.ConstructorsData.ConstructorsInfo.Length + " Pars Length: (" + data.ConstructorsData.ConstructorsParsInfo.Length + ")");
                for (int i = 0; i < data.ConstructorsData.ConstructorsInfo.Length; i++)
                {
                    var pars = "";
                    for (int p = 0; p < data.ConstructorsData.ConstructorsParsInfo[i].Length; p++)
                        pars += data.ConstructorsData.ConstructorsParsInfo[i][p].ParameterType.Name + ",";

                    Console.Log("\t[" + i + "] " + data.ConstructorsData.ConstructorsInfo[i].Name + "(" + pars + ")");
                }
                Console.Log("# Fields: " + data.FieldsInfo.Length);
                for (int i = 0; i < data.FieldsInfo.Length; i++)
                {
                    Console.Log("\t[" + i + "] " + data.FieldsInfo[i].Name);
                }
                Console.Log("# Properties: " + data.PropertiesInfo.Length);
                for (int i = 0; i < data.PropertiesInfo.Length; i++)
                {
                    Console.Log("\t[" + i + "] " + data.PropertiesInfo[i].Name);
                }
                Console.Log("# Methods: " + data.MethodsData.MethodsInfo.Length + " Pars Length: (" + data.MethodsData.MethodsParsInfo.Length + ")");
                for (int i = 0; i < data.MethodsData.MethodsInfo.Length; i++)
                {
                    var pars = "";
                    for (int p = 0; p < data.MethodsData.MethodsParsInfo[i].Length; p++)
                        pars += data.MethodsData.MethodsParsInfo[i][p].ParameterType.Name + ",";

                    Console.Log("\t[" + i + "] " + data.MethodsData.MethodsInfo[i].Name + "(" + pars + ")");
                }
            }
        #endregion

        #region Arrange
            #region IMockFirstInterface/MockFirstClass
            private interface IMockFirstInterface
            {
                string FirstWork();
            }

            private class MockFirstClass : IMockFirstInterface
            {
                private string PrivateField = "MockFirstClass: Private Field";
                protected string ProtectedField = "MockFirstClass: Protected Field";
                public string StringProperty { get; private set; }

                public MockFirstClass(int argInteger, string argString) =>
                    Console.Log("Constructor: MockFirstClass(argInteger: " + argInteger + ", argString: " + argString + ")");
                public virtual string FirstWork() => "MockFirstClass: public virtual FirstWork()";
                private string PrivateMethod() => "MockFirstClass: PrivateMethod()";
            }
            #endregion

            #region IMockSecondInterface/MockSecondClass
            private interface IMockSecondInterface
            {
                string SecondWork();
            }

            private class MockSecondClass : MockFirstClass, IMockSecondInterface
            {
                protected new string ProtectedField = "MockSecondClass: Protected Field";
                public MockSecondClass() : base(2021, "Parent") => Console.Log("Constructor: MockSecondClass()");
                public string SecondWork() => "MockSecondClass: SecondWork()";
            }
            #endregion

            #region IMockThirdInterface/MockThirdClass
            private interface IMockThirdInterface
            {
                string ThirdWork();
            }
            private class MockThirdClass : MockFirstClass, IMockThirdInterface
            {
                public MockThirdClass() : base(2019, "Parent") => Console.Log("Constructor: MockThirdClass()");
                public string ThirdWork() => "MockThirdClass: ThirdWork()";
                public override string FirstWork() => "MockThirdClass: public override FirstWork()";
            }
        #endregion
        #endregion

        [Test]
        public void ReflectTypes_Then_SetPrivateProperties()
        {
            var mockSecond = new MockSecondClass();
            var mockThird = new MockThirdClass();

            var t1 = mockSecond.GetType().Reflect();
            var t2 = mockThird.GetType().Reflect();

            // Get parameterless constructor
            var p1 = t1.GetData().GetProperty(propertyName: "StringProperty");
            p1.SetValue(mockSecond, "PrivateSet: MockSecond");
            p1.GetValue(mockSecond).Should().Be("PrivateSet: MockSecond");

            var p2 = t2.GetData().GetProperty(propertyName: "StringProperty");
            p2.SetValue(mockThird, "PrivateSet: MockThird");
            p2.GetValue(mockThird).Should().Be("PrivateSet: MockThird");
        }

        [Test]
        public void ReflectTypes_Then_GetPrivate_And_ProtectedFileds()
        {
            var mockSecond = new MockSecondClass();
            var mockThird = new MockThirdClass();

            var t1 = mockSecond.GetType().Reflect();
            var t2 = mockThird.GetType().Reflect();

            // Get parameterless constructor
            t1.GetData().GetField(fieldName: "PrivateField").GetValue(mockSecond).Should().Be("MockFirstClass: Private Field");
            t1.GetData().GetField(fieldName: "ProtectedField").GetValue(mockSecond).Should().Be("MockSecondClass: Protected Field"); // MockSecondClass: protected new string ProtectedField

            t2.GetData().GetField(fieldName: "PrivateField").GetValue(mockThird).Should().Be("MockFirstClass: Private Field");
            t2.GetData().GetField(fieldName: "ProtectedField").GetValue(mockThird).Should().Be("MockFirstClass: Protected Field");
        }

        [Test]
        public void ReflectTypes_Then_GetConstructors()
        {
            var t1 = typeof(MockSecondClass).Reflect();
            var t2 = typeof(MockThirdClass).Reflect();

            // Get parameterless constructor
            t1.GetData().GetConstructor().Info.Name.Should().Be(".ctor");
            t1.GetData().GetConstructor().Parameters.Length.Should().Be(0);

            // Trying to get constructors by signature
            // #1 Getting an existing constructor
            var successful = t1.GetData().GetConstructor<int, string>();
            successful.Info.Name.Should().Be(".ctor");
            successful.Parameters.Length.Should().Be(2);
            // #2 Getting a non-existent constructor
            var unsuccessful = t1.GetData().GetConstructor<int, int>();
            unsuccessful.IsEmpty.Should().Be(true);
        }

        [Test]
        public void ReflectTypes_Then_GetMethodsByName()
        {
            var t1 = typeof(MockSecondClass).Reflect();
            var t2 = typeof(MockThirdClass).Reflect();

            // Check the number of reflected data
            Reflector.Cache.Length.Should().Be(1);
            Reflector.Cache[t1.NamespaceId].Length.Should().Be(3);

            // Check types name
            t1.GetData().TypeName.Should().Be("MockSecondClass");
            t2.GetData().TypeName.Should().Be("MockThirdClass");

            // Find methods by name
            // #1 Getting an existing method
            t1.GetData().GetMethod("FirstWork").Info.Name.Should().Be("FirstWork");
            // #1 Getting an non-existent method
            t2.GetData().GetMethod("UnknownMethod").IsEmpty.Should().Be(true);
        }

        [Test]
        public void ReflectTypes_Then_Check_DataAmount_and_TypesName()
        {
            var t1 = typeof(MockSecondClass).Reflect();
            var t2 = typeof(MockThirdClass).Reflect();

            // Check the number of reflected data
            Reflector.Cache.Length.Should().Be(1);
            Reflector.Cache[t1.NamespaceId].Length.Should().Be(3);

            // Check the name of the types.
            t1.GetData().TypeName.Should().Be("MockSecondClass");
            t2.GetData().TypeName.Should().Be("MockThirdClass");
        }

        [Test]
        public void ReflectedCache_Add16Items_and_CheckNameOfItemAtIndex5()
        {
            var cache = new ReflectedCache(ReflectedCache.DefaultCapacity);

            for (int i = 0; i < 16; i++)
                cache.Add("Namespace", new ReflectedData(default(ReflectedId), "Name_" + i, false, null, null, null, null, null, null));

            int index = cache.GetIndex("Namespace");

            // Check the number of reflected data
            index.Should().BeGreaterThan(-1);
            cache[index].Length.Should().Be(16);

            // Check the name
            cache[index][5].TypeName.Should().Be("Name_5");
        }
    }
}