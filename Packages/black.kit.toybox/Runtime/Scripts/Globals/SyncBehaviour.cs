using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

namespace black.kit.toybox
{
    /// <summary>
    /// <para>
    /// Abstract class with helper methods for synchronization.
    /// </para>
    /// <para>
    /// You can extend this class to implement synchronization classes.
    /// </para>
    /// </summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public abstract class SyncBehaviour : UdonSharpBehaviour
    {
        /// <summary>The property name of the Subject component.</summary>
        public const string NAME_SUBJECT = nameof(subject);

        /// <summary>
        /// Error messages in incomplete synchronization requirements.
        /// </summary>
        private const string ERR_INVALID_SYNC =
            "Aborted to syncing: A non-owner player attempted to synchronize.";

#pragma warning disable IDE0044
        /// <summary>The subject when synchronizing.</summary>
        [SerializeField]
        [Tooltip("(Optional) Specify the subject to synchronize.")]
        private Subject subject;
#pragma warning restore IDE0044

        /// <summary>
        /// The flag that indicates whether the object is initialized.
        /// </summary>
        protected bool Initialized { get; private set; }

        /// <summary>Change the object owner to the local player.</summary>
        public virtual void ChangeOwner()
        {
            var player = Networking.LocalPlayer;
            if (!(player == null || IsOwner()))
            {
                Networking.SetOwner(player, gameObject);
            }
        }

        /// <summary>Starts the syncing.</summary>
        public virtual void Sync()
        {
            if (!IsOwner())
            {
                Log.Warn(ERR_INVALID_SYNC);
                return;
            }
            RequestSerialization();
            UpdateView();
            if (subject)
            {
                subject.Notify();
            }
        }

        /// <summary>The callback when completed to synchronize.</summary>
        public override void OnDeserialization()
        {
            UpdateView();
            if (subject)
            {
                subject.Notify();
            }
        }

        /// <summary>The callback when a player joins.</summary>
        /// <param name="player">The player who joined</param>
        public override void OnPlayerJoined(VRCPlayerApi player)
        {
            if (IsOwner())
            {
                Sync();
            }
        }

        /// <summary>Determines if the local player is the owner.</summary>
        /// <returns>True if the local player is the owner</returns>
        public virtual bool IsOwner()
        {
            var player = Networking.LocalPlayer;
            // If the player is null, the owner is the local player.
            return player == null || Networking.IsOwner(player, gameObject);
        }

        /// <summary>
        /// Update the view when the component is enabled.
        /// </summary>
        protected virtual void OnEnable()
        {
            InitializeWhenFirst();
            UpdateView();
        }

        /// <summary>Implement to initialize the view.</summary>
        protected abstract void Initialize();

        /// <summary>Implement to update the view.</summary>
        /// <remarks>
        /// The OnDeserialization method cannot be called explicitly.
        /// Therefore, instead, override this method to update the view.
        /// </remarks>
        protected abstract void UpdateView();

        /// <summary>
        /// Initialize the object when it is first started.
        /// </summary>
        private void InitializeWhenFirst()
        {
            if (!Initialized)
            {
                Initialize();
                Initialized = true;
            }
        }
    }
}
