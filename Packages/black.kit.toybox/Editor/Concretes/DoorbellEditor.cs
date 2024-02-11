using UnityEditor;
using UnityEngine;

namespace black.kit.toybox.Editor
{
    /// <summary>The inspector of the <see cref="Doorbell"/>.</summary>
    [CustomEditor(typeof(Doorbell))]
    public class DoorbellEditor : EditorBase<Doorbell>
    {
        /// <summary>Initialize the editor.</summary>
        public DoorbellEditor() : base(L10n.Tr(T.DETAIL_DOORBELL))
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
            EditorGUILayout.LabelField(L10n.Tr(T.USAGE_DOORBELL), style);
            EditorGUILayout.EndVertical();
            base.OnInspectorGUI();

            serializedObject.Update();
            AutoCompleteObject<AudioSource>(Doorbell.NAME_SOURCE);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
