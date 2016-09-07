﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionLib
{
    public interface IConverter
    {
        string ConvertFromIntToRoman(int input);

        int ConvertFromRomanToInt(string romanInput);
    }
}
