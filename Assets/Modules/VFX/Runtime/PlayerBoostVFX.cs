using SitS.Player;
using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.VFX;

namespace SitS.VFX {
    sealed class PlayerBoostVFX : MonoBehaviour {
        [SerializeField, Expandable]
        PlayerModel player;
        [SerializeField, Expandable]
        VisualEffect visualEffect;

        [Space]
        [SerializeField]
        string fieldName = "IsEmitting";

        void Update() {
            bool shouldBeEmitting = player && player.isBoosting;
            visualEffect.SetBool(fieldName, shouldBeEmitting);
        }
    }
}
