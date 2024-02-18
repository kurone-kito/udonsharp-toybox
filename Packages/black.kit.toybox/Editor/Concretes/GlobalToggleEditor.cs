using UnityEditor;
using UnityEngine.UI;

namespace black.kit.toybox.Editor
{
    /// <summary>The inspector of the <see cref="GlobalToggle"/>.</summary>
    [CustomEditor(typeof(GlobalToggle))]
    public sealed class GlobalToggleEditor
        : GlobalUIEditorBase<GlobalToggle>
    {
        /// <summary>Initialize the editor.</summary>
        public GlobalToggleEditor() : base(
            details: L10n.Tr(T.DETAIL_GLOBAL_TOGGLE),
            usage: new[] {
                T.USAGE_GLOBAL_TOGGLE_0,
                T.USAGE_GLOBAL_TOGGLE_1
            },
            argument: T.USAGE_ON_TOGGLE)
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
            AutoCompleteObject<Toggle>(GlobalToggle.NAME_TOGGLE);
            AutoCompleteObject<Subject>(SyncBehaviour.NAME_SUBJECT);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
