using System;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace black.kit.toybox
{
    /// <summary>
    /// The component synchronizes the selection state of the Toggle UI
    /// component.
    /// </summary>
    [AddComponentMenu("UdonSharp Toybox/Global/Global Toggle")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public sealed class GlobalToggle : SyncBehaviour
    {
        /// <summary>The property name of the Toggle component.</summary>
        public const string NAME_TOGGLE = nameof(toggle);

        /// <summary>
        /// The warning message when the Toggle component is not found.
        /// </summary>
        private const string WARN_NO_TOGGLE =
            "Toggle component is not found.";

        /// <summary>The value to synchronize.</summary>
        [NonSerialized, UdonSynced]
        public bool value;

#pragma warning disable IDE0044
        /// <summary>
        /// The toggle component to synchronize the value.
        /// </summary>
        [SerializeField, Tooltip("Specify the toggle to synchronize.")]
        private Toggle toggle;
#pragma warning restore IDE0044

        /// <summary>The callback when the value is changed.</summary>
        public void OnToggle()
        {
            if (toggle == null)
            {
                return;
            }
            SetValue(toggle.isOn);
        }

        /// <summary>Set the value to the toggle.</summary>
        /// <param name="value">The value to set.</param>
        public void SetValue(bool value)
        {
            if (toggle == null)
            {
                return;
            }
            if (toggle.isOn != value)
            {
                UpdateView();
            }
            if (this.value != value)
            {
                ChangeOwner();
                this.value = value;
                Sync();
            }
        }

        /// <summary>
        /// The callback to update the view,
        /// e.g. on synchronized the value.
        /// </summary>
        protected override void UpdateView()
        {
            if (toggle)
            {
                toggle.isOn = value;
            }
        }

#pragma warning disable IDE0051
        /// <summary>
        /// Update the view when the component is enabled.
        /// </summary>
        private void OnEnable() => UpdateView();

        /// <summary>
        /// Update the target transform when the component is started.
        /// </summary>
        private void Start()
        {
            if (!toggle)
            {
                Log.Warn(WARN_NO_TOGGLE);
                return;
            }
            if (IsOwner())
            {
                value = toggle.isOn;
            }
        }
#pragma warning restore IDE0051
    }
}
