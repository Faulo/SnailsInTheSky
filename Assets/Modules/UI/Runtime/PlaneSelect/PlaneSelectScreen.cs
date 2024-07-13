using System;
using System.Collections.Generic;
using SitS.Player;
using UnityEngine;
using UnityEngine.UIElements;

namespace SitS.UI.PlaneSelect
{
    sealed class PlaneSelectScreen : MonoBehaviour
    {
        [SerializeField]
        VisualTreeAsset listEntryTemplate;

        [SerializeField]
        List<PlaneModel> planeModels;

        PlaneListVM planeListVM;

        void OnEnable()
        {
            var uiDocument = GetComponent<UIDocument>();

            // @TODO: Stop player simulation

            planeListVM = new PlaneListVM();
            planeListVM.Init(uiDocument.rootVisualElement, planeModels, listEntryTemplate);
            planeListVM.onPlaneSelected += (PlaneModel selectedPlaneModel) =>
            {
                uiDocument.rootVisualElement.RemoveFromHierarchy();

                // @TODO: Start/resume player simulation
            };
        }
    }
}
