using Microsoft.Extensions.Logging;
using ToDay_Shop.Payments.Core.Domain.Common.Exceptions;
using ToDay_Shop.Payments.Core.RequestResponse.Common;
using ToDay_Shop.Payments.Core.RequestResponse.Common.Queries;
using ToDay_Shop.Payments.Core.Resources.Constants;

namespace ToDay_Shop.Payments.Core.ApplicationServices.Common.Queries;

public class QueryDispatcherDomainExceptionHandlerDecorator : QueryDispatcherDecorator
{
    #region Fields
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<QueryDispatcherDomainExceptionHandlerDecorator> _logger;
    public override int Order => 2;
    #endregion

    #region Constructors
    public QueryDispatcherDomainExceptionHandlerDecorator(IServiceProvider serviceProvider,
                                                          ILogger<QueryDispatcherDomainExceptionHandlerDecorator> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }
    #endregion

    #region Query Dispatcher
    public override async Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query)
    {
        try
        {
            var result = await _queryDispatcher.Execute<TQuery, TData>(query);
            return result;

        }
        catch (DomainStateException ex)
        {
            _logger.LogError(ApplicationConsts.DomainValidationException,
                             ex,
                             "Processing of {QueryType} With value {Query} failed at {StartDateTime} because there are domain exceptions.",
                             query.GetType(),
                             query,
                             DateTime.Now);
            return DomainExceptionHandlingWithReturnValue<TQuery, TData>(ex);
        }
        catch (AggregateException ex)
        {
            if (ex.InnerException is DomainStateException domainStateException)
            {
                _logger.LogError(ApplicationConsts.DomainValidationException,
                                 ex,
                                 "Processing of {QueryType} With value {Query} failed at {StartDateTime} because there are domain exceptions.",
                                 query.GetType(),
                                 query,
                                 DateTime.Now);
                return DomainExceptionHandlingWithReturnValue<TQuery, TData>(domainStateException);
            }
            throw ex;
        }
    }
    #endregion

    #region Privaite Methods
    private QueryResult<TData> DomainExceptionHandlingWithReturnValue<TQuery, TData>(DomainStateException ex)
    {
        var queryResult = new QueryResult<TData>()
        {
            Status = ApplicationServiceStatus.InvalidDomainState
        };

        queryResult.AddMessage(GetExceptionText(ex));

        return queryResult;
    }

    private string GetExceptionText(DomainStateException domainStateException)
    {
        // can use translator service to translate exception message
        _logger.LogInformation(ApplicationConsts.DomainValidationException,
                               "Domain Exception message is {DomainExceptionMessage}",
                               domainStateException);

        return domainStateException.ToString();
    }
    #endregion
}