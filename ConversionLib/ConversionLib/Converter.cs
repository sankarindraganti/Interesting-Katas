using System;
using System.Collections.Generic;
using System.Text;

namespace ConversionLib
{
    public class Converter : IConverter
    {
        private readonly Dictionary<char,int> _romanMap = new Dictionary<char, int>();

        private readonly List<Tuple<int, string>> _numberMap = new List<Tuple<int, string>>();

        public Converter()
        {
            _romanMap.Add('I',1);
            _romanMap.Add('V',5);
            _romanMap.Add('X',10);
            _romanMap.Add('L',50);
            _romanMap.Add('C',100);
            _romanMap.Add('D',500);
            _romanMap.Add('M',1000);

            _numberMap.Add(new Tuple<int, string>(1,"I"));
            _numberMap.Add(new Tuple<int, string>(4,"IV"));
            _numberMap.Add(new Tuple<int, string>(5, "V"));
            _numberMap.Add(new Tuple<int, string>(9, "IX"));
            _numberMap.Add(new Tuple<int, string>(10, "X"));
            _numberMap.Add(new Tuple<int, string>(40,"XL"));
            _numberMap.Add(new Tuple<int, string>(50,"L"));
            _numberMap.Add(new Tuple<int, string>(90,"XC"));
            _numberMap.Add(new Tuple<int, string>(100, "C"));
            _numberMap.Add(new Tuple<int, string>(400,"CD"));
            _numberMap.Add(new Tuple<int, string>(500,"D"));
            _numberMap.Add(new Tuple<int, string>(900,"CM"));
            _numberMap.Add(new Tuple<int, string>(1000,"M"));
        }
        public string ConvertFromIntToRoman(int input)
        {
            if(input == 0)
                throw new ArgumentException("0 is not a valid Roman Number");
            if(input>=5000)
                throw new ArgumentException("ConvertFromIntToRoman supports conversion of int between 0 to 4999");

            var result = new StringBuilder();
            while (input > 0)
            {
                for (var i = _numberMap.Count-1; i >= 0; i--)
                {
                    if (input/_numberMap[i].Item1 >0)
                    {
                        result.Append(_numberMap[i].Item2);
                        input -= _numberMap[i].Item1;
                        break;
                    }
                }

            }
            return result.ToString();
        }

        public int ConvertFromRomanToInt(string romanInput)
        {
            if(string.IsNullOrEmpty(romanInput))
                throw new ArgumentNullException($"Roman input cannot be null");

            var result = 0;
            for (var i = 0; i < romanInput.Length; i++)
            {
                if (_romanMap.ContainsKey(romanInput[i]))
                {
                    if ((i + 1 < romanInput.Length) && (_romanMap[romanInput[i]] < _romanMap[romanInput[i + 1]]))
                    {
                        result -= _romanMap[romanInput[i]];
                    }
                    else
                    {
                        result += _romanMap[romanInput[i]];
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid roman number");
                }
            }
            return result;
        }
    }
}
