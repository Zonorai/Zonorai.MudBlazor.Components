using MediatR;

namespace Zonorai.MudBlazorComponents.Models
{
    public enum ResultStatus
    {
        ValidationFailed,
        Success,
        Failure
    }

    public class SubmitResult<TRequest,TResponse> where TRequest : IRequest<TResponse>
    {
        public SubmitResult(IRequest<TResponse> request, TResponse response, ResultStatus status)
        {
            Data = response;
            Status = status;
            OriginalRequest = request;
        }
        public SubmitResult(ResultStatus status, TRequest originalRequest)
        {
            Status = status;
            OriginalRequest = originalRequest;
            Data = default;
        }
        public IRequest<TResponse> OriginalRequest { get; init; }
        private TResponse Data { get; init; }
        public ResultStatus Status { get; init; }
        
        public TResponse GetResult()
        {
            return Data;
        }
    }
}