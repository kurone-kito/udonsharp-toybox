using UdonSharp;
using UnityEditor;
using UnityEngine;

namespace black.kit.toybox.Editor
{
    /// <summary>
    /// The base inspector of the active relay components.
    /// </summary>
    /// <typeparam name="Tb">The type of the target.</typeparam>
    public abstract class ActiveRelayEditorBase<Tb> : EditorBase<Tb>
        where Tb : UdonSharpBehaviour
    {
        /// <summary>Initialize the editor.</summary>
        public ActiveRelayEditorBase(string details) : base(details)
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
                ActiveRelayToAnimationBase.NAME_ANIMATOR);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
