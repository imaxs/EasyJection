namespace EasyJection.Tests.EditMode
{
    using Console = UnityEngine.Debug;

    using NUnit.Framework;
    using System;
    using EasyJection.Hooking;
    using static EasyJection.Tests.EditMode.OriginalMethod;

    [TestFixture]
    public class HookingTests
    {

        [Test]
        public void TestHook_String()
        {
            var container = new Container();
            container.Bind<string>().ToInstance("Hello bro!");
            container.Bind<MockClassString>().ToSelf(UseDefaultConstructor: true);

            var binding = container[typeof(string)];

            var instance = new MockClassString();

            Assert.AreEqual("Hello bro!", binding.Value);
            Assert.AreEqual("Hello bro!", instance.GetSring());

            container.Dispose();
        }

        [Test]
        public void TestHook_Constructor()
        {
            var container = new Container();
            container.Bind<OriginalMethod>().ToSelf()
                    .InjectionTo()
                    .Constructor<string>();

            var hookedMethod = container[typeof(OriginalMethod)][typeof(HookedMethodVoid<string>)][0];

            var instance = new OriginalMethod("Original string");

            Assert.AreEqual("Original string", instance.stringValue);

            container.Dispose();
        }

        [Test]
        public void TestHook_ConstructorWithArgements()
        {
            var container = new Container();
            container.Bind<OriginalMethod>()
                    .ToSelf()
                    .InjectionTo()
                    .Constructor<string, int>()
                    .WithArguments<string, int>("From Hook", 2023);

            var hookedMethod = container[typeof(OriginalMethod)][typeof(HookedMethodVoid<string, int>)][0];

            var instance = new OriginalMethod("Original string", 555);

            Assert.AreEqual("From Hook", instance.stringValue);
            Assert.AreEqual(2023, instance.number);

            container.Dispose();
        }

        [Test]
        public void TestHook_MethodReturnedIntValue()
        {
            var container = new Container();
            container.Bind<OriginalMethod>().ToSelf()
                    .InjectionTo()
                    .MethodResult<int, int>("GetNumber")
                    .WithArguments<int>(2023);

            var hookedMethod = container[typeof(OriginalMethod)][typeof(HookedMethodResult<int,int>)][0];

            var instance = new OriginalMethod();

            // The 'getNumber' method returns the integer value obtained using the argument.
            // But with a hook, the integer value should be changed from 555 to 2023
            int returnedValue = instance.GetNumber(555);
            Assert.AreEqual(2023, returnedValue);

            returnedValue = instance.GetNumber(444);
            Assert.AreEqual(2023, returnedValue);
            returnedValue = instance.GetNumber(222);
            Assert.AreEqual(2023, returnedValue);

            container.Dispose();
        }

        [Test]
        public void TestHook_MethodsReturnedIntValue()
        {
            var container = new Container();
            container.Bind<OriginalMethod_2>().ToSelf()
                    .InjectionTo()
                    .MethodResult<int, int>("GetNumber").WithArguments<int>(2023)
                    .MethodResult<int, int>("GetNumber_SecondMethod").WithArguments<int>(9999);

            var hookedMethod = container[typeof(OriginalMethod_2)][typeof(HookedMethodResult<int, int>)][0];

            var hookedMethodSecond = container[typeof(OriginalMethod_2)][typeof(HookedMethodResult<int, int>)][1];


            var instance = new OriginalMethod_2();

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

            container.Dispose();
        }

        [Test]
        public void TestHook_MethodsReturnedIntAndFloatValues()
        {
            var container = new Container();
            container.Bind<OriginalMethod_3>().ToSelf()
                    .InjectionTo()
                    .MethodResult<int, int>("GetNumber").WithArguments<int>(2023)
                    .MethodResult<float, float>("GetNumber").WithArguments<float>(0.123f);

            var hookedMethod = container[typeof(OriginalMethod_3)][typeof(HookedMethodResult<int, int>)][0];

            var hookedMethodSecond = container[typeof(OriginalMethod_3)][typeof(HookedMethodResult<float, float>)][0];


            var instance = new OriginalMethod_3();

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

            container.Dispose();
        }

        [Test]
        public void TestHook_Scoped()
        {
            var container = new Container();
            container.Bind<IRotate>().To<Rotate>();
            container.Bind<Cube>().ToSelf(UseDefaultConstructor: true);

            var cube = Activator.CreateInstance<Cube>();
            cube.Update();

            Assert.AreEqual(1.75f, cube.CheckValue);

            container.Dispose();
        }

        [Test]
        public void TestHook_IFactory()
        {
            var container = new Container();
            container.Bind<IMockClassConstructArgument>()
                     .To<MockClassConstructArgument>()
                     .InjectionTo().Constructor<IHeirMockInterface>();

            container.Bind<IHeirMockInterface>().ToFactory<HeirMockClassFactory>();

            var mock = new MockClassConstructArgument(null);
            container.Inject(mock);

            Assert.AreEqual((int)TestValue.IntValueThroughDefaultConstructor, mock.Instance.IntValue);

            container.Dispose();
        }

        [Test]
        public void TestHook_CustomFactory()
        {
            var container = new Container();
            container.Bind<IMockClassConstructArgument>()
                     .To<MockClassConstructArgument>()
                     .InjectionTo().Constructor<IHeirMockInterface>();

            container.Bind<IHeirMockInterface>()
                     .ToFactory<HeirMockClassCustomFactory>("CreateInstance")
                     .InjectionTo().Constructor<string>(UseForInstantiation: true).WithArguments<string>("My Sweet Factory");

            var mock = new MockClassConstructArgument(null);
            container.Inject(mock);

            Assert.AreEqual((int)TestValue.IntValueThroughDefaultConstructor, mock.Instance.IntValue);

            container.Dispose();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            GC.Collect();
        }
    }
}
