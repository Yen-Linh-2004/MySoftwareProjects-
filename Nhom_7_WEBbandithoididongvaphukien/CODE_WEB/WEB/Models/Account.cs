using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            this.Carts = new HashSet<GIOHANG>();
            //this.Invoices = new HashSet<Invoice>();
        }

        public string account_name { get; set; }
        public string account_password { get; set; }
        public string role { get; set; }
        public Nullable<int> users_id { get; set; }
        public Nullable<bool> isdeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIOHANG> Carts { get; set; }
        public virtual USER User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDH> Invoices { get; set; }
    }
}