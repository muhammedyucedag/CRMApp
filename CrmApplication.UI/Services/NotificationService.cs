﻿using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace CrmApplication.UI.Services
{
    public enum NotifyType
    {
        Success,
        Error,
        Warning
    }
    public struct NotifyData // struct içine değer atayabildiğimiz sınıf anlamına gelir
    {
        public NotifyType Type { get; set; }
        public string Message { get; set; }
    }

    public interface INotificationService
    {
        void Notification(NotifyType type, string message);
        IList<NotifyData> GetNotifications();
    }
    public class NotificationService : INotificationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor; // httpcontext proje boyunca ayakta duran tüm alanlara erişebildiğimiz bir sınıf
        private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory; // 
        public NotificationService(IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory)
        {
            _httpContextAccessor = httpContextAccessor;
            _tempDataDictionaryFactory = tempDataDictionaryFactory;
        }
        private ITempDataDictionary TempData => _tempDataDictionaryFactory.GetTempData(_httpContextAccessor.HttpContext);

        public IList<NotifyData> GetNotifications()
        {
            return TempData.ContainsKey("temp-notify-list") ? JsonConvert.DeserializeObject<IList<NotifyData>>(TempData["temp-notify-list"].ToString()?? string.Empty): new List<NotifyData>();
        }

        public void Notification(NotifyType type, string message)
        {
            var notifies = GetNotifications();
            notifies.Add(new NotifyData {Type= type, Message = message});
            TempData["temp-notify-list"] = JsonConvert.SerializeObject(notifies);
        }
    }
}
