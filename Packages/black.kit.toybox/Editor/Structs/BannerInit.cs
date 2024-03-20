using UnityEditor;
using UnityEngine;

namespace black.kit.toybox.Editor
{
    /// <summary>The information of the banner.</summary>
    public readonly struct BannerInit
    {
        /// <summary>The information of the Toybox banner.</summary>
        public static readonly BannerInit Toybox =
            new()
            {
                AspectRatio = 2f,
                Unique = "0041afc9ac3aebd4c88ce9706afe240f"
            };

        /// <summary>The aspect ratio of the banner.</summary>
        public float AspectRatio { get; init; }

        /// <summary>The unique identifier of the banner.</summary>
        public string Unique { get; init; }

        /// <summary>
        /// Initialize the information of the banner.
        /// </summary>
        /// <param name="aspectRatio">
        /// The aspect ratio of the banner.
        /// </param>
        /// <param name="unique">
        /// The unique identifier of the banner.
        /// </param>
        public BannerInit(float aspectRatio, string unique)
        {
            AspectRatio = aspectRatio;
            Unique = unique;
        }

        /// <summary>
        /// Deconstruct the information of the banner.
        /// </summary>
        /// <param name="aspectRatio">
        /// The aspect ratio of the banner.
        /// </param>
        /// <param name="unique">
        /// The unique identifier of the banner.
        /// </param>
        public readonly void Deconstruct(
            out float aspectRatio, out string unique)
        {
            aspectRatio = AspectRatio;
            unique = Unique;
        }

        /// <summary>Get the height of the banner.</summary>
        /// <param name="width">The width of the banner.</param>
        /// <returns>The height of the banner.</returns>
        public readonly float GetHeight(float width) =>
            GetHeight(width: width, aspectRatio: AspectRatio);

        /// <summary>Load the texture of the banner.</summary>
        /// <returns>The texture of the banner.</returns>
        public readonly Texture LoadTexture()
        {
            var path = AssetDatabase.GUIDToAssetPath(Unique);
            var type = typeof(Texture);
            return AssetDatabase.LoadAssetAtPath(path, type) as Texture;
        }

        /// <summary>Get the height of the banner.</summary>
        /// <param name="width">The width of the banner.</param>
        /// <param name="aspectRatio">
        /// The aspect ratio of the banner.
        /// </param>
        /// <returns>The texture of the banner.</returns>
        public static float GetHeight(float width, float aspectRatio) =>
            width * (1f / aspectRatio);
    }
}
