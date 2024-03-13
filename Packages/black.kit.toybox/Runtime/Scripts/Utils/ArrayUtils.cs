using System;
using UnityEngine;

namespace black.kit.toybox
{
    /// <summary>The utility class for arrays</summary>
    public static class ArrayUtils
    {
        /// <summary>
        /// Returns the element at the specified index in the array.
        /// </summary>
        /// <remarks>
        /// If the specified index is negative, elements counted from the
        /// end are obtained. And also, If the specified index is outside
        /// the range, the elements within the range are obtained by
        /// calculating the remainder.
        /// </remarks>
        /// <typeparam name="T">Type of array elements</typeparam>
        /// <param name="array">the array</param>
        /// <param name="index">The index of the element to obtain</param>
        /// <returns>
        /// The element at the specified index in the array.
        /// If null, the default value of the type.
        /// </returns>
        public static T At<T>(this T[] array, int index)
        {
            if (array == null)
            {
                return default;
            }
            return array[array.AtIndex(index)];
        }

        /// <summary>
        /// Returns the index at the specified index in the array.
        /// </summary>
        /// <remarks>
        /// If the specified index is negative, elements counted from the
        /// end are obtained. And also, If the specified index is outside
        /// the range, the elements within the range are obtained by
        /// calculating the remainder.
        /// </remarks>
        /// <typeparam name="T">Type of array elements</typeparam>
        /// <param name="array">the array</param>
        /// <param name="index">The index of the element to obtain</param>
        /// <returns>
        /// The index at the specified index in the array.
        /// If array is null, the negative value of the type.
        /// </returns>
        public static int AtIndex<T>(this T[] array, int index)
        {
            if (array == null)
            {
                return -1;
            }
            if (index < 0)
            {
                index = array.Length + index % array.Length;
            }
            return index % array.Length;
        }

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
