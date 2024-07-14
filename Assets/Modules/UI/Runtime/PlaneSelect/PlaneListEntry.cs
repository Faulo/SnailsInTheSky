using SitS.Player;
using UnityEngine.UIElements;

namespace SitS.UI.PlaneSelect {
    sealed class PlaneListEntry {
        readonly PlaneModel planeModel;

        readonly Button uiSelectButton;
        readonly Label uiNameLabel;
        readonly VisualElement uiPortrait;

        readonly ProgressBar uiBarManeuverability;
        readonly ProgressBar uiBarLift;
        readonly ProgressBar uiBarSize;
        readonly ProgressBar uiBarNitro;

        public delegate void OnPlaneSelectedDelegate(PlaneModel planeModel);
        public event OnPlaneSelectedDelegate onPlaneSelected;

        public PlaneListEntry(VisualElement visualElement, PlaneModel planeModel) {
            this.planeModel = planeModel;

            uiSelectButton = visualElement.Q<Button>("SelectButton");
            uiNameLabel = visualElement.Q<Label>("PlaneName");
            uiPortrait = visualElement.Q<VisualElement>("PlanePortrait");

            uiBarManeuverability = visualElement.Q<ProgressBar>("ManeuverabilityBar");
            uiBarLift = visualElement.Q<ProgressBar>("LiftBar");
            uiBarSize = visualElement.Q<ProgressBar>("SizeBar");
            uiBarNitro = visualElement.Q<ProgressBar>("NitroBar");

            uiSelectButton.clicked += () => onPlaneSelected?.Invoke(this.planeModel);
            uiNameLabel.text = planeModel.displayName;
            uiPortrait.style.backgroundImage = new StyleBackground(planeModel.portrait);

            uiBarManeuverability.value = planeModel.manoeuvrability;
            uiBarManeuverability.title = planeModel.manoeuvrability.ToString();

            uiBarLift.value = planeModel.lift;
            uiBarLift.title = planeModel.lift.ToString();

            uiBarSize.value = planeModel.size;
            uiBarSize.title = planeModel.size.ToString();

            uiBarNitro.value = planeModel.nitro;
            uiBarNitro.title = planeModel.nitro.ToString();
        }
    }
}
