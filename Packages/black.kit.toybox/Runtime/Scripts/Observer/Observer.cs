using UdonSharp;

namespace black.kit.toybox
{
    /// <summary>
    /// The class of the observer side in the publish-subscribe model.
    /// </summary>
    /// <remarks>
    /// Usage:
    /// <list type="number">
    /// <item>
    /// <description>
    /// (in the inspector of Unity Editor)
    /// Add this component or prefab to the scene.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Implement the <c>OnNotify</c> method to receive a call from the
    /// subject.
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <seealso cref="Subject"/>
    /// <seealso cref="ObserverHub"/>
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
