<img src="https://github.com/imaxs/EasyJection/blob/main/Documentation/Images/logo.svg?sanitize=true" align="left"/>
<br/>
<h4>EasyJection is an easy-to-use Dependency Injection Framework</h4>

![GitHub](https://img.shields.io/github/license/imaxs/EasyJection)
![GitHub issues](https://img.shields.io/github/issues/imaxs/EasyJection)
![GitHub last commit (branch)](https://img.shields.io/github/last-commit/imaxs/EasyJection/main)

✅ | <b>➡️ Without using any attributes for injection</b>
:---: | :---
✅ | <b>Quick and easy setup to get started</b>
✅ | <b>There is no need to add a Using directive to each project file that uses DI</b>
✅ | <b>Allows for much more flexible, reusable, and encapsulated code to be written</b>

## 🗂 Contents ##

  * [Introduction](#-introduction)
    * [What is it?](#what-is-it)
    * [Why use it?](#why-use-it)
    * [Why use it with Unity?](#why-use-it-with-unity)
  * [Key Features and Concepts](#-key-features-and-concepts)
  * [Motivation](#-motivation)
  * [Installation](#-installation)
  * [Usage](#-usage)
     * [General notes](#general-notes)
     * [DI / IoC container](#di--ioc-container)
     * [Bindings](#bindings)
       * [Available Bindings](#available-bindings)
         * [To Implementation](#-to-implementation)
         * [To Singleton](#-to-singleton)
         * [To Factory](#-to-factory)
         * [To Instance](#-to-instance)
         * [To Self](#-to-self)
     * [Injection Conditions](#injection-conditions)
         * [Constructor Injection](#-constructor-injection)
         * [Method Injection](#-method-injection)
           * [Non-return Method (MethodVoid)](#non-return-method-methodvoid)
           * [Method with result (MethodResult)](#method-with-result-methodresult) 
         * [Injection Notes](#injection-notes)
  * [Change Log](#-change-log)
  * [Contributing](#-contributing)
  * [License](#-license)

## 📝 Introduction ##
#### What is it? ####
EasyJection is an easy-to-use Dependency Injection (DI) Framework for *C#(.Net)* and *Unity* projects.<br/>
The framework implements dependency injection **without** using attributes. Such an implementation avoids tying your project code to the framework. Write your code without direct dependencies on the framework itself. You will not have to include framework's namespaces everywhere 
> *Since when the attributes (as well as the namespace) are used in your project's class, that class, at least indirectly, begins to know about where it gets its dependency from.*

This project is open source.

#### Why use it? ####
If you're familiar with dependency injection and see how EasyJection could help your project, check out the [installation](#installation) and [key features](#key-features-and-concepts) to see more. If not, read on:

Dependency Injection (DI) is an intimidating word for a simple concept you're likely familiar with. Dependency Injection in simple words, is a software design concept that allows a service to be injected in a way that is completely independent of any client consumption. Dependency Injection separates the creation of a client's dependencies from the client's behavior, which allows program designs to be loosely coupled. A DI container, in pair with a good architecture, can ensure [SOLID](https://en.wikipedia.org/wiki/SOLID) principles and help you write better code.

In its simpler form it usually looks like this:
<p><img src="./Documentation/Images/Dependency_Injection.jpeg" width="75%"/></p>
More details can be found here: https://en.wikipedia.org/wiki/Dependency_injection

#### Why use it with Unity? ####
Unfortunately the Unity game engine isn't very SOLID-friendly out of the box. Even the official documentation and examples for it may give a wrong idea on how to write a code correctly. By using a DI container along with Unity, it's possible to write code that is more reusable, extensible and less oriented to use the [base class](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html) from which every Unity script derives.

## 🪆 Key Features and Concepts ##

  * Injection Mechanisms
    * Standard C# objects *(a.k.a. [POCO](https://en.wikipedia.org/wiki/Plain_old_CLR_object))*
      * Constructor injection
      * Method injection
      * Field injection
      * Property injection
    * Inherited from MonoBehaviour
      * Constructor injection *(as the Unity documentation says, you shouldn't implement and call constructors for MonoBehaviours. Unity automatically invokes the constructor.)*
      * Method injection *(through Awake() and Start(), or other custom methods)*
      * Field injection
      * Property injection
  * Replacing the original parameters of the method/constructor.
  * Can inject on non public members.
  * Convention based binding.
  * Conditional binding *(eg. by method name, by signature, etc.)*
  * Context Aware Injection Support *(dependencies can be automatically injected using the components contained in the child and parents)*

## 💡 Motivation ##
Allow references to high-level objects (typically managers or services) at a single entry point without using singletons or spaghetti serialization, or endless constructor parameters.

Usually, when developing a project in Unity, it's often necessary for one system of the game object to reference another. For example, a game object needs a reference to a movement component. 

⬇️ It might look like below:

```csharp
// Cube.cs
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField]
    // The dependency that provides an implementation of the rotating system.
    private IRotate m_RotateSystem;
    
    private void Update()
    {
        m_RotateSystem.DoRotate(0, 0.25f, 0);
    }
}
```
*➡️ This approach has some problems:*
- ❌ The need to always assign fields in the inspector.
- ❌ Unity doesn't support displaying C# interfaces in the Inspector (Interfaces are not serializable).

⬇️ There is an attempt at a solution:
<table><tr><td><details>
 <summary>📃 Cube.cs</summary>
 
```csharp
// Cube.cs
using UnityEngine;

public class Cube : MonoBehaviour
{
    // The dependency that provides an implementation of the rotating system.
    private IRotate m_RotateSystem;
    
    private void Awake()
    {
        ////////////////////////////////////////////////
        // Below are 3 ways to resolve the dependency.
        ////////////////////////////////////////////////
        
        /* Just create a new instance (if a class doesn't inherit from MonoBehaviour)
           and pass the 'Cube' class instance through the constructor: */
        m_RotateSystem = new Rotate(this); // #1
        
        /* otherwise find a component like this: */
        m_RotateSystem = GetComponentInParent<Rotate>(); // #2
        
        // or
        m_RotateSystem = FindObjectOfType<Rotate>(); // #3
    }
    
    private void Update()
    {
        m_RotateSystem.DoRotate(0, 0.25f, 0);
    }
}
```
</details></td></tr></table>

*➡️ Each of these ways is a workable solution, but they all have same disadvantages:*
- ❌ When a class holds its dependencies and tries to manage them itself without any interference from others, it's an anti-pattern named *Control Freak*.
- ❌ The need to manually write in the source code of each component. 
- ❌ Extending and maintaining the classes in your project will take a lot more effort.

⬇️ We can try to solve the disadvantages described above by using any other popular IOC / DI framework for the Unity game engine:
<table><tr><td><details>
 <summary>📃 Cube.cs</summary>
 
```csharp
// Cube.cs
using UnityEngine;
using AnyOtherDIFramework; // adds the namespace of the framework to the source code of our project

public class Cube : MonoBehaviour
{
    // The dependency that provides an implementation of the rotating system.
    [Inject]
    private IRotate m_RotateSystem;
    
    private void Update()
    {
        m_RotateSystem.DoRotate(0, 0.25f, 0);
    }
}
```
</details></td></tr></table>

*➡️ It's almost perfect, but there are some snags:*
- ❌ The need to add the Using directive to each source code file of our project (`using AnyOtherDIFramework;` in this case).
- ❌ The need to manually write attributes in the source code of each component.
- ❌ As in the previous solution, extending and maintaining the classes in your project will take a lot more effort.
- ❌ The *Cube* class indirectly begins to know where it gets its dependency from.

**✅ EasyJection was created precisely to eliminate all this!**

ℹ️ In order to start using this framework, you <ins>don't</ins> need to add `using EasyJection;` to each source code file, and also <ins>don't</ins> need to specify any attributes.

<table>
<tr><td>The source files of project are neat and don't contain dependencies on third-party frameworks. (<b>without</b> `using EasyJection;` etc.)</td></tr>
<tr><td>
<details>
 <summary>📃 Cube.cs</summary>
 
 ```csharp
// Cube.cs
using UnityEngine;

// Note: Dependency injection occurs when a method or constructor is called,
// it depends on what you specify.
public class Cube : MonoBehaviour
{
    private IRotate m_RotateSystem;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    // For injection via the constructor
    public Cube()
    {
        UnityEngine.Debug.Log("Constructor");
    }
    
    // For injection via 'Awake' method
    private void Awake()
    {
        UnityEngine.Debug.Log("Awake");
    }

    private void Update()
    {
        m_RotateSystem.DoRotate(0, 0.25f, 0);
    }
}
```
</details>
</td></tr>
<tr><td>
<details>
 <summary>📃 IRotate.cs</summary>
 
 ```csharp
// IRotate.cs
using UnityEngine;

public interface IRotate
{
    void DoRotate(float x, float y, float z);
}
```
</details>
</td></tr>
<tr><td>
<details>
 <summary>📃 Rotate.cs</summary>
 
 ```csharp
// Rotate.cs
using UnityEngine;

public class Rotate : IRotate
{
    private Cube m_Cube;

    public void DoRotate(float x, float y, float z)
    {
        m_Cube.transform.Rotate(x, y, z);
    }
}
```
</details>
</td></tr>
</table>

<table>
<tr><td>Source code <b>with</b> <code>using EasyJection;</code> directive.</td></tr>
<tr><td>
<details>
 <summary>📃 EntryPoint.cs</summary>
 
 ```csharp
// EntryPoint.cs
using UnityEngine;
using EasyJection;

/*
  This is the entry point of the application, where EasyJection sets up 
  all the various dependencies before starting your game scene.
*/
public class EntryPoint
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    /* The Unity documentation mention that the order might be undefined 
       depending on platform, not sure what that means for actual usage.
 
       Methods with RuntimeInitializeLoadType.AfterSceneLoad, or RuntimeInitializeLoadType.BeforeSceneLoad 
       will only be called for the first scene in a run of the application, not every scene. */
    static void OnBeforeSceneLoadRuntimeMethod()
    {
        var container = new Container();
        container.Bind<IRotate>().To<Rotate>();
        
        ////////////////////////////////////////////////
        // Below are 2 injection ways (use only one of them)
        ////////////////////////////////////////////////
        
        // #1 when the constructor is called. 
        container.Bind<Cube>().ToSelf(UseDefaultConstructor: true);
        
        // #2 or when the 'Awake' method is called.
        // This way is recommended for objects inherited from MonoBehaviour
         container.Bind<Cube>().ToSelf().InjectionTo().MethodVoid("Awake");
 
        /* Note: You can also create a container and set bindings in a class inherited
                 from MonoBehaviour and then add the script to the current active scene.
                 This script needs to be called first. Verify the script execution order
                 in Unity by accessing the menu: Edit->Project Settings->Script Execution Order 
                 and add the script to execute before all other scripts. Enter a large 
                 negative number to have this script before all the others on the list. */
    }
}
``` 
</details>
</td></tr>
</table>

<details>
 <summary>Attaching the script to the game object</summary>
 <img src="https://github.com/imaxs/EasyJection/blob/develop/Documentation/Images/Inspector.png?sanitize=true)"/>
</details>
 
<details>
 <summary>Result</summary>
 <img src="https://github.com/imaxs/EasyJection/blob/develop/Documentation/Images/result.gif?sanitize=true)"/>
</details>

As you can see, the framework does all the work of resolving the dependencies.

So now the injection will also work fine every time you create a gameobject, something like this:
```csharp
 GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
 cube.AddComponent<Cube>()
```

> ⚠️ Attention: Attempting to get any MonoBehaviour component inside a constructor of class 'Rotate' will throw an exception, since the injection is done via a constructor of an object inherited from MonoBehaviour.

<details>
 <summary>The code below throws an UnityException</summary>
 
```csharp
public class Rotate : IRotate
{
    private Cube m_Cube;
    private Transform m_Transform;
 
    public Rotate(Cube cube)
    {
       m_Cube = cube;
       m_Transform = cube.transform; // <-- UnityException: get_transform is not allowed to be called from a MonoBehaviour constructor (or instance field initializer), call it in Awake or Start instead. Called from MonoBehaviour 'Cube'.
    }

    public void DoRotate(float x, float y, float z)
    {
        m_Cube.transform.Rotate(x, y, z);
    }
}
```
</details>
                                            
## 🛠 Installation ##

### You can install EasyJection using any of the below options: ###
#### 🔘 Adding a line to Packages/manifest.json ####
You can use the path query parameter in the Git URL to notify the Package Manager where to find the package.
```
{
  "dependencies": {
    "com.imaxs.easyjection": "https://github.com/imaxs/EasyJection.git?path=/UnityPackage"
  }
}
```
#### 🔘 Install via UPM *(Requires Unity 2019+)* ####
`Window` ⇨ `Package Manager` ⇨ `+ sign` ⇨ `Add package from git URL`: <br/>*`https://github.com/imaxs/EasyJection.git?path=/UnityPackage`*

#### 🔘 Install manually ####
- Download the .unitypackage from [releases page](https://github.com/imaxs/EasyJection/releases)
- Import EasyJection.X.X.X.unitypackage

## 🎲 Usage ##
### General notes ###

 - A dependency will be resolved for a field, property, and parameter if its value is NULL.
 - If an instance is not found, it will be resolved to NULL.
 
### DI / IoC container ###

DI container (a.k.a IoC Container) is a key feature of the dependency injection implementation. The container creates an object of the specified type and then automatically injects all the dependency objects through a constructor, property, field or method at runtime. This is done automatically by the DI (IoC) container so that you don’t have to create and manage these dependency objects manually.
```csharp
using EasyJection;
...
// Create the container
Container container = new Container();
```

### Bindings ###
The created container should then 'know' how to create all the object instances in your application, by recursively resolving all dependencies for a given object. Therefore, you need to create bindings. Binding is the action of linking a type to another type or instance. EasyJection makes it simple by providing different ways to create them. Each binding must be performed to a specific key type by calling the `Bind()` method. For example, given the following class:
 
 ```csharp
 // The class implements an interface
public SomeClass : ISomeInterface
{
    // ... some code implementing the interface
}

// The class that requires a dependency
public class Foo
{
    private ISomeInterface instance;

    public Foo(ISomeInterface instance)
    {
        this.instance = instance;
    }
}
```
You can bind dependencies using the following:
 
```csharp
// Binding some interface to its class implementation
container.Bind<ISomeInterface>().To<SomeClass>();
container.Bind<Foo>().ToSelf(UseDefaultConstructor: true);
```
This is a simple way to bind some interface to its class implementation. This means that any class that requires the `ISomeInterface` interface (like Foo) will be given the same instance of type `SomeClass`.
 
Below is the full binding format:

```csharp
  // Binding an interface to an implementation type
  container.Bind<KeyInterfaceType>()
           .To<ImplementationType>()
           .InjectionTo()
           .MethodVoid<T1...T9>(methodName).WithArguments<T1...T9>(T1 arg1, ...T9 arg9)
           .MethodResult<T1...T9, TResult>(methodName).WithArguments<T1..T9>(T1 arg1, ...T9 arg9)
           .Constructor<T1...T9>(UseForInstantiation: True | False).WithArguments<T1...T9>(T1 arg1, ...T9 arg9);
```
Where:

 - *KeyInterfaceType* — The type of binding for.
 - *ImplementationType* — The type to be bound to.
 - `InjectionTo()` — allows you to set the injection conditions.
 - `MethodVoid<T1...T9>(methodName)` — field, property and parameters injection occurs immediately when the non-return method corresponding to the specified method signature is called.
    - *<T1...T9>* — types of parameters of a non-return method. Maximum of 9 parameters, where T1...T9 their types.
    - *methodName* — the name of a non-return method.
 - `MethodResult<T1...T9, TResult>(methodName)` — field, property and parameters injection occurs immediately when the method corresponding to the specified method signature is called.
     - *<T1...T9, TResult>* — types of method parameters. A maximum of 9 parameters, where T1...T9 their types and the return value is the type specified by the TResult.
     - *methodName* — the name of a method.
 - `Constructor<T1...T9>(UseForInstantiation: True | False)` — field, property and parameters injection occurs immediately when the constructor corresponding to the specified signature is called.
     - *<T1...T9>* — types of parameters of a constructor.
     - *UseForInstantiation* — if True, the container will use this constructor to create an instance, otherwise it will use the default constructor.
 - `WithArguments<T1...T9>(T1 arg1, ...T9 arg9)` — arguments used to pass to the called method or constructor.
     - *<T1...T9>* — types of arguments passed. 
        - ⚠️ Attention:
           - _The types must fully match the signature of a method or constructor._
           - _The original arguments passed to the called method will be replaced with the specified arguments from the binding._
 
 What is a method signature?
 
 Section 3.6 of the C# Language Specification (version 4.0) contains the following:
> The signature of a method consists of the name of the method, the number of type parameters and the type and kind (value, reference, or output) of each of its formal parameters, considered in the order left to right. For these purposes, any type parameter of the method that occurs in the type of a formal parameter is identified not by its name, but by its ordinal position in the type argument list of the method. The signature of a method specifically does not include the return type, the params modifier that may be specified for the right-most parameter, nor the optional type parameter constraints.

The method declaration consists of the following:

 <img src="./Documentation/Images/method.png" width="60%"/>
 
 - **Modifier** — It defines access type of the method i.e. from where it can be accessed in your application. In C# there are Public, Protected, Private access modifiers. 
 - **Name of the Method** — It describes the name of the user defined method by which the user calls it or refer it. Eg. GetName()
 - **Return type** — It defines the data type returned by the method. It depends upon user as it may also return void value i.e return nothing
 - **Body of the Method** — It refers to the line of code of tasks to be performed by the method during its execution. It is enclosed between braces.
 - **Parameter list** — Comma separated list of the input parameters are defined, preceded with their data type, within the enclosed parenthesis. If there are no parameters, then empty parentheses () have to use out.

Let's look at all the available bindings provided by EasyJection.
 
#### Available Bindings ####
There is three types of available bindings:
 
- **Transient**  —  a new instance is created each time a dependency needs to be resolved.
- **Singleton**  —  one instance is created and used for any dependencies.
- **Factory**  — creates the instance and returns it.
 
#### 🔘 To Implementation ####
```csharp
// A new instance is created each time a dependency needs to be resolved
container.Binder.Bind<ISomeInterface>().To<SomeClass>();
```

#### 🔘 To Singleton ####
Binds the key type to a singleton instance of the implementation type. The key must be a class.
```csharp
container.Bind<ISomeInterface>()
         .ToSingleton<SomeClass>(UseDefaultConstructor: True | False);
```
or bind the type as a singleton to itself.  
```csharp
// The key type must be a class!
container.Bind<SomeClass>()
         .ToSingleton(UseDefaultConstructor: True | False);
```
Where:
 - *UseDefaultConstructor* — If True, the injection occurs each time the default constructor is called (from `new()`).
 
#### 🔘 To Factory ####
When you need to handle object instantiation manually, you can create a factory class by inheriting it from `EasyJection.Types.IFactory` interface.
```csharp
public class MyFactory : EasyJection.Types.IFactory {
     /// <summary>
     /// Creates an instance of an object of the type created by the factory.
     /// </summary>
     /// <param name="bindingData">Instance implementing the IBindingData interface</param>
     /// <returns>The instance.</returns>
     public object CreateInstance(IBindingData bindingData = null) {
        //Instantiate and return the object.
        var myObject = new SomeClass();
        return myObject;
     }
}
```
There are two ways to bind the factory.
```csharp
// #1 The container creates the factory itself.
container.Bind<ISomeInterface>()
         .ToFactory<MyFactory>(UseDefaultConstructor: True | False);
 
// #2 or bind it to an existing factory instance.
container.Bind<ISomeInterface>()
         .ToFactory<MyFactory>(factoryInstance);
```
Where:
 - *UseDefaultConstructor* — If True, the injection occurs each time the default constructor is called (from `new()`).
 
#### 🔘 To Instance ####
You can also bind the key type to an existing instance.
```csharp
container.Bind<ISomeInterface>()
         .ToInstance<SomeClass>(someClassInstance);
``` 
 
#### 🔘 To Self ####
```csharp
// Binds the key type to a transient of itself. The key must be a class.
container.Bind<SomeClass>().ToSelf(UseDefaultConstructor: True | False);
```
 Where:
 - *UseDefaultConstructor* — If True, the injection occurs each time the default constructor is called (from `new()`).
 
### Injection Conditions ###
EasyJection provides injection through a constructor or method call. Constructor injection forces the dependency to only be resolved once, at instance creation, which is usually what you want. Inject methods are the recommended approach for MonoBehaviours (e.g. 'Awake' and 'Start' methods). Injection conditions are set by calling the `InjectionTo()` method. In order to specify a constructor or method for injection, you need to specify its signature.

EasyJection will also always try to resolve any dependencies for constructor or method parameters it might need, using information from its bindings, or trying to instantiate any types that are unknown to the binder. EasyJection allows you to replace the original values of method or constructor arguments with values from the binding
 
> Note: If you don’t provide a constructor for your class, a new instance is created using the default constructor `new()`, C# creates one and sets member variables to the default values. But if you decide to create an instance by calling `new()` (with or without arguments) recommended to provide a constructor with `[MethodImpl(MethodImplOptions.NoInlining)]` attribute.
 
Let's get acquainted with the available injection conditions.
 
#### 🔘 Constructor Injection ####
Injection occurs each time the specified constructor is called.
 
Parameter-less constructor:
```csharp
container.Bind<SomeClass>()
         .ToSelf()
         .InjectionTo()
         .Constructor(UseForInstantiation: True | False);
```
Constructor with parameters:
```csharp
container.Bind<SomeClass>()
         .ToSelf()
         .InjectionTo()
         .Constructor<T1, T2 ... T9>(UseForInstantiation: True | False);
```
Constructor with passing argument values:
```csharp
container.Bind<SomeClass>()
         .ToSelf()
         .InjectionTo()
         .Constructor<T1, T2 ... T9>(UseForInstantiation: True | False)
         .WithArguments<T1, T2 ... T9>(T1 arg1, T2 arg2 ... T9 arg9);
```

Where:
  - *UseForInstantiation* — if True, the container will use this constructor to create an instance, otherwise it will use the default constructor.
  - *<T1, T2 ... T9>* — types of constructor parameters.
#### 🔘 Method Injection ####
The Inject-injection method works very similar to constructor injection in terms of specifying parameter types. However, there are nuances. There are two types of methods that return values and non-return (named as void). 

##### Non-return Method (MethodVoid)  #####
To specify the non-return method use the `MethodVoid()`.
 
Parameter-less void method:
```csharp
container.Bind<SomeClass>()
         .ToSelf()
         .InjectionTo()
         .MethodVoid(methodName);
```
with parameters:
```csharp
container.Bind<SomeClass>()
         .ToSelf()
         .InjectionTo()
         .MethodVoid<T1, T2 ... T9>(methodName);
```
with passing argument values:
```csharp
container.Bind<SomeClass>()
         .ToSelf()
         .InjectionTo()
         .MethodVoid<T1, T2 ... T9>(methodName);
         .WithArguments<T1, T2 ... T9>(T1 arg1, T2 arg2 ... T9 arg9);
```
  - *methodName* — the name of a non-return method
  - *<T1, T2 ... T9>* — types of constructor parameters.
##### Method with result (MethodResult) #####
To specify a method that returns a result, use `MethodResult()`.
 
Parameter-less method:
```csharp
container.Bind<SomeClass>()
         .ToSelf()
         .InjectionTo()
         .MethodResult<TResult>(methodName);
```
with parameters:
```csharp
container.Bind<SomeClass>()
         .ToSelf()
         .InjectionTo()
         .MethodResult<T1, T2 ... T9, TResult>(methodName);
```
with passing argument values:
```csharp
container.Bind<SomeClass>()
         .ToSelf()
         .InjectionTo()
         .MethodResult<T1, T2 ... T9, TResult>(methodName);
         .WithArguments<T1, T2 ... T9>(T1 arg1, T2 arg2 ... T9 arg9);
```
  - *methodName* — the name of a method.
  - *<T1, T2 ... T9>* — types of constructor parameters.
  - *TResult* — type of return value.
#### Injection Notes ####

## 💾 Change Log ##

All notable changes to this project will be documented in files:
 1. This [CHANGELOG](./Framework/CHANGELOG.md) includes the changes in recent updates of the framework.
 2. This [CHANGELOG](./UnityPackage/CHANGELOG.md) only contains changes specific to a package (UnityPackage).

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/) and this project adheres to [Semantic Versioning](https://semver.org/).

## 👽 Contributing ##

Found a bug or fixed it already? <br/>
You are welcome to create an issue on the project's [GitHub page](https://github.com/imaxs/EasyJection/issues) or submit a pull request.

Here's how we suggest you make changes to this project:

 - [Fork](https://help.github.com/articles/fork-a-repo/) this project to your account.
 - [Create a branch](https://help.github.com/articles/creating-and-deleting-branches-within-your-repository) for the change you intend to make.
 - Make your changes to your fork.
 - Send a [pull request](https://help.github.com/articles/using-pull-requests/) from your fork’s branch to our [`develop`](https://github.com/imaxs/EasyJection/tree/develop) branch.

## 📄 License ##

Licensed under the [Apache-2.0 License](https://www.apache.org/licenses/LICENSE-2.0). Please see [LICENSE](./LICENSE) for more information.
