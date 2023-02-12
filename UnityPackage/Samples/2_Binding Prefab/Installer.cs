using EasyJection.Extensions;
using System;
using UnityEngine;

namespace EasyJection.Samples.BindingPrefab
{
    [DefaultExecutionOrder(-800)]
    public class Installer : MonoInstaller
    {
        protected override void InstallBindings()
        {
            Container.Bind<IRotate>().To<Rotate>();
            Container.Bind<ICube>().ToGameObject<Cube>("Cube");
            Container.Bind<CircleFormation>().ToSelf().InjectionTo().MethodVoid("Awake");
        }
    }
}
