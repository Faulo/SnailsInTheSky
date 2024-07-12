using MyBox;
using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SitS.Player {
    sealed class PlaneInput : MonoBehaviour {
        [SerializeField]
        PlaneController controller;

        public void OnTilt(InputValue input) {
            (controller.intendedPitch, controller.intendedYaw) = input.Get<Vector2>();
        }

        [Space]
        [SerializeField, ReadOnly]
        float m_leftRoll;
        float leftRoll {
            get => m_leftRoll;
            set {
                m_leftRoll = value;
                UpdateRoll();
            }
        }

        [SerializeField, ReadOnly]
        float m_rightRoll;
        float rightRoll {
            get => m_rightRoll;
            set {
                m_rightRoll = value;
                UpdateRoll();
            }
        }

        void UpdateRoll() {
            controller.intendedRoll = leftRoll - rightRoll;
        }

        public void OnRollLeft(InputValue input) {
            leftRoll = input.Get<float>();
        }

        public void OnRollRight(InputValue input) {
            rightRoll = input.Get<float>();
        }
    }
}
