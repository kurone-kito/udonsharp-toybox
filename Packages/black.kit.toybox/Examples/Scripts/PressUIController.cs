using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace black.kit.toybox.Examples
{
    /// <summary>
    /// The example component that handles the long-press action on a button.
    /// </summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public sealed class PressUIController : UdonSharpBehaviour
    {
#pragma warning disable IDE0044
        /// <summary>
        /// The component that handles the long-press action on a button.
        /// </summary>
        [SerializeField]
        [Tooltip("The component that handles the long-press action on a button.")]
        private LongPressTrigger longPressTrigger;

        /// <summary>The progress the long-press action.</summary>
        [SerializeField]
        [Tooltip("The progress the long-press action.")]
        private Slider progressBar;

        /// <summary>The indicator when fails to long-press.</summary>
        [SerializeField]
        [Tooltip("The indicator when fails to long-press.")]
        private GameObject failIndicator;

        /// <summary>The indicator when succeeds to long-press.</summary>
        [SerializeField]
        [Tooltip("The indicator when succeeds to long-press.")]
        private GameObject successIndicator;
#pragma warning restore IDE0044

        /// <summary>The callback when interacting the object.</summary>
        public override void Interact()
        {
            SendCustomEventDelayedFrames(nameof(UpdateView), 0);
            failIndicator.SetActive(false);
            successIndicator.SetActive(false);
            progressBar.value = 0f;
        }

        /// <summary>Update the view of the UI.</summary>
        public void UpdateView()
        {
            if (!(longPressTrigger && longPressTrigger.IsPressing))
            {
                return;
            }
            progressBar.value = longPressTrigger.Progress;
            SendCustomEventDelayedFrames(nameof(UpdateView), 2);
        }

        /// <summary>
        /// Called when the long-press action is completed.
        /// </summary>
        public void OnLongPress()
        {
            failIndicator.SetActive(false);
            successIndicator.SetActive(true);
            progressBar.value = 0f;
        }

        /// <summary>
        /// Called when the long-press action is released before the threshold.
        /// </summary>
        public void OnRelease()
        {
            failIndicator.SetActive(true);
            successIndicator.SetActive(false);
            progressBar.value = 0f;
        }
    }
}
