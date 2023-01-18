namespace TestWork5.Data.Dtos;

public class HtmlParseDataTaskDto
{
    public required string Url { get; set; }
    public required int ElementsCount { get; set; }
    public required int EmailsCount { get; set; }
    public required IReadOnlyCollection<string> ElementsAttributeList { get; set; }
    public required IReadOnlyCollection<string> EmailsList { get; set; }
}