using SitS.Player;
using Slothsoft.UnityExtensions;
using UnityEngine;

namespace SitS.VFX {
    sealed class PlayerHealthMaterial : MonoBehaviour {
        [SerializeField, Expandable]
        PlayerModel player;
        [SerializeField, Expandable]
        Renderer attachedRenderer;

        [Space]
        [SerializeField]
        string fieldName = "health";
        [SerializeField]
        bool negate = false;

        void Update() {
            float health = negate
                ? 1 - player.health
                : player.health;

            attachedRenderer.material.SetFloat(fieldName, health);
        }
    }
}
