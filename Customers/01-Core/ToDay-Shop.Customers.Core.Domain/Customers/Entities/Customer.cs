using ToDay_Shop.Customers.Core.Domain.Common.Entities;
using ToDay_Shop.Customers.Core.Domain.Common.ValueObjects;
using ToDay_Shop.Customers.Core.Domain.Customers.Events;
using ToDay_Shop.Customers.Core.Domain.Customers.Parameters;

namespace ToDay_Shop.Customers.Core.Domain.Customers.Entities;
public sealed class Customer : AggregateRoot
{
    #region Properties
    public Name FirstName { get; private set; }
    public Name LastName { get; private set; }
    #endregion

    #region Constructors
    private Customer()
    {
    }

    private Customer(CreateCustomerParameter createCustomer)
    {
        FirstName = createCustomer.FirstName;
        LastName = createCustomer.LastName;

        AddEvent(new CustomerCreated
        {
            FirstName = FirstName.Value,
            LastName = LastName.Value
        });
    }
    #endregion

    #region Commands
    public static Customer Create(CreateCustomerParameter createCustomerParameter)
        => new(createCustomerParameter);
    #endregion
}
