namespace EasyJection.Tests.EditMode
{
    using Console = UnityEngine.Debug;

    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using EasyJection.Hooking;
    using EasyJection.Binding.Extensions;
    using static EasyJection.Tests.EditMode.OriginalMethod;

    [TestFixture]
    public class HookingTests
    {        
        [Test]
        public void TestHook_Constructor()
        {
            Container.Instance
                .Bind<OriginalMethod>().ToSelf()
                .InjectionTo()
                .Constructor<string>();

            var hookedMethod = Container.Instance[typeof(OriginalMethod)]
                                                 [typeof(HookedMethodVoid<string>)][0];

            hookedMethod.HookManager.Hook();

            var instance = new OriginalMethod("Original string");

            Assert.AreEqual("Original string", instance.stringValue);
        }

        [Test]
        public void TestHook_ConstructorWithArgements()
        {
            Container.Instance
                .Bind<OriginalMethod>().ToSelf()
                .InjectionTo()
                .Constructor<string, int>().WithArguments<string, int>("From Hook", 2023);

            var hookedMethod = Container.Instance[typeof(OriginalMethod)]
                                                 [typeof(HookedMethodVoid<string, int>)][0];

            hookedMethod.HookManager.Hook();

            var instance = new OriginalMethod("Original string", 555);

            Assert.AreEqual("From Hook", instance.stringValue);
            Assert.AreEqual(2023, instance.number);
        }

        [Test]
        public void TestHook_MethodReturnedIntValue()
        {
            Container.Instance
                .Bind<OriginalMethod>().ToSelf()
                .InjectionTo()
                .MethodResult<int, int>("GetNumber").WithArguments<int>(2023);

            var hookedMethod = Container.Instance[typeof(OriginalMethod)]
                                                 [typeof(HookedMethodResult<int,int>)][0];


            var instance = new OriginalMethod();

            hookedMethod.HookManager.Hook();

            // The 'getNumber' method returns the integer value obtained using the argument.
            // But with a hook, the integer value should be changed from 555 to 2023
            int returnedValue = instance.GetNumber(555);
            Assert.AreEqual(2023, returnedValue);

            returnedValue = instance.GetNumber(444);
            Assert.AreEqual(2023, returnedValue);
            returnedValue = instance.GetNumber(222);
            Assert.AreEqual(2023, returnedValue);
        }

        [Test]
        public void TestHook_MethodsReturnedIntValue()
        {
            Container.Instance
                .Bind<OriginalMethod_2>().ToSelf()
                .InjectionTo()
                .MethodResult<int, int>("GetNumber").WithArguments<int>(2023)
                .MethodResult<int, int>("GetNumber_SecondMethod").WithArguments<int>(9999);

            var hookedMethod = Container.Instance[typeof(OriginalMethod_2)]
                                               [typeof(HookedMethodResult<int, int>)][0];

            var hookedMethodSecond = Container.Instance[typeof(OriginalMethod_2)]
                                                     [typeof(HookedMethodResult<int, int>)][1];


            var instance = new OriginalMethod_2();

            hookedMethod.HookManager.Hook();

            // The 'getNumber' method returns the integer value obtained using the argument.
            // But with a hook, the integer value should be changed from 555 to 2023
            int returnedValue = instance.GetNumber(555);
            Assert.AreEqual(2023, returnedValue);

            returnedValue = instance.GetNumber(444);
            Assert.AreEqual(2023, returnedValue);
            returnedValue = instance.GetNumber(222);
            Assert.AreEqual(2023, returnedValue);

            hookedMethodSecond.HookManager.Hook();

            int secondValue = instance.GetNumber_SecondMethod(555);
            Assert.AreEqual(9999, secondValue);

            secondValue = instance.GetNumber_SecondMethod(444);
            Assert.AreEqual(9999, secondValue);
            secondValue = instance.GetNumber_SecondMethod(222);
            Assert.AreEqual(9999, secondValue);
        }

        [Test]
        public void TestHook_MethodsReturnedIntAndFloatValues()
        {
            Container.Instance
                .Bind<OriginalMethod_3>().ToSelf()
                .InjectionTo()
                .MethodResult<int, int>("GetNumber").WithArguments<int>(2023)
                .MethodResult<float, float>("GetNumber").WithArguments<float>(0.123f);

            var hookedMethod = Container.Instance[typeof(OriginalMethod_3)]
                                               [typeof(HookedMethodResult<int, int>)][0];

            var hookedMethodSecond = Container.Instance[typeof(OriginalMethod_3)]
                                                     [typeof(HookedMethodResult<float, float>)][0];


            var instance = new OriginalMethod_3();

            hookedMethod.HookManager.Hook();

            // The 'getNumber' method returns the integer value obtained using the argument.
            // But with a hook, the integer value should be changed from 555 to 2023
            int returnedValue = instance.GetNumber(555);
            Assert.AreEqual(2023, returnedValue);

            returnedValue = instance.GetNumber(444);
            Assert.AreEqual(2023, returnedValue);
            returnedValue = instance.GetNumber(222);
            Assert.AreEqual(2023, returnedValue);

            hookedMethodSecond.HookManager.Hook();

            float floatValue = instance.GetNumber(0.777f);
            Assert.AreEqual(0.123f, floatValue);

            floatValue = instance.GetNumber(0.555f);
            Assert.AreEqual(0.123f, floatValue);
            floatValue = instance.GetNumber(0.222f);
            Assert.AreEqual(0.123f, floatValue);
        }
    }
}
