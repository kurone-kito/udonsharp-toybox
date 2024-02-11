using VRC.SDKBase;

namespace black.kit.toybox
{
    /// <summary>The utility class forVRCPlayerApi.</summary>
    public static class PlayerUtils
    {
        /// <summary>Get the player name.</summary>
        /// <param name="player">Player instance.</param>
        /// <param name="fallback">Fallback name.</param>
        /// <returns>player name</returns>
        public static string GetPlayerName(
            this VRCPlayerApi player, string fallback = null)
        {
            var concretePlayer = player ?? Networking.LocalPlayer;
            return concretePlayer == null || !concretePlayer.IsValid()
                ? fallback
                : concretePlayer.displayName;
        }

        /// <summary>Get the safety player name.</summary>
        /// <remarks>
        /// Note: The fallback string returns <strong>WITHOUT</strong>
        /// validation.
        /// </remarks>
        /// <param name="player">Player instance.</param>
        /// <param name="safeCharset">
        /// String containing characters to be checked.
        /// </param>
        /// <param name="fallback">Fallback name.</param>
        /// <returns>player name</returns>
        public static string GetSafePlayerName(
            this VRCPlayerApi player, string safeCharset, string fallback = null)
        {
            var displayName = player.GetPlayerName(fallback);
            return displayName.AreAllCharsContained(safeCharset)
                ? displayName
                : fallback;
        }
    }
}
