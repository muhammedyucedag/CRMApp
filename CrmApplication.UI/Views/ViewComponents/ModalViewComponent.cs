using CrmApplication.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrmApplication.UI.Views.ViewComponents
{
    public class ModalViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string modalId, string headerText, string formId, string buttonText, string buttonClass, string detailDivId)
        {
            ModalViewComponentModel model = new ModalViewComponentModel();
            model.ModalId = modalId;
            model.HeaderText = headerText;
            model.FormId = formId;
            model.ButtonText = buttonText;
            model.ButtonClass = buttonClass;
            model.DetailDivId = detailDivId;

            return View(model);
        }
    }
}
