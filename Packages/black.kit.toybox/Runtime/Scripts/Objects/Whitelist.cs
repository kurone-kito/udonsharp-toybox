using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

namespace black.kit.toybox
{
    /// <summary>
    /// <para>
    /// The allowlist to enable or disable the colliders and game objects.
    /// </para>
    /// <para>
    /// If local users are included in the allowlist, this component
    /// toggles between enabled and disabled states.
    /// </para>
    /// </summary>
    [AddComponentMenu("UdonSharp Toybox/Object/Whitelist")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public sealed class Whitelist : UdonSharpBehaviour
    {
#pragma warning disable IDE0044
        /// <summary>The display names of the allowlist.</summary>
        /// <remarks>It doesn't match the empty or null.</remarks>
        [SerializeField]
        [Tooltip("Specify the display name of the allowlist")]
        private string[] displayNames;

        /// <summary>
        /// Specify the colliders to flip the enabled state.
        /// </summary>
        /// <remarks>
        /// If local users are included in the allowlist, this component
        /// toggles between enabled and disabled states.
        /// </remarks>
        [SerializeField]
        [Tooltip("Specify the collider to enable or disable")]
        private Collider[] colliders;

        /// <summary>
        /// Specify the game objects to flip the enabled state.
        /// </summary>
        /// <remarks>
        /// If local users are included in the allowlist, this component
        /// toggles between enabled and disabled states.
        /// </remarks>
        [SerializeField]
        [Tooltip("Specify the game object to enable or disable")]
        private GameObject[] objects;
#pragma warning restore IDE0044

        /// <summary>Toggle the colliders.</summary>
        private void ToggleColliders()
        {
            foreach (var collider in colliders)
            {
                if (collider)
                {
                    collider.enabled = !collider.enabled;
                }
            }
        }

        /// <summary>Toggle the game objects.</summary>
        private void ToggleGameObjects()
        {
            foreach (var obj in objects)
            {
                if (obj)
                {
                    obj.SetActive(!obj.activeSelf);
                }
            }
        }

#pragma warning disable IDE0051
        /// <summary>The callback when the object is enabled.</summary>
        private void Start()
        {
            var name = Networking.LocalPlayer.GetPlayerName();
            if (!string.IsNullOrEmpty(name) && displayNames.Contains(name))
            {
                ToggleColliders();
                ToggleGameObjects();
            }
        }
#pragma warning restore IDE0051
    }
}
