using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace black.kit.toybox
{
    /// <summary>
    /// This component works with the Toggle component to perform animation
    /// when toggling on and off.
    /// </summary>
    /// <remarks>
    /// Usage (in the inspector of Unity Editor):
    /// <list type="number">
    /// <item>
    /// <description>
    /// Add this component on the same object as the Animator component.
    /// If the component is not found on the same object, you should
    /// specify the Animator component in the <c>Animator</c> field.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Deploy this component on the same object as the Toggle component or
    /// manually link it.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Set the following to <c>OnValueChanged (Boolean)</c> of the tied
    /// Toggle component.
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
    [AddComponentMenu("UdonSharp Toybox/Animation/Toggle With Animator")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public sealed class ToggleWithAnimator : UdonSharpBehaviour
    {
        /// <summary>The property name of the animator.</summary>
        public const string NAME_ANIMATOR = nameof(animator);

        /// <summary>The property name of the parameter.</summary>
        public const string NAME_PARAMETER = nameof(parameter);

        /// <summary>The property name of the toggle.</summary>
        public const string NAME_TOGGLE = nameof(toggle);

#pragma warning disable IDE0044
        /// <summary>The animator of the toggle.</summary>
        [SerializeField, Tooltip("Specifies the animator.")]
        private Animator animator;

        /// <summary>The parameter name of the animator.</summary>
        [SerializeField, Tooltip("Specifies the parameter name.")]
        private string parameter;

        /// <summary>The toggle to be animated.</summary>
        [SerializeField, Tooltip("Specifies the toggle.")]
        private Toggle toggle;
#pragma warning restore IDE0044

        /// <summary>The parameter ID of the animator.</summary>
        private int parameterId;

        /// <summary>
        /// Callback for when the value of the toggle changes.
        /// </summary>
        public void OnValueChanged()
        {
            if (animator == null || string.IsNullOrEmpty(parameter))
            {
                return;
            }
            animator.SetBool(parameterId, toggle.isOn);
        }

#pragma warning disable IDE0051
        /// <summary>The callback when the object is enabled.</summary>
        private void OnEnable()
        {
            if (animator == null || string.IsNullOrEmpty(parameter))
            {
                return;
            }
            parameterId = Animator.StringToHash(parameter);
            animator.SetBool(parameterId, toggle.isOn);
        }
#pragma warning restore IDE0051
    }
}
