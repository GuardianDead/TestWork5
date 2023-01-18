using Microsoft.AspNetCore.Mvc;
using TestWork5.Controllers.ParseController.Requests;
using TestWork5.Controllers.ParseController.Responses;
using TestWork5.Data.Dtos;
using TestWork5.Services.Interfaces;

namespace TestWork5.Controllers.ParseController;

[ApiController]
[Route("api/[controller]")]
public class ParseController : ControllerBase
{
    private readonly IHtmlParseService _htmlParseService;
    private readonly IAesDecryptService _aesDecryptService;

    public ParseController(IHtmlParseService htmlParseService, IAesDecryptService aesDecryptService)
    {
        _htmlParseService = htmlParseService;
        _aesDecryptService = aesDecryptService;
    }

    [HttpPost]
    public IActionResult Parse([FromBody] ParseRequest request)
    {
        HtmlParseDataTaskDto htmlParseDataTaskDto;
        AesDecryptDataTaskDto aesDecryptDataTaskDto;
        try
        {
            htmlParseDataTaskDto = _htmlParseService.Parse(request.HtmlParseDataTask);
            aesDecryptDataTaskDto = _aesDecryptService.Decrypt(request.AesDecryptDataTask);
        }
        catch (Exception e)
        {
            return BadRequest(new ParseResponse()
            {
                IsValid = false,
                ErrorMessage = e.Message
            });
        }
        
        return Ok(new ParseResponse()
        {
            IsValid = true,
            HtmlParseDataTaskDto = htmlParseDataTaskDto,
            AesDecryptDataTaskDto = aesDecryptDataTaskDto
        });
    }
}