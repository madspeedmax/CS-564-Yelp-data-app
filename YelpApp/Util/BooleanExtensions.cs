using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YelpApp.Util
{
    public static class BooleanExtensions
    {
        public static string ToYesNoString(this bool value)
        {
            return value ? "Yes" : "No";
        }
    }
}