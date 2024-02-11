using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace black.kit.toybox.Editor
{
    /// <summary>The inspector of the <see cref="TickingDown"/>.</summary>
    [CustomEditor(typeof(TickingDown))]
    public sealed class TickingDownEditor : EditorBase<TickingDown>
    {
        /// <summary>Initialize the editor.</summary>
        public TickingDownEditor() : base(L10n.Tr(T.DETAIL_TICKING_DOWN))
        {
        }

        /// <summary>The callback to draw the inspector GUI.</summary>
        public override void OnInspectorGUI()
        {
            DrawBanner();
            DrawDetails();
            EditorGUILayout.BeginVertical(GUI.skin.box);
            var style = defaultStyle.Value;
            EditorGUILayout.LabelField(L10n.Tr(T.USAGE_COMPONENT), style);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField(
                L10n.Tr(T.USAGE_TICKING_DOWN), style);
            EditorGUILayout.EndVertical();
            base.OnInspectorGUI();

            serializedObject.Update();
            AutoCompleteObject<Text>(TickingDown.NAME_TEXT);
            AutoCompleteObject<TextMeshProUGUI>(TickingDown.NAME_TEXT_MESH);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
