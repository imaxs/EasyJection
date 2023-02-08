// Cube.cs
using UnityEngine;

public class Cube : MonoBehaviour
{
    private IRotate m_RotateSystem;

    private void Update()
    {
        m_RotateSystem.DoRotate(0, 0.25f, 0);
    }
}