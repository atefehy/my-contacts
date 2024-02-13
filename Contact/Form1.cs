using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contact
{
    public partial class contactmain : Form
    {
        IContactsRepository repository;
        public contactmain()
        {
            InitializeComponent();
            repository = new ContactsRepository();
        }
        private void BindGrid()
        {
            dgcontact.Columns[0].Visible = false;
            dgcontact.AutoGenerateColumns = false;
            dgcontact.DataSource = repository.SelectAll();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            BindGrid();
        }



        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            FrmAddorEdit frm = new FrmAddorEdit();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgcontact.CurrentRow != null)
            {
                string name = dgcontact.CurrentRow.Cells[1].Value.ToString();
                string family = dgcontact.CurrentRow.Cells[2].Value.ToString();
                string fullname = name + " " + family;
                if (MessageBox.Show($"ایا از حذف {fullname} اطمینان دارید", "توجه", MessageBoxButtons.YesNo) == DialogResult.Yes) ;
                {
                    int contactId = int.Parse(dgcontact.CurrentRow.Cells[0].Value.ToString());
                    repository.Delete(contactId);
                    BindGrid();
                }
            }
            else
            {
                MessageBox.Show("لطفا یک شخص را انتخاب کنید.");

            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dgcontact.CurrentRow != null)
            {
                int ContactId = int.Parse(dgcontact.CurrentRow.Cells[0].Value.ToString());
                FrmAddorEdit frm = new FrmAddorEdit();
                frm.Contact_id = ContactId;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            dgcontact.DataSource = repository.Search(txtsearch.Text);
        }
    }
}
