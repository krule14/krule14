using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace color_mile2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MileConverter()
        {
            double Retval = 0;

            string MetricUnitsString = Request.QueryString["Metric"];
            double Miles = Convert.ToDouble(Request.QueryString["Miles"]);

            Retval = Miles * 1.60934;

            if (MetricUnitsString == "millimeters")
                Retval *= 1000000;
            else if (MetricUnitsString == "centimeters")
                Retval *= 100000;
            else if (MetricUnitsString == "meters")
                Retval *= 1000;
            else if (MetricUnitsString == "kilometers")
            { }
            else
            {
                ViewBag.Message = "";
                return View();
            }

            ViewBag.Message = Miles + " miles is " + Retval + " " + MetricUnitsString;

            return View();

        }

        public ActionResult ColorMixer()
        {
            //turning to color because it makes the bit manipulation clearer
            if (!string.IsNullOrEmpty(Request.QueryString["HexVal1"]) ||
                !string.IsNullOrEmpty(Request.QueryString["HexVal1"]))
            {

                var color1 = HexToColor(Request.QueryString["HexVal2"]);
                var color2 = HexToColor(Request.QueryString["HexVal2"]);
                // var color1 = HexToColor(ViewBag.HexVal1);
                //var color2 = HexToColor(ViewBag.HexVal2);
                //color mixing (be sure each value is between 0 and 255)
                Color mixed = Color.FromArgb(255, ColorRanger(color1.R + color2.R),
                    ColorRanger(color1.G + color2.G), ColorRanger(color1.B + color2.B));

                //convert argb to rgb, make it exactly 6 chars(fill with 0's), put it in the form of capital hex values, then convert to a string format
                string retval = string.Format("#{0:X06}", ColorToUInt(mixed) & 0xffffff);

                ViewBag.MixedColor = retval;
            }
            return View();
        }
        private int ColorRanger(int myInt)
        {
            if (myInt > 255)
            {
                return 255;
            }
            if (myInt < 0)
            {
                return 0;
            }
            return myInt;
        }
        private uint ColorToUInt(Color color)
        {
            return (uint)((color.A << 24) | (color.R << 16) |
                          (color.G << 8) | (color.B << 0));
        }
        private Color UIntToColor(uint color)
        {
            byte a = (byte)(color >> 24);
            byte r = (byte)(color >> 16);
            byte g = (byte)(color >> 8);
            byte b = (byte)(color >> 0);
            return Color.FromArgb(a, r, g, b);
        }

        private void Blend()
        {

        }

        private Color HexToColor(string myVal)
        {

            if (!string.IsNullOrEmpty(myVal) && myVal.Length >= 7 && myVal[0] == '#')
            {
                uint.TryParse(myVal.Substring(1),
                        NumberStyles.HexNumber,
                        CultureInfo.CurrentCulture,
                        out uint color);

                return UIntToColor(color);
            }
            return UIntToColor(0);
        }

    }
}