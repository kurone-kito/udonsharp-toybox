using UdonSharp;
using UnityEngine;

namespace black.kit.toybox
{
    /// <summary>
    /// This component transfers parameters to the Animator component of
    /// the specified object according to a predetermined sequence when
    /// the active state changes.
    /// </summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public abstract class ActiveRelayToAnimationBase : UdonSharpBehaviour
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

        /// <summary>The bool parameter name of the animator.</summary>
        [SerializeField]
        [Tooltip("Specify the bool parameter name of the animator.")]
        private string boolName;

        /// <summary>The float parameter name of the animator.</summary>
        [SerializeField]
        [Tooltip("Specify the float parameter name of the animator.")]
        private string floatName;

        /// <summary>The int parameter name of the animator.</summary>
        [SerializeField]
        [Tooltip("Specify the int parameter name of the animator.")]
        private string intName;
#pragma warning restore IDE0044
        /// <summary>
        /// The animator component to relay the active state.
        /// </summary>
        protected Animator Animator => animator;

        /// <summary>
        /// The ID of the bool parameter name of the animator.
        /// </summary>
        protected int IdBool { get; private set; }

        /// <summary>
        /// The ID of the float parameter name of the animator.
        /// </summary>
        protected int IdFloat { get; private set; }

        /// <summary>
        /// The ID of the int parameter name of the animator.
        /// </summary>
        protected int IdInt { get; private set; }

        /// <summary>Initialized the hashes.</summary>
        protected bool Initialized { get; private set; }

        /// <summary>Current boolean value of the animator.</summary>
        protected abstract bool CurrentBool { get; }

        /// <summary>Current float value of the animator.</summary>
        protected abstract float CurrentFloat { get; }

        /// <summary>Current integer value of the animator.</summary>
        protected abstract int CurrentInt { get; }

        /// <summary>Initialize the hashes.</summary>
        private void Initialize()
        {
            if (!Animator || Initialized)
            {
                return;
            }
            if (!string.IsNullOrEmpty(boolName))
            {
                IdBool = Animator.StringToHash(boolName);
            }
            if (!string.IsNullOrEmpty(floatName))
            {
                IdFloat = Animator.StringToHash(floatName);
            }
            if (!string.IsNullOrEmpty(intName))
            {
                IdInt = Animator.StringToHash(intName);
            }
            PostInitialize();
            Initialized = true;
        }

        /// <summary>Update the sequence.</summary>
        protected void Sequence()
        {
            if (!Animator)
            {
                return;
            }
            if (!Initialized)
            {
                Initialize();
            }
            if (!string.IsNullOrEmpty(boolName))
            {
                animator.SetBool(IdBool, CurrentBool);
            }
            if (!string.IsNullOrEmpty(floatName))
            {
                animator.SetFloat(IdFloat, CurrentFloat);
            }
            if (!string.IsNullOrEmpty(intName))
            {
                animator.SetInteger(IdInt, CurrentInt);
            }
            PostSequence();
        }

        /// <summary>Set the trigger of the animator.</summary>
        /// <param name="index">The index of the trigger.</param>
        /// <param name="names">The names of the triggers.</param>
        /// <param name="ids">The IDs of the triggers.</param>
        protected void SetTrigger(int index, string[] names, int[] ids)
        {
            if (ids.Length > 0 && !string.IsNullOrEmpty(names.At(index)))
            {
                Animator.SetTrigger(ids.At(index));
            }
        }

        /// <summary>Specifies more initialization.</summary>
        protected abstract void PostInitialize();

        /// <summary>Specifies more sequence.</summary>
        protected abstract void PostSequence();

        /// <summary>Create the IDs of the parameters.</summary>
        /// <param name="names">The names of the parameters.</param>
        /// <returns>The IDs of the parameters.</returns>
        protected static int[] CreateParameterIds(string[] names)
        {
            var ids = new int[names.Length];
            for (var i = names.Length; --i >= 0;)
            {
                var name = names[i];
                ids[i] =
                    string.IsNullOrEmpty(name)
                    ? default
                    : Animator.StringToHash(name);
            }
            return ids;
        }
    }
}
