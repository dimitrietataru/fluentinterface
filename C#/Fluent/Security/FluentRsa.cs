using Fluent.Security.Enums;
using Fluent.Security.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Fluent.Security
{
    public class FluentRsa : IRsaKey, IRsaKeySize, IRsaPadding, IRsaExecute
    {
        private readonly ActionType actionType;
        private readonly string text;
        private RSAParameters key;
        private int keySize;
        private RSAEncryptionPadding rsaPadding;

        private FluentRsa(ActionType actionType, string text)
        {
            this.actionType = actionType;
            this.text = text;

            keySize = 2048;
            rsaPadding = RSAEncryptionPadding.Pkcs1;
        }

        public static IRsaKey Initialize(ActionType action, string text)
        {
            return new FluentRsa(action, text);
        }

        public IRsaKeySize WithKey(RSAParameters key = default)
        {
            this.key = key;

            return this;
        }

        public IRsaPadding WithKeySize(int keySize)
        {
            this.keySize = keySize;

            return this;
        }

        public IRsaExecute WithPadding(RSAEncryptionPadding rsaPadding)
        {
            this.rsaPadding = rsaPadding;

            return this;
        }

        public string ExecuteEncrypt(out RSAParameters privateKey)
        {
            if (actionType is ActionType.Encrypt)
            {
                return Encrypt(out privateKey);
            }

            throw new InvalidOperationException();
        }

        public string ExecuteDecrypt()
        {
            if (actionType is ActionType.Decrypt)
            {
                return Decrypt();
            }

            throw new InvalidOperationException();
        }

        private string Encrypt(out RSAParameters privateKey)
        {
            var textAsBites = Encoding.UTF8.GetBytes(text);

            var rsa = new RSACryptoServiceProvider(keySize);

            privateKey = rsa.ExportParameters(true);

            var encryptedText = rsa.Encrypt(textAsBites, rsaPadding);
            rsa.Clear();

            return Convert.ToBase64String(encryptedText, 0, encryptedText.Length);
        }

        private string Decrypt()
        {
            var textAsBites = Convert.FromBase64String(text);

            var rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(key);

            var decryptedText = rsa.Decrypt(textAsBites, rsaPadding);

            return Encoding.UTF8.GetString(decryptedText);
        }
    }
}
