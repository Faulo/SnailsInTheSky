using TMPro;
using UnityEngine;

namespace SitS.UI {
    [ExecuteAlways]
    sealed class PrintVersion : MonoBehaviour {
        [SerializeField]
        TextMeshProUGUI textComponent;

        void Start() {
            UpdateText();
        }

#if UNITY_EDITOR
        void Update() {
            UpdateText();
        }
#endif
        void UpdateText() {
            if (textComponent) {
                textComponent.text = $"{Application.productName} v{Application.version}";
            }
        }
    }
}
