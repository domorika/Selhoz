// Services/CaesarCipher.cs
namespace Selhoz.Services
{
    public class CaesarCipher
    {
        private const int EncryptionStep = 3; // Шаг сдвига

        public string EncryptData(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            char[] buffer = input.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (char)(buffer[i] + EncryptionStep);
            }
            return new string(buffer);
        }

        public string DecryptData(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            char[] buffer = input.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (char)(buffer[i] - EncryptionStep);
            }
            return new string(buffer);
        }
    }
}