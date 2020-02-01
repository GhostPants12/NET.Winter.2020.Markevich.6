using System;
using System.Collections.Generic;
using System.Text;

namespace PolynomialExtension
{
    public class Polynomial
    {
        private readonly double x;
        private readonly int power;
        private readonly double[] multipliersArray;

        /// <summary>Initializes a new instance of the <see cref="Polynomial"/> class.</summary>
        /// <param name="value">The value.</param>
        /// <param name="powerValue">The power value.</param>
        /// <param name="multipliers">The multipliers array.</param>
        /// <exception cref="System.ArgumentNullException">multipliers - Multipliers array is null.</exception>
        /// <exception cref="System.ArgumentException">Wrong multipliers array.</exception>
        public Polynomial(double value, int powerValue, double[] multipliers)
        {
            if (multipliers == null)
            {
                throw new ArgumentNullException(nameof(multipliers), "Multipliers array is null");
            }

            if (multipliers.Length != powerValue + 1)
            {
                throw new ArgumentException("Wrong multipliers array");
            }

            this.x = value;
            this.power = powerValue;
            this.multipliersArray = new double[powerValue + 1];
            for (int i = 0; i < multipliers.Length; i++)
            {
                this.multipliersArray[i] = multipliers[i];
            }
        }

        /// <summary>Gets the variable value.</summary>
        /// <value>The value.</value>
        public double Variable
        {
            get { return this.x; }
        }

        /// <summary>Gets the maximum power of the polynomial.</summary>
        /// <value>The maximum power of the polynomial.</value>
        public int Power
        {
            get { return this.power; }
        }

        /// <summary>Implements the operator +.</summary>
        /// <param name="ls">The left-side value.</param>
        /// <param name="rs">The right-side value.</param>
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

            if (ls.Variable == rs.Variable)
            {
                double[] resultMultiplierArray;
                double[] minimalArray;
                if (ls.GetMultipliers().Length > rs.GetMultipliers().Length)
                {
                    resultMultiplierArray = ls.GetMultipliers();
                    minimalArray = rs.GetMultipliers();
                }
                else
                {
                    resultMultiplierArray = rs.GetMultipliers();
                    minimalArray = ls.GetMultipliers();
                }

                for (int i = 0; i < minimalArray.Length; i++)
                {
                    resultMultiplierArray[i] += minimalArray[i];
                }

                return new Polynomial(ls.Variable, resultMultiplierArray.Length - 1, resultMultiplierArray);
            }
            else
            {
                return ls;
            }
        }

        /// <summary>Implements the operator -.</summary>
        /// <param name="ls">The left-side value.</param>
        /// <param name="rs">The right-side value.</param>
        /// <returns>The result of the operation.</returns>
        public static Polynomial operator -(Polynomial ls, Polynomial rs)
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

            if (ls?.Variable == rs?.Variable)
            {
                double[] resultMultiplierArray;
                double[] minimalArray;
                if (ls.GetMultipliers().Length > rs.GetMultipliers().Length)
                {
                    resultMultiplierArray = ls.GetMultipliers();
                    minimalArray = rs.GetMultipliers();
                }
                else
                {
                    resultMultiplierArray = rs.GetMultipliers();
                    minimalArray = ls.GetMultipliers();
                }

                for (int i = 0; i < minimalArray.Length; i++)
                {
                    resultMultiplierArray[i] -= minimalArray[i];
                }

                return new Polynomial(ls.Variable, resultMultiplierArray.Length - 1, resultMultiplierArray);
            }
            else
            {
                return null;
            }
        }

        /// <summary>Implements the operator *.</summary>
        /// <param name="ls">The left-side value.</param>
        /// <param name="rs">The right-side value.</param>
        /// <returns>The result of the operation.</returns>
        public static Polynomial operator *(Polynomial ls, Polynomial rs)
        {
            if (ls == null || rs == null)
            {
                return null;
            }

            if (ls.Variable == rs.Variable)
            {
                double[] resultMultiplierArray = new double[ls.Power + rs.Power + 1];
                for (int i = 0; i < ls.GetMultipliers().Length; i++)
                {
                    for (int j = 0; j < rs.GetMultipliers().Length; j++)
                    {
                        resultMultiplierArray[i + j] += ls.GetMultipliers()[i] * rs.GetMultipliers()[j];
                    }
                }

                return new Polynomial(ls.Variable, ls.Power + rs.Power, resultMultiplierArray);
            }
            else
            {
                return ls;
            }
        }

        /// <summary>Implements the operator ==.</summary>
        /// <param name="ls">The left-side value.</param>
        /// <param name="rs">The right-side value.</param>
        /// <returns>  Returns if two polynomials are equal.</returns>
        public static bool operator ==(Polynomial ls, Polynomial rs)
        {
            try
            {
                if (ls.Equals(rs))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (NullReferenceException)
            {
                return (object)ls == (object)rs;
            }
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

            Polynomial comparingPolynomial = obj as Polynomial;
            if (this.Variable == comparingPolynomial.Variable && this.Power == comparingPolynomial.Power)
            {
                for (int i = 0; i < this.power + 1; i++)
                {
                    if (comparingPolynomial.GetMultipliers()[i] != this.GetMultipliers()[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>Gets the multipliers array.</summary>
        /// <returns>Multipliers array.</returns>
        public double[] GetMultipliers()
        {
            return this.multipliersArray;
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
            for (int i = this.power; i >= 0; i--)
            {
                if (i != this.power)
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
                    stringRepresentation += $"{this.multipliersArray[i]}x^{i}";
                }
            }

            return stringRepresentation;
        }
    }
}
