using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Hmb.Biriba.Scanner
{
    public class ParametricUrlEncodedContent : ParametricContent
    {
        public class UrlEncodedContentParameter : Parameter
        {

        }

        public override IEnumerable<Parameter> GetParameters()
        {
            if (Content is null)
            {
                yield break;
            }

            var parameters = from parameter in Content.Split('&')
                             let keyValuePair = parameter.Split('=')
                             select new KeyValuePair<string?, string?>(
                                 HttpUtility.UrlDecode(keyValuePair[0]),
                                 HttpUtility.UrlDecode(keyValuePair[1])
                              );

            foreach (var parameter in parameters)
            {
                yield return new UrlEncodedContentParameter
                {
                };
            }

        }
    }
}
