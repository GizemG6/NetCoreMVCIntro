using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMVCIntro.StringExtensions//örnek extension
{
    //extension sınıfları static olur.static sınıfların içine zaten static üyeler yazabiiriz.
    public static class StringExtensions
    {
        //this keyword ile c# da extent edebileceğimiz tipi belirtiriz.
        //this IApplicationBuilder app IApplicationBuilder interfaceden türeyen tüm nesneleri extent etmiş.
        public static string ToUpperCase(this string value)
        {
            return value.ToUpper();
        }
        public static string GetPrettyDate(this DateTime date)
        {
            return date.ToShortDateString();
        }
    }
}
