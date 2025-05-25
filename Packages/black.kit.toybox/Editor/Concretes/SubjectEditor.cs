using UnityEditor;

namespace black.kit.toybox.Editor
{
    /// <summary>The inspector of the <see cref="Subject"/>.</summary>
    [CustomEditor(typeof(Subject))]
    public sealed class SubjectEditor : EditorBase<Subject>
    {
        /// <summary>Initialize the editor.</summary>
        public SubjectEditor() : base(L10n.Tr(T.DETAIL_SUBJECT))
        {
        }

        /// <summary>Called after drawing the default inspector.</summary>
        protected override void OnAfterInspectorGUI()
        {
            EditorGUILayout.LabelField(
                L10n.Tr(T.WARN_AVOID_EMPTY_ARRAY), defaultStyle.Value);
        }
    }
}
