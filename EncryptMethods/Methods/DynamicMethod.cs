using EncryptMethods.Interfaces;
using EncryptMethods.Services;
using System;

namespace EncryptMethods.Methods
{
    internal class DynamicMethod : ISecurityElement
    {
        Func<char, char> _dynamicEncryptMethod;
        Func<char, char> _dynamicDecryptMethod;
        EncryptDecryptService service;

        public DynamicMethod(Func<char, char> dynamicEncryptMethod, Func<char, char> dynamicDecryptMethod)
        {
            _dynamicEncryptMethod = dynamicEncryptMethod;
            _dynamicDecryptMethod = dynamicDecryptMethod;

            service = new EncryptDecryptService();
        }

        public string Decrypt(string text)
        {
            return service.DynamicEncryptDecrypt(_dynamicDecryptMethod, text);
        }

        public string Encrypt(string text)
        {
            return service.DynamicEncryptDecrypt(_dynamicEncryptMethod, text);
        }
    }
}
