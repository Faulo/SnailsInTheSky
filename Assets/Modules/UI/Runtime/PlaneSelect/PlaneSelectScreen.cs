using System;
using System.Collections.Generic;
using SitS.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace SitS.UI.PlaneSelect
{
    sealed class PlaneSelectScreen : MonoBehaviour
    {
        [SerializeField]
        VisualTreeAsset listEntryTemplate;

        [SerializeField]
        List<PlaneModel> planeModels;

        public string gameScene = "SC_L01_KidsRoom";

        PlaneListVM planeListVM;

        void OnEnable()
        {
            var uiDocument = GetComponent<UIDocument>();

            planeListVM = new PlaneListVM();
            planeListVM.Init(uiDocument.rootVisualElement, planeModels, listEntryTemplate);
            planeListVM.onPlaneSelected += (PlaneModel selectedPlaneModel) =>
            {
                SceneManager.LoadScene(gameScene);
            };
        }
    }
}
