using System;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace black.kit.toybox
{
    /// <summary>
    /// The component synchronizes the value of the Slider UI component.
    /// </summary>
    /// <remarks>
    /// Usage (in the inspector of Unity Editor):
    /// <list type="number">
    /// <item>
    /// <description>
    /// Add this component on the same object as the Slider component.
    /// If the component is not found on the same object, you should
    /// specify the Slider component in the <c>Slider</c> field.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Set the following to <c>OnValueChanged (Single)</c> of the tied
    /// Slider component.
    /// </description>
    /// </item>
    /// </list>
    /// <list type="table">
    /// <item>
    /// <term>Emission</term>
    /// <description>Runtime Only</description>
    /// </item>
    /// <item>
    /// <term>Reference</term>
    /// <description>Specify this component in hierarchy</description>
    /// </item>
    /// <item>
    /// <term>Function</term>
    /// <description>
    /// <c>UdonBehaviour.SendCustomEvent (string)</c>
    /// </description>
    /// </item>
    /// <item>
    /// <term>Argument</term>
    /// <description><c>OnValueChanged</c></description>
    /// </item>
    /// </list>
    /// </remarks>
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
            if (!Mathf.Approximately(this.value, value))
            {
                ChangeOwner();
                this.value = value;
                Sync();
            }
        }

        /// <summary>Initialize the object.</summary>
        protected override void Initialize()
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
    }
}
