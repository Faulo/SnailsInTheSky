using SitS.Player;
using UnityEngine.UIElements;

namespace SitS.UI.PlaneSelect
{
    sealed class PlaneListEntryVM
    {
        PlaneModel planeModel;

        Button uiSelectButton;
        Label uiNameLabel;
        VisualElement uiPortrait;

        public delegate void OnPlaneSelectedDelegate(PlaneModel planeModel);
        public event OnPlaneSelectedDelegate onPlaneSelected;

        public void Init(VisualElement visualElement, PlaneModel planeModel)
        {
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
