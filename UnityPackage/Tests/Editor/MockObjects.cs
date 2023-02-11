using EasyJection.Binding;
using EasyJection.Resolving;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using Console = UnityEngine.Debug;

namespace EasyJection.Tests.EditMode
{
    public enum TestValue : int
    {
        PublicField = 10_0,
        PrivateField = 10_2,
        ProtectedField = 10_3,

        PrivateProperty = 10_4,
        ProtectedProperty = 10_5,
        PublicProperty = 10_6,

        VirtualMethod = 10_7,
        PrivateMethod = 10_8,
        ProtectedMethod = 10_9,
        PublicMethod = 11_0,

        Method = 11_1,
        IntValueThroughDefaultConstructor = 11_2
    }

    public interface IMockClassInterface
    {
        int PublicProperty { get; }
        int VirtualMethod();
        int PublicMethod();
    }

    public interface IHeirMockInterface
    {
        int Method();
        int Method(int val);
        bool BoolValue { get; }
        int IntValue { get; }
    }

    public interface IMockClassConstructArgument 
    {
        IHeirMockInterface Instance { get; }
    }

    public class MockClass : IMockClassInterface
    {
        public int PublicField = (int)TestValue.PublicField;
        private int PrivateField = (int)TestValue.PrivateField;
        protected int ProtectedField = (int)TestValue.ProtectedField;

        public int PublicProperty { get => (int)TestValue.PublicProperty; }
        private int PrivateProperty { get => (int)TestValue.PrivateProperty; }
        protected int ProtectedProperty { get => (int)TestValue.ProtectedProperty; }

        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        public virtual int VirtualMethod() => (int)TestValue.VirtualMethod;

        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        private int PrivateMethod() => (int)TestValue.PrivateMethod;

        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        protected int ProtectedMethod() => (int)TestValue.ProtectedMethod;

        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        public int PublicMethod() => (int)TestValue.PublicMethod;
    }

    public class HeirMockClass : MockClass, IHeirMockInterface
    {
        private bool _boolValue;
        public bool BoolValue { get => _boolValue;  }
        private int _intValue;
        public int IntValue { get => _intValue; }

        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        public HeirMockClass()
        {
            _intValue = (int)TestValue.IntValueThroughDefaultConstructor;
            _boolValue = true;
        }

        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        private HeirMockClass(bool boolValue) => _boolValue = boolValue;

        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        protected HeirMockClass(int intBalue, bool boolValue) 
        {
            _intValue = intBalue;
            _boolValue = boolValue;
        }

        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        public int Method(int val) => val;
        public int Method() => (int)TestValue.Method;
    }

    /// <summary>
    /// Basic mock class with a basic dependency.
    /// </summary>
    public class MockClassBasic
    {
        public IMockClassInterface field;
    }

    /// <summary>
    /// The basic mock class for implementation via the property setter
    /// </summary>
    public class MockClassBasicProperty
    {
        public IMockClassInterface property { get; set; }
    }

    /// <summary>
    /// The basic mock class for implementation via default constructor
    /// </summary>
    public class MockClassBasicConstruct
    {
        private IHeirMockInterface m_Field;
        public IHeirMockInterface Field { get => this.m_Field; }

    }

    /// <summary>
    /// The basic mock class for implementation
    /// </summary>
    public class MockClassConstruct
    {
        private IMockClassConstructArgument m_Instance;
        public IMockClassConstructArgument Instance { get => m_Instance; }
        public int IntValue { get => this.m_Instance.Instance.IntValue; }
        public bool BoolValue { get => this.m_Instance.Instance.BoolValue; }

    }

    /// <summary>
    /// The mock class for implementation via constructor argument
    /// </summary>
    public class MockClassConstructArgument : IMockClassConstructArgument
    {
        private IHeirMockInterface m_Instance;
        public IHeirMockInterface Instance { get => this.m_Instance; }

        public MockClassConstructArgument(IHeirMockInterface instance) 
        {
            m_Instance = instance;
        }
    }

