using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TaskBoard.Domain.Common;

namespace TaskBoard.Application.Behaviors;

// Logs request and response information for each MediatR handler
public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        _logger.LogInformation("Handling {RequestName}", requestName);

        var stopwatch = Stopwatch.StartNew();

        try
        {
            var response = await next();
            stopwatch.Stop();

            if (response is IResult result && result.IsError)
                _logger.LogWarning("Handled {RequestName} with error: {Error} in {ElapsedMs}ms", requestName, result.Error, stopwatch.ElapsedMilliseconds);
            else
                _logger.LogInformation("Handled {RequestName} successfully in {ElapsedMs}ms", requestName, stopwatch.ElapsedMilliseconds);

            return response;
        }
        catch (FluentValidation.ValidationException ex)
        {
            stopwatch.Stop();
            _logger.LogWarning("Validation failed for {RequestName}: {Errors} in {ElapsedMs}ms",
                requestName,
                string.Join("; ", ex.Errors.Select(e => e.ErrorMessage)),
                stopwatch.ElapsedMilliseconds);
            throw;
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            _logger.LogError(ex, "Unhandled exception in {RequestName} after {ElapsedMs}ms", requestName, stopwatch.ElapsedMilliseconds);
            throw;
        }
    }
}