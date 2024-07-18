using UdonSharp;
using UnityEngine;

namespace black.kit.toybox
{
    /// <summary>
    /// This component transfers parameters to the Animator component of
    /// the specified object according to a predetermined sequence when the
    /// active state changes. The significant difference from the
    /// <see cref="SequenceActiveRelayToAnimator"/> is that different
    /// states can be specified for each turn on and off.
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
    /// Specify the parameter names of the animator.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Specify the sequences.
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <seealso cref="SequenceActiveRelayToAnimator"/>
    [AddComponentMenu("UdonSharp Toybox/Animation/Conditional Active Relay To Animator")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public sealed class ConditionalActiveRelayToAnimator : ActiveRelayToAnimationBase
    {
#pragma warning disable IDE0044
        /// <summary>
        /// The triggers parameter name of the animator when disabled.
        /// </summary>
        [SerializeField]
        [Tooltip("Specify the triggers parameter name of the animator when disabled.")]
        private string[] triggersNameOnDisabled;

        /// <summary>
        /// The triggers parameter name of the animator when enabled.
        /// </summary>
        [SerializeField]
        [Tooltip("Specify the triggers parameter name of the animator when enabled.")]
        private string[] triggersNameOnEnabled;

        /// <summary>The bool sequence when disabled.</summary>
        [SerializeField]
        [Tooltip("Specify the bool sequence when disabled.")]
        private bool[] boolSequenceOnDisabled;

        /// <summary>The bool sequence when enabled.</summary>
        [SerializeField]
        [Tooltip("Specify the bool sequence when enabled.")]
        private bool[] boolSequenceOnEnabled;

        /// <summary>The float sequence when disabled.</summary>
        [SerializeField]
        [Tooltip("Specify the float sequence when disabled.")]
        private float[] floatSequenceOnDisabled;

        /// <summary>The float sequence when enabled.</summary>
        [SerializeField]
        [Tooltip("Specify the float sequence when enabled.")]
        private float[] floatSequenceOnEnabled;

        /// <summary>The int sequence when disabled.</summary>
        [SerializeField, Tooltip("Specify the int sequence when disabled.")]
        private int[] intSequenceOnDisabled;

        /// <summary>The int sequence when enabled.</summary>
        [SerializeField, Tooltip("Specify the int sequence when enabled.")]
        private int[] intSequenceOnEnabled;
#pragma warning restore IDE0044
        /// <summary>
        /// The IDs of the triggers parameter name of the animator when
        /// disabled.
        /// </summary>
        private int[] idsTriggersOnDisabled;

        /// <summary>
        /// The IDs of the triggers parameter name of the animator when
        /// enabled.
        /// </summary>
        private int[] idsTriggersOnEnabled;

        /// <summary>The index of the sequence when disabled.</summary>
        private int indexOnDisabled;

        /// <summary>The index of the sequence when enabled.</summary>
        private int indexOnEnabled;

        /// <summary>The current bool value of the animator.</summary>
        protected override bool CurrentBool =>
            gameObject.activeSelf
                ? boolSequenceOnEnabled.At(indexOnEnabled)
                : boolSequenceOnDisabled.At(indexOnDisabled);

        /// <summary>The current float value of the animator.</summary>
        protected override float CurrentFloat =>
            gameObject.activeSelf
                ? floatSequenceOnEnabled.At(indexOnEnabled)
                : floatSequenceOnDisabled.At(indexOnDisabled);

        /// <summary>The current integer value of the animator.</summary>
        protected override int CurrentInt =>
            gameObject.activeSelf
                ? intSequenceOnEnabled.At(indexOnEnabled)
                : intSequenceOnDisabled.At(indexOnDisabled);

        /// <summary>
        /// Initialize the hashes of the triggers parameter name.
        /// </summary>
        protected override void PostInitialize()
        {
            idsTriggersOnDisabled =
                CreateParameterIds(triggersNameOnDisabled);
            idsTriggersOnEnabled =
                CreateParameterIds(triggersNameOnEnabled);
        }

        /// <summary>
        /// Update the sequence of the triggers parameter name.
        /// </summary>
        protected override void PostSequence()
        {
            var active = gameObject.activeSelf;
            SetTrigger(
                active ? indexOnEnabled : indexOnDisabled,
                active ? triggersNameOnEnabled : triggersNameOnDisabled,
                active ? idsTriggersOnEnabled : idsTriggersOnDisabled);
            if (active)
            {
                indexOnEnabled++;
            }
            else
            {
                indexOnDisabled++;
            }
        }

#pragma warning disable IDE0051
        /// <summary>
        /// Update the target transform when the component is disabled.
        /// </summary>
        private void OnDisable() => Sequence();

        /// <summary>
        /// Update the target transform when the component is enabled.
        /// </summary>
        private void OnEnable() => Sequence();
#pragma warning restore IDE0051
    }
}
