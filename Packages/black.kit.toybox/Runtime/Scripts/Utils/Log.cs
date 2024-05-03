using UnityEngine;

namespace black.kit.toybox
{
    /// <summary>The static class for logging.</summary>
    public static class Log
    {
        /// <summary>The default tag for logging.</summary>
        public const string DEFAULT_TAG = nameof(toybox);

        /// <summary>The default color for logging.</summary>
        public const string DEFAULT_COLOR = "red";

        /// <summary>
        /// Create a message with a tag and a color.
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="tag">specify the tag</param>
        /// <param name="color">specify the color</param>
        /// <returns>The message with a tag and a color</returns>
        /// <example>
        /// <code>
        /// Log.CreateMessage("Hello, World!");
        /// <![CDATA[ // "[<color=red>toybox</color>] Hello, World!" ]]>
        ///
        /// Log.CreateMessage("Hello, World!", "MyTag");
        /// <![CDATA[ // "[<color=red>MyTag</color>] Hello, World!" ]]>
        ///
        /// Log.CreateMessage("Hello, World!", "MyTag", "blue");
        /// <![CDATA[ // "[<color=blue>MyTag</color>] Hello, World!" ]]>
        /// </code>
        /// </example>
        public static string CreateMessage(
            string message,
            string tag = DEFAULT_TAG,
            string color = DEFAULT_COLOR)
            => $"[<color={color}>{tag}</color>] {message}";

        /// <summary>
        /// Log a message with a tag and a color.
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="tag">specify the tag</param>
        /// <param name="color">specify the color</param>
        /// <example>
        /// <code>
        /// Log.Info("Hello, World!");
        /// <![CDATA[ // ℹ️ Log: "[<color=red>toybox</color>] Hello, World!" ]]>
        ///
        /// Log.Info("Hello, World!", "MyTag");
        /// <![CDATA[ // ℹ️ Log: "[<color=red>MyTag</color>] Hello, World!" ]]>
        ///
        /// Log.Info("Hello, World!", "MyTag", "blue");
        /// <![CDATA[ // ℹ️ Log: "[<color=blue>MyTag</color>] Hello, World!" ]]>
        /// </code>
        /// </example>
        public static void Info(
            string message,
            string tag = DEFAULT_TAG,
            string color = DEFAULT_COLOR)
            => Debug.Log(CreateMessage(message, tag, color));

        /// <summary>
        /// Log a warning message with a tag and a color.
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="tag">specify the tag</param>
        /// <param name="color">specify the color</param>
        /// <example>
        /// <code>
        /// Log.Warn("Hello, World!");
        /// <![CDATA[ // ⚠️ Log: "[<color=red>toybox</color>] Hello, World!" ]]>
        ///
        /// Log.Warn("Hello, World!", "MyTag");
        /// <![CDATA[ // ⚠️ Log: "[<color=red>MyTag</color>] Hello, World!" ]]>
        ///
        /// Log.Warn("Hello, World!", "MyTag", "blue");
        /// <![CDATA[ // ⚠️ Log: "[<color=blue>MyTag</color>] Hello, World!" ]]>
        /// </code>
        /// </example>
        public static void Warn(
            string message,
            string tag = DEFAULT_TAG,
            string color = DEFAULT_COLOR)
            => Debug.LogWarning(CreateMessage(message, tag, color));

        /// <summary>
        /// Log a error message with a tag and a color.
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="tag">specify the tag</param>
        /// <param name="color">specify the color</param>
        /// <example>
        /// <code>
        /// Log.Error("Hello, World!");
        /// <![CDATA[ // 🛑 Log: "[<color=red>toybox</color>] Hello, World!" ]]>
        ///
        /// Log.Error("Hello, World!", "MyTag");
        /// <![CDATA[ // 🛑 Log: "[<color=red>MyTag</color>] Hello, World!" ]]>
        ///
        /// Log.Error("Hello, World!", "MyTag", "blue");
        /// <![CDATA[ // 🛑 Log: "[<color=blue>MyTag</color>] Hello, World!" ]]>
        /// </code>
        /// </example>
        public static void Error(
            string message,
            string tag = DEFAULT_TAG,
            string color = DEFAULT_COLOR)
            => Debug.LogError(CreateMessage(message, tag, color));
    }
}
