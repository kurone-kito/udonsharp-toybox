using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace black.kit.toybox.Examples
{
    /// <summary>
    /// The component toggles the target game object when the toggle
    /// component is toggled.
    /// </summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public sealed class ToggleHelper : UdonSharpBehaviour
    {
        /// <summary>
        /// The warning message when no toggle component is found.
        /// </summary>
        private const string WARN_TOGGLE_NOT_FOUND =
            "No toggle component is found.";

        /// <summary>
        /// The warning message when no target transform is specified.
        /// </summary>
        private const string WARN_NO_TARGET =
            "No target transform is specified.";

#pragma warning disable IDE0044
        /// <summary>The target game object to be updated.</summary>
        [SerializeField]
        [Tooltip("The target game object to be updated.")]
        private GameObject target;
#pragma warning restore IDE0044

        /// <summary>The toggle component to be updated.</summary>
        private Toggle toggle;

        /// <summary>Toggle the toggle component.</summary>
        public void OnToggle()
        {
            if (target && toggle)
            {
                target.SetActive(toggle.isOn);
            }
        }

#pragma warning disable IDE0051
        /// <summary>
        /// Update the target transform when the component is started.
        /// </summary>
        private void Start()
        {
            toggle = GetComponent<Toggle>();
            if (!toggle)
            {
                Log.Warn(WARN_TOGGLE_NOT_FOUND);
            }
            if (!target)
            {
                Log.Warn(WARN_NO_TARGET);
            }
        }
#pragma warning restore IDE0051
    }
}
