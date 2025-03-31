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
        /// <param name="array">
        /// The array. If the array is null, returns the default value.
        /// </param>
        /// <param name="index">The index of the element to obtain</param>
        /// <returns>
        /// The element at the specified index in the array.
        /// If null, the default value of the type.
        /// </returns>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// int[] array = { 1, 2, 3 };
        /// array.At(0); // 1
        /// array.At(1); // 2
        /// array.At(2); // 3
        /// array.At(3); // 1
        /// array.At(-1); // 3
        /// array.At(-2); // 2
        /// array.At(-3); // 1
        /// array.At(-4); // 3
        /// ]]>
        /// </code>
        /// </example>
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
        /// <param name="array">
        /// The array. If the array is null, returns the negative value.
        /// </param>
        /// <param name="index">The index of the element to obtain</param>
        /// <returns>
        /// The index at the specified index in the array.
        /// If array is null, the negative value of the type.
        /// </returns>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// int[] array = { 1, 2, 3 };
        /// array.AtIndex(0); // 0
        /// array.AtIndex(1); // 1
        /// array.AtIndex(2); // 2
        /// array.AtIndex(3); // 0
        /// array.AtIndex(-1); // 2
        /// array.AtIndex(-2); // 1
        /// array.AtIndex(-3); // 0
        /// array.AtIndex(-4); // 2
        /// ]]>
        /// </code>
        /// </example>
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
        /// <param name="array">
        /// The array. If the array is null, returns false.
        /// </param>
        /// <param name="value">The value to contains</param>
        /// <returns>
        /// True if the specified array contains the specified value.
        /// Otherwise, false.
        /// </returns>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// int[] array = { 1, 2, 3 };
        /// array.Contains(2); // true
        /// array.Contains(4); // false
        /// ]]>
        /// </code>
        /// </example>
        public static bool Contains<T>(
            this T[] array, T value) where T : IEquatable<T>
        {
            if (array == null)
            {
                return false;
            }
            foreach (var obj in array)
            {
                if (obj == null)
                {
                    if (value == null)
                    {
                        return true;
                    }
                }
                else if (obj.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Fill the array with the specified value.
        /// </summary>
        /// <typeparam name="T">Type of array elements</typeparam>
        /// <param name="array">The array to fill</param>
        /// <param name="value">The value to fill the array with</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// int[] array = { 1, 2, 3 };
        /// array.Fill(0); // { 0, 0, 0 }
        /// array.Fill(1); // { 1, 1, 1 }
        /// array.Fill(2); // { 2, 2, 2 }
        /// array.Fill(3); // { 3, 3, 3 }
        /// array.Fill(4); // { 4, 4, 4 }
        /// ]]>
        /// </code>
        /// </example>
        public static void Fill<T>(this T[] array, T value)
        {
            if (array == null)
            {
                return;
            }
            for (var i = array.Length; --i >= 0; )
            {
                array[i] = value;
            }
        }

        /// <summary>
        /// Determines whether the specified array is filled with the
        /// same value.
        /// </summary>
        /// <typeparam name="T">Type of array elements</typeparam>
        /// <param name="array">The array to check</param>
        /// <returns>
        /// True if the array is filled with the same value,
        /// otherwise false.
        /// </returns>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// int[] arrayA = { 1, 1, 1 };
        /// int[] arrayB = { 1, 2, 2 };
        /// int[] arrayC = { 2, 2, 2 };
        /// int[] arrayD = new int[0];
        /// arrayA.IsFill(); // true
        /// arrayB.IsFill(); // false
        /// arrayC.IsFill(); // true
        /// arrayD.IsFill(); // false
        /// ]]>
        /// </code>
        /// </example>
        public static bool IsFill<T>(this T[] array) where T : IEquatable<T> =>
            array != null && array.Length > 0 && array.IsFill(array[0]);

        /// <summary>
        /// Determines whether the specified array is filled with the
        /// specified value.
        /// </summary>
        /// <typeparam name="T">Type of array elements</typeparam>
        /// <param name="array">The array to check</param>
        /// <param name="value">The value to compare against</param>
        /// <returns>
        /// True if the array is filled with the specified value,
        /// otherwise false.
        /// </returns>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// int[] arrayA = { 1, 1, 1 };
        /// int[] arrayB = { 1, 2, 2 };
        /// int[] arrayC = { 2, 2, 2 };
        /// arrayA.IsFill(1); // true
        /// arrayA.IsFill(2); // false
        /// arrayB.IsFill(1); // false
        /// arrayB.IsFill(2); // false
        /// arrayC.IsFill(1); // false
        /// arrayC.IsFill(2); // true
        /// ]]>
        /// </code>
        /// </example>
        public static bool IsFill<T>(this T[] array, T value) where T : IEquatable<T>
        {
            if (array == null || array.Length == 0)
            {
                return false;
            }
            foreach (var obj in array)
            {
                if (obj == null)
                {
                    if (value != null)
                    {
                        return false;
                    }
                }
                else if (!obj.Equals(value))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Batch setting of game object activation status.
        /// </summary>
        /// <param name="array">
        /// Array of game objects. If the array is null, do nothing.
        /// </param>
        /// <param name="active">New activation status</param>
        /// <remarks>
        /// If the elements contain null or invalid, it is ignored,
        /// but we recommend removing them for performance reasons.
        /// </remarks>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// [SerializeField] private GameObject[] objects;
        /// [SerializeField] private Toggle toggle;
        ///
        /// public void OnValueChanged() => objects.SetActive(toggle.isOn);
        /// ]]>
        /// </code>
        /// </example>
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
