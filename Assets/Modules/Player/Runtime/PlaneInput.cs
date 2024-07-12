using UnityEngine;
using UnityEngine.InputSystem;

namespace SitS.Player {
    sealed class PlaneInput : MonoBehaviour {
        [SerializeField]
        PlayerController controller;

        public void OnTilt(InputValue input) {
            controller.intendedTilt = input.Get<Vector2>();
        }
    }
}
