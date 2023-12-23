using FinControl.Business.Notifications;

namespace FinControl.Business.Interfaces;

public interface INotifier
{
    bool HaveNotification();
    List<Notification> GetNotifications();
    void AddNotification(Notification notification);
}