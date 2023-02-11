namespace EasyJection.Tests.EditMode
{
    using Console = UnityEngine.Debug;

    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ContainerTests
    {
        [Test]
        public void TestInjection_Fields()
        {
            IContainer container = new Container();
            container.Bind<IMockClassInterface>()
                     .To<MockClass>()
                     .Constructor(UseForInstantiation: true);

            var mock = new MockClassBasic();
            container.Inject(mock);

            Assert.NotNull(mock.field);

            container.Dispose();
        }

        [Test]
        public void TestInjection_Property()
        {
            IContainer container = new Container();
            container.Bind<IMockClassInterface>()
                     .To<MockClass>()
                     .Constructor(UseForInstantiation: true);

            var mock = new MockClassBasicProperty();
            container.Inject(mock);

            Assert.NotNull(mock.property);
            Assert.AreEqual((int)TestValue.PublicProperty, mock.property.PublicProperty);

            container.Dispose();
        }

        [Test]
        public void TestInjection_ProtectedConstructor()
        {
            IContainer container = new Container();
            container.Bind<IHeirMockInterface>()
                     .To<HeirMockClass>()
                     .Constructor<int, bool>(UseForInstantiation: true)
                     .WithArguments<int, bool>(999, true);

            var mock = new MockClassBasicConstruct();
            container.Inject(mock);

            Assert.NotNull(mock.Field);
            Assert.IsTrue(mock.Field.BoolValue);
            Assert.IsTrue(mock.Field.IntValue == 999);

            container.Dispose();
        }

        [Test]
        public void TestInjection_Instance()
        {
            var instance = new HeirMockClass();

            IContainer container = new Container();
            container.Bind<IHeirMockInterface>()
                     .ToInstance<HeirMockClass>(instance);

            var mock = new MockClassBasicConstruct();
            container.Inject(mock);

            Assert.NotNull(mock.Field);
            Assert.IsTrue(mock.Field.BoolValue);
            Assert.AreEqual((int)TestValue.IntValueThroughDefaultConstructor, mock.Field.IntValue);

            container.Dispose();
        }

        [Test]
        public void TestInjection_FactoryInstance()
        {
            var instanceFactory = new HeirMockClassFactory();

            IContainer container = new Container();
            container.Bind<IHeirMockInterface>()
                     .ToFactory(instanceFactory);

            var mock = new MockClassBasicConstruct();
            container.Inject(mock);

            Assert.NotNull(mock.Field);
            Assert.IsTrue(mock.Field.BoolValue);
            Assert.AreEqual((int)TestValue.IntValueThroughDefaultConstructor, mock.Field.IntValue);

            container.Dispose();
        }

        [Test]
        public void TestInjection_FactoryType()
        {
            IContainer container = new Container();
            container.Bind<IHeirMockInterface>()
                     .ToFactory<HeirMockClassFactory>(UseDefaultConstructor: true);

            var mock = new MockClassBasicConstruct();
            container.Inject(mock);

            Assert.NotNull(mock.Field);
            Assert.IsTrue(mock.Field.BoolValue);
            Assert.AreEqual((int)TestValue.IntValueThroughDefaultConstructor, mock.Field.IntValue);

            container.Dispose();
        }

        [Test]
        public void TestInjection_ConstructorArgument()
        {
            IContainer container = new Container();
            container.Bind<IHeirMockInterface>()
                     .To<HeirMockClass>()
                     .Constructor<int, bool>(UseForInstantiation: true).WithArguments<int, bool>(999, true);
            container.Bind<IMockClassConstructArgument>()
                     .To<MockClassConstructArgument>()
                     .Constructor<IHeirMockInterface>(UseForInstantiation: true).WithArguments<IHeirMockInterface>(null);

            var mock = new MockClassConstruct();
            container.Inject(mock);

            Assert.NotNull(mock.Instance);
            Assert.IsTrue(mock.BoolValue);
            Assert.AreEqual(999, mock.IntValue);

            container.Dispose();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            GC.Collect();
        }
    }
}
