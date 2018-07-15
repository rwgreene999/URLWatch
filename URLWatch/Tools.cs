using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLWatch
{
    // C# V6 updates to these extensions 
    public static class Tools
    {

        //// todo:  See if there is a way to generic this 
        //public static T TryParse<T>(this string NumberString, T DefaultResponse)
        //{
        //    if (T.TryParse(NumberString, out var response))
        //    {
        //        return response;
        //    }
        //    else
        //    {
        //        return DefaultResponse;
        //    }
        //}


        public static int TryParse(this string NumberString, int DefaultResponse)
        {
            return int.TryParse(NumberString, out var results) ? results : DefaultResponse;
        }
        public static long TryParse(this string NumberString, long DefaultResponse)
        {
            return long.TryParse(NumberString, out var results) ? results : DefaultResponse;
        }
        public static double TryParse(this string NumberString, double DefaultResponse)
        {
            return double.TryParse(NumberString, out var results) ? results : DefaultResponse;
        }
    }
}
