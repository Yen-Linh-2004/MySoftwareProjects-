using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class TransactionDetail
    {
        public HOADON Order { get; set; }
        public List<CHITIETHD> CHITIETDHList { get; set; }
    }
}