using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 复制粘贴plus
{
    public class BaiduTranslate
    {
        public string from { get; set; }
        public string to { get; set; }
        public List<BaiduTranslateResult> trans_result { get; set; }

        public class BaiduTranslateResult
        {
            public string dst { get; set; }
            public string src { get; set; }
        }
    }
}
