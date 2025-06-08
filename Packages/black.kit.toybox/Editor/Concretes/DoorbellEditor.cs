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

        /// <summary>Called before drawing the default inspector.</summary>
        protected override void OnBeforeInspectorGUI()
        {
            EditorGUILayout.BeginVertical(GUI.skin.box);
            var style = defaultStyle.Value;
            EditorGUILayout.LabelField(L10n.Tr(T.USAGE_COMPONENT), style);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField(L10n.Tr(T.USAGE_DOORBELL), style);
            EditorGUILayout.EndVertical();
        }

        /// <summary>Called after drawing the default inspector.</summary>
        protected override void OnAfterInspectorGUI()
        {
            serializedObject.Update();
            EnsureComponentAssigned<AudioSource>(Doorbell.NAME_SOURCE);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
