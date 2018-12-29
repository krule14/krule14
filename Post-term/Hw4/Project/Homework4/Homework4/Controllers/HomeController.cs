using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Chooser()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Chooser(string Color1, string Color2)
        {
            ViewBag.err = "";

            if (!IsHex(Color1) || !IsHex(Color2))
            {
                ViewBag.err = "Sorry, you must input valid hex values.";
                return View();
            }
            ViewBag.Color1 = Color1;
            ViewBag.Color2 = Color2;
            ViewBag.Result = MixColors(Color1, Color2);

            return View();
        }
        public string MixColors(string firstColor, string secondColor)
        {
            if (!IsHex(firstColor) || !IsHex(secondColor))
            {
                return "Err";
            }
            return Mix(firstColor, secondColor);
        }
        private string Mix(string firstColor, string secondColor)
        {
            string[] colorString1 = { firstColor.Substring(0, 2), firstColor.Substring(2, 2), firstColor.Substring(4, 2) };
            string[] colorString2 = { secondColor.Substring(0, 2), secondColor.Substring(2, 2), secondColor.Substring(4, 2) };

            int[] colorint1 = { HexStrToInt(colorString1[0]), HexStrToInt(colorString1[1]), HexStrToInt(colorString1[2]) };
            int[] colorint2 = { HexStrToInt(colorString2[0]), HexStrToInt(colorString2[1]), HexStrToInt(colorString2[2]) };


            string retString = "";
            for (int i = 2; i >= 0; i--)
            {
                int tempInt = colorint1[i] + colorint2[i];
                if (tempInt > 255) { tempInt = 255; }
                if (tempInt < 0) { tempInt = 0; }

                retString = HexInttoString(tempInt) + retString;
            }

            return retString;

        }
        private string HexInttoString(int hexInt)
        {
            string retval = "";
            int num = hexInt;
            while (num > 15)
            {
                retval = HIntToStrHelper(num % 16) + retval;
                num = (int)(num / 16);
            }
            retval = HIntToStrHelper(num % 16) + retval;
            return retval;
        }
        private string HIntToStrHelper(int num)
        {
            if (num < 10) return "" + num;
            switch (num)
            {
                case 10: return "A";
                case 11: return "B";
                case 12: return "C";
                case 13: return "D";
                case 14: return "E";
                case 15: return "F";
            }
            return "";

        }
        private int HexStrToInt(string hexString)
        {
            int retval = 0;
            int place = hexString.Length - 1;
            foreach (char n in hexString)
            {
                if (CharToInt(n) != -1)
                {
                    retval += (CharToInt(n) * (int)(Math.Pow(16, place)));
                }
                place--;
            }
            return retval;
        }
        private int CharToInt(char hexChar)
        {
            switch (hexChar)
            {
                case '0': return 0;
                case '1': return 1;
                case '2': return 2;
                case '3': return 3;
                case '4': return 4;
                case '5': return 5;
                case '6': return 6;
                case '7': return 7;
                case '8': return 8;
                case '9': return 9;

                case 'A': return 10;
                case 'a': return 10;
                case 'B': return 11;
                case 'b': return 11;
                case 'C': return 12;
                case 'c': return 12;
                case 'D': return 13;
                case 'd': return 13;
                case 'E': return 14;
                case 'e': return 14;
                case 'F': return 15;
                case 'f': return 15;
                default:
                    return -1;
            }

        }
        private bool IsHex(string hexval)
        {
            if (hexval.Length != 6)
            {
                return false;
            }

            foreach (char n in hexval)
            {
                if (!(
                        n == '0' || n == '1' || n == '2' || n == '3' || n == '4' ||
                        n == '5' || n == '6' || n == '7' || n == '8' || n == '9' ||

                        n == 'A' || n == 'a' || n == 'B' || n == 'b' ||
                        n == 'C' || n == 'c' || n == 'D' || n == 'd' ||
                        n == 'E' || n == 'e' || n == 'F' || n == 'f'
                    ))
                {
                    return false;
                }
            }
            return true;
        }


        public ActionResult Converter()
        {
            return View();
        }
    }
}