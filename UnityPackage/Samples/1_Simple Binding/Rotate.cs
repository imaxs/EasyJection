﻿// Rotate.cs
using System.Runtime.CompilerServices;
using UnityEngine;

public class Rotate : IRotate
{
    private Cube m_Cube;

    public void DoRotate(float x, float y, float z)
    {
        m_Cube.transform.Rotate(x, y, z);
    }
}