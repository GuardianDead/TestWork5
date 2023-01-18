using System.Collections.Immutable;
using System.Text;
using System.Text.RegularExpressions;
using AngleSharp.Html.Parser;
using TestWork5.Data.Dtos;
using TestWork5.Data.Models;
using TestWork5.Services.Interfaces;

namespace TestWork5.Services;

public partial class HtmlParseService : IHtmlParseService
{
    public HtmlParseDataTaskDto Parse(HtmlParseDataTask parseDataTask)
    {
        var url = Encoding.UTF8.GetString(Convert.FromBase64String(parseDataTask.UrlBase64));
        var page = Encoding.UTF8.GetString(Convert.FromBase64String(parseDataTask.PageBase64));
        var document = new HtmlParser().ParseDocument(page);
        var elements = document.QuerySelectorAll(parseDataTask.Selector);
        var attributeValues = elements.Select(element => element.Attributes.Single(attribute => attribute.Name == parseDataTask.Attribute).Value).Distinct();
        var emails = EmailRegex().Matches(page).Select(match => match.Value).Distinct();
        return new HtmlParseDataTaskDto()
        {
            Url = url,
            ElementsCount = elements.Length,
            EmailsCount = emails.Count(),
            ElementsAttributeList = attributeValues.ToImmutableArray(),
            EmailsList = emails.ToImmutableArray()
        };
    }

    [GeneratedRegex("((?!\\.)[\\w_.]*[^.])(@\\w+)(\\.\\w+(\\.\\w+)?[^.\\W])", RegexOptions.Compiled)]
    private static partial Regex EmailRegex();
}