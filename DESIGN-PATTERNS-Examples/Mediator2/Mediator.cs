using Mediator2.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Mediator2
{
    public class Mediator : Interfaces.IMediator
    {
        Assembly assemblyHandler;

        public Mediator(Assembly assemblyHandler)
        {
            this.assemblyHandler = assemblyHandler;
        }

        ReturnType? Handle<ReturnType, RequestType>(RequestType request, CancellationToken cancellationToken)
        {
            if(request == null)
                throw new InvalidOperationException($"No se ha proporcionado un tipo de solicitud. No es válido NULL.");

            Type requestHandlerGenericTypeDefinition;
            if (typeof(ReturnType).IsGenericType)
            {
                requestHandlerGenericTypeDefinition = typeof(IRequestHandler<,>);
            }
            else
            {
                requestHandlerGenericTypeDefinition = typeof(IRequestHandler<>);
            }

            Type? requestHandlerType = assemblyHandler.GetTypes()
                .Where(t => t.IsClass && !t.IsInterface &&
                    t.GetInterfaces().Any(it => it.IsGenericType && it.GetGenericTypeDefinition() == requestHandlerGenericTypeDefinition
                        && it.GetGenericArguments().First() == typeof(RequestType)
                    )).FirstOrDefault();

            if (requestHandlerType == null)
                throw new InvalidOperationException($"No existe un manejador de solicitud para el tipo \"{typeof(RequestType)}\" en el ensamblado \"{assemblyHandler.FullName}\"");

            var requestHandler = Activator.CreateInstance(requestHandlerType);
            ReturnType? result;
            // 2. Obtener el MethodInfo del método que quieres llamar.
            MethodInfo? handleMethod = requestHandlerType.GetMethod("Handle");
            if(handleMethod == null)
                throw new InvalidOperationException($"No existe un método \"Handle\" para el manejador de solicitud para el tipo \"{typeof(RequestType)}\" en el ensamblado \"{assemblyHandler.FullName}\"");
            // Prepara los argumentos en un arreglo de objetos.
            object?[] parameters = { request, cancellationToken };
            result = (ReturnType?)handleMethod?.Invoke(requestHandler, parameters);

            return result;
        }
            
        public Task Send(IRequest request, CancellationToken cancellationToken = default)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return Handle<Task, IRequest>(request, cancellationToken);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public Task<ReturnType> Send<ReturnType>(IRequest<ReturnType> request, CancellationToken cancellationToken = default)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return Handle<Task<ReturnType>, IRequest<ReturnType>>(request, cancellationToken);
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}