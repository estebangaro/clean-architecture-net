﻿using System.Reflection;

namespace Mediator
{
    public class Mediator : IMediator
    {
        Assembly HandlersAssembly;
        public Mediator(Assembly handlersAssembly)
        {
            HandlersAssembly = handlersAssembly;

            if (HandlersAssembly == null)
            {
                throw new ArgumentNullException("Se debe proporcionar información del ensamblado");
            }
        }

        ReturnType Handle<ReturnType, RequestType>(
            RequestType request, CancellationToken cancellationToken)
        {
            ReturnType Result = default;
            Type RequestHandlerType;

            if (typeof(ReturnType).IsGenericType)
            {
                RequestHandlerType = typeof(IRequestHandler<,>);
            }
            else
            {
                RequestHandlerType = typeof(IRequestHandler<>);
            }

            Type Handler = HandlersAssembly != null ? HandlersAssembly.GetTypes()
                .FirstOrDefault(t => t.GetInterfaces()
                    .Any(i =>
                        i.IsGenericType &&
                        i.GetGenericTypeDefinition() == RequestHandlerType &&
                        i.GetGenericArguments()[0] == request.GetType())) : null;

            if (Handler != null)
            {
                var HandlerInstance = Activator.CreateInstance(Handler);
                Result = (ReturnType)Handler.GetMethod("Handle").Invoke(
                    HandlerInstance, new object[] { request, cancellationToken });
            }
            else
            {
                throw new InvalidOperationException(string.Format(
                    "Error constructing handler for request of type {0}",
                    request.GetType()));
            }

            return Result;
        }

        public Task Send(IRequest request, CancellationToken cancellationToken = default)
        {
            return Handle<Task, IRequest>(request, cancellationToken);
        }

        public Task<ResponseType> Send<ResponseType>(IRequest<ResponseType> request, CancellationToken cancellationToken = default)
        {
            return Handle<Task<ResponseType>, IRequest<ResponseType>>(request, cancellationToken);
        }
    }
}
