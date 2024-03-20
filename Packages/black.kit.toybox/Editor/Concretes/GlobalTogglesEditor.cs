using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace black.kit.toybox.Editor
{
    /// <summary>The inspector of the <see cref="GlobalToggles"/>.</summary>
    [CustomEditor(typeof(GlobalToggles))]
    public sealed class GlobalTogglesEditor
        : GlobalUIEditorBase<GlobalToggles>
    {
        /// <summary>
        /// The field info of the <see cref="ToggleGroup.m_Toggles"/>.
        /// </summary>
        private FieldInfo togglesFieldInfo;

        /// <summary>Initialize the editor.</summary>
        public GlobalTogglesEditor() : base(
            details: L10n.Tr(T.DETAIL_GLOBAL_TOGGLES),
            usage: new[]
                {
                    T.USAGE_GLOBAL_TOGGLES_0,
                    T.USAGE_GLOBAL_TOGGLES_1
                },
            argument: T.USAGE_ON_VALUE_CHANGED)
        {
        }

        /// <summary>
        /// The field info of the <see cref="ToggleGroup.m_Toggles"/>.
        /// </summary>
        private FieldInfo ToggleFieldInfo
        {
            get
            {
                if (togglesFieldInfo == null)
                {
                    var flags =
                        BindingFlags.Instance |
                        BindingFlags.NonPublic;
                    togglesFieldInfo = typeof(ToggleGroup).GetField(
                        "m_Toggles",
                        flags);
                }
                return togglesFieldInfo;
            }
        }

        /// <summary>The callback to draw the inspector GUI.</summary>
        public override void OnInspectorGUI()
        {
            DrawBanner();
            DrawDetails();
            DrawUsage();
            base.OnInspectorGUI();

            serializedObject.Update();
            var group = AutoCompleteObject<ToggleGroup>(
                GlobalToggles.NAME_TOGGLE_GROUP);
            if (group &&
                ToggleFieldInfo?.GetValue(group) is List<Toggle> list)
            {
                var prop = serializedObject.FindProperty(
                GlobalToggles.NAME_TOGGLES);
                if (prop.arraySize != list.Count)
                {
                    prop.arraySize = list.Count;
                }
                list.Sort((a, b) => a.GetComponent<Transform>()
                    .GetSiblingIndex().CompareTo(
                        b.GetComponent<Transform>().GetSiblingIndex()));
                for (var i = list.Count; --i >= 0;)
                {
                    prop.GetArrayElementAtIndex(i).objectReferenceValue =
                        list[i];
                }
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}
