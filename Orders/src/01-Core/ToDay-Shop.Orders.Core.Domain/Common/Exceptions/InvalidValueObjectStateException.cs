namespace ToDay_Shop.Orders.Core.Domain.Common.Exceptions;
public class InvalidValueObjectStateException : DomainStateException
{
    public InvalidValueObjectStateException(string message, params string[] parameters) : base(message)
    {
        Parameters = parameters;
    }
}
