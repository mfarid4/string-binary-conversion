using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace StringToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                switch (args[0])
                {
                    case "":
                        break;
                    case "-bts":
                        PrintDetails printBTS = new(BinaryToString.BinToStr(args[1]));
                        break;
                    case "-stb":
                        PrintDetails printSTB = new(StringToBinary.StrToBin(args[1]));
                        break;
                    default:
                        Console.WriteLine("type '-bts' to convert from byte to string");
                        Console.WriteLine("type '-stb' to convert from string to byte");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public class BinaryToString
        {
            public static string BinToStr(string data)
            {
                List<byte> binaryCodesSum = new();
                string[] binaryCodesArr = data.Split(' ');

                foreach (string binaryCode in binaryCodesArr)
                {
                    binaryCodesSum.Add(Convert.ToByte(binaryCode, 2));
                }
                return Encoding.ASCII.GetString(binaryCodesSum.ToArray());
            }
        }

        public class StringToBinary
        {
            public static string StrToBin(string text)
            {
                StringBuilder binaryCodesSum = new();
                char[] binaryCodesArr = text.ToCharArray();

                foreach (var (item, index) in binaryCodesArr.WithIndex())
                {
                    if (index != text.Length)
                    {
                        binaryCodesSum.Append($"{Convert.ToString(item, 2).PadLeft(8, '0')} ");
                    }
                    else
                    {
                        binaryCodesSum.Append(Convert.ToString(item, 2).PadLeft(8, '0'));
                    }

                }
                return binaryCodesSum.ToString();
            }
        }

        public class PrintDetails
        {
            public PrintDetails(string message)
            {
                Console.WriteLine(message);
            }
        }

        internal class BinaryStringConversion
        {
            // without using Convert.ToByte
            internal static string BinaryToStringWithoutGenericMethod(string binaryCodes)
            {
                List<byte> binaryCodesSum = new();
                string[] binaryCodesArr = binaryCodes.Split(' ');

                foreach (var binarycode in binaryCodesArr)
                {
                    char[] binaryCodeToChar = binarycode.ToCharArray();
                    Array.Reverse(binaryCodeToChar);

                    int sum = 0;
                    int binaryMultiplier = 0;
                    foreach (char digit in binaryCodeToChar)
                    {
                        int digitMultiplier = Convert.ToInt32(Math.Pow(2, binaryMultiplier));
                        sum += digitMultiplier * Convert.ToInt32(digit.ToString());
                        binaryMultiplier++;
                    }
                    char converted = Convert.ToChar(sum);
                    binaryCodesSum.Add(Convert.ToByte(converted));

                    // reset sum and binaryMultiplier for next iteration
                    sum = 0;
                    binaryMultiplier = 0;
                }

                return Encoding.ASCII.GetString(binaryCodesSum.ToArray());
            }
        }
    }

    public static class CHelper
    {
        public static readonly Regex sWhitespace = new Regex(@"\s+");

        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
           => self.Select((item, index) => (item, index));

    }
}