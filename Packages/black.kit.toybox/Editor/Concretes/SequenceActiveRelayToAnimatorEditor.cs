using UnityEditor;
using UnityEngine;

namespace black.kit.toybox.Editor
{
    /// <summary>
    /// The inspector of the <see cref="SequenceActiveRelayToAnimator"/>.
    /// </summary>
    [CustomEditor(typeof(SequenceActiveRelayToAnimator))]
    public class SequenceActiveRelayToAnimatorEditor : EditorBase<SequenceActiveRelayToAnimator>
    {
        /// <summary>Initialize the editor.</summary>
        public SequenceActiveRelayToAnimatorEditor()
            : base(L10n.Tr(T.DETAIL_SEQUENCE_ACTIVE_RELAY_TO_ANIMATOR))
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
            EditorGUILayout.LabelField(L10n.Tr(T.USAGE_TO_ANIMATOR), style);
            EditorGUILayout.EndVertical();
            base.OnInspectorGUI();

            serializedObject.Update();
            AutoCompleteObject<Animator>(
                SequenceActiveRelayToAnimator.NAME_ANIMATOR);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
