using System;

namespace ShiftArrayElements
{
    public static class RecursiveEnumShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using directions from <see cref="directions"/> array, one element shift per each direction array element.
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="directions">An array with directions.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">directions array is null.</exception>
        /// <exception cref="InvalidOperationException">direction array contains an element that is not <see cref="Direction.Left"/> or <see cref="Direction.Right"/>.</exception>
        public static int[] Shift(int[] source, Direction[] directions)
        {
            // #1. Implement the method using recursive local functions and Array.Copy method.
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "Source not be null.");
            }

            if (directions is null)
            {
                throw new ArgumentNullException(nameof(directions), "Directions not be null.");
            }

            LeftSift(source, directions);
            RightSift(source, directions);
            return source;
        }

        /// <summary>
        /// Shifts elements in a <see cref="source"/> array by left.
        /// </summary>
        /// <param name="source">>A source array.</param>
        /// <param name="directions">An array with directions.</param>
        private static void LeftSift(int[] source, Direction[] directions)
        {
            if (directions.Length < 1)
            {
                return;
            }

            if (directions[0] == Direction.Left)
            {
                int temp = source[0];
                Array.Copy(source, 1, source, 0, source.Length - 1);
                source[^1] = temp;
                LeftSift(source, directions[1..]);
            }
            else if (directions[0] == Direction.Right)
            {
                LeftSift(source, directions[1..]);
            }
            else
            {
                throw new InvalidOperationException("Element of direction array contains invalid value.");
            }
        }

        /// <summary>
        /// Shifts elements in a <see cref="source"/> array by right.
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="directions">An array with directions.</param>
        private static void RightSift(int[] source, Direction[] directions)
        {
            if (directions.Length < 1)
            {
                return;
            }

            if (directions[0] == Direction.Right)
            {
                int temp = source[^1];
                Array.Copy(source, 0, source, 1, source.Length - 1);
                source[0] = temp;
                RightSift(source, directions[1..]);
            }
            else if (directions[0] == Direction.Left)
            {
                RightSift(source, directions[1..]);
            }
            else
            {
                throw new InvalidOperationException("Element of direction array contains invalid value.");
            }
        }
    }
}
