using System.Web;
using Api.Shared.Contracts;

namespace Api.Shared.Support;

public abstract class Filter : IFilter
{
    public abstract List<string> LocalParams { get; }

    public string ToQueryString()
    {
        var properties = from p in this.GetType().GetProperties()
                         where p.GetValue(this, null) is not null
                         select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(this, null).ToString());

        return string.Join("&", properties.ToArray());
    }

    public List<string> GetFilteredParams()
    {
        var properties = from p in this.GetType().GetProperties()
                         where p.GetValue(this, null) is not null && LocalParams.Contains(p.Name)
                         select p.Name;

        return properties.ToList();
    }

}