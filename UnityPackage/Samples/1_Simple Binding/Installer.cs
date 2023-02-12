using UnityEngine;

namespace EasyJection.Samples.SimpleBinding
{
    [DefaultExecutionOrder(-800)]
    public class Installer : MonoInstaller
    {
        protected override void InstallBindings()
        {
            Container.Bind<IRotate>().To<Rotate>();
            Container.Bind<Cube>().ToSelf(UseDefaultConstructor: true);
        }
    }
}
