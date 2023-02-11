// Cube.cs
using System.Runtime.CompilerServices;
using UnityEngine;

public class BasicCube : MonoBehaviour
{
    protected IRotate m_RotateSystem;
}

public class Cube : BasicCube
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Cube()
    {
        UnityEngine.Debug.Log("Cube()");
    }

    private void Update()
    {
        m_RotateSystem.DoRotate(0, 0.25f, 0);
    }
}