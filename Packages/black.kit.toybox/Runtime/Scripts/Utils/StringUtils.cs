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
        /// <example>
        /// <code>
        /// <![CDATA[
        /// "bcd".AreAllCharsContained("abcde"); // true
        /// "bcd".AreAllCharsContained("bcd"); // true
        /// "abc".AreAllCharsContained("bcd"); // false
        /// "abc".AreAllCharsContained("def"); // false
        /// "".AreAllCharsContained("abc"); // true
        /// "abc".AreAllCharsContained(""); // false
        /// "abc".AreAllCharsContained(null); // false
        /// "".AreAllCharsContained(""); // true
        /// ]]>
        /// </code>
        /// </example>
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
                if (chars.IndexOf(c) < 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
