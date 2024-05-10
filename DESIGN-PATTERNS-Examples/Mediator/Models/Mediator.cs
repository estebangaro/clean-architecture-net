using Mediator.Interfaces;
using Mediator.RequestHandlers;
using Mediator.Requests;
using System.Reflection;

namespace Mediator.Models
{
    public class Mediator : IMediator
    {
        Assembly _assembly;

        public Mediator(Assembly assembly)
        {
            _assembly = assembly;
        }

        private ResponseType Handle<RequestType, ResponseType>(RequestType request, CancellationToken cancellationToken)
            where ResponseType : Task
        {
            var typeOf_Response = typeof(ResponseType);
            var genericDefinitionTypeOf_TaskGeneric = typeof(Task<>);

            Type genericDefinitionTypeOf_IRequestHandler;

            if (typeOf_Response.IsGenericType && typeOf_Response.GetGenericTypeDefinition() == genericDefinitionTypeOf_TaskGeneric)
            {
                //Se devuelve Task<ResponseType>, por lo tanto, se busca un manejador de solicitudes con la definición de tipo genérico IRequestHandler<,>, cuyo primer argumento de tipo corresponda con el tipo de la solicitud.
                genericDefinitionTypeOf_IRequestHandler = typeof(IRequestHandler<,>);
            }
            else
            {
                //Se devuelve Task, por lo tanto, se busca un manejador de solicitudes con la definición de tipo genérico IRequestHandler<>, cuyo argumento de tipo corresponda con el tipo de la solicitud.
                genericDefinitionTypeOf_IRequestHandler = typeof(IRequestHandler<>);
            }

            var assemblyTypes = _assembly.GetTypes();
            var type_request = request.GetType();
            var assemblyTypes_withGenericTypeDefinition = assemblyTypes.Where(assemblyType => assemblyType.GetInterfaces().Any(assemblyType_interface =>
                    assemblyType_interface.IsGenericType && assemblyType_interface.GetGenericTypeDefinition() == genericDefinitionTypeOf_IRequestHandler
                        && assemblyType_interface.GenericTypeArguments.First() == type_request));

            Type requestHandlerType;
            if (assemblyTypes_withGenericTypeDefinition.Any())
            {
                requestHandlerType = assemblyTypes_withGenericTypeDefinition.First();
            }
            else
            {
                requestHandlerType = null;
            }

            if (requestHandlerType == null)
            {
                throw new NotSupportedException("No existe un manejador de solicitudes para el IRequest / IRequest<> especificado.");
            }
            else
            {
                var requestHandler = Activator.CreateInstance(requestHandlerType);

                return requestHandlerType.GetMethod("Handle").Invoke(requestHandler, [request, cancellationToken]) as ResponseType;
            }
        }

        public Task Send(IRequest request, CancellationToken cancellationToken = default)
        {
            return Handle<IRequest, Task>(request, cancellationToken);
        }

        public Task<ResponseType> Send<ResponseType>(IRequest<ResponseType> request, CancellationToken cancellationToken = default)
        {
            return Handle<IRequest<ResponseType>, Task<ResponseType>>(request, cancellationToken);
        }
    }
}
