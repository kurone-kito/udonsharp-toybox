using UnityEditor;

namespace black.kit.toybox.Editor
{
    /// <summary>The inspector of the <see cref="Whitelist"/>.</summary>
    [CustomEditor(typeof(Whitelist))]
    public sealed class WhitelistEditor : EditorBase<Whitelist>
    {
        /// <summary>Initialize the editor.</summary>
        public WhitelistEditor() : base(L10n.Tr(T.DETAIL_WHITELIST))
        {
        }

        /// <summary>The callback to draw the inspector GUI.</summary>
        public override void OnInspectorGUI()
        {
            DrawBanner();
            DrawDetails();
            base.OnInspectorGUI();
            EditorGUILayout.LabelField(
                L10n.Tr(T.WARN_AVOID_EMPTY_ARRAY), defaultStyle.Value);
        }
    }
}
