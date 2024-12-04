using System;
using System.Globalization;
using System.Linq;

namespace GrozaGames.Kit
{
    public class StringUtils
    {
        public static string ToCamelCase(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            str = ToPascalCase(str);
            return char.ToLowerInvariant(str[0]) + str[1..];
        }

        public static string ToPascalCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            var textInfo = CultureInfo.InvariantCulture.TextInfo;

            return string.Concat(input
                .Split(new[] { ' ', '-', '_', '.' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(word => textInfo.ToTitleCase(word.ToLower())));
        }
    }
}