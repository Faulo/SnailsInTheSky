using System.Collections;
using UnityEngine;

namespace Sits.Collectibles {
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
