using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace black.kit.toybox.Editor
{
    /// <summary>The utility class for the editor.</summary>
    public static class EditorUtils
    {
        /// <summary>Draw the banner to the inspector.</summary>
        /// <param name="banner">The texture of the banner.</param>
        public static void DrawBanner(Texture banner, float aspectRatio)
        {
            if (!banner)
            {
                return;
            }
            const float PADDING = 20f;
            var width = EditorGUIUtility.currentViewWidth - PADDING * 2f;
            var height = BannerInit.GetHeight(width, aspectRatio);
            var rect = new Rect() { width = width, height = height };
            var rect2 = GUILayoutUtility.GetRect(rect.width, rect.height);
            rect.x = PADDING - 4f;
            rect.y = rect2.y;
            GUI.DrawTexture(rect, banner, ScaleMode.StretchToFill);
            EditorGUILayout.Space();
        }

        /// <summary>Draw the detail of the inspector.</summary>
        /// <typeparam name="T">The type of the target.</typeparam>
        /// <param name="detail">The detail to draw.</param>
        /// <param name="style">The style of the detail.</param>
        public static void DrawDetail<T>(string detail, GUIStyle style)
            where T : MonoBehaviour
        {
            EditorGUILayout.BeginVertical(GUI.skin.box);
            var className = typeof(T).FullName;
            EditorGUILayout.LabelField($"<b>{className}</b>", style);
            EditorGUILayout.LabelField(detail, style);
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space();
        }

        /// <summary>Draw the list of the inspector.</summary>
        /// <param name="list">The list to draw.</param>
        /// <param name="style">The style of the list.</param>
        /// <param name="selectable">The list is selectable.</param>
        public static void DrawList(
            IEnumerable<string> list,
            GUIStyle style,
            ListOptions options = new ())
        {
            var putItem = options.CreatePutItem(style);
            foreach (
                var (item, index)
                in list.Select((item, index) => (item, index)))
            {
                putItem(item, index);
            }
        }

        /// <summary>Draw the Udon event of the inspector.</summary>
        /// <param name="argument">The argument of the Udon event.</param>
        /// <param name="style">The style of the list.</param>
        /// <param name="tr">The translation function.</param>
        public static void DrawUdonEvent(
            string argument,
            GUIStyle style,
            Func<string, string> tr = null)
        {
            var list = new[]
            {
                T.USAGE_RUNTIME_ONLY,
                T.USAGE_THIS_COMPONENT,
                T.USAGE_SEND_CUSTOM_EVENT,
                argument,
            };
            EditorGUI.indentLevel++;
            DrawList(list, style, new() { Selectable = true, Tr = tr });
            EditorGUI.indentLevel--;
        }
    }
}
