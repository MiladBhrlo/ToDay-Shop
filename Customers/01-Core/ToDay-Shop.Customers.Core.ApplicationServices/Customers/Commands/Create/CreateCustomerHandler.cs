using ToDay_Shop.Customers.Core.ApplicationServices.Common.Commands;
using ToDay_Shop.Customers.Core.Contracts.Customers.Commands;
using ToDay_Shop.Customers.Core.Domain.Customers.Entities;
using ToDay_Shop.Customers.Core.Domain.Customers.Parameters;
using ToDay_Shop.Customers.Core.RequestResponse.Common.Commands;
using ToDay_Shop.Customers.Core.RequestResponse.Customers.Commands.CreateCustomer;

namespace ToDay_Shop.Customers.Core.ApplicationServices.Customers.Commands.Create;
public sealed class CreateCustomerHandler : CommandHandler<CreateCustomerCommand, long>
{
    private readonly ICustomerCommandRepository _customerCommandRepository;

    public CreateCustomerHandler(ICustomerCommandRepository customerCommandRepository)
    {
        _customerCommandRepository = customerCommandRepository;
    }

    public override async Task<CommandResult<long>> Handle(CreateCustomerCommand command)
    {
        Customer customer = Customer.Create(new CreateCustomerParameter(command.FirstName, command.LastName));

        await _customerCommandRepository.InsertAsync(customer);
        await _customerCommandRepository.CommitAsync();

        return Ok(customer.Id);
    }
}
