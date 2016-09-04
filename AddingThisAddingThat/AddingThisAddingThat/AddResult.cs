using System;
using System.Collections.Generic;
using System.Linq;

namespace AddingThisAddingThat
{
    public class AddResult
    {
        private byte[] f;
        private byte[] s;
        private byte[] result;

        public AddResult(byte[] f, byte[] s, byte[] result)
        {
            this.f = f;
            this.s = s;
            this.result = result;
        }

        //Override the Equals method to compare two objects of AddResult type.
        public override bool Equals(object obj)
        {
            var objectToCompare = obj as AddResult;

            //objectToCompare may not be null but just in case.
            if (objectToCompare != null)
            {
                return this.f.SequenceEqual(objectToCompare.f) 
                        && this.s.SequenceEqual(objectToCompare.s) 
                        && this.result.SequenceEqual(objectToCompare.result);
            }
            else
            {
                return false;
            }
        }
    }
}