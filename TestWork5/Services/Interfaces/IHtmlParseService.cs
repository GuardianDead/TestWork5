using TestWork5.Data.Dtos;
using TestWork5.Data.Models;

namespace TestWork5.Services.Interfaces;

public interface IHtmlParseService
{
    public HtmlParseDataTaskDto Parse(HtmlParseDataTask parseDataTask);
}