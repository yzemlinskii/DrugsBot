using System.Text.RegularExpressions;

namespace Domain.Primitives;

/// <summary>
/// Регулярные паттерны
/// </summary>
public static class RegexPatterns
{
    /// <summary>
    /// Регулярка для валидации почты
    /// </summary>
    public static readonly Regex EmailRegexPattern = new(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
}