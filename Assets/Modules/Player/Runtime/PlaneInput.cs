using MyBox;
using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SitS.Player {
    sealed class PlaneInput : MonoBehaviour {
        [SerializeField, Expandable]
        InputModel input;

        public void OnTilt(InputValue input) {
            (this.input.intendedPitch, this.input.intendedYaw) = input.Get<Vector2>();
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
            input.intendedRoll = leftRoll - rightRoll;
        }

        public void OnRollLeft(InputValue input) {
            leftRoll = input.Get<float>();
        }

        public void OnRollRight(InputValue input) {
            rightRoll = input.Get<float>();
        }

        public void OnFire(InputValue input) {
            this.input.intendsBoost = input.isPressed;
        }
    }
}
