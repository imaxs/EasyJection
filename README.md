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
    * Standard C# objects *(a.k.a. [POCO](https://ru.wikipedia.org/wiki/Plain_old_CLR_object))*
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

## 🎲 Examples ##

## 💾 Change Log ##

All notable changes to this project will be documented in [CHANGELOG](#change-log) file. <br/>
The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/) and this project adheres to [Semantic Versioning](https://semver.org/).

## 👽 Contributing ##

Found a bug or fixed it already? <br/>
You are welcome to create an issue on the project's [GitHub page](https://github.com/imaxs/EasyJection/issues) or submit a pull request.

Here's how we suggest you make changes to this project:

 - [Fork](https://help.github.com/articles/fork-a-repo/) this project to your account.
 - [Create a branch](https://help.github.com/articles/creating-and-deleting-branches-within-your-repository) for the change you intend to make.
 - Make your changes to your fork.
 - Send a [pull request](https://help.github.com/articles/using-pull-requests/) from your fork’s branch to our `develop` branch.

## 📄 License ##

Licensed under the [Apache-2.0 License](https://www.apache.org/licenses/LICENSE-2.0). Please see [LICENSE](./LICENSE) for more information.
