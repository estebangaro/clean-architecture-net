using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator2.Interfaces
{
    public interface IRequestHandler<RequestType> where RequestType : IRequest
    {
        public Task Handle(RequestType request, CancellationToken cancellationToken);
    }

    public interface IRequestHandler<RequestType, ResponseType> where RequestType : IRequest<ResponseType>
    {
        public Task<ResponseType> Handle(RequestType request, CancellationToken cancellationToken);
    }
}