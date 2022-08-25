using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinHelperLibrary.BaiduTranslateHelper
{
    public class BaiduTranslateResult
    {
        public string from { get; set; }
        public string to { get; set; }
        public List<BaiduTranslateTransResult> trans_result { get; set; }

        public class BaiduTranslateTransResult
        {
            public string dst { get; set; }
            public string src { get; set; }
        }
    }
}
