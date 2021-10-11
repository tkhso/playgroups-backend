using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Web;

namespace HMMJ.Helpers
{
    public static class Extensions
    {
        public static RouteValueDictionary RouteValues(this QueryString q)
        {
            var queryString = HttpUtility.ParseQueryString(q.Value);

            var dic = new RouteValueDictionary();
            foreach (var key in queryString.AllKeys)
            {
                string val;
                if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty((val = queryString[key])))
                    continue;
                dic.Add(key, val);
            }
            return dic;
        }
    }
}
