using System;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace black.kit.toybox
{
    /// <summary>
    /// The component synchronizes the selection state of the Toggles UI
    /// component.
    /// </summary>
    [AddComponentMenu("UdonSharp Toybox/Global/Global Toggles")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public sealed class GlobalToggles : SyncBehaviour
    {
        /// <summary>
        /// The property name of the toggle group component.
        /// </summary>
        public const string NAME_TOGGLE_GROUP = nameof(toggleGroup);

        /// <summary>The property name of the toggle component.</summary>
        public const string NAME_TOGGLES = nameof(toggles);

        /// <summary>
        /// The warning message when the ToggleGroup component is not found.
        /// </summary>
        private const string WARN_NO_TOGGLE_GROUP =
            "ToggleGroup component is not found.";

        /// <summary>The value to synchronize.</summary>
        /// <remarks>
        /// The value is the index of the selected toggle.
        /// When the value is -1, no toggle is selected.
        /// </remarks>
        [NonSerialized, UdonSynced]
        public sbyte index;

#pragma warning disable IDE0044
        /// <summary>
        /// The toggle group component to synchronize the value.
        /// </summary>
        [SerializeField]
        [Tooltip("Specify the toggle group to synchronize.")]
        private ToggleGroup toggleGroup;

        /// <summary>
        /// The toggles components to synchronize the value.
        /// </summary>
        /// <remarks>Up to 128 toggles can be synchronized.</remarks>
        [SerializeField, Tooltip("Specify the toggle to synchronize.")]
        private Toggle[] toggles;
#pragma warning restore IDE0044

        /// <summary>The callback when the value is changed.</summary>
        public void OnValueChanged()
        {
            if (!toggleGroup)
            {
                return;
            }
            SetValue((sbyte)GetComponentIndex());
        }

        public void SetValue(sbyte index)
        {
            if (!toggleGroup)
            {
                return;
            }
            if (this.index != index)
            {
                UpdateView();
            }
            if (this.index != index)
            {
                ChangeOwner();
                this.index = index;
                Sync();
            }
        }

        /// <summary>Initialize the object.</summary>
        protected override void Initialize()
        {
            if (!toggleGroup)
            {
                Log.Warn(WARN_NO_TOGGLE_GROUP);
                return;
            }
            if (IsOwner())
            {
                index = (sbyte)GetComponentIndex();
            }
        }

        /// <summary>
        /// The callback to update the view,
        /// e.g. on synchronized the value.
        /// </summary>
        protected override void UpdateView()
        {
            if (toggleGroup &&
                toggleGroup.allowSwitchOff &&
                index < 0 || index >= toggles.Length)
            {
                toggleGroup.SetAllTogglesOff();
            }
            var toggle = toggles[index];
            if (toggle && !toggle.isOn)
            {
                toggle.isOn = true;
            }
        }

        /// <summary>
        /// Get the index of the selected toggle.
        /// </summary>
        /// <returns>
        /// The index of the selected toggle.
        /// When no toggle is selected, returns -1.
        /// </returns>
        private int GetComponentIndex()
        {
            for (int i = toggles.Length; --i >= 0;)
            {
                if (toggles[i].isOn)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
