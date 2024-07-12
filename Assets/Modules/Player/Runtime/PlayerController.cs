using MyBox;
using UnityEngine;

namespace SitS.Player {
    sealed class PlayerController : MonoBehaviour {
        [SerializeField, ReadOnly]
        internal Vector2 intendedTilt;

        [SerializeField]
        float yawSpeed = 1;
        [SerializeField]
        float maximumYaw = 90;

        [Space]
        [SerializeField]
        float pitchSpeed = 1;
        [SerializeField]
        float maximumPitch = 90;

        void FixedUpdate() {
            float deltaYaw = Time.deltaTime * yawSpeed * intendedTilt.y;
            float deltaPitch = Time.deltaTime * pitchSpeed * intendedTilt.x;

            var current = transform.eulerAngles;

            current.x += deltaYaw;
            current.y += deltaPitch;

            //current.x = Mathf.Clamp(current.x, -maximumYaw, maximumYaw);
            //current.y = Mathf.Clamp(current.y, -maximumPitch, maximumPitch);

            transform.eulerAngles = current;
        }
    }
}
