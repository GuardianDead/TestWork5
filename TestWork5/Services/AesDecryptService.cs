using System.Security.Cryptography;
using System.Text;
using TestWork5.Data.Dtos;
using TestWork5.Data.Models;
using TestWork5.Services.Interfaces;

namespace TestWork5.Services;

public class AesDecryptService : IAesDecryptService
{
    public AesDecryptDataTaskDto Decrypt(AesDecryptDataTask data)
    {
        var encryptedText = Convert.FromBase64String(data.EncryptedTextBytesBase64);
        var key = Convert.FromBase64String(data.KeyBytesBase64);
        using var aes = Aes.Create();
        aes.Key = key;
        var text = Encoding.UTF8.GetString(aes.DecryptEcb(encryptedText, PaddingMode.None));
        return new AesDecryptDataTaskDto()
        {
            DecryptedPlainText = text
        };
    }
}