using UnityEditor;
using UnityEngine.UI;

namespace black.kit.toybox.Editor
{
    /// <summary>The inspector of the <see cref="GlobalToggles"/>.</summary>
    [CustomEditor(typeof(GlobalToggles))]
    public sealed class GlobalTogglesEditor
        : GlobalUIEditorBase<GlobalToggles>
    {
        /// <summary>Initialize the editor.</summary>
        public GlobalTogglesEditor() : base(
            details: L10n.Tr(T.DETAIL_GLOBAL_TOGGLES),
            usage: new[]
                {
                    T.USAGE_GLOBAL_TOGGLES_0,
                    T.USAGE_GLOBAL_TOGGLES_1
                },
            argument: T.USAGE_ON_VALUE_CHANGED)
        {
        }

        /// <summary>The callback to draw the inspector GUI.</summary>
        public override void OnInspectorGUI()
        {
            DrawBanner();
            DrawDetails();
            DrawUsage();
            base.OnInspectorGUI();

            serializedObject.Update();
            var toggleGroup = EnsureComponentAssigned<ToggleGroup>(
                GlobalToggles.NAME_TOGGLE_GROUP);
            var arrayProp = serializedObject.FindProperty(
                GlobalToggles.NAME_TOGGLES);
            toggleGroup.CompleteToggles(arrayProp);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
