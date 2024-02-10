using System;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace black.kit.toybox
{
    /// <summary>
    /// The component synchronizes the value of the Slider UI component.
    /// </summary>
    [AddComponentMenu("UdonSharp Toybox/Global/Global Slider")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public sealed class GlobalSlider : SyncBehaviour
    {
        /// <summary>The property name of the Slider component.</summary>
        public const string NAME_SLIDER = nameof(slider);

        /// <summary>
        /// The warning message when the Slider component is not found.
        /// </summary>
        private const string WARN_NO_SLIDER =
            "Slider component is not found.";

        /// <summary>The value to synchronize.</summary>
        [NonSerialized, UdonSynced]
        public float value;

#pragma warning disable IDE0044
        /// <summary>
        /// The slider component to synchronize the value.
        /// </summary>
        [SerializeField, Tooltip("Specify the slider to synchronize.")]
        private Slider slider;
#pragma warning restore IDE0044

        /// <summary>The callback when the value is changed.</summary>
        public void OnValueChanged()
        {
            if (slider == null)
            {
                return;
            }
            SetValue(slider.value);
        }

        /// <summary>Set the value to the slider.</summary>
        /// <param name="value">The value to set.</param>
        public void SetValue(float value)
        {
            if (slider == null)
            {
                return;
            }
            if (!Mathf.Approximately(slider.value, value))
            {
                UpdateView();
            }
            if (!Mathf.Approximately(this.value, value))
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
            if (slider)
            {
                slider.value = value;
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
            if (!slider)
            {
                Log.Warn(WARN_NO_SLIDER);
                return;
            }
            if (IsOwner())
            {
                value = slider.value;
            }
        }
#pragma warning restore IDE0051
    }
}
