namespace EvolentContact.Services.Services.Interfaces
{
    public interface ILogService
    {
        void Information(string message);
        void Warning(string message);
        void Debug(string message);
        void Error(string message);
    }
}
