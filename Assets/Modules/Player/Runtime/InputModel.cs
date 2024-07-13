using UnityEngine;

namespace SitS.Player {
    [CreateAssetMenu]
    sealed class InputModel : ScriptableObject {
        [SerializeField]
        internal float intendedYaw;
        [SerializeField]
        internal float intendedPitch;
        [SerializeField]
        internal float intendedRoll;
        [SerializeField]
        internal bool intendsBoost;
    }
}
