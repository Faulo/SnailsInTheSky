using MyBox;
using UnityEngine;

namespace SitS.Player {
    sealed class PlaneController : MonoBehaviour {
        [SerializeField, ReadOnly]
        internal float intendedYaw;
        [SerializeField, ReadOnly]
        internal float intendedPitch;
        [SerializeField, ReadOnly]
        internal float intendedRoll;

        [SerializeField]
        float yawSpeed = 1;
        [SerializeField]
        float maximumYaw = 90;

        [Space]
        [SerializeField]
        float pitchSpeed = 1;
        [SerializeField]
        float maximumPitch = 90;

        [Space]
        [SerializeField]
        float rollSpeed = 1;

        [Space]
        [SerializeField]
        float forwardSpeed = 1;

        void FixedUpdate() {
            float deltaYaw = Time.deltaTime * yawSpeed * intendedYaw;
            float deltaPitch = Time.deltaTime * pitchSpeed * intendedPitch;
            float deltaRoll = Time.deltaTime * rollSpeed * intendedRoll;

            var current = transform.eulerAngles;

            current.x += deltaYaw;
            current.y += deltaPitch;
            current.z += deltaRoll;

            //current.x = Mathf.Clamp(current.x, -maximumYaw, maximumYaw);
            //current.y = Mathf.Clamp(current.y, -maximumPitch, maximumPitch);

            transform.eulerAngles = current;

            transform.position += forwardSpeed * Time.deltaTime * transform.forward;
        }
    }
}
