using SOLID.ValueObject;

namespace SOLID.Dependency_Inversion_Substitution_Principle
{
    public interface ILogger
    {
        void WriteLog(Activity activity);
    }
}