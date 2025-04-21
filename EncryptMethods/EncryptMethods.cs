using EncryptMethods.Methods;
using System;

namespace EncryptMethods
{
    public class EncryptMethods
    {
        public string EncryptText(string text)
        {
            var invertCharsMethod = new InvertCharsMethod();
            text = invertCharsMethod.Encrypt(text);

            var recursiveMethod = new RecursiveMethod();
            text = recursiveMethod.Encrypt(text);

            var dynamicMethod = new DynamicMethod(DynamicEncryptCharMethod, DynamicDecryptCharMethod);
            text = dynamicMethod.Encrypt(text);

            return text;
        }

        public string DecryptText(string text)
        {
            DynamicMethod dynamicMethod = new DynamicMethod(DynamicEncryptCharMethod, DynamicDecryptCharMethod);
            text = dynamicMethod.Decrypt(text);

            RecursiveMethod recursiveMethod = new RecursiveMethod();
            text = recursiveMethod.Decrypt(text);

            InvertCharsMethod invertCharsMethod = new InvertCharsMethod();
            text = invertCharsMethod.Decrypt(text);
            return text;
        }

        public char DynamicEncryptCharMethod(char character)
        {
            const char changePositions = (char)5;

            var charPos = Convert.ToInt16(character);
            var result = charPos + changePositions;

            //si son números varío entre los caracteres de los números
            if (charPos >= 48 && charPos <= 57 && result > 57)
            {
                return (char)(result - 10);
            }

            //si son mayúsculas varío entre los caracteres de las mayúsculas
            if (charPos >= 65 && charPos <= 90 && result > 90)
            {
                return (char)(result - 25);
            }

            //si son minúsculas varío entre los caracteres de las minúsculas
            if (charPos >= 97 && charPos <= 122 && result > 122)
            {
                return (char)(result - 25);
            }

            return (char)result;
        }

        public char DynamicDecryptCharMethod(char character)
        {
            const char changePositions = (char)5;

            var charPos = Convert.ToInt16(character);
            var result = charPos - changePositions;

            //si son números varío entre los caracteres de los números
            if (charPos >= 48 && charPos <= 57 && result < 48)
            {
                return (char)(result + 10);
            }

            //si son mayúsculas varío entre los caracteres de las mayúsculas
            if (charPos >= 65 && charPos <= 90 && result < 65)
            {
                return (char)(result + 25);
            }

            //si son minúsculas varío entre los caracteres de las minúsculas
            if (charPos >= 97 && charPos <= 122 && result < 97)
            {
                return (char)(result + 25);
            }

            return (char)result;
        }
    }
}
