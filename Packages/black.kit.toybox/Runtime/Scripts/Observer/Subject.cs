using UdonSharp;
using UnityEngine;

namespace black.kit.toybox
{
    /// <summary>
    /// The class of the subject side in the publish-subscribe model.
    /// </summary>
    /// <remarks>
    /// Usage (in the inspector of Unity Editor):
    /// <list type="number">
    /// <item>
    /// <description>
    /// Add this component or prefab to the scene.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Specify the observers to notify.
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <seealso cref="Observer"/>
    /// <seealso cref="ObserverHub"/>
    [AddComponentMenu("UdonSharp Toybox/Observer/Subject")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class Subject : UdonSharpBehaviour
    {
#pragma warning disable IDE0044
        /// <summary>The list of the observers.</summary>
        [SerializeField, Tooltip("Specify the observers to notify.")]
        private Observer[] observers;
#pragma warning restore IDE0044

        /// <summary>Gets the class name of the subject.</summary>
        /// <remarks>
        /// Override this property to change the class name.
        /// </remarks>
        public virtual string ClassName => nameof(Subject);

        /// <summary>Notify all observers.</summary>
        public virtual void Notify()
        {
            foreach (Observer observer in observers)
            {
                if (observer != null)
                {
                    observer.OnNotify(this);
                }
            }
        }
    }
}
