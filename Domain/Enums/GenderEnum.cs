using System.ComponentModel;

namespace Domain.Enums
{
    public enum GenderEnum : int
    {
        [Description("مرد")]
        Male = 1,

        [Description("زن")]
        Female = 2
    }
}
