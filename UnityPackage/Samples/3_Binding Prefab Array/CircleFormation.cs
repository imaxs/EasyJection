using System.Runtime.CompilerServices;
using UnityEngine;

namespace EasyJection.Samples.BindingPrefabArray
{   
    public class CircleFormation : MonoBehaviour
    {
        private ICube[] array; 

        [SerializeField]
        private float radius = 5f;

        private const int count = 20;

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected CircleFormation() 
        {
            array = new ICube[count];
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        // Dependency injection occurs when the 'Awake' method is called.
        private void Awake()
        { }

        void Start()
        {
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