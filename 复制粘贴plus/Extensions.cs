using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 复制粘贴plus
{
    static class Extensions
    {
        public static T ObjCast<T>(this object obj, T sample)
        {
            return (T)obj;
        }
    }
}
