using System.Linq;

namespace Foaas.Bot.Extensions
{
    public static class StringExtensions
    {
        public static bool IsHi(this string message)
        {
            var variants = new[] {"hi", "hello", "yo", "hey", "what's up", "whats up"};
            return variants.Any(message.ToLower().StartsWith);
        }
    }
}