namespace ToDay_Shop.Customers.Core.Resources.Utilities;
public static class StringPatternReplacementUtil
{
    public static string ReplaceArgs(string pattern, params string[] arguments)
    {
        for (int i = 0; i < arguments.Length; i++)
        {
            string placeHolder = $"{{{i}}}";
            pattern = pattern.Replace(placeHolder, arguments[i]);
        }

        return pattern;
    }
}
