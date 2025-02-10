namespace ToDay_Shop.Payments.Core.RequestResponse.Common;
public interface IApplicationServiceResult
{
    IEnumerable<string> Messages { get; }
    ApplicationServiceStatus Status { get; set; }
}
