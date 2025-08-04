using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator2.Interfaces
{
    public interface IMediator
    {
        public Task Send(IRequest request, CancellationToken cancellationToken = default);

        public Task<ReturnType> Send<ReturnType>(IRequest<ReturnType> request, CancellationToken cancellationToken = default);
    }
}