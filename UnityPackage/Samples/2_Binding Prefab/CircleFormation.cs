using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace EasyJection.Samples.BindingPrefab
{   
    public class CircleFormation : MonoBehaviour
    {
        private ICube[] array; 

        private ICube cube_1;
        private ICube cube_2;
        private ICube cube_3;
        private ICube cube_4;
        private ICube cube_5;
        private ICube cube_6;
        private ICube cube_7;
        private ICube cube_8;
        private ICube cube_9;
        private ICube cube_10;
        private ICube cube_11;
        private ICube cube_12;
        private ICube cube_13;
        private ICube cube_14;
        private ICube cube_15;

        [SerializeField]
        private float radius = 5f;

        [MethodImpl(MethodImplOptions.NoInlining)]
        // Dependency injection occurs when the 'Awake' method is called.
        private void Awake()
        { }

        void Start()
        {
            // Push all 15 'iCube' objects into an array
            array = new[]
            {
                cube_1,
                cube_2,
                cube_3,
                cube_4,
                cube_5,
                cube_6,
                cube_7,
                cube_8,
                cube_9,
                cube_10,
                cube_11,
                cube_12,
                cube_13,
                cube_14,
                cube_15
            };

            for (int i = 0; i < array.Length; i++)
            {
                float angle = i * Mathf.PI * 2 / array.Length;
                float x = Mathf.Cos(angle) * radius;
                float z = Mathf.Sin(angle) * radius;
                Vector3 pos = transform.position + new Vector3(x, 0, z);
                array[i].SetPosition(pos);
            }
        }
    }
}