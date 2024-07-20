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
    public sealed class TickingDown : IntervalBase
    {
        /// <summary>The property name of the format.</summary>
        public const string NAME_TEXT = nameof(text);

        /// <summary>The property name of the format.</summary>
        public const string NAME_TEXT_MESH = nameof(textMesh);

#pragma warning disable IDE0044
        /// <summary>The format to display the date and time.</summary>
        [SerializeField]
        [Tooltip("Specify the format to display the date and time.")]
        private string format = "yyyy-MM-ddTHH:mm:ss";

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

        /// <summary>Update the view of the UI.</summary>
        public override void UpdateView()
        {
            var now = DateTime.Now.ToString(format);
            if (text)
            {
                text.text = now;
            }
            if (textMesh)
            {
                textMesh.text = now;
            }
        }

        /// <summary>Validate the inspector.</summary>
        /// <returns>Whether the inspectors are valid.</returns>
        protected override bool ValidateInspector() => text || textMesh;
    }
}
