using System;
using NUnit.Framework;
using System.Collections;

namespace AddingThisAddingThat
{
    [TestFixture]
    public class AddingThisAddingThatTests
    {
        public static IEnumerable Add_Source
        {
            get
            {
                yield return new TestCaseData(new byte[3] { 1, 1, 1 }, new byte[3] { 1, 1, 1 })
                                        .Returns(new AddResult(new byte[3] { 1, 1, 1 }, new byte[3] { 1, 1, 1 }, new byte[3] { 2, 2, 2 }));
                yield return new TestCaseData(new byte[3] { 1, 1, 255 }, new byte[3] { 0, 0, 1})
                                   .Returns(new AddResult(new byte[3] { 1, 1, 255 }, new byte[3] { 0, 0, 1 }, new byte[3] { 1, 1, 0 }));
                
            }
        }

        [Test]
        [TestCaseSource("Add_Source")]
        public AddResult Add_UsingARecursiveAlgorithm_ValuesAreAdded(byte[] f, byte[] s)
        {
            // Arrange
            // Act
            var result = AddRecursive(f, s);

            // Assert
            return new AddResult(f, s, result);
        }

        private byte[] AddRecursive(byte[] f, byte[] s)
        {
            var result = new byte[f.Length];
            this.AddRecursive(f, s, result, 0);
            return result;
        }

        private void AddRecursive(byte[] f, byte[] s, byte[] result,int index)
        {
            if(index == f.Length)
            {
                return;
            }
            else
            {
                result[index] = (byte)(f[index] + s[index]);
                AddRecursive(f, s, result, index + 1);
            }
        }
    }
}
