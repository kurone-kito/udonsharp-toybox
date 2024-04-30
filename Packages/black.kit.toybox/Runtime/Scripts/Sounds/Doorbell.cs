using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

namespace black.kit.toybox
{
    /// <summary>
    /// The component plays the notify sound when the player joins the
    /// world.
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
    /// Specify the audio source to play the notify sound.
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    [AddComponentMenu("UdonSharp Toybox/Sounds/Doorbell")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public sealed class Doorbell : UdonSharpBehaviour
    {
        /// <summary>
        /// The property name of the AudioSource component.
        /// </summary>
        public const string NAME_SOURCE = nameof(source);

        /// <summary>
        /// The warning message when the AudioSource component is not found.
        /// </summary>
        private const string WARN_NO_AUDIO_SOURCE =
            "AudioSource component is not found.";

#pragma warning disable IDE0044
        /// <summary>
        /// The audio source component to play the notify sound.
        /// </summary>
        [SerializeField, Tooltip("Specify the audio source to play.")]
        private AudioSource source;
#pragma warning restore IDE0044

        /// <summary>
        /// Play the notify sound when the player joins the world.
        /// </summary>
        /// <param name="player">The player who joined the world.</param>
        public override void OnPlayerJoined(VRCPlayerApi player)
        {
            if (!player.isLocal && source)
            {
                source.Play();
            }
        }

#pragma warning disable IDE0051
        /// <summary>
        /// Update the target transform when the component is started.
        /// </summary>
        private void Start()
        {
            if (!source)
            {
                Log.Warn(WARN_NO_AUDIO_SOURCE);
            }
        }
#pragma warning restore IDE0051
    }
}