    public class HeirMockClassFactory : Types.IFactory
    {
        public object CreateInstance(IBindingData bindingData = null)
        {
            return new HeirMockClass();
        }
    }

    public class HeirMockClassCustomFactory
    {
        private string m_Name;

        public HeirMockClassCustomFactory(string factoryName) 
        {
            this.m_Name = factoryName;
        }

        public object CreateInstance()
        {
            UnityEngine.Debug.Log("Factory Name: " + this.m_Name);
            return new HeirMockClass();
        }
    }

    public class MockClassString 
    {
        public string m_String;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public MockClassString()
        {
            m_String = null;
        }

        public string GetSring() 
        {
            return m_String;
        }
    }

    public class OriginalMethod
    {
        public string stringValue;
        public int number;

        public OriginalMethod()
            : this(null, 0)
        { }

        public OriginalMethod(string name)
        {
            this.stringValue = name;
        }

        public OriginalMethod(string name, int number)
        {
            this.stringValue = name;
            this.number = number;
        }

        public int MethodWithoutArguments()
        {
            UnityEngine.Debug.Log(
                "ORIGINAL METHOD WITHOUT  ARGUMETN: " + this.GetType().Name
                );
            return 555;
        }

        public int GetNumber(int number)
        {
            UnityEngine.Debug.Log(
            "ORIGINAL METHOD (GetNumber): " + this.GetType().Name + "\t" +
            "ARGUMENT INT VALUE: " + number
            );
            return number;
        }

        public float GetNumber(float number)
        {
            UnityEngine.Debug.Log(
            "ORIGINAL METHOD (GetNumber): " + this.GetType().Name + "\t" +
            "ARGUMENT INT VALUE: " + number
            );
            return number;
        }

        public void Method_1(int number, string name)
        {
            UnityEngine.Debug.Log(
                "ORIGINAL METHOD #1: " + this.GetType().Name + "\t" +
                "ARGS: NAME = " + name + "\t" + "NUMBER = " + number
                );
        }

        public void Method_2(int number, string name)
        {
            UnityEngine.Debug.Log(
                "ORIGINAL METHOD #2: " + this.GetType().Name + "\t" +
                "ARGS: NAME = " + name + "\t" + "NUMBER = " + number
                );
        }

        public class OriginalMethod_1
        {
            private string name;
            private int number;

            public OriginalMethod_1()
                : this(null, 0)
            { }

            public OriginalMethod_1(string name, int number)
            {
                this.name = name;
                this.number = number;
            }

            public int GetNumber(int number)
            {
                UnityEngine.Debug.Log(
                "ORIGINAL METHOD (GetNumber): " + this.GetType().Name + "\t" +
                "ARGUMENT INT VALUE: " + number
                );
                return number;
            }
        }

        public class OriginalMethod_2
        {
            private string name;
            private int number;

            public OriginalMethod_2()
                : this(null, 0)
            { }

            public OriginalMethod_2(string name, int number)
            {
                this.name = name;
                this.number = number;
            }

            public int GetNumber(int number)
            {
                UnityEngine.Debug.Log(
                "ORIGINAL METHOD (GetNumber): " + this.GetType().Name + "\t" +
                "ARGUMENT INT VALUE: " + number
                );
                return number;
            }

            public int GetNumber_SecondMethod(int number)
            {
                UnityEngine.Debug.Log(
                "ORIGINAL METHOD (GetNumber): " + this.GetType().Name + "\t" +
                "ARGUMENT INT VALUE: " + number
                );
                return number;
            }
        }

        public class OriginalMethod_3
        {
            private string name;
            private int number;

            public OriginalMethod_3()
                : this(null, 0)
            { }

            public OriginalMethod_3(string name, int number)
            {
                this.name = name;
                this.number = number;
            }

            public int GetNumber(int number)
            {
                UnityEngine.Debug.Log(
                "ORIGINAL METHOD (GetNumber): " + this.GetType().Name + "\t" +
                "ARGUMENT INT VALUE: " + number
                );
                return number;
            }

