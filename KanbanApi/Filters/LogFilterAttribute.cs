using KanbanApi.Repositories;
using KanbanApi.Repositories;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;

namespace KanbanApi.Filters
{
    public class LogFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var action = filterContext.RouteData.Values.ContainsKey("action") ? filterContext.RouteData.Values["action"].ToString() : null;

            string logString = DateTime.Now.ToString();

            

            switch (action)
            {
                case "Edit":
                    var cardAlterado = ((Card)filterContext.ActionArguments["card"]);
                    logString += " - Card " + cardAlterado.Id +" "+ cardAlterado.Titulo + " - Alterado";
                    break;
                case "Delete":
                    var guidCard = ((Guid)filterContext.ActionArguments["id"]);
                    logString += " - Card " + guidCard + " - Removido";
                    break;
            }


            Console.WriteLine(logString);
            Debug.WriteLine(logString);
        }
    }
}
