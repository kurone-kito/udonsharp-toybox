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

        /// <summary>Called before drawing the default inspector.</summary>
        protected override void OnBeforeInspectorGUI()
        {
            EditorGUILayout.BeginVertical(GUI.skin.box);
            var style = defaultStyle.Value;
            EditorGUILayout.LabelField(L10n.Tr(T.USAGE_COMPONENT), style);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField(L10n.Tr(T.USAGE_TO_ANIMATOR), style);
            EditorGUILayout.EndVertical();
        }

        /// <summary>Called after drawing the default inspector.</summary>
        protected override void OnAfterInspectorGUI()
        {
            serializedObject.Update();
            EnsureComponentAssigned<Animator>(
                ActiveRelayToAnimationBase.NAME_ANIMATOR);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
