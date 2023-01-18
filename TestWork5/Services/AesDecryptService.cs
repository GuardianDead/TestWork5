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
        byte[] encryptedText = Convert.FromBase64String(data.EncryptedTextBytesBase64);
        byte[] key = Convert.FromBase64String(data.KeyBytesBase64);
        using Aes aes = Aes.Create();
        aes.Key = key;
        string text = Encoding.UTF8.GetString(aes.DecryptEcb(encryptedText, PaddingMode.None));
        return new AesDecryptDataTaskDto()
        {
            DecryptedPlainText = text
        };
    }
}