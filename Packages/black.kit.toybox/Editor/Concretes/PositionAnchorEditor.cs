using UnityEditor;

namespace black.kit.toybox.Editor
{
    /// <summary>The inspector of the <see cref="PositionAnchor"/>.</summary>
    [CustomEditor(typeof(PositionAnchor))]
    public sealed class PositionAnchorEditor : EditorBase<PositionAnchor>
    {
        /// <summary>Initialize the editor.</summary>
        public PositionAnchorEditor()
            : base(L10n.Tr(T.DETAIL_POSITION_ANCHOR))
        {
        }
    }
}
