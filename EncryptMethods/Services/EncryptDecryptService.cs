using System;
using System.Linq;

namespace EncryptMethods.Services
{
    public class EncryptDecryptService
    {

        public string InvertChars(string text)
        {
            var encryptedText = string.Empty;

            var lastCharPos = text.Length - 1;
            for (int i = 0; i < text.Length; i++)
            {
                encryptedText += text[lastCharPos - i];
            }

            return encryptedText;
        }

        public string DynamicEncryptDecrypt(Func<char, char> encryptDecryptMethod, string text)
        {
            var encryptedText = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                encryptedText += encryptDecryptMethod.Invoke(text[i]);
            }

            return encryptedText;
        }

        const string _recursiveRefBase = "abcdefghijklmnñopqrstuvwxyx";
        const string _recursiveRefFinal = "trpsfuromfduiduyrfuiereuiry";

        public string RecursiveEncrypt(string text, int refPos = 0)
        {
            var result = from s in text
                         select s == _recursiveRefBase[refPos] ?
                            _recursiveRefFinal[refPos] : s == _recursiveRefFinal[refPos] ?
                                _recursiveRefBase[refPos] : s;

            var resultString = new String(result.ToArray());

            if (refPos < _recursiveRefBase.Length - 1)
            {
                return RecursiveEncrypt(resultString, refPos + 1);
            }

            return resultString;
        }

        public string RecursiveDecrypt(string text, int? refPos = null)
        {
            if (refPos == null)
            {
                refPos = _recursiveRefFinal.Length - 1;
            }

            var result = from s in text
                         select s == _recursiveRefFinal[refPos.Value] ?
                            _recursiveRefBase[refPos.Value] : s == _recursiveRefBase[refPos.Value] ?
                                _recursiveRefFinal[refPos.Value] : s;

            var resultString = new String(result.ToArray());

            if (refPos > 0)
            {
                return RecursiveDecrypt(resultString, refPos - 1);
            }

            return resultString;
        }
    }
}
