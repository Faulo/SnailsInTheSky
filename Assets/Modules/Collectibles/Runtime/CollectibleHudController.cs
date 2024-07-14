using UnityEngine;
using UnityEngine.UIElements;

namespace Sits.Collectibles {
    sealed class CollectibleHudController : MonoBehaviour {
        [SerializeField]
        public UIDocument uiDocument;

        [SerializeField]
        SitS.Player.PlayerModel playerModel;

        Label uiCurrentCollectibles;
        Label uiMaxCollectibles;

        void OnEnable() {
            var uiRoot = uiDocument.rootVisualElement;
            uiCurrentCollectibles = uiRoot.Q<Label>("CurrentCollectibles");
            uiMaxCollectibles = uiRoot.Q<Label>("MaxCollectibles");

            uiMaxCollectibles.text = playerModel.collectiblesMax.ToString();
        }

        void FixedUpdate() {
            uiCurrentCollectibles.text = playerModel.collectiblesCollected.ToString();
        }
    }
}
