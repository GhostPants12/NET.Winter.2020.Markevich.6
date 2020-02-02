using System;
using NUnit.Framework;
using PolynomialExtension;

namespace PolynomialExtension.Tests
{
    public class Tests
    {
        private Polynomial polynomialOne = new Polynomial( new double[] { -1.2, 1.3, 1.6, 0, 0, 5 });
        private Polynomial polynomialTwo = new Polynomial( new double[] { 1.6, 0, 0, 5 });
        private Polynomial polynomialThree = new Polynomial( new double[] { -1.2, 1.3, 1.6, 0, 0, 5 });
        private Polynomial resultPolynomial;
        private Polynomial nullPolynomial = null;
        [Test]
        public void PolynomialAdd_WithAllValidParameters()
        {
            resultPolynomial = new Polynomial(new double[] { -2.4, 2.6, 3.2, 0, 0, 10 });
            Assert.AreEqual(true, resultPolynomial == (polynomialOne+polynomialOne));
        }
        [Test]
        public void PolynomiaAdd_WithOneNullParameter()
        {
            resultPolynomial = polynomialOne;
            Assert.AreEqual(true, resultPolynomial == (polynomialOne + nullPolynomial));
        }

        [Test]
        public void PolynomialAdd_WithTwoNullParameters()
        {
            resultPolynomial = nullPolynomial;
            Assert.AreEqual(true, resultPolynomial==(nullPolynomial+nullPolynomial));
        }

        [Test]
        public void PolynomialSubtract_WithAllValidParameters()
        {
            resultPolynomial = new Polynomial( new double[] { 0, 0, 0, 0, 0, 0 });
            Assert.AreEqual(true, resultPolynomial == (polynomialOne - polynomialOne));
        }
        [Test]
        public void PolynomialSubtract_WithOneNullParameter()
        {
            resultPolynomial = polynomialOne;
            Assert.AreEqual(true, resultPolynomial == (polynomialOne - nullPolynomial));
        }

        [Test]
        public void PolynomialSubtract_WithTwoNullParameters()
        {
            resultPolynomial = nullPolynomial;
            Assert.AreEqual(true, resultPolynomial == (nullPolynomial - nullPolynomial));
        }

        [Test]
        public void EqualsTest_Operator()
        {
            Assert.AreEqual(polynomialOne.Equals(polynomialTwo), polynomialOne == polynomialTwo);
        }

        [Test]
        public void EqualsTests_ForNull()
        {
            Assert.AreEqual(false, polynomialOne.Equals(nullPolynomial));
        }

        [Test]
        public void EqualsTest_ForTwoEqualPolynomials()
        {
            Assert.AreEqual(true, polynomialOne.Equals(polynomialThree));
        }
        [Test]
        public void EqualsTest_ViceVersa()
        {
            Assert.AreEqual(polynomialOne.Equals(polynomialTwo), polynomialTwo.Equals(polynomialOne));
        }

        [Test]
        public void EqualsTest_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(delegate{nullPolynomial.Equals(polynomialOne);});
        }

        [Test]
        public void MultiplyTest_ForNullParameters()
        {
            Assert.AreEqual(true, nullPolynomial == nullPolynomial*nullPolynomial);
        }

        [Test]
        public void MultiplyTest_WithAllValidParameters()
        {
            resultPolynomial = new Polynomial(new double[]{-1.92, 2.08, 2.5600000000000005, -6, 6.5, 16, 0, 0, 25 });
            Assert.AreEqual(true, resultPolynomial == polynomialOne * polynomialTwo);
        }

        [Test]
        public void ToStringTest()
        {
            Assert.AreEqual("5x^5+1,6x^2+1,3x-1,2", polynomialThree.ToString());
        }

        [Test]
        public void ToStringTest_ForNull()
        {
            Assert.Throws<NullReferenceException>(delegate { nullPolynomial.ToString(); });
        }

        [Test]
        public void NotEqualOperatorTest_ForNotEqualParameters()
        {
            Assert.AreEqual(true, polynomialOne!=polynomialTwo);
        }

        [Test]
        public void NotEqualOperatorTest_ForEqualParameters()
        {
            Assert.AreEqual(false, polynomialOne != polynomialThree);
        }
    }
}