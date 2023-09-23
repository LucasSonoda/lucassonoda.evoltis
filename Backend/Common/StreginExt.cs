using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Common
{
    public static class StreginExt
    {
        public static bool IsNull(this string @this) => string.IsNullOrWhiteSpace(@this?.Trim());
    }
}
