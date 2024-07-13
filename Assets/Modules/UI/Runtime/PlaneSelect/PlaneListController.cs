using System.Collections.Generic;
using SitS.Player;
using UnityEngine.UIElements;
using static SitS.UI.PlaneSelect.PlaneListEntry;

namespace SitS.UI.PlaneSelect {
    sealed class PlaneListController : VisualElement {
        readonly VisualElement list;

        readonly VisualTreeAsset listEntryTemplate;

        readonly IReadOnlyList<PlaneModel> availablePlaneModels;

        public event OnPlaneSelectedDelegate onPlaneSelected;

        public PlaneListController(VisualElement list, IReadOnlyList<PlaneModel> planeModels, VisualTreeAsset listElementTemplate) {
            this.list = list;
            availablePlaneModels = planeModels;
            listEntryTemplate = listElementTemplate;
            FillPlaneList();
        }

        void FillPlaneList() {
            foreach (var planeModel in availablePlaneModels) {
                var listEntry = listEntryTemplate.Instantiate();

                var listEntryVM = new PlaneListEntry(listEntry, planeModel);
                listEntryVM.onPlaneSelected += (PlaneModel planeModel) => onPlaneSelected?.Invoke(planeModel);

                list.Add(listEntry);
            }
        }
    }
}
