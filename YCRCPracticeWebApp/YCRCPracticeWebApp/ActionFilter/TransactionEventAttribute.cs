using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YCRCPracticeWebApp.Repository.Interface;

namespace YCRCPracticeWebApp.ActionFilter
{
    /// <summary>
    /// Class TransactionEventAttribute. This class cannot be inherited.
    /// the unitofwork saveChanges
    /// </summary>
    /// <seealso cref="System.Web.Mvc.ActionFilterAttribute" />
    public sealed class TransactionEventAttribute : ActionFilterAttribute
    {

        /// <summary>
        /// 在動作方法執行之後，由 ASP.NET MVC 架構呼叫。
        /// </summary>
        /// <param name="filterContext">篩選內容。</param>
        /// <exception cref="System.ArgumentNullException">UnitOfWork</exception>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var unitOfWork = DependencyResolver.Current.GetService<IUnitOfWork>();
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            unitOfWork.SaveChanges();
            unitOfWork.Dispose();
            base.OnActionExecuted(filterContext);
        }
    }
}