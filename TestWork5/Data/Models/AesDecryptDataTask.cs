namespace TestWork5.Data.Models;

public class AesDecryptDataTask
{
    public required string EncryptedTextBytesBase64 { get; set; }
    public required string KeyBytesBase64 { get; set; }
}