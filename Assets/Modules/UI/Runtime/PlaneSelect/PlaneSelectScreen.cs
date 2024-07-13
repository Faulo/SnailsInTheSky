using SitS.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace SitS.UI.PlaneSelect {
    sealed class PlaneSelectScreen : MonoBehaviour {
        [SerializeField]
        VisualTreeAsset listEntryTemplate;

        [SerializeField]
        PlaneModel[] planeModels;

        [SerializeField]
        PlayerModel player;

        public string gameScene = "SC_L01_KidsRoom";

        PlaneListController planeListVM;

        void OnEnable() {
            var uiDocument = GetComponent<UIDocument>();

            planeListVM = new PlaneListController(uiDocument.rootVisualElement.Q<VisualElement>("PlaneList"), planeModels, listEntryTemplate);
            planeListVM.onPlaneSelected += (PlaneModel selectedPlaneModel) => {
                player.plane = selectedPlaneModel;
                SceneManager.LoadScene(gameScene);
            };
        }
    }
}
