using UdonSharp;
using UnityEngine;
using VRC.Udon.Common;

namespace black.kit.toybox
{
    /// <summary>
    /// The component that handles the long-press action on a button.
    /// </summary>
    [AddComponentMenu("UdonSharp Toybox/UI/Long-Press Trigger")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class LongPressTrigger : UdonSharpBehaviour
    {
#pragma warning disable IDE0044
        /// <summary>The threashold time to trigger the event.</summary>
        [SerializeField, Range(0.1f, 10f)]
        [Tooltip("The threshold time to trigger the event.")]
        private float threshold = 1f;

        /// <summary>The event to trigger.</summary>
        [SerializeField]
        [Tooltip("The event to trigger.")]
        private UdonSharpBehaviour eventTrigger;

        /// <summary>The event name when long-pressed.</summary>
        [SerializeField]
        [Tooltip("The event name when long-pressed.")]
        private string eventNameOnLongPress = "OnLongPress";

        /// <summary>The event name when released before the threshold.</summary>
        [SerializeField]
        [Tooltip("The event name when released before the threshold.")]
        private string eventNameOnRelease = "OnRelease";
#pragma warning restore IDE0044

        /// <summary>Whether the button is currently pressed.</summary>
        private bool isPressing = false;

        /// <summary>The time when the button was pressed down.</summary>
        private float pressStartTime = 0f;

        /// <summary>The progress of the long-press action.</summary>
        public float Progress => Mathf.Clamp01(Duration / Threshold);

        /// <summary>Whether the button is currently pressed.</summary>
        public bool IsPressing => isPressing;

        /// <summary>The threashold time to trigger the event.</summary>
        public float Threshold => threshold;

        /// <summary>The time when the button was pressed down.</summary>
        private float Duration => Time.time - pressStartTime;

        /// <summary>The callback when interacting the object.</summary>
        public override void Interact()
        {
            isPressing = true;
            pressStartTime = Time.time;
            SendCustomEventDelayedFrames(nameof(OnPressing), 0);
        }

        /// <summary>The calllback when uses the object.</summary>
        /// <param name="value"></param>
        /// <param name="args">The arguments.</param>
        public override void InputUse(bool value, UdonInputEventArgs args)
        {
            if (!value && isPressing)
            {
                isPressing = false;
                if (Duration < Threshold)
                {
                    eventTrigger.SendCustomEvent(eventNameOnRelease);
                }
            }
        }

        /// <summary>
        /// Called when pressing the trigger every frame.
        /// </summary>
        public void OnPressing()
        {
            if (!isPressing)
            {
                return;
            }
            if (Duration >= Threshold)
            {
                isPressing = false;
                eventTrigger.SendCustomEvent(eventNameOnLongPress);
            }
            else
            {
                SendCustomEventDelayedFrames(nameof(OnPressing), 1);
            }
        }

#pragma warning disable IDE0051
        /// <summary>
        /// Update the target transform when the component is started.
        /// </summary>
        private void Start()
        {
            if (eventTrigger == null)
            {
                eventTrigger = this;
            }
        }
#pragma warning restore IDE0051
    }
}
