namespace ToDay_Shop.Payments.Core.Domain.Common.Exceptions;
public class InvalidEntityStateException : DomainStateException
{
    public InvalidEntityStateException(string message, params string[] parameters) : base(message)
    {
        Parameters = parameters;
    }
}
