using UnityEditor;
using UnityEngine.UI;

namespace black.kit.toybox.Editor
{
    /// <summary>The inspector of the <see cref="GlobalSlider"/>.</summary>
    [CustomEditor(typeof(GlobalSlider))]
    public sealed class GlobalSliderEditor
        : GlobalUIEditorBase<GlobalSlider>
    {
        /// <summary>Initialize the editor.</summary>
        public GlobalSliderEditor() : base(
            details: L10n.Tr(T.DETAIL_GLOBAL_SLIDER),
            usage: new[]
                {
                    T.USAGE_GLOBAL_SLIDER_0,
                    T.USAGE_GLOBAL_SLIDER_1
                },
            argument: T.USAGE_ON_VALUE_CHANGED)
        {
        }

        /// <summary>Called after drawing the default inspector.</summary>
        protected override void OnAfterInspectorGUI()
        {
            serializedObject.Update();
            EnsureComponentAssigned<Slider>(GlobalSlider.NAME_SLIDER);
            EnsureComponentAssigned<Subject>(SyncBehaviour.NAME_SUBJECT);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
