namespace black.kit.toybox
{
    /// <summary>The utility class for strings</summary>
    public static class StringUtils
    {
        /// <summary>
        /// Determine whether the string contains all the characters
        /// in the specified string.
        /// </summary>
        /// <param name="target">String to be checked.</param>
        /// <param name="chars">
        /// String containing characters to be checked.
        /// </param>
        /// <returns>
        /// True if the string contains all the characters
        /// in the specified string,
        /// </returns>
        public static bool AreAllCharsContained(
            this string target, string chars)
        {
            if (string.IsNullOrEmpty(target))
            {
                return true;
            }
            if (string.IsNullOrEmpty(chars))
            {
                return false;
            }
            foreach (char c in target)
            {
                if (!chars.Contains(c.ToString()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
