using System;
using UnityEngine;

namespace SitS.Player {
    [CreateAssetMenu]
    public sealed class PlayerModel : ScriptableObject {
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
        public PlaneModel plane;

        [SerializeField, Range(0, 1)]
        float _health = 1;
        public float health {
            get => _health;
            internal set => _health = Mathf.Clamp01(value);
        }

        internal bool canBoost => _health > 0;

        [SerializeField]
        bool _isBoosting = false;
        public bool isBoosting {
            get => _isBoosting;
            internal set => _isBoosting = value;
        }

        [SerializeField]
        internal float burnSpeed = 1;
    }
}
