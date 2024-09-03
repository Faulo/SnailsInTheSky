using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace SitS.UI.EndScreen {
    sealed class EndScreenController : MonoBehaviour {
        [SerializeField]
        public UIDocument uiDocument;

        [SerializeField]
        Player.PlayerModel playerModel;

        Label uiTitle;
        Label uiMessage;
        Button uiButtonPlaneSelect;
        Button uiButtonQuit;

        void OnEnable() {
            var uiRoot = uiDocument.rootVisualElement;

            uiTitle = uiRoot.Q<Label>("Title");
            uiMessage = uiRoot.Q<Label>("Message");
            uiButtonPlaneSelect = uiRoot.Q<Button>("ButtonPlaneSelect");
            uiButtonQuit = uiRoot.Q<Button>("ButtonQuit");

            uiTitle.text = playerModel.collectedEverything ? "You Won!" : "You Lost!";
            uiMessage.text = "You collected " + playerModel.collectiblesCollected + " collectible(s) out of " + playerModel.collectiblesMax + "!";
            uiButtonPlaneSelect.clicked += () => SceneManager.LoadScene("SC_PlaneSelect");
            uiButtonQuit.clicked += () => Application.Quit();
        }
    }
}
