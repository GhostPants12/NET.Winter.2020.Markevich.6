using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace PolynomialExtension
{
    public sealed class Polynomial : ICloneable, IEquatable<Polynomial>
    {
        private readonly int maxPower;
        private readonly double[] multipliersArray;

        /// <summary>Initializes a new instance of the <see cref="Polynomial"/> class.</summary>
        /// <param name="multipliers">The multipliers array.</param>
        /// <exception cref="System.ArgumentNullException">multipliers - Multipliers array is null.</exception>
        public Polynomial(double[] multipliers)
        {
            if (multipliers == null)
            {
                throw new ArgumentNullException(nameof(multipliers), "Multipliers array is null");
            }

            this.maxPower = multipliers.Length - 1;
            this.multipliersArray = new double[multipliers.Length];
            Array.Copy(multipliers, this.multipliersArray, multipliers.Length);
        }

        public double this[int index]
        {
            get
            {
                if (index >= 0 && index <= this.maxPower)
                {
                    return this.multipliersArray[index];
                }

                return 0;
            }
        }

        /// <summary>Implements the operator +.</summary>
        /// <param name="ls">The left-side Polynomial.</param>
        /// <param name="rs">The right-side Polynomial.</param>
        /// <returns>The result of the operation.</returns>
        public static Polynomial operator +(Polynomial ls, Polynomial rs)
        {
            if (ls == null)
            {
                if (rs == null)
                {
                    return null;
                }

                return rs;
            }

            if (rs == null)
            {
                return ls;
            }

            double[] resultMultiplierArray;
            double[] minimalArray;
            if (ls.multipliersArray.Length > rs.multipliersArray.Length)
            {
                resultMultiplierArray = ls.multipliersArray;
                minimalArray = rs.multipliersArray;
            }
            else
            {
                resultMultiplierArray = rs.multipliersArray;
                minimalArray = ls.multipliersArray;
            }

            for (int i = 0; i < minimalArray.Length; i++)
            {
                resultMultiplierArray[i] += minimalArray[i];
            }

            return new Polynomial(resultMultiplierArray);
        }

        /// <summary>Implements the operator -.</summary>
        /// <param name="ls">The left-side Polynomial.</param>
        /// <param name="rs">The right-side Polynomial.</param>
        /// <returns>The result of the operation.</returns>
        public static Polynomial operator -(Polynomial ls, Polynomial rs)
        {
            return ls + (rs * (-1));
        }

        /// <summary>Implements the operator *.</summary>
        /// <param name="ls">The left-side Polynomial.</param>
        /// <param name="rs">The right-side Polynomial.</param>
        /// <returns>The result of the operation.</returns>
        public static Polynomial operator *(Polynomial ls, Polynomial rs)
        {
            if (ls == null || rs == null)
            {
                return null;
            }

            double[] resultMultiplierArray = new double[ls.maxPower + rs.maxPower + 1];
            for (int i = 0; i < ls.multipliersArray.Length; i++)
            {
                for (int j = 0; j < rs.multipliersArray.Length; j++)
                {
                    resultMultiplierArray[i + j] += ls.multipliersArray[i] * rs.multipliersArray[j];
                }
            }

            return new Polynomial(resultMultiplierArray);
        }

        /// <summary>Implements the operator *.</summary>
        /// <param name="ls">The left-side Polynomial.</param>
        /// <param name="rs">The right-side double value.</param>
        /// <returns>The result of the operation.</returns>
        public static Polynomial operator *(Polynomial ls, double rs)
        {
            if (ls == null)
            {
                return null;
            }

            double[] resultMultiplierArray = new double[ls.maxPower + 1];
            for (int i = 0; i < ls.multipliersArray.Length; i++)
            {
                resultMultiplierArray[i] = ls.multipliersArray[i] * rs;
            }

            return new Polynomial(resultMultiplierArray);
        }

        /// <summary>Implements the operator ==.</summary>
        /// <param name="ls">The left-side value.</param>
        /// <param name="rs">The right-side value.</param>
        /// <returns>  Returns if two polynomials are equal.</returns>
        public static bool operator ==(Polynomial ls, Polynomial rs)
        {
            if (ReferenceEquals(ls, null))
            {
                if (ReferenceEquals(rs, null))
                {
                    return true;
                }

                return false;
            }

            return ls.Equals(rs);
        }

        /// <summary>Implements the operator ==.</summary>
        /// <param name="ls">The left-side value.</param>
        /// <param name="rs">The right-side value.</param>
        /// <returns>  Returns if two polynomials are not equal.</returns>
        public static bool operator !=(Polynomial ls, Polynomial rs)
        {
            return !(ls == rs);
        }

        /// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
        /// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            return this.Equals(obj as Polynomial);
        }

        /// <summary>Returns a hash code for this instance.</summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode(StringComparison.InvariantCulture);
        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="string"/> that represents this instance.</returns>
        public override string ToString()
        {
            string stringRepresentation = string.Empty;
            for (int i = this.maxPower; i >= 0; i--)
            {
                if (i != this.maxPower)
                {
                    switch (i)
                    {
                        case 0:
                            if (this.multipliersArray[i] > 0)
                            {
                                stringRepresentation += $"+{this.multipliersArray[i]}";
                            }

                            if (this.multipliersArray[i] < 0)
                            {
                                stringRepresentation += $"{this.multipliersArray[i]}";
                            }

                            break;
                        case 1:
                            if (this.multipliersArray[i] > 0)
                            {
                                stringRepresentation += $"+{this.multipliersArray[i]}x";
                            }

                            if (this.multipliersArray[i] < 0)
                            {
                                stringRepresentation += $"{this.multipliersArray[i]}x";
                            }

                            break;
                        default:
                            if (this.multipliersArray[i] > 0)
                            {
                                stringRepresentation += $"+{this.multipliersArray[i]}x^{i}";
                            }

                            if (this.multipliersArray[i] < 0)
                            {
                                stringRepresentation += $"{this.multipliersArray[i]}x^{i}";
                            }

                            break;
                    }
                }
                else
                {
                    if (this.multipliersArray[i] > 0 || this.multipliersArray[i] < 0)
                    {
                        stringRepresentation += $"{this.multipliersArray[i]}x^{i}";
                    }
                }
            }

            return stringRepresentation;
        }

        public bool Equals(Polynomial other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            return string.Equals(this.ToString(), other.ToString(), StringComparison.InvariantCulture);
        }

        public object Clone() => this.MemberwiseClone();
    }
}