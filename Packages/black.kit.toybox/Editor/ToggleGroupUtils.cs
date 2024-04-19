using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine.UI;

namespace black.kit.toybox.Editor
{
    /// <summary>
    /// The utility class for the <see cref="ToggleGroup"/>.
    /// </summary>
    public static class ToggleGroupUtils
    {
        /// <summary>
        /// The toggle group for get the toggles list name.
        /// </summary>
        private sealed class TG : ToggleGroup {
            /// <summary>
            /// The name of the <see cref="ToggleGroup.m_Toggles"/>.
            /// </summary>
            internal const string NAME = nameof(m_Toggles);
        }

        /// <summary>
        /// The field info of the <see cref="ToggleGroup.m_Toggles"/>.
        /// </summary>
        private static readonly FieldInfo toggles;

        /// <summary>
        /// Initialize the <see cref="ToggleGroupUtils"/> class.
        /// </summary>
        static ToggleGroupUtils()
        {
            var flags = BindingFlags.Instance | BindingFlags.NonPublic;
            toggles = typeof(ToggleGroup).GetField(TG.NAME, flags);
        }

        /// <summary>
        /// Get the toggles of the <paramref name="group"/>.
        /// </summary>
        /// <param name="group">The toggle group.</param>
        /// <returns>The toggles of the <paramref name="group"/>.</returns>
        public static Toggle[] GetToggles(this ToggleGroup group) =>
            (group ? toggles?.GetValue(group) as List<Toggle> : null)
                ?.OrderBy(toggle => toggle.transform.GetSiblingIndex())
                ?.ToArray();
    }
}