            public float GetNumber(float number)
            {
                UnityEngine.Debug.Log(
                "ORIGINAL METHOD (GetNumber): " + this.GetType().Name + "\t" +
                "ARGUMENT INT VALUE: " + number
                );
                return number;
            }
        }

        public class Resolver_1 : IResolver
        {
            public void Inject(object instance)
            {
                throw new NotImplementedException();
            }

            public void Inject(object instance, IDictionary<Type, object> scopedInstances)
            {
                throw new NotImplementedException();
            }

            public void Inject(Type instanceType, object instance, IDictionary<Type, object> scopedInstances)
            {
                throw new NotImplementedException();
            }

            public void Inject(IBindingData bindingData, object instance, IDictionary<Type, object> scopedInstances)
            {
                throw new NotImplementedException();
            }

            public T Resolve<T>(IDictionary<Type, object> scopedInstances)
            {
                throw new NotImplementedException();
            }

            public object Resolve(Type type, IDictionary<Type, object> scopedInstances)
            {
                throw new NotImplementedException();
            }

            public object[] Resolve(object[] objects, Type[] types, IDictionary<Type, object> scopedInstances)
            {
                throw new NotImplementedException();
            }
        }

        public class Resolver_2 : IResolver
        {
            public void Inject(object instance)
            {
                throw new NotImplementedException();
            }

            public void Inject(object instance, IDictionary<Type, object> scopedInstances)
            {
                throw new NotImplementedException();
            }

            public void Inject(Type instanceType, object instance, IDictionary<Type, object> scopedInstances)
            {
                throw new NotImplementedException();
            }

            public void Inject(IBindingData bindingData, object instance, IDictionary<Type, object> scopedInstances)
            {
                throw new NotImplementedException();
            }

            public T Resolve<T>(IDictionary<Type, object> scopedInstances)
            {
                throw new NotImplementedException();
            }

            public object Resolve(Type type, IDictionary<Type, object> scopedInstances)
            {
                throw new NotImplementedException();
            }

            public object[] Resolve(object[] objects, Type[] types, IDictionary<Type, object> scopedInstances)
            {
                throw new NotImplementedException();
            }
        }

        public class Resolver_3 : IResolver
        {
            public void Inject(object instance)
            {
                throw new NotImplementedException();
            }

            public void Inject(object instance, IDictionary<Type, object> scopedInstances)
            {
                throw new NotImplementedException();
            }

            public void Inject(Type instanceType, object instance, IDictionary<Type, object> scopedInstances)
            {
                throw new NotImplementedException();
            }

            public void Inject(IBindingData bindingData, object instance, IDictionary<Type, object> scopedInstances)
            {
                throw new NotImplementedException();
            }

            public T Resolve<T>(IDictionary<Type, object> scopedInstances)
            {
                throw new NotImplementedException();
            }

            public object Resolve(Type type, IDictionary<Type, object> scopedInstances)
            {
                throw new NotImplementedException();
            }

            public object[] Resolve(object[] objects, Type[] types, IDictionary<Type, object> scopedInstances)
            {
                throw new NotImplementedException();
            }
        }

        public interface IRotate
        {
            void DoRotate(float x, float y, float z);
        }

        public class Rotate : IRotate
        {
            private Cube m_Cube;

            [MethodImpl(MethodImplOptions.NoInlining)]
            public Rotate()
            {
                m_Cube = null;
            }

            public void DoRotate(float x, float y, float z)
            {
                m_Cube.CheckValue = x + y + z;
            }
        }

        public class Cube
        {
            public float CheckValue;
            private IRotate m_RotateSystem;

            //[MethodImpl(MethodImplOptions.NoInlining)]
            //public Cube()
            //{ }

            public void Update()
            {
                m_RotateSystem.DoRotate(1.0f, 0.25f, 0.5f);
            }
        }
    }
}
