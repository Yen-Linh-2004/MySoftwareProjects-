using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Nha_Hang
{
    //"accountNo": 113366668888,
    //"accountName": "QUY VAC XIN PHONG CHONG COVID",
    //"acqId": 970415,
    //"amount": 79000,
    //"addInfo": "Ung Ho Quy Vac Xin",
    //"format": "text",
    //"template": "compact"

    public class APIRequest
    {
        public long accountNo { get; set; }
        public string accountName { get; set; }
        public int acqId { get; set; }
        public int amount { get; set; }
        public string addInfo { get; set; }
        public string format { get; set; }
        public string template { get; set; }
    }

    public class DataResponse
    {
        public int acpId { get; set; }
        public string accountName { get; set; }
        public string qrCode { get; set; }
        public string qrDataURL { get; set; }
    }

    public class APIResponse
    {
        public string code { get; set; }
        public string desc { get; set; }
        public DataResponse data { get; set; }
    }


}
