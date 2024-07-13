using Slothsoft.UnityExtensions;
using UnityEngine;

namespace SitS.Player {
    [ExecuteAlways]
    sealed class PlaneController : MonoBehaviour {

        [SerializeField, Expandable]
        PlaneModel plane;
        [SerializeField, Expandable]
        InputModel input;
        [SerializeField, Expandable]
        PlayerModel player;

        [Space]
        [SerializeField]
        Rigidbody attachedRigidbody;

        [Space]
        [SerializeField]
        float maximumYaw = 90;
        [SerializeField]
        float maximumPitch = 90;

        GameObject modelPrefab => plane
            ? plane.meshPrefab
            : null;
        GameObject modelInstance => transform.childCount > 0
            ? transform.GetChild(0).gameObject
            : null;

        void Start() {
            RecreateModel();
        }

#if UNITY_EDITOR
        void Update() {
            RecreateModel();
        }
#endif

        void RecreateModel() {
            if (modelPrefab) {
                if (modelInstance && modelInstance.name != modelPrefab.name) {
                    DestroyModel();
                }

                if (!modelInstance) {
                    CreateModel();
                }
            } else {
                DestroyModel();
            }
        }

        void DestroyModel() {
            if (modelInstance) {
                if (Application.isPlaying) {
                    Destroy(modelInstance);
                } else {
                    DestroyImmediate(modelInstance);
                }
            }
        }

        void CreateModel() {
#if UNITY_EDITOR
            if (Application.isPlaying) {
#endif
                var instance = Instantiate(modelPrefab, transform);
                instance.name = modelPrefab.name;
#if UNITY_EDITOR
            } else {
                var instance = UnityEditor.PrefabUtility.InstantiatePrefab(modelPrefab, transform);
                instance.hideFlags = HideFlags.DontSave | HideFlags.NotEditable;
                instance.name = modelPrefab.name;
            }
#endif
        }

        [SerializeField]
        Vector3 boostStep;

        [SerializeField]
        Vector3 gravityStep;

        [SerializeField]
        Vector3 liftStep;

        [SerializeField]
        Vector3 dragStep;

        [SerializeField]
        Vector3 velocity = Vector3.zero;

        void FixedUpdate() {
            if (!Application.isPlaying) {
                return;
            }

            float deltaYaw = plane.yawSpeed * input.intendedYaw;
            float deltaPitch = plane.pitchSpeed * input.intendedPitch;
            float deltaRoll = plane.rollSpeed * input.intendedRoll;

            // var deltaRotation = Quaternion.Euler(deltaYaw, deltaPitch, deltaRoll);

            attachedRigidbody.angularVelocity = new(deltaYaw, deltaPitch, deltaRoll);

            velocity = attachedRigidbody.velocity;

            ProcessBoost();

            gravityStep = Time.deltaTime * plane.gravityMultiplier * Vector3.down;

            liftStep = velocity == Vector3.zero
                ? Vector3.zero
                : plane.liftRotation * (Time.deltaTime * plane.liftCoefficient * plane.area * velocity.sqrMagnitude * velocity.normalized);

            dragStep = velocity == Vector3.zero
                ? Vector3.zero
                : Time.deltaTime * plane.dragCoefficient * plane.area * velocity.sqrMagnitude * velocity.normalized;

            velocity += boostStep + gravityStep + liftStep - dragStep;

            attachedRigidbody.velocity = velocity;
        }

        void ProcessBoost() {

            player.isBoosting = input.intendsBoost && player.canBoost;

            if (player.isBoosting) {
                player.health -= Mathf.Clamp01(Time.deltaTime * player.burnSpeed);
                boostStep = Time.deltaTime * plane.boostMultiplier * transform.forward;
            } else {
                boostStep = Vector3.zero;
            }
        }
    }
}
