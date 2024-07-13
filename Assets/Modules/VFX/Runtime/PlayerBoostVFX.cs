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

        bool wasEmitting = false;

        void Update() {
            bool shouldBeEmitting = player && player.isBoosting;

            if (wasEmitting != shouldBeEmitting) {
                wasEmitting = shouldBeEmitting;
                if (shouldBeEmitting) {
                    visualEffect.Play();
                } else {
                    visualEffect.Stop();
                }
            }
        }
    }
}
