// EntryPoint.cs
using UnityEngine;
using EasyJection;
using EasyJection.Extensions;

public class EntryPoint
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnBeforeSceneLoadRuntimeMethod()
    {
        var container = Container.Instance;
        container.Bind<IRotate>().To<Rotate>();
        container.Bind<Cube>().ToGameObject().InjectionTo().Constructor();
    }
}