using System;

namespace ShiftArrayElements
{
    public static class RecursiveShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using <see cref="iterations"/> array for getting directions and iterations (odd elements - left direction, even elements - right direction).
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="iterations">An array with iterations.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">iterations array is null.</exception>
        public static int[] Shift(int[] source, int[] iterations)
        {
            // #2. Implement the method using recursive local functions and indexers only (don't use Array.Copy method here).
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "Source array not be null.");
            }

            if (iterations is null)
            {
                throw new ArgumentNullException(nameof(iterations), "Iterations array not be null.");
            }

            for (int i = 0; i < iterations.Length; i++)
            {
                while (iterations[i] != 0)
                {
                    ShiftLeft(source, source.Length - 1);
                    iterations[i]--;
                }

                if (++i >= iterations.Length)
                {
                    break;
                }

                while (iterations[i] != 0)
                {
                    ShiftRight(source, 0);
                    iterations[i]--;
                }
            }

            return source;
        }

        /// <summary>
        /// Shifts elements in a <see cref="source"/> array by right.
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="start">Start index.</param>
        public static void ShiftRight(int[] source, int start)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "Source array not be null.");
            }

            if (start >= source.Length - 1)
            {
                return;
            }

            (source[start], source[^1]) = (source[^1], source[start]);
            ShiftRight(source, ++start);
        }

        /// <summary>
        /// Shifts elements in a <see cref="source"/> array by left.
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="start">Start index.</param>
        public static void ShiftLeft(int[] source, int start)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "Source array not be null.");
            }

            if (start < 1)
            {
                return;
            }

            (source[start], source[0]) = (source[0], source[start]);
            ShiftLeft(source, --start);
        }
    }
}
