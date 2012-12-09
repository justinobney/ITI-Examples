namespace Jobney.ITI.Interfaces
{
    public interface ICallbackNotifier
    {
        string Message { get; set; }
        string NotificationAddress { get; set; }
        void SendNotification();
        string Subject { get; set; }
    }
}
