using SOLID.ValueObject;

namespace SOLID.Open_Closed_Principle
{
    //Abstracción que permite utilizar la funcionalidad de escritura de información de log en medio de almacenamiento...
    public interface ILogger
    {
        void Write(Activity activity);
    }
}