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
        [SerializeField]
        string initialPosZ = "startPosZ";
        [SerializeField]
        string endPosZ = "endPosZ";
        [SerializeField]
        string currentPosZ = "PosDeltaZ";

        void Update() {
            bool shouldBeEmitting = player && player.isBoosting;
            visualEffect.SetBool(fieldName, shouldBeEmitting);

            float initialPositionZ = 0;
            initialPositionZ = visualEffect.GetFloat(initialPosZ);
            float endPositionZ = 0;
            endPositionZ = visualEffect.GetFloat(endPosZ);
            float currentHealth = player.health;
            visualEffect.SetFloat(currentPosZ, Mathf.Lerp(initialPositionZ, endPositionZ, currentHealth));
        }
    }
}
