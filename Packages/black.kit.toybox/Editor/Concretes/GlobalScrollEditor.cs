using UnityEditor;
using UnityEngine.UI;

namespace black.kit.toybox.Editor
{
    /// <summary>The inspector of the <see cref="GlobalScroll"/>.</summary>
    [CustomEditor(typeof(GlobalScroll))]
    public sealed class GlobalScrollEditor
        : GlobalUIEditorBase<GlobalScroll>
    {
        /// <summary>Initialize the editor.</summary>
        public GlobalScrollEditor() : base(
            details: L10n.Tr(T.DETAIL_GLOBAL_SCROLL),
            usage: new[]
                {
                    T.USAGE_GLOBAL_SCROLL_0,
                    T.USAGE_GLOBAL_SCROLL_1
                },
            argument: T.USAGE_ON_SCROLL)
        {
        }

        /// <summary>Called after drawing the default inspector.</summary>
        protected override void OnAfterInspectorGUI()
        {
            serializedObject.Update();
            EnsureComponentAssigned<ScrollRect>(GlobalScroll.NAME_SCROLL_RECT);
            EnsureComponentAssigned<Subject>(SyncBehaviour.NAME_SUBJECT);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
