using System.Collections.Generic;
using UdonSharp;
using UnityEditor;
using UnityEngine;

namespace black.kit.toybox.Editor
{
    /// <summary>The base inspector of the global components.</summary>
    /// <typeparam name="Tb">The type of the target.</typeparam>
    public abstract class GlobalUIEditorBase<Tb> : EditorBase<Tb>
        where Tb : UdonSharpBehaviour
    {
        /// <summary>Initialize the editor.</summary>
        public GlobalUIEditorBase(
            string details,
            IEnumerable<string> usage,
            string argument) : base(details)
        {
            this.usage = usage;
            events = new[]
                {
                    T.USAGE_RUNTIME_ONLY,
                    T.USAGE_THIS_COMPONENT,
                    T.USAGE_SEND_CUSTOM_EVENT,
                    argument,
                };
        }

        /// <summary>The usage of the target.</summary>
        private readonly IEnumerable<string> usage;

        /// <summary>The events usage of the target.</summary>
        private readonly IEnumerable<string> events;

        /// <summary>Draw the usage of the component.</summary>
        protected void DrawUsage()
        {
            var style = defaultStyle.Value;
            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUILayout.LabelField(L10n.Tr(T.USAGE_COMPONENT), style);
            EditorGUILayout.Space();
            DrawList(usage);
            EditorGUI.indentLevel++;
            DrawList(events, selectable: true);
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();
        }
    }
}
