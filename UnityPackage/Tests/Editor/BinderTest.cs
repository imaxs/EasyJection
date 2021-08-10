namespace EasyJection.Tests.EditMode
{
    using Console = UnityEngine.Debug;
    using EasyJection;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using NUnit.Framework;
    using FluentAssertions;
    using NSubstitute;

    using UnityEngine;
    using UnityEngine.TestTools;
    
    [TestFixture]
    public class BinderTests
    {
        #region [Test]_AddTwoBindings_WhereSecondAsSingle_And_WithTwoArgumentsEach()
        #region Arrange
            #region IMockFirstInterface/MockFirstClass
            private interface IMockFirstInterface
            {
                string FirstWork();
            }

            private class MockFirstClass : IMockFirstInterface
            {
                public MockFirstClass(int argInteger, string argString) =>
                    Console.Log("Constructor: MockFirstClass(argInteger: " + argInteger + ", argString: " + argString + ")");
                public string FirstWork() => "MockFirstClass: FirstWork()";
            }
            #endregion

            #region IMockSecondInterface/MockSecondClass
            private interface IMockSecondInterface
            {
                string SecondWork();
            }

            private class MockSecondClass : IMockSecondInterface
            {
                public MockSecondClass() => Console.Log("Constructor: MockSecondClass()");
                public string SecondWork() => "MockSecondClass: SecondWork()";
            }
            #endregion
        #endregion

        [Test]
        public void AddTwoBindings_WhereSecondAsSingle_And_WithTwoArgumentsEach()
        {
            var binder = new Binder(null);

            binder.Bind<IMockFirstInterface>().To<MockFirstClass>().ConstructionMethod().WithArguments(new object[]{ 1, "First" });
            binder.Bind<IMockSecondInterface>().To<MockSecondClass>().AsSingle().WithArguments<int, string>(2, "Second");

            // Check the number of bindings
            var bindings = binder.GetAllBindings();
            bindings.Count.Should().Be(2);

            // Check the type of each binding
            bindings[0].InstanceType.Should().Be(BindingInstanceType.Transient);
            bindings[1].InstanceType.Should().Be(BindingInstanceType.Single);

            // Check the number of arguments of each binding
            bindings[0].Arguments.Length.Should().Be(2);
            bindings[1].Arguments.Length.Should().Be(2);
        }
        #endregion
    }
}