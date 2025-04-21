using EncryptMethods.Interfaces;
using EncryptMethods.Services;

namespace EncryptMethods.Methods
{
    internal class RecursiveMethod : ISecurityElement
    {
        EncryptDecryptService service;
        public RecursiveMethod() {
            service = new EncryptDecryptService();
        }

        public string Decrypt(string text)
        {
            return service.RecursiveDecrypt(text);
        }

        public string Encrypt(string text)
        {
            return service.RecursiveEncrypt(text);
        }
    }
}
