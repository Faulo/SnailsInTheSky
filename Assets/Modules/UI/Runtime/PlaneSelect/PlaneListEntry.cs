using SitS.Player;
using UnityEngine.UIElements;

namespace SitS.UI.PlaneSelect {
    sealed class PlaneListEntry {
        readonly PlaneModel planeModel;

        readonly Button uiSelectButton;
        readonly Label uiNameLabel;
        readonly VisualElement uiPortrait;

        public delegate void OnPlaneSelectedDelegate(PlaneModel planeModel);
        public event OnPlaneSelectedDelegate onPlaneSelected;

        public PlaneListEntry(VisualElement visualElement, PlaneModel planeModel) {
            this.planeModel = planeModel;

            uiSelectButton = visualElement.Q<Button>("SelectButton");
            uiNameLabel = visualElement.Q<Label>("PlaneName");
            uiPortrait = visualElement.Q<VisualElement>("PlanePortrait");

            uiSelectButton.clicked += () => onPlaneSelected?.Invoke(this.planeModel);
            uiNameLabel.text = planeModel.displayName;
            uiPortrait.style.backgroundImage = new StyleBackground(planeModel.portrait);
        }
    }
}
