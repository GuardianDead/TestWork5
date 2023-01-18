using TestWork5.Data.Dtos;

namespace TestWork5.Controllers.ParseController.Responses;

public class ParseResponse
{
    public required bool IsValid { get; set; }
    public string? ErrorCode { get; set; }
    public string? ErrorMessage { get; set; }
    
    public AesDecryptDataTaskDto? AesDecryptDataTaskDto { get; set; }
    public HtmlParseDataTaskDto? HtmlParseDataTaskDto { get; set; }
}