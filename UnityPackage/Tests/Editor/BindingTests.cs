namespace EasyJection.Tests.EditMode
{
    using Console = UnityEngine.Debug;

    using System;
    using NUnit.Framework;
    using EasyJection.Binding;
    using FluentAssertions;
    using EasyJection.Hooking;
    using EasyJection.Binding.Extensions;

    [TestFixture]
    public class BindingTests
    {
        [Test]
        public void TestGetBindings()
        {
            var binder = new Binder();

            binder.Bind(typeof(IMockClassInterface)).To<MockClass>();
            binder.Bind<IHeirMockInterface>().To(typeof(HeirMockClass));

            var bindings = binder.GetBindings();

            Assert.AreEqual(2, bindings.Count);

            binder.CancelAll();
        }

        [Test]
        public void TestBinding_DefaultConstructor()
        {
            var binder = new Binder();

            binder.Bind<IMockClassInterface>().To<MockClass>(UseDefaultConstructor: true);

            var binding = binder.GetBindingFor<IMockClassInterface>();

            Assert.NotNull(binding.InstantiationConstructor);

            binder.CancelAll();
        }

        [Test]
        public void TestContainsByType()
        {
            var binder = new Binder();

            binder.Bind<IMockClassInterface>().To<MockClass>();

            var contains = binder.ContainsBindingFor(typeof(IMockClassInterface));

            Assert.AreEqual(true, contains);

            binder.CancelAll();
        }

        [Test]
        public void TestGetBindingsFor()
        {
            var binder = new Binder();

            binder.Bind<IMockClassInterface>().To<MockClass>();

            var bindings = binder.GetBindingFor<IMockClassInterface>();

            Assert.AreEqual(typeof(IMockClassInterface), bindings.Type);
            Assert.AreEqual(typeof(MockClass), bindings.Value);

            binder.CancelAll();
        }

        [Test]
        public void TestBinding_ConstructorMethodWithArguments()
        {
            var binder = new Binder();

            binder.Bind<IMockClassInterface>().ToSelf<HeirMockClass>()
                                              .Constructor<int, bool>().WithArguments<int, bool>(999, true);

            var bindings = binder.GetBindingFor<IMockClassInterface>();
            var invokeData = bindings[typeof(HeirMockClass).FindConstructorWithArguments<int, bool>()].HookManager.InvokeData;

            Assert.AreEqual(BindingInstanceType.Transient, bindings.InstanceType);
            Assert.NotNull(invokeData);
            Assert.AreEqual(typeof(int), invokeData.ArgumentTypes[0]);
            Assert.AreEqual(999, (int) invokeData.ArgumentsObjects[0]);
            Assert.AreEqual(typeof(bool), invokeData.ArgumentTypes[1]);
            Assert.AreEqual(true, (bool)invokeData.ArgumentsObjects[1]);

            binder.CancelAll();
        }

        [Test]
        public void TestBinding_MethodByName()
        {
            var binder = new Binder();

            binder.Bind<IMockClassInterface>().To<MockClass>()
                                              .InjectionTo()
                                              .MethodResult<int>("PublicMethod")
                                              .Constructor();

            var binding = binder.GetBindingFor<IMockClassInterface>();

            Assert.AreEqual(BindingInstanceType.Transient, binding.InstanceType);
            Assert.NotNull(binding[typeof(MockClass).FindMethodResultByName<int>("PublicMethod")]);

            binder.CancelAll();
        }

        [Test]
        public void TestBinding_MethodByNameWithArguments()
        {
            var binder = new Binder();

            binder.Bind<IHeirMockInterface>().To<HeirMockClass>()
                                             .InjectionTo()
                                             .MethodResult<int, int>("Method").WithArguments<int>(1993)
                                             .Constructor();

            var binding = binder.GetBindingFor<IHeirMockInterface>();

            Assert.AreEqual(BindingInstanceType.Transient, binding.InstanceType);
            Assert.NotNull(binding[typeof(HeirMockClass).FindMethodResultByNameWithArguments<int, int>("Method")]);
            Assert.AreEqual(1993, binding[typeof(HeirMockClass).FindMethodResultByNameWithArguments<int, int>("Method")].HookManager.InvokeData.ArgumentsObjects[0]);
            Assert.AreEqual(typeof(int), binding[typeof(HeirMockClass).FindMethodResultByNameWithArguments<int, int>("Method")].HookManager.InvokeData.ArgumentTypes[0]);

            binder.CancelAll();
        }

        [Test]
        public void TestBinding_InjectionToMethodSignature()
        {
            var container = new Container();
            container.Bind<OriginalMethod>().ToSelf()
                              .InjectionTo()
                              .MethodResult<int, int>("GetNumber");

            var binding = container[typeof(OriginalMethod)];

            Assert.AreEqual(BindingInstanceType.Transient, binding.InstanceType);
            Assert.AreEqual(1, binding[typeof(HookedMethodResult<int,int>)].Count);

            container.Dispose();
        }

        [Test]
        public void TestBinding_InjectionToMethodWithArguments()
        {
            var container = new Container();
            container.Bind<OriginalMethod>().ToSelf()
                              .InjectionTo()
                              .MethodResult<int, int>("GetNumber").WithArguments<int>(2023);

            var binding = container[typeof(OriginalMethod)];
            var hooList = binding[typeof(HookedMethodResult<int, int>)];

            Assert.AreEqual(BindingInstanceType.Transient, binding.InstanceType);
            Assert.AreEqual(1, hooList.Count);

            container.Dispose();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            GC.Collect();
        }
    }
}
