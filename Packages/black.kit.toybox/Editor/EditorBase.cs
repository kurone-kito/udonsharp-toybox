using System;
using System.Collections.Generic;
using UdonSharp;
using UnityEditor;
using UnityEngine;

namespace black.kit.toybox.Editor
{
    /// <summary>The base class for the custom editor.</summary>
    /// <typeparam name="Tb">The type of the target.</typeparam>
    public abstract class EditorBase<Tb> : UnityEditor.Editor
        where Tb : UdonSharpBehaviour
    {
        /// <summary>The translation function.</summary>
        protected readonly Func<string, string> Tr;

        /// <summary>The information of the banner.</summary>
        private readonly BannerInit bannerInit;

        /// <summary>Initialize the editor.</summary>
        /// <param name="details">The details of the target.</param>
        /// <param name="bannerInit">The information of the banner.</param>
        public EditorBase(
            string details, Lazy<BannerInit> bannerInit = null, Func<string, string> tr = null)
            : this(
                details: details,
                bannerInit: bannerInit?.Value ?? BannerInit.Toybox,
                tr: tr)
        {
        }

        /// <summary>Initialize the editor.</summary>
        /// <param name="details">The details of the target.</param>
        /// <param name="bannerInit">The information of the banner.</param>
        public EditorBase(string details, BannerInit bannerInit, Func<string, string> tr = null) : base()
        {
            this.details = details;
            this.bannerInit = bannerInit;
            Tr = tr ?? L10n.Tr;
        }

        /// <summary>The default style of the inspector.</summary>
        protected readonly Lazy<GUIStyle> defaultStyle =
            new(() => new(GUI.skin.label)
            {
                richText = true,
                wordWrap = true
            });

        /// <summary>The details of the target.</summary>
        private readonly string details;

        /// <summary>The texture of the banner.</summary>
        private Texture banner;

        /// <summary>The target of the inspector.</summary>
        protected Tb TypedTarget => target as Tb;

        /// <summary>
        /// Ensure the specified serialized reference has a component
        /// from the inspected object. When the reference is empty this
        /// method searches for the component on the target and assigns
        /// it automatically.
        /// </summary>
        /// <typeparam name="T">Component type to resolve.</typeparam>
        /// <param name="propertyName">Serialized property name.</param>
        /// <returns>Resolved component instance.</returns>
        protected T EnsureComponentAssigned<T>(string propertyName)
            where T : Component
        {
            var prop = serializedObject.FindProperty(propertyName);
            if (prop.objectReferenceValue)
            {
                return prop.objectReferenceValue as T;
            }
            var component = TypedTarget.GetComponent<T>();
            prop.objectReferenceValue = component;
            return component;
        }

        /// <summary>Draw the banner of the inspector.</summary>
        protected void DrawBanner() =>
            EditorUtils.DrawBanner(
                banner: LoadTexture(), aspectRatio: bannerInit.AspectRatio);

        /// <summary>Draw the list of the inspector.</summary>
        /// <param name="list">The list to draw.</param>
        /// <param name="selectable">The list is selectable.</param>
        protected void DrawList(IEnumerable<string> list, bool selectable = false) =>
            DrawList(list, new ListOptions() { Selectable = selectable, Tr = Tr });

        /// <summary>Draw the list of the inspector.</summary>
        /// <param name="list">The list to draw.</param>
        /// <param name="options">The options of the list.</param>
        protected void DrawList(IEnumerable<string> list, ListOptions options) =>
            EditorUtils.DrawList(
                list: list,
                style: defaultStyle.Value,
                options: options);

        /// <summary>Draw the description of the inspector.</summary>
        protected void DrawDetails() =>
            EditorUtils.DrawDetail<Tb>(
                detail: details, style: defaultStyle.Value);

        /// <summary>Load the texture of the banner.</summary>
        /// <param name="Force">Force to load the texture.</param>
        /// <returns>The texture of the banner.</returns>
        private Texture LoadTexture(bool Force = false) =>
            banner = (Force || !banner) ? bannerInit.LoadTexture() : banner;

        /// <summary>Draw the Udon event of the inspector.</summary>
        /// <param name="argument">The argument of the Udon event.</param>
        protected void DrawUdonEvent(string argument) =>
            EditorUtils.DrawUdonEvent(
                argument: argument, style: defaultStyle.Value, tr: Tr);

        /// <summary>Called before drawing the default inspector.</summary>
        protected virtual void OnBeforeInspectorGUI()
        {
        }

        /// <summary>Called after drawing the default inspector.</summary>
        protected virtual void OnAfterInspectorGUI()
        {
        }

        /// <summary>The callback to draw the inspector GUI.</summary>
        public override void OnInspectorGUI()
        {
            DrawBanner();
            DrawDetails();
            OnBeforeInspectorGUI();
            base.OnInspectorGUI();
            OnAfterInspectorGUI();
        }

#pragma warning disable IDE0051
        /// <summary>The callback when the object is enabled.</summary>
        private void OnEnable() => LoadTexture();
#pragma warning restore IDE0051
    }
}
