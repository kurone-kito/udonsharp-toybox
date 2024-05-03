using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace black.kit.toybox.Editor
{
    /// <summary>
    /// The inspector of the <see cref="ToggleWithAnimator"/>.
    /// </summary>
    [CustomEditor(typeof(ToggleWithAnimator))]
    public sealed class ToggleWithAnimatorEditor
        : EditorBase<ToggleWithAnimator>
    {
        /// <summary>The usage of the target.</summary>
        private readonly string[] usage = new[]
        {
            T.USAGE_LINK_ANIMATOR,
            T.USAGE_LINK_TOGGLE,
            T.USAGE_GLOBAL_TOGGLE_1,
        };

        /// <summary>Initialize the editor.</summary>
        public ToggleWithAnimatorEditor()
            : base(L10n.Tr(T.DETAIL_TOGGLE_WITH_ANIMATOR))
        {
        }

        /// <summary>The callback to draw the inspector GUI.</summary>
        public override void OnInspectorGUI()
        {
            DrawBanner();
            DrawDetails();
            EditorGUILayout.BeginVertical(GUI.skin.box);
            DrawList(
                usage, new ListOptions() { Ordered = true, Tr = L10n.Tr });
            DrawUdonEvent(T.USAGE_ON_VALUE_CHANGED);
            EditorGUILayout.EndVertical();
            base.OnInspectorGUI();

            serializedObject.Update();
            var animator = AutoCompleteObject<Animator>(
                ToggleWithAnimator.NAME_ANIMATOR);
            var toggle = AutoCompleteObject<Toggle>(
                ToggleWithAnimator.NAME_TOGGLE);
            var param = serializedObject.FindProperty(
                ToggleWithAnimator.NAME_PARAMETER);
            if (animator)
            {
                animator.SetBool(
                    param.stringValue, toggle && toggle.isOn);
                animator.Update(Time.deltaTime * 100f);
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}
