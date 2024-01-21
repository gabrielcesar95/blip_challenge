using System.Web;
using Api.Shared.Contracts;

namespace Api.Shared.Support;

public class Filter : IFilter
{
    public string ToQueryString()
    {
        var properties = from p in this.GetType().GetProperties()
                         where p.GetValue(this, null) is not null
                         select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(this, null).ToString());

        return string.Join("&", properties.ToArray());
    }
}