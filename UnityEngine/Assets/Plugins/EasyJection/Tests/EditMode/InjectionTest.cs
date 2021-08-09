namespace EasyJection.Tests.EditMode
{
    using Console = UnityEngine.Debug;

    using System;
    using EasyJection;
    using NUnit.Framework;
    using FluentAssertions;
    using Arrange.InjectionTest;

    using MVC = Arrange.InjectionTest.MVC;
    using MVP = Arrange.InjectionTest.MVP;
    using MVVM = Arrange.InjectionTest.MVVM;

    namespace Arrange.InjectionTest
    {
        using System.Reflection;

        #region IMockBaseInterface/MockBaseClass
        public interface IMockBaseInterface
        {
            string BaseWork();
            int Integer { get; }
            string String { get; }
        }

        public class MockBaseClass : IMockBaseInterface
        {
            private readonly int m_Integer;
            public int Integer { get => m_Integer; }
            private readonly string m_String;
            public string String { get => m_String; }

            public MockBaseClass(IMockArgumentInterface injectedArgument, int argInteger, string argString)
            {
                Console.Log("Constructor: MockBaseClass(injectedArgument:" + injectedArgument.Argument + ", argInteger: " + argInteger + ", argString: " + argString + ")");
                m_Integer = argInteger;
                m_String = argString + injectedArgument.Argument;
            }
            public string BaseWork() => "MockBaseClass: public BaseWork()";
            private string PrivateMethod() => "MockBaseClass: PrivateMethod()";
        }
        #endregion // IMockBaseInterface/MockBaseClass

        #region IMockAbstractInterface/MockAbstractSecondClass
        public interface IMockAbstractInterface
        {
            string AbstractWork();
        }

        public abstract class MockAbstractClass : IMockAbstractInterface
        {
            protected IMockBaseInterface MockBaseClassImpl;
            public MockAbstractClass() => Console.Log("Constructor: MockAbstractClass()");
            public string AbstractWork() => "MockAbstractClass: AbstractWork()";
        }
        #endregion // IMockAbstractInterface/MockAbstractSecondClass

        #region IMockInterface/MockClass
        public interface IMockInterface
        {
            string Test();
        }
        public class MockClass : MockAbstractClass, IMockInterface
        {
            private Vector3 m_Vector3;
            public string Test() => MockBaseClassImpl.BaseWork();
            public int Integer() => MockBaseClassImpl.Integer;
            public string String() => MockBaseClassImpl.String;
            public Vector3 Vector3 { get => m_Vector3; }
        }
        #endregion // IMockInterface/MockClass

        #region IMockArgumentInterface/MockArgumentClass
        public interface IMockArgumentInterface
        {
            string Argument { get; }
        }

        public struct MockArgumentStruct : IMockArgumentInterface
        {
            private IMockInterface m_MockClassInstance;
            private string m_Argument;
            public string Argument { get => m_Argument; }
            public MockArgumentStruct(Vector2 vector)
            {
                Console.Log("Constructor: MockArgumentStruct(Vector2: X = " + vector.X + ", Y = " + vector.Y + ")");
                m_Argument = "_MockArgumentStruct" + vector.X + vector.Y;
                m_MockClassInstance = null;
            }
        }
        #endregion // IMockArgumentInterface/MockArgumentClass

        #region Vector2 / Vector3
        public struct Vector2
        {
            public int X;
            public int Y;

            public Vector2(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        public struct Vector3
        {
            public int X;
            public int Y;
            public int Z;

            public Vector3(int x, int y, int z)
            {
                this.X = x;
                this.Y = y;
                this.Z = z;
            }
        }
        #endregion // Vector2 / Vector3
    }

    //
    //  All MV* patterns have similar goals, however they achieve them in different way.
    //  Below diagram describes the key differences:
    //  https://mytechnetknowhows.files.wordpress.com/2014/09/slide11.png
    //
    namespace Arrange.InjectionTest.MVC
    {
        #region IModel/Model
        public interface IModel
        {
            string GetData();
            void SetNumber(int number);
        }

        public class Model : IModel
        {
            private int m_Number;
            private string m_MockData;

            public Model()
            {
                m_Number = 0;
                m_MockData = "MockData [MVC]: ";
            }

            public void SetNumber(int value) => m_Number += value;
            public string GetData() => m_MockData + m_Number;
        }
        #endregion // IModel/Model

        #region IController/Controller
        public interface IController
        {
            void IncreaseBy100();
            string PrintView();
        }

        public class Controller : IController
        {
            private readonly IModel m_Model;
            private readonly IView m_View;

            public Controller(IModel model, IView view)
            {
                m_Model = model;
                m_View = view;
            }

            public string PrintView()
            {
                return m_View.DisplayData();
            }

            public void IncreaseBy100()
            {
                m_Model.SetNumber(100);
                this.UpdateData();
            }

            private void UpdateData()
            {
                string data = m_Model.GetData();
                m_View.RefreshView(data);
            }
        }
        #endregion // IController/Controller

        #region IView/View
        public interface IView
        {
            void RefreshView(string data);
            string DisplayData();
        }

        public class View : IView
        {
            private string dataPrinted;

            public View()
            {
                dataPrinted = "Initial data";
            }

            public void RefreshView(string data)
            {
                dataPrinted = data;
            }

            public string DisplayData()
            {
                Console.Log("MVC.View: UpdateView(" + dataPrinted + ")");
                return dataPrinted;
            }
        }
        #endregion // IView/View

        #region App
        public class App
        {
            public IController Controller;
        }
        #endregion // App
    }

    namespace Arrange.InjectionTest.MVP
    {
        #region IModel/Model
        public interface IModel
        {
            string GetData();
            void SetNumber(int number);
        }

        public class Model : IModel
        {
            private int m_Number;
            private string m_MockData;

            public Model()
            {
                m_Number = 0;
                m_MockData = "MockData [MVP]: ";
            }

            public void SetNumber(int value) => m_Number += value;
            public string GetData() => m_MockData + m_Number;
        }
        #endregion // IModel/Model

        #region IPresenter/Presenter
        public interface IPresenter
        {
            void IncreaseBy100();
        }

        public class Presenter : IPresenter
        {
            private readonly IModel m_Model;
            private readonly IView m_View;

            public Presenter(IModel model, IView view)
            {
                m_Model = model;
                m_View = view;
            }

            public void IncreaseBy100()
            {
                m_Model.SetNumber(100);
                this.UpdateView();
            }

            private void UpdateView()
            {
                string data = m_Model.GetData();
                m_View.RefreshView(data);
            }
        }
        #endregion // IPresenter/Presenter

        #region IView/View
        public interface IView
        {
            void ClickIncreaseButton();
            void RefreshView(string data);
            string DisplayData();
        }

        public class View : IView
        {
            private IPresenter m_Presenter;
            private string dataPrinted;

            public View() // (!) IPresenter presenter — setting a dependency through a constructor parameter causes a recursive loop resulting stack overflow.
            {
                dataPrinted = "Initial data";
            }

            public void ClickIncreaseButton()
            {
                m_Presenter.IncreaseBy100();
            }

            public void RefreshView(string data)
            {
                dataPrinted = data;
            }

            public string DisplayData()
            {
                return dataPrinted;
            }
        }
        #endregion // IView/View

        #region App
        public class App
        {
            public IView View;
        }
        #endregion // App
    }

    namespace Arrange.InjectionTest.MVVM
    {
        using Architecture;

        #region IModel/Model
        public interface IModel : INotifyPropertyChanged
        {
            string StringData { get; }
            int IntValue { get; }
            void UpdateDate(string data, int number);
        }

        public class Model : PropertyChangedBase, IModel
        {
            private int m_IntValue;
            public int IntValue 
            { 
                get => m_IntValue;
                private set
                {
                    m_IntValue = value;
                    OnPropertyChanged("IntValue");
                }
            }

            private string m_StringData;
            public string StringData 
            { 
                get => m_StringData;
                private set
                {
                    m_StringData = value;
                    OnPropertyChanged("StringData");
                }
            }

            public Model()
            {
                UpdateDate("MockData [MVVM]: ", 2021);
            }
        
            public void UpdateDate(string data, int number)
            {
                IntValue = number;
                StringData = data;
            }
        }
        #endregion // IModel/Model

        #region IViewModel/ViewModel
        public interface IViewModel : INotifyPropertyChanged
        {
            string Data { get; }
            ICommand ClearData { get; }
        }

        public class ViewModel : PropertyChangedBase, IViewModel
        {
            private readonly IModel m_Model;

            public string Data
            {
                get => m_Model.StringData + m_Model.IntValue;
            }

            private void SetStringValue(string value)
            {
                m_Model.UpdateDate(value, m_Model.IntValue);
            }

            private void SetNumberValue(int value)
            {
                m_Model.UpdateDate(m_Model.StringData, value);
            }

            private ICommand m_ClearData;
            public ICommand ClearData
            {
                get => m_ClearData ?? (m_ClearData = new Command(ClearModelData));
            }

            public ViewModel(IModel model)
            {
                m_Model = model;
                m_Model.PropertyChanged += ModelPropertyChanged;
            }

            private void ClearModelData(object parameter)
            {
                string propertyName = parameter as String;
                if (String.CompareOrdinal(propertyName, "String") == 0)
                    SetStringValue("");
                else if (String.CompareOrdinal(propertyName, "Number") == 0)
                    SetNumberValue(0);
            }

            private void ModelPropertyChanged(object sender, IPropertyChangedEventArgs e)
            {
                string propertyName = e.PropertyName;
                if (propertyName != null &&
                    String.CompareOrdinal(propertyName, "StringData") == 0 ||
                    String.CompareOrdinal(propertyName, "IntValue") == 0)
                    this.OnPropertyChanged("Data");
            }
        }
        #endregion // IViewModel/ViewModel

        #region IView/View
        public interface IView
        {
            void RefreshAll();
            string DisplayData();
            void ClearData(string propertyName);
        }

        public class View : IView
        {
            private readonly IViewModel m_ViewModel;

            private string m_StringLine;

            public View(IViewModel viewModel)
            {
                m_StringLine = "Initial data";
                m_ViewModel = viewModel;
                m_ViewModel.PropertyChanged += VMPropertyChanged;
            }

            public void RefreshAll() => m_StringLine = m_ViewModel.Data;
            public void ClearData(string propertyName) => m_ViewModel.ClearData.Execute(propertyName);
            public string DisplayData() => m_StringLine;

            private void VMPropertyChanged(object sender, IPropertyChangedEventArgs e)
            {
                string propertyName = e.PropertyName;
                if (propertyName != null && 
                    String.CompareOrdinal(propertyName, "Data") == 0)
                    RefreshAll();
            }

        }
        #endregion // IView/View

        #region IApp/App
        public interface IApp
        {
            IView View { get; }
            void Awake();
        }

        public class App : IApp
        {
            private IView m_View;
            public IView View { get => m_View; }

            public void Awake()
            {
                Console.Log("App: Awake()");
            }
        }
        #endregion // App
    }

    [TestFixture]
    public class InjectionTest
    {
        [Test]
        public void Inject_MVVM()
        {
            // Container
            Container container = new Container();

            container.Binder.Bind<MVVM.IView>().To<MVVM.View>()
                .ConstructionMethod().Signature<MVVM.IViewModel>();
            container.Binder.Bind<MVVM.IViewModel>().To<MVVM.ViewModel>()
                .ConstructionMethod().Signature<MVVM.IModel>();
            container.Binder.Bind<MVVM.IModel>().To<MVVM.Model>();
            container.Binder.Bind<MVVM.App>().ToSelf().ConstructionMethod("Awake");

            // App
            MVVM.IApp app = new MVVM.App();
            app.Awake();

            app.View.DisplayData().Should().Be("Initial data");

            app.View.RefreshAll();
            app.View.DisplayData().Should().Be("MockData [MVVM]: 2021");

            app.View.ClearData("Number");
            app.View.DisplayData().Should().Be("MockData [MVVM]: 0");

            app.View.ClearData("String");
            app.View.DisplayData().Should().Be("0");
        }

        [Test]
        public void Inject_MVP()
        {
            Container container = new Container();

            container.Binder.Bind<MVP.IPresenter>().To<MVP.Presenter>()
                .ConstructionMethod().Signature<MVP.IModel, MVP.IView>();

            container.Binder.Bind<MVP.IModel>().To<MVP.Model>();
            container.Binder.Bind<MVP.IView>().To<MVP.View>();

            MVP.App app = new MVP.App();
            container.Inject(app);

            app.View.DisplayData().Should().Be("Initial data");

            app.View.ClickIncreaseButton();
            app.View.DisplayData().Should().Be("MockData [MVP]: 100");

            app.View.ClickIncreaseButton();
            app.View.DisplayData().Should().Be("MockData [MVP]: 200");
        }

        [Test]
        public void Inject_MVC()
        {
            Container container = new Container();

            container.Binder.Bind<MVC.IController>().To<MVC.Controller>()
                .ConstructionMethod().Signature<MVC.IModel, MVC.IView>();

            container.Binder.Bind<MVC.IModel>().To<MVC.Model>();
            container.Binder.Bind<MVC.IView>().To<MVC.View>();

            MVC.App app = new MVC.App();
            container.Inject(app);

            app.Controller.PrintView().Should().Be("Initial data");

            app.Controller.IncreaseBy100();
            app.Controller.PrintView().Should().Be("MockData [MVC]: 100");

            app.Controller.IncreaseBy100();
            app.Controller.PrintView().Should().Be("MockData [MVC]: 200");
        }

        [Test]
        public void Inject_ConstructionMethodWithArguments()
        {
            /*  MockClass is a reference type inherited from the abstract class MockAbstractClass.
                MockAbstractClass has an IMockBaseInterface interface protected field. The injection 
                should set the field to the appropriate value according to the binding data. */
            MockClass mockObj = new MockClass();

            Container container = new Container();

            //  Vector3 is a value type with a three-argument constructor.
            //  Adding constructor argument values to the binding.
            container.Binder.Bind<Vector3>().ToSelf()
                .ConstructionMethod().WithArguments<int, int, int>(4, 9, 3);

            //  Vector2 is a value type with a two-argument constructor.
            //  Adding constructor argument values to the binding.
            container.Binder.Bind<Vector2>().ToSelf()
                .ConstructionMethod().WithArguments<int, int>(2, 3);

            //  Binding the IMockArgumentInterface to the MockArgumentStruct value type with an one-argument constructor.
            //  Adding to the binding specifying the signature of the required constructor method.
            //  * This is relevant for an instance of a value type (struct) otherwise an attempt will be made to invoke the default constructor method. *
            //  ** If a constructor method with the specified signature doesn't exist, an exception will be thrown. **
            container.Binder.Bind<IMockArgumentInterface>().To<MockArgumentStruct>()
                .ConstructionMethod().Signature<Vector2>();

            //  Arguments:
            //   1. IMockArgumentInterface -> null    (will be changed to the value from the binding, if it exists) 
            //   2. INT -> 2021                       (will be passed to the constructor unchanged)
            //   3. STRING -> "Test"                  (will be passed to the constructor unchanged)
            container.Binder.Bind<IMockBaseInterface>().To<MockBaseClass>()
                .ConstructionMethod().WithArguments<IMockArgumentInterface, int, string>(null, 2021, "Test");

            // Injection
            container.Inject(mockObj);

            mockObj.Test().Should().Be("MockBaseClass: public BaseWork()");
            mockObj.Integer().Should().Be(2021);
            mockObj.String().Should().Be("Test_MockArgumentStruct23");

            var vector = mockObj.Vector3;
            vector.X.Should().Be(4);
            vector.Y.Should().Be(9);
            vector.Z.Should().Be(3);
        }
    }
}