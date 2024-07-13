using MyBox;
using Slothsoft.UnityExtensions;
using UnityEngine;

namespace SitS.Player {
    [ExecuteAlways]
    sealed class PlaneController : MonoBehaviour {

        [SerializeField, Expandable]
        PlaneModel model;

        [Space]
        [SerializeField]
        float maximumYaw = 90;
        [SerializeField]
        float maximumPitch = 90;

        GameObject modelPrefab => model
            ? model.meshPrefab
            : null;
        GameObject modelInstance => transform.childCount > 0
            ? transform.GetChild(0).gameObject
            : null;

        [Space]
        [SerializeField, ReadOnly]
        internal float intendedYaw;
        [SerializeField, ReadOnly]
        internal float intendedPitch;
        [SerializeField, ReadOnly]
        internal float intendedRoll;
        [SerializeField, ReadOnly]
        internal bool intendsBoost;

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

            float deltaYaw = Time.deltaTime * model.yawSpeed * intendedYaw;
            float deltaPitch = Time.deltaTime * model.pitchSpeed * intendedPitch;
            float deltaRoll = Time.deltaTime * model.rollSpeed * intendedRoll;

            var current = transform.eulerAngles;

            current.x += deltaYaw;
            current.y += deltaPitch;
            current.z += deltaRoll;

            //current.x = Mathf.Clamp(current.x, -maximumYaw, maximumYaw);
            //current.y = Mathf.Clamp(current.y, -maximumPitch, maximumPitch);

            transform.eulerAngles = current;

            gravityStep = Time.deltaTime * model.gravityMultiplier * Physics.gravity;

            liftStep = Time.deltaTime * model.liftCoefficient * model.area * velocity.sqrMagnitude * transform.up;

            dragStep = velocity == Vector3.zero
                ? Vector3.zero
                : Time.deltaTime * model.dragCoefficient * model.area * velocity.sqrMagnitude * velocity.normalized;

            velocity += gravityStep + liftStep - dragStep;

            transform.position += Time.deltaTime * velocity;
        }
    }
}
