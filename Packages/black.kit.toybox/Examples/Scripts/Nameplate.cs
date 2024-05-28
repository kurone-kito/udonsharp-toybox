using UdonSharp;
using UnityEngine.UI;
using VRC.SDKBase;

namespace black.kit.toybox.Examples
{
    /// <summary>
    /// The component updates the text component with the player's name.
    /// </summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public sealed class Nameplate : UdonSharpBehaviour
    {
        /// <summary>
        /// The warning message when no text component is found.
        /// </summary>
        private const string WARN_TEXT_NOT_FOUND =
            "No text component is found.";

#pragma warning disable IDE0051
        /// <summary>
        /// Update the target transform when the component is started.
        /// </summary>
        private void Start()
        {
            var text = GetComponent<Text>();
            if (text)
            {
                text.text = Networking.LocalPlayer.GetPlayerName();
            }
            else
            {
                Log.Warn(WARN_TEXT_NOT_FOUND);
            }
        }
#pragma warning restore IDE0051
    }
}
