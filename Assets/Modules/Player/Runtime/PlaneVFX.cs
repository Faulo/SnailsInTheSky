using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.VFX;

namespace SitS.Player {
    sealed class PlaneVFX : MonoBehaviour {
        [SerializeField, Expandable]
        PlayerModel player;
        [SerializeField, Expandable]
        VisualEffect visualEffect;

        bool isEmitting => player && player.isBoosting;

        void Update() {
            if (isEmitting) {
                visualEffect.Play();
            } else {
                visualEffect.Stop();
            }
        }
    }
}
