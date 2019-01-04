using Fluent.Security.Enums;
using Fluent.Security.Interfaces;

namespace Fluent.Security
{
    public class FluentSecurity : ITextPlain, ITextCipher, ISecurityAlgorithm
    {
        private readonly ActionType actionType;
        private string text;

        private FluentSecurity(ActionType actionType) => this.actionType = actionType;

        public static ITextPlain Encrypt() => new FluentSecurity(ActionType.Encrypt);

        public static ITextCipher Decrypt() => new FluentSecurity(ActionType.Encrypt);

        public ISecurityAlgorithm PlainText(string text)
        {
            this.text = text;

            return this;
        }

        public ISecurityAlgorithm CipherText(string text)
        {
            this.text = text;

            return this;
        }

        public IAesKey UsingAes() => FluentAes.Initialize(actionType, text);

        public IRsaKey UsingRsa() => FluentRsa.Initialize(actionType, text);
    }
}
