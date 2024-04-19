using System;
using UdonSharp;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace black.kit.toybox.Editor
{
    /// <summary>The base class for the custom editor.</summary>
    /// <typeparam name="Tb">The type of the target.</typeparam>
    public abstract class EditorBase<Tb> : UnityEditor.Editor
        where Tb : UdonSharpBehaviour
    {
        /// <summary>The information of the banner.</summary>
        private readonly BannerInit bannerInit;

        /// <summary>Initialize the editor.</summary>
        /// <param name="details">The details of the target.</param>
        /// <param name="bannerInit">The information of the banner.</param>
        public EditorBase(
            string details, Lazy<BannerInit> bannerInit = null)
            : this(
                details: details,
                bannerInit: bannerInit?.Value ?? BannerInit.Toybox)
        {
        }

        /// <summary>Initialize the editor.</summary>
        /// <param name="details">The details of the target.</param>
        /// <param name="bannerInit">The information of the banner.</param>
        public EditorBase(string details, BannerInit bannerInit) : base()
        {
            this.details = details;
            this.bannerInit = bannerInit;
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
        /// Auto-complete the object reference of the specified component.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The component.</returns>
        protected T AutoCompleteObject<T>(string propertyName)
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

        /// <summary>Complete the toggles of the specified array.</summary>
        /// <param name="toggleGroup">The toggle group.</param>
        /// <param name="arrayProp">
        /// The serialized property of the array.
        /// </param>
        /// <returns>The toggles of the array.</returns>
        protected Toggle[] CompleteToggles(
            ToggleGroup toggleGroup, SerializedProperty arrayProp)
        {
            var array = toggleGroup.GetToggles();
            if (arrayProp != null && arrayProp.isArray && array != null)
            {
                var length = array.Length;
                if (arrayProp.arraySize != length)
                {
                    arrayProp.arraySize = length;
                }
                for (var i = length; --i >= 0;)
                {
                    arrayProp.GetArrayElementAtIndex(i).objectReferenceValue =
                        array[i];
                }
            }
            return array;
        }

        /// <summary>Draw the banner of the inspector.</summary>
        protected void DrawBanner() =>
            EditorUtils.DrawBanner(
                banner: LoadTexture(), aspectRatio: bannerInit.AspectRatio);

        /// <summary>
        /// Draw the list of the inspector.
        /// </summary>
        /// <param name="list">The list to draw.</param>
        /// <param name="selectable">The list is selectable.</param>
        protected void DrawList(string[] list, bool selectable = false) =>
            EditorUtils.DrawList(
                list: list,
                style: defaultStyle.Value,
                options: new() { Selectable = selectable });

        /// <summary>Draw the description of the inspector.</summary>
        protected void DrawDetails() =>
            EditorUtils.DrawDetail<Tb>(
                detail: details, style: defaultStyle.Value);

        /// <summary>Load the texture of the banner.</summary>
        /// <param name="Force">Force to load the texture.</param>
        /// <returns>The texture of the banner.</returns>
        private Texture LoadTexture(bool Force = false) =>
            banner = (Force || !banner) ? bannerInit.LoadTexture() : banner;

#pragma warning disable IDE0051
        /// <summary>The callback when the object is enabled.</summary>
        private void OnEnable() => LoadTexture();
#pragma warning restore IDE0051
    }
}
