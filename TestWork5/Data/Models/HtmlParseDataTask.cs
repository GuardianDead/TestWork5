using TestWork5.Data.Validators.Common;

namespace TestWork5.Data.Models;

public class HtmlParseDataTask : ModelValidator<HtmlParseDataTask>
{
    public required string Selector { get; set; }
    public required string Attribute { get; set; }
    public required string UrlBase64 { get; set; }
    public required string PageBase64 { get; set; }
}