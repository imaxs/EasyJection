namespace EasyJection.Tests.EditMode
{
    using Console = UnityEngine.Debug;

    using NUnit.Framework;
    using Resolving;
    using Binding;
    using Reflection;
    using EasyJection.Resolving.Extensions;

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
            binder = new Binder();
            cache = new ReflectionCache();
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
        public void TestResolveByGenerics_DefaultConstructor()
        {
            var instance = this.resolver.Resolve<IMockClassInterface>();

            Assert.AreEqual(typeof(MockClass), instance.GetType());
        }

        [Test]
        public void TestResolveByType_DefaultConstructor()
        {
            var instance = this.resolver.Resolve(typeof(IMockClassInterface));

            Assert.AreEqual(typeof(MockClass), instance.GetType());
        }

        [Test]
        public void TestResolveByGenerics_ConstructorWithArguments()
        {
            var instance = this.resolver.Resolve<IHeirMockInterface>();

            Assert.AreEqual(typeof(HeirMockClass), instance.GetType());
            Assert.AreEqual(777, instance.IntValue);
            Assert.AreEqual(true, instance.BoolValue);
        }

        [Test]
        public void TestResolveByType_ConstructorWithArguments()
        {
            var instance = (IHeirMockInterface)this.resolver.Resolve(typeof(IHeirMockInterface));

            Assert.AreEqual(typeof(HeirMockClass), instance.GetType());
            Assert.AreEqual(777, instance.IntValue);
            Assert.AreEqual(true, instance.BoolValue);
        }
    }
}