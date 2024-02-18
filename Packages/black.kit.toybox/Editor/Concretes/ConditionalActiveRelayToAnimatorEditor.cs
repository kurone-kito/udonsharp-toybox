using UnityEditor;

namespace black.kit.toybox.Editor
{
    /// <summary>
    /// The inspector of the <see cref="ConditionalActiveRelayToAnimator"/>.
    /// </summary>
    [CustomEditor(typeof(ConditionalActiveRelayToAnimator))]
    public sealed class ConditionalActiveRelayToAnimatorEditor
        : ActiveRelayEditorBase<ConditionalActiveRelayToAnimator>
    {
        /// <summary>Initialize the editor.</summary>
        public ConditionalActiveRelayToAnimatorEditor()
            : base(L10n.Tr(T.DETAIL_CONDITIONAL_ACTIVE_RELAY_TO_ANIMATOR))
        {
        }
    }
}
