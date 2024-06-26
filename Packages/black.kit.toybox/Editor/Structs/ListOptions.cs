using System;
using UnityEditor;
using UnityEngine;

namespace black.kit.toybox.Editor
{
    /// <summary>The options of the list of the inspector.</summary>
    public readonly struct ListOptions
    {
        /// <summary>The list is ordered.</summary>
        public bool Ordered { get; init; }

        /// <summary>The list is selectable.</summary>
        public bool Selectable { get; init; }

        /// <summary>The translation function.</summary>
        public Func<string, string> Tr { get; init; }

        /// <summary>
        /// Initialize the options of the list of the inspector.
        /// </summary>
        /// <param name="ordered">The list is ordered.</param>
        /// <param name="selectable">The list is selectable.</param>
        public ListOptions(
            bool ordered = false,
            bool selectable = false,
            Func<string, string> tr = null)
        {
            Ordered = ordered;
            Selectable = selectable;
            Tr = tr ?? L10n.Tr;
        }

        /// <summary>
        /// Deconstruct the options of the list of the inspector.
        /// </summary>
        /// <param name="ordered">The list is ordered.</param>
        /// <param name="selectable">The list is selectable.</param>
        public readonly void Deconstruct(
            out bool ordered, out bool selectable)
        {
            ordered = Ordered;
            selectable = Selectable;
        }

        /// <summary>
        /// Create the action to put the item to the inspector.
        /// </summary>
        /// <param name="style">The style of the item.</param>
        /// <returns>The action to put the item to the inspector.</returns>
        public readonly Action<string, int> CreatePutItem(GUIStyle style)
        {
            Action<string> output = Selectable
                ? item => EditorGUILayout.SelectableLabel(item, style)
                : item => EditorGUILayout.LabelField(item, style);
            var tr = Tr ?? L10n.Tr; // Countermeasures to CS1673
            Func<string, int, string> getText = Ordered
                ? (item, index) => $"{index + 1}.{tr(item)}"
                : (item, _) => tr(item);
            return (name, index) => output(getText(name, index));
        }
    }
}
