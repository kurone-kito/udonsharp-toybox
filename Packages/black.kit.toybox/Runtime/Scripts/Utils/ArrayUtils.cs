using System;
using UnityEngine;

namespace black.kit.toybox
{
    /// <summary>The utility class for arrays</summary>
    public static class ArrayUtils
    {
        /// <summary>
        /// Determines whether the specified array contains the specified
        /// value.
        /// </summary>
        /// <typeparam name="T">Type of array elements</typeparam>
        /// <param name="array">Array</param>
        /// <param name="value">The value to contains</param>
        /// <returns>
        /// True if the specified array contains the specified value.
        /// Otherwise, false.
        /// </returns>
        public static bool Contains<T>(
            this T[] array, T value) where T : IEquatable<T>
        {
            if (array == null)
            {
                return false;
            }
            foreach (var obj in array)
            {
                if (obj.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Batch setting of game object activation status.
        /// </summary>
        /// <param name="array">Array of game objects</param>
        /// <param name="active">New activation status</param>
        public static void SetActive(this GameObject[] array, bool active)
        {
            if (array == null)
            {
                return;
            }
            foreach (var obj in array)
            {
                if (obj)
                {
                    obj.SetActive(active);
                }
            }
        }
    }
}
