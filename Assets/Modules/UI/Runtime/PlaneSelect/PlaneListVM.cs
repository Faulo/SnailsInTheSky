using System.Collections.Generic;
using SitS.Player;
using UnityEngine;
using UnityEngine.UIElements;
using static SitS.UI.PlaneSelect.PlaneListEntryVM;

namespace SitS.UI.PlaneSelect
{
    sealed class PlaneListVM
    {
        VisualTreeAsset listEntryTemplate;

        VisualElement uiPlaneList;

        List<PlaneModel> availablePlaneModels;

        public event OnPlaneSelectedDelegate onPlaneSelected;

        public void Init(VisualElement root, List<PlaneModel> planeModels, VisualTreeAsset listElementTemplate)
        {
            availablePlaneModels = planeModels;
            listEntryTemplate = listElementTemplate;
            uiPlaneList = root.Q<VisualElement>("PlaneList");
            FillPlaneList();
        }

        void FillPlaneList()
        {
            foreach (var planeModel in availablePlaneModels)
            {
                var listEntry = listEntryTemplate.Instantiate();

                var listEntryVM = new PlaneListEntryVM();
                listEntryVM.Init(listEntry, planeModel);
                listEntryVM.onPlaneSelected += (PlaneModel planeModel) => onPlaneSelected?.Invoke(planeModel);

                uiPlaneList.Add(listEntry);
            }
        }
    }
}
