using SitS.Player;
using Slothsoft.UnityExtensions;
using UnityEngine;

namespace SitS.VFX {
    sealed class PlayerBreakVFX : MonoBehaviour {
        [SerializeField, Expandable]
        PlayerModel player;
        [SerializeField, Expandable]
        TrailRenderer breakEffectLeft;
        [SerializeField, Expandable]
        TrailRenderer breakEffectRight;

        void Update() {
            if (player) {
                float leftBreakValue = player.leftBrake;
                if (leftBreakValue > 0f) {
                    Debug.Log(leftBreakValue);
                }

                breakEffectLeft.emitting = leftBreakValue > 0f;
                breakEffectLeft.startWidth = Mathf.Lerp(0.13f, 0.05f, leftBreakValue);

                float rightBreakValue = player.rightBrake;
                breakEffectRight.emitting = rightBreakValue > 0f;
                breakEffectRight.startWidth = Mathf.Lerp(0.13f, 0.05f, rightBreakValue);
            }
        }
    }
}
