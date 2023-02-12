// Cube.cs
using System.Runtime.CompilerServices;
using UnityEngine;

namespace EasyJection.Samples.SimpleBinding
{
    public class BasicCube : MonoBehaviour
    {
        protected IRotate m_RotateSystem;
    }

    public class Cube : BasicCube
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public Cube()
        { }

        private void Update()
        {
            m_RotateSystem.DoRotate(0, 0.25f, 0);
        }
    }
}