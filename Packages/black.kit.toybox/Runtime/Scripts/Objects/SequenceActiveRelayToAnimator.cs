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
    public sealed class SequenceActiveRelayToAnimator : UdonSharpBehaviour
    {
        /// <summary>The property name of the animator.</summary>
        public const string NAME_ANIMATOR = nameof(animator);

#pragma warning disable IDE0044
        /// <summary>
        /// The animator component to relay the active state.
        /// </summary>
        [SerializeField]
        [Tooltip("Specify the animator component to relay the active state.")]
        private Animator animator;

        /// <summary>
        /// The event type to relay the active state.
        /// </summary>
        [SerializeField]
        [Tooltip("Specify the event type to relay the active state.")]
        private ActiveRelayToAnimatorEventType eventType;

        /// <summary>The triggers parameter name of the animator.</summary>
        [SerializeField]
        [Tooltip("Specify the triggers parameter name of the animator.")]
        private string[] triggersName;

        /// <summary>The bool parameter name of the animator.</summary>
        [SerializeField]
        [Tooltip("Specify the bool parameter name of the animator.")]
        private string boolName;

        /// <summary>The bool sequence.</summary>
        [SerializeField]
        [Tooltip("Specify the bool sequence.")]
        private bool[] boolSequence;

        /// <summary>The int parameter name of the animator.</summary>
        [SerializeField]
        [Tooltip("Specify the int parameter name of the animator.")]
        private string intName;

        /// <summary>The int sequence.</summary>
        [SerializeField]
        [Tooltip("Specify the int sequence.")]
        private int[] intSequence;

        /// <summary>The float parameter name of the animator.</summary>
        [SerializeField]
        [Tooltip("Specify the float parameter name of the animator.")]
        private string floatName;

        /// <summary>The float sequence.</summary>
        [SerializeField]
        [Tooltip("Specify the float sequence.")]
        private float[] floatSequence;
#pragma warning restore IDE0044
        /// <summary>
        /// The IDs of the triggers parameter name of the animator.
        /// </summary>
        private int[] idsTriggers;

        /// <summary>
        /// The ID of the bool parameter name of the animator.
        /// </summary>
        private int idBool;

        /// <summary>
        /// The ID of the int parameter name of the animator.
        /// </summary>
        private int idInt;

        /// <summary>
        /// The ID of the float parameter name of the animator.
        /// </summary>
        private int idFloat;

        /// <summary>Initialized the hashes.</summary>
        private bool initialized;

        /// <summary>The index of the sequence.</summary>
        private int index;

        /// <summary>Initialize the hashes.</summary>
        private void Initialize()
        {
            if (!animator || initialized)
            {
                return;
            }
            idsTriggers = new int[triggersName.Length];
            for (var i = triggersName.Length; --i >= 0;)
            {
                idsTriggers[i] = Animator.StringToHash(triggersName[i]);
            }
            if (!string.IsNullOrEmpty(boolName))
            {
                idBool = Animator.StringToHash(boolName);
            }
            if (!string.IsNullOrEmpty(intName))
            {
                idInt = Animator.StringToHash(intName);
            }
            if (!string.IsNullOrEmpty(floatName))
            {
                idFloat = Animator.StringToHash(floatName);
            }
            initialized = true;
        }

        /// <summary>Update the sequence.</summary>
        private void Sequence()
        {
            if (!animator)
            {
                return;
            }
            if (!initialized)
            {
                Initialize();
            }
            if (idsTriggers.Length > 0)
            {
                animator.SetTrigger(
                    idsTriggers[index % idsTriggers.Length]);
            }
            if (!string.IsNullOrEmpty(boolName))
            {
                animator.SetBool(idBool, boolSequence[index % boolSequence.Length]);
            }
            if (!string.IsNullOrEmpty(intName))
            {
                animator.SetInteger(idInt, intSequence[index % intSequence.Length]);
            }
            if (!string.IsNullOrEmpty(floatName))
            {
                animator.SetFloat(idFloat, floatSequence[index % floatSequence.Length]);
            }
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
