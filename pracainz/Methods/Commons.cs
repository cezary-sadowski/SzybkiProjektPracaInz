using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pracainz.Models;
using System.Windows.Forms;

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

        public static string ConvertRTF()
        {
            string path = @"C:\_TMP\pracainz\pracainz\label11.rtf";
            RichTextBox rtBox = new RichTextBox();

            string rtfText = System.IO.File.ReadAllText(path);
            rtBox.Rtf = rtfText;
            string plainText = rtBox.Text;

            //System.IO.File.WriteAllText(@"@output", plainText);
            return plainText;
        }
    }
}