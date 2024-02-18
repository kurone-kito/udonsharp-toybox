using UdonSharp;
using UnityEngine;

namespace black.kit.toybox
{
    /// <summary>
    /// The event type to relay the active state.
    /// </summary>
    public enum ActiveRelayToAnimatorEventType
    {
        Active,
        Inactive,
        ActiveAndInactive,
    }

    /// <summary>
    /// This component transfers parameters to the Animator component of
    /// the specified object according to a predetermined sequence when
    /// the active state changes.
    /// </summary>
    [AddComponentMenu("UdonSharp Toybox/Object/Sequence Active Relay To Animator")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public sealed class SequenceActiveRelayToAnimator : ActiveRelayToAnimationBase
    {
#pragma warning disable IDE0044
        /// <summary>The triggers parameter name of the animator.</summary>
        [SerializeField]
        [Tooltip("Specify the triggers parameter name of the animator.")]
        private string[] triggerNames;

        /// <summary>The bool sequence.</summary>
        [SerializeField]
        [Tooltip("Specify the bool sequence.")]
        private bool[] boolSequence;

        /// <summary>The int sequence.</summary>
        [SerializeField]
        [Tooltip("Specify the int sequence.")]
        private int[] intSequence;

        /// <summary>The float sequence.</summary>
        [SerializeField]
        [Tooltip("Specify the float sequence.")]
        private float[] floatSequence;

        /// <summary>
        /// The event type to relay the active state.
        /// </summary>
        [SerializeField]
        [Tooltip("Specify the event type to relay the active state.")]
        private ActiveRelayToAnimatorEventType eventType;
#pragma warning restore IDE0044
        /// <summary>
        /// The IDs of the triggers parameter name of the animator.
        /// </summary>
        private int[] idsTriggers;

        /// <summary>The index of the sequence.</summary>
        private int index;

        /// <summary>The current bool value of the animator.</summary>
        protected override bool CurrentBool => boolSequence.At(index);

        /// <summary>The current float value of the animator.</summary>
        protected override float CurrentFloat => floatSequence.At(index);

        /// <summary>The current integer value of the animator.</summary>
        protected override int CurrentInt => intSequence.At(index);

        /// <summary>
        /// Initialize the hashes of the triggers parameter name.
        /// </summary>
        protected override void PostInitialize()
        {
            idsTriggers = CreateParameterIds(triggerNames);
        }

        /// <summary>
        /// Update the sequence of the triggers parameter name.
        /// </summary>
        protected override void PostSequence()
        {
            SetTrigger(index, triggerNames, idsTriggers);
            index++;
        }

#pragma warning disable IDE0051
        /// <summary>
        /// Update the target transform when the component is disabled.
        /// </summary>
        private void OnDisable()
        {
            switch (eventType)
            {
                case ActiveRelayToAnimatorEventType.Inactive:
                case ActiveRelayToAnimatorEventType.ActiveAndInactive:
                    Sequence();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Update the target transform when the component is enabled.
        /// </summary>
        private void OnEnable()
        {
            switch (eventType)
            {
                case ActiveRelayToAnimatorEventType.Active:
                case ActiveRelayToAnimatorEventType.ActiveAndInactive:
                    Sequence();
                    break;
                default:
                    break;
            }
        }
#pragma warning restore IDE0051
    }
}
