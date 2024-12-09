using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace GrozaGames.Kit
{
    public static class StringUtils
    {
        /// <summary>
        /// Преобразует входную строку в camelCase.
        /// Данный метод удаляет все неалфавитные символы (кроме пробелов и знаков подчёркивания), 
        /// разделяет строку на слова по пробелам и символам подчёркивания, 
        /// после чего превращает их в строку в стиле camelCase.
        /// Пример: "Пример строки для КОНВЕРТАЦИИ" -> "примерСтрокиДляКонвертации"
        /// </summary>
        /// <param name="input">Входная строка.</param>
        /// <returns>Преобразованная в camelCase строка.</returns>
        public static string ToCamelCase(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Удаляем все символы, не являющиеся буквами или цифрами (кроме пробелов и подчёркиваний)
            var cleaned = Regex.Replace(input, @"[^\p{L}\p{Nd}\s_]", "");

            // Разбиваем по пробелам и подчёркиваниям
            var words = cleaned
                .Split(new[] { ' ', '_' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.Trim());

            // Преобразуем все слова в нижний регистр, кроме заглавной буквы у всех, кроме первого
            var processedWords = words
                .Select((word, index) =>
                {
                    var lower = word.ToLower();
                    return index == 0 ? lower : char.ToUpper(lower[0]) + lower[1..];
                });

            return string.Concat(processedWords);
        }

        /// <summary>
        /// Преобразует входную строку в PascalCase.
        /// Данный метод удаляет все неалфавитные символы (кроме пробелов и знаков подчёркивания),
        /// разделяет строку на слова по пробелам и символам подчёркивания,
        /// после чего каждое слово пишется с заглавной буквы, а остальные буквы строчные.
        /// Пример: "Пример строки для КОНВЕРТАЦИИ" -> "ПримерСтрокиДляКонвертации"
        /// </summary>
        /// <param name="input">Входная строка.</param>
        /// <returns>Преобразованная в PascalCase строка.</returns>
        public static string ToPascalCase(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Удаляем все символы, не являющиеся буквами или цифрами (кроме пробелов и подчёркиваний)
            var cleaned = Regex.Replace(input, @"[^\p{L}\p{Nd}\s_]", "");

            // Разбиваем по пробелам и подчёркиваниям
            var words = cleaned
                .Split(new[] { ' ', '_' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.Trim());

            // Каждое слово: первая буква заглавная, остальные строчные
            var processedWords = words
                .Select(word =>
                {
                    var lower = word.ToLower();
                    return char.ToUpper(lower[0]) + lower[1..];
                });

            return string.Concat(processedWords);
        }
    }
}