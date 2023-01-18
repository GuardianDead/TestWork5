using TestWork5.Data.Models;

namespace TestWork5.Controllers.ParseController.Requests;

public class ParseRequest
{
    public required HtmlParseDataTask HtmlParseDataTask { get; set; }
    public required AesDecryptDataTask AesDecryptDataTask { get; set; }
}