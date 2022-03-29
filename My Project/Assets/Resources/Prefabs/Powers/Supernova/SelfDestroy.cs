using UnityEngine;
using System.Collections;

namespace WindRose.Powers
{
    public class SelfDestroy : MonoBehaviour
    {
        public float TimeDestroy;

        void Start()
        {
            StartCoroutine("Destroy", TimeDestroy);
        }

        IEnumerator Destroy(float time)
        {
            yield return new WaitForSeconds(time);
            Destroy(gameObject);
        }
    }
}
