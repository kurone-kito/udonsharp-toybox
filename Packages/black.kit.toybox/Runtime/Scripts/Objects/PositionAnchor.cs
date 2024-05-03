using UdonSharp;
using UnityEngine;

namespace black.kit.toybox
{
    /// <summary>
    /// The component maintains coordinate information when active and
    /// inactive and switches coordinate information the moment the active
    /// state changes.
    /// </summary>
    /// <remarks>
    /// Usage (in the inspector of Unity Editor):
    /// <list type="number">
    /// <item>
    /// <description>
    /// Add this component or prefab to the scene.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Specify the target transform to update the coordinate information.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Specify the coordinate information when active and inactive.
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    [AddComponentMenu("UdonSharp Toybox/Object/Position Anchor")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public sealed class PositionAnchor : UdonSharpBehaviour
    {
        /// <summary>
        /// The warning message when no target transform is specified.
        /// </summary>
        private const string WARN_NO_TARGET =
            "No target transform is specified.";

#pragma warning disable IDE0044
        /// <summary>The target transform is to be updated.</summary>
        [SerializeField, Tooltip("The target transform is to be updated.")]
        private Transform target;

        /// <summary>The coordinate information when active.</summary>
        [SerializeField, Tooltip("The coordinate information when active.")]
        private Transform transformOnActive;

        /// <summary>The coordinate information when inactive.</summary>
        [SerializeField]
        [Tooltip("The coordinate information when inactive.")]
        private Transform transformOnDeactive;
#pragma warning restore IDE0044

        /// <summary>
        /// Update the target transform with the coordinate information.
        /// </summary>
        private void UpdateTargetTransform()
        {
            if (!target)
            {
                Log.Warn(WARN_NO_TARGET);
                return;
            }
            if (!gameObject.activeInHierarchy && transformOnDeactive)
            {
                target.transform.SetPositionAndRotation(
                    transformOnDeactive.position, transformOnDeactive.rotation);
            }
            if (gameObject.activeInHierarchy && transformOnActive)
            {
                target.transform.SetPositionAndRotation(
                    transformOnActive.position, transformOnActive.rotation);
            }
        }

#pragma warning disable IDE0051
        /// <summary>
        /// Update the target transform when the component is disabled.
        /// </summary>
        private void OnDisable() => UpdateTargetTransform();

        /// <summary>
        /// Update the target transform when the component is enabled.
        /// </summary>
        private void OnEnable() => UpdateTargetTransform();

        /// <summary>
        /// Update the target transform when the component is started.
        /// </summary>
        private void Start()
        {
            if (!transformOnActive)
            {
                transformOnActive = transform;
            }
            if (!target)
            {
                Log.Warn(WARN_NO_TARGET);
            }
            UpdateTargetTransform();
        }
#pragma warning restore IDE0051
    }
}
