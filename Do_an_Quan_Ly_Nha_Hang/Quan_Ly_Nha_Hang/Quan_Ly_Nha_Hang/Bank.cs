using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Nha_Hang
{
    public class Datum
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string bin { get; set; }
        public string shortName { get; set; }
        public string logo { get; set; }
        public int transferSupported { get; set; }
        public int lookupSupported { get; set; }
        public string short_name { get; set; }
        public int support { get; set; }
        public int isTransfer { get; set; }
        public string swift_code { get; set; }
    }

    public class Bank
    {
        public string code { get; set; }
        public string desc { get; set; }
        public Datum data { get; set; }

        public Bank()
        {
            data = new Datum();
            data.id = 26;
            data.name = "Ngân hàng TMCP Phương Đông";
            data.code = "OCB";
            data.bin = "970448";
            data.shortName = "OCB";
            data.logo = "https://api.vietqr.io/img/OCB.png";
            data.transferSupported = 1;
            data.lookupSupported =  1;
            data.short_name = "OCB";
            data.support = 3;
            data.isTransfer = 1;
            data.swift_code = "ORCOVNVX";
        }
    }

}
