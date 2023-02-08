namespace EasyJection.Tests.EditMode
{
    using Console = UnityEngine.Debug;

    using NUnit.Framework;
    using Resolving;
    using Binding;
    using Reflection;
    using EasyJection.Resolving.Extensions;
    using static EasyJection.Tests.EditMode.OriginalMethod;
    using System;

    [TestFixture]
    public class ResolvingTests
    {
        /// <summary>Resolver used on tests.</summary>
        private IResolver resolver;
        /// <summary>Binder used on tests.</summary>
        private IBinder binder;
        /// <summary>Reflection cache used on tests.</summary>
        protected IReflectionCache cache;

        [SetUp]
        public void Init() 
        {
            cache = new ReflectionCache();
            binder = new Binder(cache);
            resolver = new Resolver(cache, binder);

            binder.Bind<IMockClassInterface>().ToSelf<MockClass>(UseDefaultConstructor: true);
            binder.Bind<IHeirMockInterface>().To<HeirMockClass>()
                                             .Constructor<int, bool>(UseForInstantiation: true)
                                             .WithArguments<int, bool>(777, true);
        }

        [Test]
        public void TestExtensions_FindConstructorWithArguments()
        {
            var reflectedData = this.cache.GetClass(typeof(HeirMockClass));

            Assert.AreEqual(typeof(Reflection.Utils.ParamsConstructorCall), reflectedData.FindConstructorWithArguments(new System.Type[] { typeof(int), typeof(bool) }).GetType());
        }

        [Test]
        public void TestExtensions_DefaultConstructor()
        {
            var reflectedData = this.cache.GetClass(typeof(HeirMockClass));

            Assert.AreEqual(typeof(Reflection.Utils.ConstructorCall), reflectedData.DefaultConstructor().GetType());
        }

        [Test]
        public void TestExtensions_FindMethodByName()
        {
            var reflectedData = this.cache.GetClass(typeof(HeirMockClass));

            Assert.AreEqual(typeof(Reflection.Utils.MethodCall), reflectedData.FindMethodByName("Method").GetType());
        }

        [Test]
        public void TestExtensions_FindMethodByNameWithArguments()
        {
            var reflectedData = this.cache.GetClass(typeof(HeirMockClass));

            Assert.AreEqual(typeof(Reflection.Utils.ParamsMethodCall), reflectedData.FindMethodByNameWithArguments("Method", new System.Type[] {typeof(int)}).GetType());
        }

        [Test]
        public void TestResolverContainer_AddResolver()
        {
            var container = new MultikeysCollection<System.Type, IResolver>();

            var resolver_1 = new Resolver_1();
            var resolver_2 = new Resolver_2();
            var resolver_3 = new Resolver_3();

            container.AddKey(resolver_1, typeof(MockClass));
            container.AddKey(resolver_1, typeof(OriginalMethod));
            container.AddKey(resolver_2, typeof(OriginalMethod_2));
            container.AddKey(resolver_3, typeof(OriginalMethod_3));

            Assert.AreEqual(3, container.Count);
        }

        [Test]
        public void TestResolverContainer_GetByType()
        {
            var container = new MultikeysCollection<System.Type, IResolver>();

            var resolver_1 = new Resolver_1();
            var resolver_2 = new Resolver_2();
            var resolver_3 = new Resolver_3();

            container.AddKey(resolver_1, typeof(MockClass));
            container.AddKey(resolver_1, typeof(OriginalMethod));
            container.AddKey(resolver_2, typeof(OriginalMethod_2));
            container.AddKey(resolver_3, typeof(OriginalMethod_3));

            Assert.AreEqual(resolver_1, container[typeof(OriginalMethod)]);
            Assert.AreEqual(resolver_1, container[typeof(MockClass)]);
            Assert.AreEqual(resolver_2, container[typeof(OriginalMethod_2)]);
            Assert.AreEqual(resolver_3, container[typeof(OriginalMethod_3)]);
        }

        [Test]
        public void TestResolverContainer_GetByIResolverInstance()
        {
            var container = new MultikeysCollection<System.Type, IResolver>();

            var resolver_1 = new Resolver_1();
            var resolver_2 = new Resolver_2();
            var resolver_3 = new Resolver_3();

            container.AddKey(resolver_1, typeof(MockClass));
            container.AddKey(resolver_1, typeof(OriginalMethod));
            container.AddKey(resolver_2, typeof(OriginalMethod_2));
            container.AddKey(resolver_3, typeof(OriginalMethod_3));

            var keyval_1 = container[resolver_1];
            var keyval_2 = container[resolver_2];
            var keyval_3 = container[resolver_3];

            Assert.NotNull(keyval_1);
            Assert.NotNull(keyval_2);
            Assert.NotNull(keyval_3);

            Assert.IsTrue(keyval_1.Key.Contains(typeof(MockClass)));
            Assert.IsTrue(keyval_1.Key.Contains(typeof(OriginalMethod)));
            Assert.IsTrue(keyval_2.Key.Contains(typeof(OriginalMethod_2)));
            Assert.IsTrue(keyval_3.Key.Contains(typeof(OriginalMethod_3)));

        }

        [Test]
        public void TestResolverContainer_RemoveResolver()
        {
            var container = new MultikeysCollection<System.Type, IResolver>();

            var resolver_1 = new Resolver_1();
            var resolver_2 = new Resolver_2();
            var resolver_3 = new Resolver_3();

            container.AddKey(resolver_1, typeof(MockClass));
            container.AddKey(resolver_1, typeof(OriginalMethod));
            container.AddKey(resolver_2, typeof(OriginalMethod_2));
            container.AddKey(resolver_3, typeof(OriginalMethod_3));

            container.RemoveValue(resolver_1);
            container.RemoveValue(resolver_2);
            container.RemoveValue(resolver_3);

            Assert.IsFalse(container.Contains(resolver_1));
            Assert.IsFalse(container.Contains(resolver_2));
            Assert.IsFalse(container.Contains(resolver_3));
        }

        [Test]
        public void TestResolverContainer_RemoveType()
        {
            var container = new MultikeysCollection<System.Type, IResolver>();

            var resolver_1 = new Resolver_1();
            var resolver_2 = new Resolver_2();
            var resolver_3 = new Resolver_3();

            container.AddKey(resolver_1, typeof(MockClass));
            container.AddKey(resolver_1, typeof(OriginalMethod));
            container.AddKey(resolver_2, typeof(OriginalMethod_2));
            container.AddKey(resolver_3, typeof(OriginalMethod_3));

            container.RemoveKey(typeof(MockClass));
            container.RemoveKey(typeof(OriginalMethod));
            container.RemoveKey(typeof(OriginalMethod_2));
            container.RemoveKey(typeof(OriginalMethod_3));

            Assert.Null(container[typeof(OriginalMethod)]);
            Assert.Null(container[typeof(MockClass)]);
            Assert.Null(container[typeof(OriginalMethod_2)]);
            Assert.Null(container[typeof(OriginalMethod_3)]);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            binder.CancelAll();
            Container.Reset();
            GC.Collect();
        }
    }
}