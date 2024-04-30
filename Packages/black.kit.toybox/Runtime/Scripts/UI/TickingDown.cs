using TMPro;
using System;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace black.kit.toybox
{
    /// <summary>
    /// This component can send date and time information with a low load
    /// to the Text or TextMeshProUGUI uGUI component.
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
    /// Specify the Text (and|or) TextMeshProUGUI component to display the
    /// date and time.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Specify the format to display the date and time.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Specify the interval to update the date and time.
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    [AddComponentMenu("UdonSharp Toybox/UI/Ticking Down")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public sealed class TickingDown : UdonSharpBehaviour
    {
        /// <summary>The property name of the format.</summary>
        public const string NAME_TEXT = nameof(text);

        /// <summary>The property name of the format.</summary>
        public const string NAME_TEXT_MESH = nameof(textMesh);

        /// <summary>
        /// The warning message when the Text component is not found.
        /// </summary>
        private const string WARN_NO_TEXT = "Text component is not found.";

#pragma warning disable IDE0044
        /// <summary>The format to display the date and time.</summary>
        [SerializeField]
        [Tooltip("Specify the format to display the date and time.")]
        private string format = "yyyy-MM-ddTHH:mm:ss";

        /// <summary>The interval to update the date and time.</summary>
        /// <remarks>It ignores less than 0.01f.</remarks>
        [SerializeField, Range(0.01f, 60f)]
        [Tooltip("Specify the interval to update the date and time by seconds. It ignores less than 0.01f.")]
        private float interval = 1f;

        /// <summary>
        /// The text component to display the date and time.
        /// </summary>
        [SerializeField]
        [Tooltip("Specify the text to display the date and time.")]
        private Text text;

        /// <summary>
        /// The text mesh component to display the date and time.
        /// </summary>
        [SerializeField]
        [Tooltip("Specify the text mesh to display the date and time.")]
        private TextMeshProUGUI textMesh;
#pragma warning restore IDE0044

        /// <summary>The callback to update the date and time.</summary>
        /// <remarks>
        /// This method is automatically called from within.
        /// <em>DO NOT CALL IT DIRECTLY</em>; it'll duplicate the calling
        /// cycle and can result in overloading.
        /// </remarks>
        public void Tick()
        {
            if (DetectNull())
            {
                return;
            }
            var now = DateTime.Now.ToString(format);
            if (text)
            {
                text.text = now;
            }
            if (textMesh)
            {
                textMesh.text = now;
            }
            var safeInterval = Mathf.Max(interval, 0.01f);
            SendCustomEventDelayedSeconds(nameof(Tick), safeInterval);
        }

        /// <summary>
        /// Determine whether the Text or TextMeshProUGUI component is null.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the Text or TextMeshProUGUI component is null;
        /// otherwise, <c>false</c>.
        /// </returns>
        private bool DetectNull()
        {
            var result = !(text || textMesh);
            if (result)
            {
                Log.Warn(WARN_NO_TEXT);
            }
            return result;
        }

#pragma warning disable IDE0051
        /// <summary>The callback when the object is enabled.</summary>
        void Start() => Tick();
#pragma warning restore IDE0051
    }
}
