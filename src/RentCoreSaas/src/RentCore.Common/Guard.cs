namespace RentCore.Common;

public static class Guard
{
    public static string AgainstNullOrWhiteSpace(string? value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{paramName} is required.", paramName);
        return value;
    }

    public static T AgainstNull<T>(T? value, string paramName) where T : class
        => value ?? throw new ArgumentNullException(paramName);

    public static decimal AgainstNegativeOrZero(decimal value, string paramName) 
    => value > 0 ? value : throw new ArgumentOutOfRangeException(paramName, "Must be greater than zero.");

}