using UnityEditor;

namespace black.kit.toybox.Editor
{
    /// <summary>
    /// The inspector of the <see cref="SequenceActiveRelayToAnimator"/>.
    /// </summary>
    [CustomEditor(typeof(SequenceActiveRelayToAnimator))]
    public sealed class SequenceActiveRelayToAnimatorEditor : ActiveRelayEditorBase<SequenceActiveRelayToAnimator>
    {
        /// <summary>Initialize the editor.</summary>
        public SequenceActiveRelayToAnimatorEditor()
            : base(L10n.Tr(T.DETAIL_SEQUENCE_ACTIVE_RELAY_TO_ANIMATOR))
        {
        }
    }
}
