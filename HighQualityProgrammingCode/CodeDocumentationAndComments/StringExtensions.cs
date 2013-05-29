namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
    
    /// <summary>
    /// Contains extension methods defined for the <see cref="System.String"/> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Returns the MD5 hash of a string.
        /// </summary>
        /// <param name="input">The string whose hash will be calculated.</param>
        /// <returns>The 128-bit hash of the string.</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Checks if the string can be interpeted as <see cref="System.Boolean"/> "true".
        /// </summary>
        /// <param name="input">The string that will be checked.</param>
        /// <returns>True if the string can be interpreted as <see cref="System.Boolean"/> "true".</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts the string to <see cref="System.Int16"/>.
        /// </summary>
        /// <param name="input">The string that will be converted to <see cref="System.Int16"/>.</param>
        /// <returns>The string value converted to <see cref="System.Int16"/>.</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts the string to <see cref="System.Int32"/>.
        /// </summary>
        /// <param name="input">The string that will be converted to <see cref="System.Int32"/>.</param>
        /// <returns>The string value converted to <see cref="System.Int32"/>.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts the string to <see cref="System.Int64"/>.
        /// </summary>
        /// <param name="input">The string that will be converted to <see cref="System.Int64"/>.</param>
        /// <returns>The string value converted to <see cref="System.Int64"/>.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts the string to <see cref="System.DateTime"/>.
        /// </summary>
        /// <param name="input">The string that will be converted to <see cref="System.DateTime"/>.</param>
        /// <returns>The string value converted to <see cref="System.DateTime"/>.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Returns the provided string with its first letter converted to uppercase.
        /// </summary>
        /// <param name="input">The string whose first letter will be converted to uppercase.</param>
        /// <returns>A copy of the provided string with its first letter converted to uppercase.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            //Extract the first letter of the provided string, convert it to
            //uppercase and concatenate it with the remaining part of the string.
            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Returns a substring which is between <paramref name="startString"/>
        /// and <paramref name="endString"/>. Search starts from <paramref name="startFrom"/> index.
        /// </summary>
        /// <param name="input">The string in which the search will be performed.</param>
        /// <param name="startString">The left delimiter of the result string.</param>
        /// <param name="endString">The right delimiter of the result string.</param>
        /// <param name="startFrom">The start position of the search.></param>
        /// <returns>A string that is equivalent to the substring which is between <paramref name="startString"/>
        /// and <paramref name="endString"/> searching from <paramref name="startFrom"/> or System.String.Empty 
        /// if <paramref name="startString"/> or <paramref name="endString"/> don't occur within this instance.</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Replaces all occurrences of Cyrillic letters in the provided string with their Latin counterparts.
        /// </summary>
        /// <param name="input">The string in which all occurrences of Cyrrilic letters
        /// will be replaces with their Latin equivalents.</param>
        /// <returns>A string in which all occurrences of Cyrillic letters are replaced with
        /// their Latin equivalents.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Replaces all occurrences of Latin letters in the provided string with their Cyrillic counterparts.
        /// </summary>
        /// <param name="input">The string in which all occurrences of Latin letters
        /// will be replaces with their Cyrillic equivalents.</param>
        /// <returns>A string in which all occurrences of Latin letters are replaced with
        /// their Cyrillic equivalents.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Returns a string in which the Cyrillic letters are replaced with their Latin equivalents
        /// and all non-alphanumeric characters (excluding the period ".") are removed.
        /// </summary>
        /// <param name="input">The string which will be validated.</param>
        /// <returns>A copy of the provided string where all Cyrillic letters are replaced with their Latin. </returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Returns a string in which the Cyrillic letters are replaced with their Latin equivalents,
        /// spaces are replaced with hyphens and all non-alphanumeric characters 
        /// (excluding the period "." and hyphen "-") are removed.</summary>
        /// <param name="input">The file name which will be validated</param>
        /// <returns>A copy of the provided file name where all Cyrillic letters are replaced with their Latin
        /// equivalents, spaces are replaced with hyphens and all non-alphanumeric characters
        /// (excluding the period "." and hyphen "-") are removed.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Returns a substring of the provided string which starts from the beginning and 
        /// whose length is the lesser of the string's length and <paramref name="charsCount"/>.
        /// </summary>
        /// <param name="input">The string from which the substring will be extracted.</param>
        /// <param name="charsCount">The number of characters in the substring.</param>
        /// <returns>A string containing the first characters of provided string.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Returns the file extension of the string (interpreted as a file name).
        /// The period "." is omitted.
        /// </summary>
        /// <param name="fileName">The file name, which extension will be extracted.</param>
        /// <returns>Returns the last item in the array which is obtained by splitting
        /// the string by the period "." character.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Returns the corresponding content type for the specified file extension.
        /// </summary>
        /// <param name="fileExtension">The file extension (excluding the period ".").</param>
        /// <returns>The content type as a string.</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts a set of characters from the specified character array into a sequence of bytes.
        /// </summary>
        /// <param name="input">The string, whose characters are going to be converted into a 
        /// sequence of bytes.</param>
        /// <returns>A byte array containing the specified set of characters.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
