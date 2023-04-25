using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CrmApplication.UI.Services
{
    public static class ModelStateController // static yapammızın sebebi newleme yapmamamız için
    {
        public static void CheckIt(INotificationService notificationService,ModelStateDictionary modelState)
        {
            foreach (var item in modelState)
            {
                if (item.Value.Errors.Count > 0)
                {
                    notificationService.Notification(NotifyType.Error, item.Value.Errors[0].ErrorMessage);
                }

            }
        }
    }
}
