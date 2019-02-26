using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pracainz.Models;

namespace pracainz.Methods
{
    public static class Commons
    {
        public static double? CountOEE(double? dostepnosc, double? wydajnosc, double? jakosc)
        {
            if (dostepnosc == null || wydajnosc == null || jakosc == null)
                return 0;

            else
                return (dostepnosc * wydajnosc * jakosc) / 1000;
        }
    }
}