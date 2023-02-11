using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyJection
{
    public class Installer : MonoInstaller
    {
        protected override void InstallBindings()
        {
            Container.Bind<IRotate>().To<Rotate>();
            Container.Bind<Cube>().ToSelf(UseDefaultConstructor: true);
        }
    }
}
