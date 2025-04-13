using System.ComponentModel;

namespace TeamTaskManagement.Domain.Common.Enums
{
    public enum PriorityLevel
    {
        [Description("عادي")]
        Normal =1,
        [Description("قليل")]
        Low = 2,
        [Description("متوسط")]
        Medium = 3,
        [Description("عالي")]
        High = 4,
        [Description("شديد الأهمية")]
        Critical = 5
    }
}
