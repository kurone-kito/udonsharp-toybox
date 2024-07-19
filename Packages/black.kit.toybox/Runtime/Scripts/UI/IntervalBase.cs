using UdonSharp;
using UnityEngine;

namespace black.kit.toybox
{
    /// <summary>The base class of the interval logic.</summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public abstract class IntervalBase : UdonSharpBehaviour
    {
        /// <summary>The safe minimum interval.</summary>
        private const float SAFE_MIN_INTERVAL = 0.01f;

        /// <summary>The warning of the null.</summary>
        private const string WARN_NULL = "Some inspector values is null.";

        /// <summary>The interval of the progress.</summary>
        /// <remarks>It ignores less than 0.01f.</remarks>
        [SerializeField, Range(SAFE_MIN_INTERVAL, 60f)]
        [Tooltip("Specifies the interval of the progress")]
        private float interval = 1f;

        /// <summary>The interval of the progress.</summary>
        public float Interval => interval;

        /// <summary>Update the view of the UI.</summary>
        public void InternalUpdateView()
        {
            UpdateView();
            var safeInterval = Mathf.Max(Interval, SAFE_MIN_INTERVAL);
            SendCustomEventDelayedSeconds(nameof(InternalUpdateView), safeInterval);
        }

        /// <summary>Update the view of the UI.</summary>
        [ContextMenu("Update view")]
        public abstract void UpdateView();

        /// <summary>Validate the inspector.</summary>
        /// <returns>Whether the inspectors are valid.</returns>
        protected abstract bool ValidateInspector();

        /// <summary>The callback when the object is initialized.</summary>
        protected virtual void Start()
        {
            if (!ValidateInspector())
            {
                Debug.LogWarning(WARN_NULL);
                return;
            }
            SendCustomEventDelayedFrames(nameof(InternalUpdateView), 1);
        }
    }
}
