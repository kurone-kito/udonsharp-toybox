using UdonSharp;

namespace black.kit.toybox
{
    /// <summary>
    /// The class of the observer side in the publish-subscribe model.
    /// </summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public abstract class Observer : UdonSharpBehaviour
    {
        /// <summary>
        /// Implement a callback when a call is received from the subject.
        /// </summary>
        /// <param name="subject">
        /// The subject that called the observer.
        /// </param>
        public abstract void OnNotify(Subject subject);
    }
}
