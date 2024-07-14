using System;
using System.Collections;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace AssemblyCSharp {
    sealed class Collectible : MonoBehaviour {
        [SerializeField]
        uint amount = 1;

        [SerializeField]
        float secondsTillDestroy = 2f;

        void OnTriggerEnter(Collider other) {
            var collector = other.GetComponentInParent<CollectibleCollector>();

            if (!collector) {
                return;
            }

            collector.Collect(amount);
            StartCoroutine(DestroyTimed());
        }

        IEnumerator DestroyTimed() {
            yield return new WaitForSeconds(secondsTillDestroy);
            Destroy(gameObject);
        }
    }
}
