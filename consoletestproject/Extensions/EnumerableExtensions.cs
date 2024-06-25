namespace consoletestproject.Extensions
{
    /// <summary>
    /// Provides extension methods for working with IEnumerable collections.
    /// </summary>
    public static class EnumerableExtensions
    {
        #region Public Methods

        /// <summary>
        /// Checks if the specified enumerable collection is either null, empty, or consists of only null or whitespace elements (if the enumerable is of type string).
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <param name="enumerable">The enumerable collection to check.</param>
        /// <returns>True if the enumerable is null, empty, or contains only null or whitespace elements (for strings); otherwise, false.</returns>
        /// <typeinfo>public static bool</typeinfo>
        public static bool IsEmptyOrNull<T>(this IEnumerable<T>? enumerable) {
            if (enumerable is string enumer) return string.IsNullOrEmpty(enumer);
            return enumerable == null || !enumerable.Any();
        }

        /// <summary>
        /// Checks if the specified index is a valid index within the enumerable collection.
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <param name="enumerable">The enumerable collection.</param>
        /// <param name="index">The index to check.</param>
        /// <returns>True if the index is valid within the bounds of the enumerable; otherwise, false.</returns>
        /// <remarks>
        /// The enumerable collection must not be null or empty for the index to be considered valid.
        /// </remarks>
        /// <typeinfo>public static bool</typeinfo>
        public static bool IsValidIndex<T>(this IEnumerable<T> enumerable, int index) {
            if (enumerable.IsEmptyOrNull())
                return false;

            return index >= 0 && index < enumerable.Count();
        }

        #endregion Public Methods
    }
}