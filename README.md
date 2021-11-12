<img src="https://github.com/imaxs/EasyJection/blob/main/Documentation/Images/logo.svg?sanitize=true" align="left"/>
<br/>
<h4>EasyJection is an easy-to-use Dependency Injection Framework</h4>

![GitHub](https://img.shields.io/github/license/imaxs/EasyJection?style=flat-square)
![GitHub issues](https://img.shields.io/github/issues/imaxs/EasyJection?style=flat-square)
![GitHub last commit (branch)](https://img.shields.io/github/last-commit/imaxs/EasyJection/main?style=flat-square)

## 🗂 Contents ##

<details>

  * [Introduction](#-introduction)
    * [What is this?](#what-is-this)
    * [Why use this?](#why-use-this)
    * [Why use it with Unity?](#why-use-it-with-unity)
  * [Key Features and Concepts](#-key-features-and-concepts)
  * [Motivation](#-motivation)
  * [Installation](#-installation)
  * [Examples](#-examples)
  * [Change Log](#-change-log)
  * [Contributing](#-contributing)
  * [License](#-license)
 
</details>

## 📝 Introduction ##
#### What is this? ####
EasyJection is an easy-to-use Dependency Injection (DI) Framework for *C#(.Net)* and *Unity* projects.<br/>
The framework implements dependency injection **without** using attributes. Such an implementation avoids tying your project code with the code of the framework itself and you can start using the framework without manipulating any part of your project code.
> *Since when the attributes (as well as the namespace) are used in your project's class code, that class, at least indirectly, begins to know about where it gets its dependency from.*

This project is open source.

#### Why use this? ####
If you're familiar with dependency injection and see how EasyJection could help your project, check out the [installation](#installation) and [key features](#key-features-and-concepts) to see more. If not, read on:

Dependency Injection (DI) is an intimidating word for a simple concept you're likely familiar with. Dependency Injection in simple words, is a software design concept that allows a service to be injected in a way that is completely independent of any client consumption. Dependency Injection separates the creation of a client's dependencies from the client's behavior, which allows program designs to be loosely coupled. A DI container, in pair with a good architecture, can ensure [SOLID](https://en.wikipedia.org/wiki/SOLID) principles and help you write better code.

In its simpler form it usually looks like this:
<p><img src="https://github.com/imaxs/EasyJection/blob/main/Documentation/Images/di_scheme.png" width="75%"/></p>
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
      * Method injection *(through Awake() and Start(), or other custom methods)*
      * Field injection
      * Property injection
  * Can inject on non public members.
  * Convention based binding *(based on type name, namespace, etc.)*
  * Conditional binding *(eg. by name, by signature, etc.)*
  * Can inject type instances that are not bound to the container.
  * Context Aware Injection Support *(dependencies can be automatically injected using the components contained in the child and parents)*

## 💡 Motivation ##

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

## 🎲 Examples ##
### DI / IoC container ###

DI container (a.k.a IoC Container) is a key feature of the dependency injection implementation. The container creates an object of the specified type and then automatically injects all the dependency objects through a constructor, property, field or method at runtime. This is done automatically by the DI (IoC) container so that you don’t have to create and manage these dependency objects manually.

```csharp
using EasyJection;
...
// Create the DI/IoC container
Container container = new Container();
```

### Bindings ###
This works the same for both reference *(class)* and value *(struct)* types.
```csharp
// Binding some interface to its class implementation
container.Binder.Bind<ISomeInterface>().To<SomeClass>();
```
```csharp
// Binding some interface to its struct implementation
container.Binder.Bind<IStructInterface>().To<SomeStruct>();
```

#### Available Bindings ####

##### To Implementation Type ####
```csharp
// A new instance is created each time a dependency needs to be resolved
container.Binder.Bind<ISomeInterface>().To<SomeClass>();
```
##### To Single #####
```csharp
// A single instance of the implementation type is created
container.Binder.Bind<ISomeInterface>().To<SomeClass>().AsSingle();
```
##### To Self #####
```csharp
// Binding the type to the transient of itself
container.Binder.Bind<SomeClass>().ToSelf();
```
#### Conditions ####
If you don’t provide a constructor for your class, a new instance is created using the default constructor `new()`, C# creates one and sets member variables to the default values. `Note that a value type (C# struct ) can't have a constructor with no parameters.` Otherwise you can specify a constructor to use to instantiate your type, this is possible in several ways:
##### Passing values to a constructor #####
```csharp
// A ValueType constructor with 3 arguments (parameters). The maximum number of parameters is 9.
// Instances will be created with the specified argument values
container.Binder.Bind<Vector3>().ToSelf().ConstructionMethod().WithArguments<int, int, int>(4, 2, 3);
// or
container.Binder.Bind<ISomeInterface>().To<SomeClass>().ConstructionMethod().WithArguments(new object[]{ "Some Text", 2021 });
```
You can pass NULL as a constructor parameter if the specific parameter is a reference type or interface. The injection will be done into constructor parameters and NULL will be changed to a value of the specific implementation contained in the container.
```csharp
// A ValueType constructor with 3 arguments (parameters). The maximum number of parameters is 9.
// Instances will be created with the specified argument values
// The injection will be done into constructor parameters
container.Binder.Bind<ISomeInterface>().To<SomeClass>()
                .ConstructionMethod().WithArguments<IArgumentInterface, string, int>(null, "Some Text", 2021);
```
##### Without passing values to a constructor #####
A function/method signature include parameters and their types.
```csharp
// Constructor with 1 argument (parameter). The maximum number of parameters is 9
// The injection will be done into constructor parameters
container.Binder.Bind<ISomeInterface>().To<SomeClass>().ConstructionMethod().Signature<Vector2>();
```
By the name of the method that is used as the constructor. The injection will be done into an instance when this method is called. With the way Unity works, you're supposed to use *Awake()* and *Start()* to handle initialization behavior.
```csharp
// A Method named "Awake"
container.Binder.Bind<MonoBehaviourGameObject>().ToSelf().ConstructionMethod("Awake");
```
### Injection ###
#### Injection directly ####
```csharp
// An instance of a type that requires dependency injection
AppClass app = new AppClass();
// Injection
container.Inject(app);
....
public class AppClass
{
    // Property injection occurs immediately after the constructor method is called
    private ISomeInterface m_someDependence;
    ...
}
```
#### Injection via hook  ####
```csharp
// Adding a constructor by name to the binding
container.Binder.Bind<AppClass>().ToSelf().ConstructionMethod("Awake");
// An instance of a type that requires dependency injection
AppClass app = new AppClass();
// Calling the method
app.Awake();
....
public class AppClass
{
    // Property injection occurs immediately after the method named "Awake" is called
    private ISomeInterface m_someDependence;
    // Almost like in MonoBehaviour ;)
    private void Awake()
    {
     ...
    }
}
```

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
