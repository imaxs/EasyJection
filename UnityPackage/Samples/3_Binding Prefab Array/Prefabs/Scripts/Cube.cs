// Cube.cs
using System.Runtime.CompilerServices;
using UnityEngine;

namespace EasyJection.Samples.BindingPrefabArray
{
    public interface ICube 
    {
        void SetPosition(Vector3 positon);
        void Update();
    }

    public class BasicCube : MonoBehaviour
    {
        protected IRotate m_RotateSystem;
    }

    public class Cube : BasicCube, ICube
    {
        public void SetPosition(Vector3 positon) 
        {
            transform.position = positon;
        }

        public void Update()
        {
            m_RotateSystem.DoRotate(0, 0.25f, 0);
        }
    }
}