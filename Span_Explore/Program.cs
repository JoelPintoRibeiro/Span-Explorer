using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Span_Test
{
    class Program
    {
        unsafe static void Main(string[] args)
        {


            char[] bytes = "HelloUnmanaged".ToArray();

            int size = Marshal.SystemDefaultCharSize * bytes.Length;

            IntPtr pnt = Marshal.AllocHGlobal(28);

            Marshal.Copy(bytes, 0, pnt, bytes.Length);

            Span<Char> unmanagedSpan = new Span<char>(pnt.ToPointer(), 14);

            string managedString = "HelloManaged";

            var reversedFromManaged = ReverseStringTest(new Span<char>(managedString.ToArray()));

            var reversedFromUnmanaged = ReverseStringTest(unmanagedSpan);

            Marshal.FreeHGlobal(pnt);

            Console.Write(reversedFromManaged);
            Console.WriteLine();
            Console.Write(reversedFromUnmanaged);
            Console.ReadKey();

        }

        public static String ReverseStringTest(ReadOnlySpan<char> parameterString)
        {
            return new string(parameterString.ToArray().Reverse().ToArray());
        }

        //public static String ReverseString(string parameterString)
        //{
        //    char[] arr = parameterString.ToCharArray();
        //    Array.Reverse(arr);
        //    return new string(arr);
        //}

        //public static unsafe String ReverseUnmanagedString(IntPtr parameterString, int lenght)
        //{

        //    byte[] arr = new byte[lenght];

        //    Marshal.Copy((IntPtr)parameterString, arr, 0, lenght);
        //    string mystring = Encoding.ASCII.GetString(arr);

        //    char[] arra = mystring.ToCharArray();
        //    Array.Reverse(arra);


        //    return new string(arra); ;

        //}


    }
}
