

namespace Services
{
    public class Guid36BytesService : Interfaces.IGuidService
    {
        Interfaces.ILoggerService _loggerService;

        public Guid36BytesService(Interfaces.ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public string Build()
        {
            var guid = Guid.NewGuid().ToString();

            //Registrar en log el guid generado...
            var activityInfo = new Interfaces.DTO.Activity
            {
                CreationDate = DateTime.Now,
                Id = 25,
                Message = $"GUID: {guid}"
            };

            _loggerService.Log(activityInfo);

            return guid;
        }
    }
}
