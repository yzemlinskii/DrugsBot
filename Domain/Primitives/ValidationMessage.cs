namespace Domain.Primitives;

public static class ValidationMessage
{
    public const string RequiredField = "Поле {PropertyName} является обязательным.";
    public const string LengthField = "Поле {PropertyName} должно содержать от {MinLength} до {MaxLength} символов.";
    public const string ExactLengthField = "Поле {PropertyName} должно содержать ровно {ExactLength} символов.";
    public const string OnlyLettersAndSpaces = "Поле {PropertyName} должно содержать только буквы и пробелы.";
    public const string OnlyUppercaseLetters = "Поле {PropertyName} должно содержать только заглавные латинские буквы.";
    public const string PositiveNumber = "Поле {PropertyName} должно быть положительным числом.";
    public const string OnlyLettersDigitsAndSpaces = "Поле {PropertyName} должно содержать только буквы, цифры и пробелы.";
    public const string OnlyLettersSpacesAndDashes = "Поле {PropertyName} должно содержать только буквы, пробелы и дефисы.";
    public const string OnlyLettersDigitsAndDashes = "Поле {PropertyName} должно содержать только буквы, цифры и дефисы.";
    public const string OnlyLettersDigitsSpacesAndDashes = "Поле {PropertyName} должно содержать только буквы, цифры, пробелы и дефисы.";
    public const string ValidCountryCode = "Поле {PropertyName} должно соответствовать существующему ISO-коду страны.";
}