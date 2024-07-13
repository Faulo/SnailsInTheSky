using System;
using UnityEngine;

namespace SitS.Player {
    [CreateAssetMenu]
    sealed class PlayerModel : ScriptableObject {
        [SerializeField]
        internal GameObject prefab;

        internal GameObject instance;

        internal void SpawnIfNotSpawnedAlready(Transform transform) {
            if (!prefab) {
                return;
            }

            if (instance) {
                return;
            }

            instance = Instantiate(prefab, transform);
        }

        [SerializeField]
        internal PlaneModel plane;

        [SerializeField, Range(0, 1)]
        internal float health = 1;
        internal bool canBoost => health > 0;

        [SerializeField]
        internal bool isBoosting = false;
        [SerializeField]
        internal float burnSpeed = 1;
    }
}
