namespace EasyJection.Tests.EditMode
{
    using Console = UnityEngine.Debug;

    using NUnit.Framework;
    using EasyJection.Reflection;

    [TestFixture]
    public class ReflectionCacheTests
    {
        [Test]
        public void TestAddType()
        {
            var cache = new ReflectionCache();
            var type = typeof(MockClass);

            cache.Add(type);

            Assert.True(cache.Contains(type));
        }

        [Test]
        public void TestRemoveType()
        {
            var cache = new ReflectionCache();
            var type = typeof(MockClass);

            cache.Add(type);
            cache.Remove(type);

            Assert.False(cache.Contains(type));
        }
    }
}
