using System.Windows.Forms;
using AddOnLimitTransaction.Log;
using CXS.Retail.Extensibility;
using CXS.SubSystem.Transaction;
using DevExpress.XtraEditors;

namespace AddonPrintTransaction
{
    class PrintTransaction : CXS.Retail.Extensibility.Modules.Transaction.TransactionReprintReceiptModuleBase
    {
        public override void OnBeforePrintTransactionClick(object sender, EventArgs<Transaction> args)
        {
            Transaction tran = args.Item;
            string keyTran = tran.Key;
            string posKey = tran.POSKey;
            int countnumber = IVendQueryBussines.iVendRunQuery("select U_LimitPrintNumber from CfgEnterprise");
            int countPrint = IVendQueryBussines.iVendRunQuery(string.Format("select count(*) from TrxTransactionPrintCount where TransactionKey = '{0}'", keyTran));
            if (countPrint > countnumber)
            {
                var className = this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;
                LogBusiness.WriteLog(LogType.INFOR, className, string.Format("PosKey: {0} - TransactionKey: {1} - PrintNumber: {2} ", posKey, keyTran, countPrint));
                XtraMessageBox.Show("Số lần in Bill đã vượt quá giới hạn cho phép " + countnumber + ("lần"), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                args.Cancel = true;
                return;
            }
        }
    }
}
