using System;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace black.kit.toybox
{
    /// <summary>
    /// The component synchronizes the scroll position of the ScrollRect
    /// uGUI component.
    /// </summary>
    [AddComponentMenu("UdonSharp Toybox/Global/Global Scroll")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public sealed class GlobalScroll : SyncBehaviour
    {
        /// <summary>
        /// The property name of the ScrollRect component.
        /// </summary>
        public const string NAME_SCROLL_RECT = nameof(scrollRect);

        /// <summary>
        /// The warning message when the ScrollRect component is not found.
        /// </summary>
        private const string WARN_NO_SCROLL_RECT =
            "ScrollRect component is not found.";

        /// <summary>The scroll position to synchronize.</summary>
        [NonSerialized, UdonSynced]
        public Vector2 position = Vector2.up;

        /// <summary>The scroll velocity to synchronize.</summary>
        [NonSerialized, UdonSynced]
        public Vector2 velocity = Vector2.zero;

#pragma warning disable IDE0044
        /// <summary>
        /// The scroll rect component to synchronize the scroll position.
        /// </summary>
        [SerializeField, Tooltip("Specify the scroll rect to synchronize.")]
        private ScrollRect scrollRect;
#pragma warning restore IDE0044

        /// <summary>
        /// The callback when the scroll position is changed.
        /// </summary>
        public void OnScroll()
        {
            if (!scrollRect)
            {
                Log.Warn(WARN_NO_SCROLL_RECT);
                return;
            }
            ChangeOwner();
            position = scrollRect.normalizedPosition;
            velocity = scrollRect.velocity;
            Sync();
        }

        /// <summary>Reset the scroll position to the top.</summary>
        public void Reset()
        {
            if (!scrollRect)
            {
                Log.Warn(WARN_NO_SCROLL_RECT);
                return;
            }
            scrollRect.normalizedPosition = Vector2.up;
            scrollRect.velocity = Vector2.zero;
            OnScroll();
        }

        /// <summary>
        /// The callback to update the view,
        /// e.g. the synchronized scroll position.
        /// </summary>
        protected override void UpdateView()
        {
            if (IsOwner() || !scrollRect)
            {
                return;
            }
            scrollRect.normalizedPosition = position;
            scrollRect.velocity = velocity;
        }

#pragma warning disable IDE0051
        /// <summary>
        /// Update the view when the component is enabled.
        /// </summary>
        private void OnEnable() => UpdateView();

        /// <summary>
        /// Update the target transform when the component is started.
        /// </summary>
        private void Start()
        {
            if (!scrollRect)
            {
                Log.Warn(WARN_NO_SCROLL_RECT);
            }
        }
#pragma warning restore IDE0051
    }
}
