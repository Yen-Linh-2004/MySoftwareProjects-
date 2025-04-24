using Quan_Ly_Nha_Hang.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Nha_Hang
{
    public partial class XemNguyenLieu : Form
    {
        public XemNguyenLieu()
        {
            InitializeComponent();
            LoadNguyenLieu();
        }

        private void LoadNguyenLieu()
        {
            var data = Main_Form.data.NGUYENLIEU.Select(t => new
            {
                t.IDNguyenLieu,
                t.TenNguyenLieu,
                t.SolgTon,  // Giữ nguyên tên gốc
                t.DVT
            }).ToList();

            guna2DataGridView1.DataSource = data;

            // Tìm cột theo HeaderText
            var soluongtonColumn = guna2DataGridView1.Columns.Cast<DataGridViewColumn>()
                .FirstOrDefault(col => col.HeaderText == "Số lượng tồn");

            if (soluongtonColumn != null)
            {
                soluongtonColumn.DefaultCellStyle.Format = "N2";
            }
        }

    }
}
