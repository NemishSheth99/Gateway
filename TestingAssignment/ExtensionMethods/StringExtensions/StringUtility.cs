using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace StringExtensions
{
    public static class StringUtility
    {
        /// <summary>
        /// Uppercase characters converted to lowercase and vice versa
        /// </summary>
        /// <param name="str"></param>
        /// <returns>string</returns>
        public static string CaseConversion(this string str)
        {
            if (str.Length > 0)
            {
                
                char[] alphabetArray = str.ToCharArray();
                for(int i=0; i<alphabetArray.Length; i++)
                {
                   
                    alphabetArray[i] = char.IsUpper(alphabetArray[i]) ? char.ToLower(alphabetArray[i]) : char.ToUpper(alphabetArray[i]);
                }
                return new string(alphabetArray);
            }
            else
                return str;
        }

        /// <summary>
        /// Converts to title case 
        /// </summary>
        /// <param name="str"></param>
        /// <returns>string</returns>
        public static string TitleCase(this string str)
        {
            if (str == null) return null;
            else return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
        }

        /// <summary>
        /// String is in lower case or not
        /// </summary>
        /// <param name="str"></param>
        /// <returns>bool</returns>
        public static bool IsLower(this string str)
        {
            if (str.Length == 0) return false;
            else
            {
                char[] alphabetArray = str.ToCharArray();
                for(int i=0; i<alphabetArray.Length; i++)
                {
                    char alphabet = alphabetArray[i];
                    if( !(char.IsWhiteSpace(alphabet) || char.IsLower(alphabet)) )
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Returns a capitalized version of given input string 
        /// </summary>
        /// <param name="str"></param>
        /// <returns>string</returns>
        public static string CapitalCase(this string str)
        {
            if (str.Length > 0)
            {
                char[] alphabetArray = str.ToCharArray();

                if (char.IsLower(alphabetArray[0])) char.ToUpper(alphabetArray[0]);

                for (int i = 1; i < alphabetArray.Length; i++)
                {
                    if (char.IsWhiteSpace(alphabetArray[i - 1]))
                    {
                        alphabetArray[i] = char.ToUpper(alphabetArray[i]);
                        i++;
                    }
                    while ( i < alphabetArray.Length && !char.IsWhiteSpace(alphabetArray[i]))
                    {
                        //if (char.IsLetter(alphabetArray[i]))
                        //{
                            alphabetArray[i] = char.ToLower(alphabetArray[i]);
                            i++;
                        //}
                    }
                }
                return new string(alphabetArray);
            }
            else
                return str;
        }

        /// <summary>
        /// String is in upper case or not
        /// </summary>
        /// <param name="str"></param>
        /// <returns>bool</returns>
        public static bool IsUpper(this string str)
        {
            if (str.Length == 0) return false;
            else
            {
                char[] alphabetArray = str.ToCharArray();
                for (int i = 0; i < alphabetArray.Length; i++)
                {
                    char alphabet = alphabetArray[i];
                    if (!(char.IsWhiteSpace(alphabet) || char.IsUpper(alphabet)))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// string can be converted to a valid numeric value or not
        /// </summary>
        /// <param name="str"></param>
        /// <returns>bool</returns>
        public static bool ToDigitPossible(this string str)
        {
            if (str.Length == 0) return false;
            else
            {
                char[] alphabetArray = str.ToCharArray();
                for (int i = 0; i < alphabetArray.Length; i++)
                {
                    if (!char.IsDigit(alphabetArray[i]))
                        return false;
                }
                return true;
            }
        }

        /// <summary>
        /// remove the last character from given the string
        /// </summary>
        /// <param name="str"></param>
        /// <returns>string</returns>
        public static string RemoveLastChar(this string str)
        {
            if(str.Length == 0)
            {
                return null;
            }
            else
            {
                return str.Substring(0, str.Length - 1);
            }
        }

        /// <summary>
        ///word count from an input string
        /// </summary>
        /// <param name="str"></param>
        /// <returns>int</returns>
        public static int CountWord(this string str)
        {
            if (str.Length == 0) return 0;
            else
            {
                string[] wordArray = str.Split(' ');
                return wordArray.Count();
            }
        }

        /// <summary>
        /// Convert an input string to integer
        /// </summary>
        /// <param name="str"></param>
        /// <returns>int</returns>
        public static int ToInt(this string str)
        { int x = 0;
           
            if(str.Length>0)
            {
                Int32.TryParse(str, out x);
            }
            return x;

        }
    }

}
