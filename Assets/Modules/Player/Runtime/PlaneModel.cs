using UnityEngine;

namespace SitS.Player {
    [CreateAssetMenu]
    public class PlaneModel : ScriptableObject {
        [Space]
        [SerializeField]
        public string displayName;
        [SerializeField]
        public Texture2D portrait;

        [Space]
        [SerializeField]
        internal float yawSpeed = 1;

        [SerializeField]
        internal float pitchSpeed = 1;

        [SerializeField]
        internal float rollSpeed = 1;

        [Space]
        [SerializeField]
        internal GameObject meshPrefab;
        [SerializeField]
        internal float dragCoefficient = 1;
        [SerializeField]
        internal float liftCoefficient = 1;
        [SerializeField]
        internal Quaternion liftRotation = Quaternion.identity;
        [SerializeField]
        internal float boostMultiplier = 1;
        [SerializeField]
        internal float area = 1;
    }
}
