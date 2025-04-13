using System.ComponentModel;

namespace TeamTaskManagement.Domain.Common.Enums
{
    public enum TaskProgressStatus
    {
        [Description("جديد")]
        New,
        [Description("قيد التنفيذ")]
        InProgress,
        [Description("مكتمل")]
        Completed,
        [Description("تم الإلغاء")]
        Cancelled
    }
}
