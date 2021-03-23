using AddOnLimitTransaction.Log;
using CXS.Platform.Data;
using System;

namespace AddonPrintTransaction
{
    public class IVendQueryBussines
    {
        public static int iVendRunQuery(string Query)
        {
            var className = typeof(IVendQueryBussines).FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                return Convert.ToInt32(SessionManager.Instance.ExecuteScalar(Query));
            }
            catch (Exception ex)
            {
                LogBusiness.WriteLog(LogType.ERROR, className, ex.Message);
                return 0;
            }
        }
    }
}
