using EncryptMethods.Interfaces;
using EncryptMethods.Services;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace EncryptMethods.Methods
{
    internal class InvertCharsMethod : ISecurityElement
    {
        EncryptDecryptService service;
        public InvertCharsMethod()
        {
            service = new EncryptDecryptService();
        }

        public string Decrypt(string text)
        {
            return service.InvertChars(text);
        }

        public string Encrypt(string text)
        {
            return service.InvertChars(text);
        }
    }
}
