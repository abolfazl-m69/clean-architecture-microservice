using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HumanResource.Framework.Core.MediatorPipelines
{
    public class TransactionPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionPipelineBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync(cancellationToken);

                var response = await next();

                await _unitOfWork.CommitAsync(cancellationToken);

                return response;

            }
            catch (Exception)
            {
                await _unitOfWork.RollBackAsync(cancellationToken);
                throw;
            }
        }
    }
}