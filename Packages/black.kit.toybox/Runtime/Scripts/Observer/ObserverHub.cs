
using UdonSharp;
using UnityEngine;

namespace black.kit.toybox
{
    /// <summary>
    /// The hub class of the observer side in the publish-subscribe model.
    /// </summary>
    /// <remarks>
    /// Use this ObserverHub when you have many Observers registered in a
    /// Subject and it isn't easy to manage them. ObserverHub can be nested
    /// infinitely, but be careful of circular references.
    /// </remarks>
    [AddComponentMenu("UdonSharp Toybox/Observer/Observer Hub")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class ObserverHub : Observer
    {
#pragma warning disable IDE0044
        /// <summary>The list of the children observers.</summary>
        [SerializeField]
        [Tooltip("Specify the children observers to notify.")]
        private Observer[] children;
#pragma warning restore IDE0044

        /// <summary>
        /// The callback when a call is received from the subject.
        /// </summary>
        /// <param name="subject">
        /// The subject that called the observer.
        /// </param>
        public override void OnNotify(Subject subject)
        {
            foreach (var child in children)
            {
                if (child)
                {
                    child.OnNotify(subject);
                }
            }
        }
    }
}
