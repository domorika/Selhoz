// Services/CaesarCipher.cs
namespace Selhoz.Services
{
    public class CaesarCipher
    {
        public string Encrypt(string text, int key)
        {
            char[] buffer = text.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                letter = (char)(letter + key);
                buffer[i] = letter;
            }
            return new string(buffer);
        }
    }
}