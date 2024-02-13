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
    public partial class FrmAddorEdit : Form
    {
        IContactsRepository repository;
        public int Contact_id = 0;
        public FrmAddorEdit()
        {
            InitializeComponent();
            repository = new ContactsRepository();

        }
        bool ValidateInputs()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("لطفا نام خود را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (txtFamily.Text == "")
            {
                MessageBox.Show("لطفا نام خانوادگی خود را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (txtMobile.Text == "")
            {
                MessageBox.Show("لطفا موبایل خود را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (txtAge.Value == 0)
            {
                MessageBox.Show("لطفا سن خود را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            return true;
        }
        private void FrmAddorEdit_Load(object sender, EventArgs e)
        {
            if (Contact_id == 0)
            {
                this.Text = "افزودن شخص جدید";

            }
            else
            {
                this.Text = "ویرایش شخص";
                DataTable dt = repository.SelectRow(Contact_id);
                txtName.Text = dt.Rows[0][1].ToString();
                txtFamily.Text = dt.Rows[0][2].ToString();
                txtAge.Text = dt.Rows[0][3].ToString();
                txtMobile.Text = dt.Rows[0][4].ToString();
                txtEmail.Text = dt.Rows[0][5].ToString();
                btn_submit.Text = "ویرایش";
            }
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                bool IsSuccess;
                if (Contact_id == 0)
                {
                    IsSuccess = repository.Insert(txtName.Text, txtFamily.Text, (int)txtAge.Value, txtMobile.Text, txtEmail.Text);
                }
                else
                {
                    IsSuccess = repository.Update(Contact_id, txtName.Text, txtFamily.Text, (int)txtAge.Value, txtMobile.Text, txtEmail.Text);
                }
                if (IsSuccess == true)
                {
                    MessageBox.Show("عملیات با موفقیت انجام شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("عملیات با شکست مواجه شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
