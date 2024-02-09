using UnityEditor;

namespace black.kit.toybox.Editor
{
    /// <summary>The inspector of the <see cref="ObserverHub"/>.</summary>
    [CustomEditor(typeof(ObserverHub))]
    public sealed class ObserverHubEditor : EditorBase<ObserverHub>
    {
        /// <summary>Initialize the editor.</summary>
        public ObserverHubEditor() : base(
            details: L10n.Tr(T.DETAIL_OBSERVER_HUB))
        {
        }

        /// <summary>The warning of the inspector.</summary>
        private readonly string[] warnings =
            new[] {
                T.WARN_CIRCULAR_REFERENCE,
                T.WARN_AVOID_EMPTY_ARRAY,
            };

        /// <summary>The callback to draw the inspector GUI.</summary>
        public override void OnInspectorGUI()
        {
            DrawBanner();
            DrawDetails();
            base.OnInspectorGUI();
            DrawList(warnings);
        }
    }
}
