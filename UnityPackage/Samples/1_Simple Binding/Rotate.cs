// Rotate.cs
using UnityEngine;

namespace EasyJection.Samples.SimpleBinding
{
    public class Rotate : IRotate
    {
        private Cube m_Cube;

        public void DoRotate(float x, float y, float z)
        {
            m_Cube.transform.Rotate(x, y, z);
        }
    }
}