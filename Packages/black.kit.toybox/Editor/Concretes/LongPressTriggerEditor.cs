using UnityEditor;

namespace black.kit.toybox.Editor
{
    /// <summary>
    /// The inspector of the <see cref="LongPressTrigger"/>.
    /// </summary>
    [CustomEditor(typeof(LongPressTrigger))]
    public sealed class LongPressTriggerEditor : EditorBase<LongPressTrigger>
    {
        /// <summary>Initialize the editor.</summary>
        public LongPressTriggerEditor() : base(
            details: L10n.Tr(T.DETAIL_LONG_PRESS_TRIGGER))
        {
        }

        /// <summary>The callback to draw the inspector GUI.</summary>
        public override void OnInspectorGUI()
        {
            DrawBanner();
            DrawDetails();
            base.OnInspectorGUI();
        }
    }
}
