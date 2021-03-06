﻿using System;
using System.Diagnostics;

namespace KangaModeling.Graphics.Primitives
{
    /// <summary>
    /// Represents an x- and y-coordinate pair in two-dimensional space.
    /// </summary>
    [DebuggerDisplay("Point (X={X} Y={Y})")]
	public sealed class Point : IEquatable<Point>
    {
        #region Fields

        private readonly float m_X;
        private readonly float m_Y;
        private static readonly Point s_Empty = new Point(0, 0);

        #endregion

        #region Construction / Destruction / Initialisation

        /// <summary>
        /// Creates a new point instance from the specifed x- and y-coordinates.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        public Point(float x, float y)
        {
            m_X = x;
            m_Y = y;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Represents a point with a x- and y-coordinate of zero.
        /// </summary>
        public static Point Empty
        {
            get { return s_Empty; }
        }

        /// <summary>
        /// Gets the x-coordinate of this point.
        /// </summary>
        public float X
        {
            get { return m_X; }
        }

        /// <summary>
        /// Gets the y-coordinate of this point.
        /// </summary>
        public float Y
        {
            get { return m_Y; }
        }

        #endregion

        #region Public Methods

		/// <summary>
		/// Returns a new point with the specified horizontal and vertical offsets applied.
		/// </summary>
		/// <param name="x">The horizontal offset to apply.</param>
		/// <param name="y">The vertical offset to apply.</param>
		/// <returns>A new point with the specified x- and y-offset applied.</returns>
        public Point Offset(float x, float y)
        {
            return new Point(m_X + x, m_Y + y);
        }

        #endregion

        #region Overrides / Overrideables

		public override string ToString()
		{
			return string.Format("Point (X={0} Y={1})", X, Y);
		}

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Point);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return m_X.GetHashCode() ^ m_Y.GetHashCode();
        }

        #endregion

        #region IEquatable<Point> Members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the other parameter; otherwise, false.
        /// </returns>
        public bool Equals(Point other)
        {
            return other != null && other.m_X == m_X && other.m_Y == m_Y;
        }

        #endregion
    }
}
