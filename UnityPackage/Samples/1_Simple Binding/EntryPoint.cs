//// EntryPoint.cs
//using UnityEngine;
//using EasyJection;

//public class EntryPoint
//{
//    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
//    static void OnBeforeSceneLoadRuntimeMethod()
//    {
//        Debug.Log("OnBeforeSceneLoadRuntimeMethod");
//        var container = Container.Instance;
//        container.Bind<IRotate>().To<Rotate>();
//        container.Bind<Cube>().ToSelf(UseDefaultConstructor: true);
//    }
//}