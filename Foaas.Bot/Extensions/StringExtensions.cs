using System.Linq;

namespace Foaas.Bot.Extensions
{
    public static class StringExtensions
    {
        public static bool CheckForHi(this string message)
        {
            var variants = new[] {"hi", "hello", "yo"};
            return variants.Any(message.ToLower().StartsWith);
        }
    }
}