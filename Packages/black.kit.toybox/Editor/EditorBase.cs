using System;
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
        /// <summary>The unique identifier of the banner.</summary>
        private const string BANNER_UNIQUE =
            "0041afc9ac3aebd4c88ce9706afe240f";

        /// <summary>Initialize the editor.</summary>
        /// <param name="details">The details of the target.</param>
        public EditorBase(string details) : base()
        {
            this.details = details;
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
        protected void AutoCompleteObject<T>(string propertyName)
            where T : Component
        {
            var target = TypedTarget;
            var component = target.GetComponent<T>();
            var prop = serializedObject.FindProperty(propertyName);
            if (component && prop.objectReferenceValue == null)
            {
                prop.objectReferenceValue = component;
            }
        }

        /// <summary>Draw the banner of the inspector.</summary>
        protected void DrawBanner()
        {
            if (!banner)
            {
                LoadTexture();
            }
            if (!banner)
            {
                return;
            }
            const float PADDING = 20f;
            var width = EditorGUIUtility.currentViewWidth - PADDING * 2f;
            var rect = new Rect() { width = width, height = width * .5f };
            var rect2 = GUILayoutUtility.GetRect(rect.width, rect.height);
            rect.x = PADDING - 4f;
            rect.y = rect2.y;
            EditorGUILayout.Space();
            GUI.DrawTexture(rect, banner, ScaleMode.StretchToFill);
            EditorGUILayout.Space();
        }

        /// <summary>
        /// Draw the list of the inspector.
        /// </summary>
        /// <param name="list">The list to draw.</param>
        /// <param name="selectable">The list is selectable.</param>
        protected void DrawList(string[] list, bool selectable = false)
        {
            var style = defaultStyle.Value;
            Array.ForEach(
                list,
                selectable
                    ? item =>
                        EditorGUILayout.SelectableLabel(
                            L10n.Tr(item), style)
                    : item =>
                        EditorGUILayout.LabelField(L10n.Tr(item), style));
        }

        /// <summary>Draw the description of the inspector.</summary>
        protected void DrawDetails()
        {
            EditorGUILayout.BeginVertical(GUI.skin.box);
            var style = defaultStyle.Value;
            var className = TypedTarget.GetType().FullName;
            EditorGUILayout.LabelField($"<b>{className}</b>", style);
            EditorGUILayout.LabelField(details, style);
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space();
        }

        /// <summary>Load the texture of the banner.</summary>
        private void LoadTexture()
        {
            var path = AssetDatabase.GUIDToAssetPath(BANNER_UNIQUE);
            banner = AssetDatabase.LoadAssetAtPath(
                path, typeof(Texture)) as Texture;
        }

#pragma warning disable IDE0051
        /// <summary>The callback when the object is enabled.</summary>
        private void OnEnable() => LoadTexture();
#pragma warning restore IDE0051
    }
}
