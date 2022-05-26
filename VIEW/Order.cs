using FastFoodManagement.BLL;
using FastFoodManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastFoodManagement
{
    public partial class Order : Form
    {
        demoPBL3 db = new demoPBL3();

        public bool isThoat = true;
        public int ChucVu;
        public string Name;

        BindingSource bsCategory = new BindingSource();
        BindingSource bsFood = new BindingSource();
        BindingSource bsTable = new BindingSource();


        //data binding doesn't work when the lastest selection element is unselection by clicking on blank dgv
        //this all temp string (in which function has it) in order to solve that problem
        
        private string txtTempIdCategory;
        private string txtTempNameCategory;

        private string txtTempIdFood;
        private string txtTempNameFood;
        private string txtTempGiaTienFood;
        private DanhMucDTO tempCbDanhMucFood;

        private string txtTempIdTable;
        private string txtTempNameTable;
        private string txtTempTrangThaiTable;
        public Order()
        {
            InitializeComponent();
            LoadAllComponent();
        }
        private void Order_Load(object sender, EventArgs e)
        {
            //QL~0, NV~1
            if (ChucVu == 0)
            {
                lbPerson.Text = Name + " - Quản Lý";
                btnAddAccount.Visible = true;
                btnSortAccount.Visible = true;
                btnDeleteAccount.Visible = true;
                btnEditAccount.Visible = true;

                //vo hieu hoa chuc nang Table
                btnAddTable.Visible = true;
                btnDelTable.Visible = true;
                btnSortTable.Visible = true;
                btnUpdateTable.Visible = true;

                //Vo hieu hoa chuc nang Category
                btnAddCategory.Visible = true;
                btnDeleteCategory.Visible = true;
                btnUpdateCategory.Visible = true;
                btnSortCategory.Visible = true;

                //Vo hieu hoa chuc nang Food
                btnAddFood.Visible = true;
                btnDeleteFood.Visible = true;
                btnSortFood.Visible = true;
                btnUpdateFood.Visible = true;
            }
            if (ChucVu != 0)
            {
                lbPerson.Text = Name + " - Nhân Viên";
                btnAddAccount.Visible = false;
                btnSortAccount.Visible = false;
                btnDeleteAccount.Visible = false;
                btnEditAccount.Visible = false;

                btnAddTable.Visible = false;
                btnDelTable.Visible = false;
                btnSortTable.Visible = false;
                btnUpdateTable.Visible = false;

                btnAddCategory.Visible = false;
                btnDeleteCategory.Visible = false;
                btnUpdateCategory.Visible = false;
                btnSortCategory.Visible = false;

                btnAddFood.Visible = false;
                btnDeleteFood.Visible = false;
                btnSortFood.Visible = false;
                btnUpdateFood.Visible = false;
            }
        }

        private void LoadAllComponent()
        {
            dgvCategory.DataSource = bsCategory;
            dgvFood.DataSource = bsFood;
            dgvTable.DataSource = bsTable;

            //Food
            LoadItemsCbDanhMuc();
            LoadDgvFood();
            AddFoodBinding();

            //Category
            LoadDgvCategory();
            AddCategoryBinding();

            //Table
            LoadDgvTable();
            AddTableBinding();
        }


        private void btnHome_Click_1(object sender, EventArgs e)
        {
            panelHome.Visible = true;
            panelOrder.Visible = false;
            panelFood.Visible = false;
            panelCategory.Visible = false;
            panelTable.Visible = false;
            panelAccount.Visible = false;
        }
        private void btnOrder_Click_1(object sender, EventArgs e)
        {
            panelOrder.Visible = true;
            panelHome.Visible = false;
            panelFood.Visible = false;
            panelCategory.Visible = false;
            panelTable.Visible = false;
            panelAccount.Visible = false;
        }

        private void btnFood_Click_1(object sender, EventArgs e)
        {
            LoadDgvFood();
            panelFood.Visible = true;
            panelHome.Visible = false;
            panelOrder.Visible = false;
            panelCategory.Visible = false;
            panelTable.Visible = false;
            panelAccount.Visible = false;
        }
        private void btnDanhmuc_Click(object sender, EventArgs e)
        {
            LoadDgvCategory();
            panelCategory.Visible = true;
            panelHome.Visible = false;
            panelOrder.Visible = false;
            panelFood.Visible = false;
            panelTable.Visible = false;
            panelAccount.Visible = false;
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            LoadDgvTable();
            panelTable.Visible = true;
            panelHome.Visible = false;
            panelOrder.Visible = false;
            panelFood.Visible = false;
            panelCategory.Visible = false;
            panelAccount.Visible = false;
        }
        private void btnAccount_Click(object sender, EventArgs e)
        {
            panelAccount.Visible = true;
            panelHome.Visible = false;
            panelOrder.Visible = false;
            panelFood.Visible = false;
            panelCategory.Visible = false;
            panelTable.Visible = false;
        }

        //LOAD FOOD
        private void LoadItemsCbDanhMuc()
        {
            cbDanhMucFood.Items.AddRange(DanhMucBLL.Instance.GetAllDanhMuc().ToArray());
            cbDanhMucFood.SelectedIndex = 0;
        }
        private void LoadDgvFood()
        {
            bsFood.DataSource = SanPhamBLL.Instance.GetAllSanPham();
            ResetTextBoxFood();
            dgvFood.CurrentCell.Selected = false;
        }

        private void AddFoodBinding()
        {
            txtIDFood.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "MaSP", true, DataSourceUpdateMode.Never));
            txtNameFood.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "TenSP", true, DataSourceUpdateMode.Never));
            txtGiaTienFood.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "Gia", true, DataSourceUpdateMode.Never));
            cbDanhMucFood.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "TenDM", true, DataSourceUpdateMode.Never));
        }

        private void ResetTextBoxFood()
        {
            txtIDFood.Text = "";
            txtNameFood.Text = "";
            txtGiaTienFood.Text = "";
            cbDanhMucFood.SelectedIndex = -1;
            txtSearchFood.Text = "";
        }

        //LOAD CATEGORY
        private void LoadDgvCategory()
        {
            bsCategory.DataSource = DanhMucBLL.Instance.GetAllDanhMuc();
            ResetTextBoxCategory();
            dgvCategory.CurrentCell.Selected = false;
        }

        private void AddCategoryBinding()
        {
            txtIDCategory.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "MaDM", true, DataSourceUpdateMode.Never));
            txtNameCategory.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "TenDM", true, DataSourceUpdateMode.Never));
        }

        private void ResetTextBoxCategory()
        {
            txtNameCategory.Text = "";
            txtIDCategory.Text = "";
            txtSearchCategory.Text = "";
        }
       
        //LOAD TABLE
        private void LoadDgvTable()
        {
            bsTable.DataSource = BanBLL.Instance.GetAllBan();
            ResetTextBoxTable();
            dgvTable.CurrentCell.Selected = false;
        }

        private void ResetTextBoxTable()
        {
            txtSearchTable.Text = "";
            txtIDTable.Text = "";
            txtNameTable.Text = "";
            txtTrangThaiTable.Text = "";
        }

        private void AddTableBinding()
        {
            txtIDTable.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "MaBan", true, DataSourceUpdateMode.Never));
            txtNameTable.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "TenBan", true, DataSourceUpdateMode.Never));
            txtTrangThaiTable.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "TrangThai", true, DataSourceUpdateMode.Never));
        }
        public event EventHandler Dangxuat;

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (isThoat)
            {
                if (MessageBox.Show("Ban co muon thoat khong?", 
                                    "Thoat chuong trinh", 
                                    MessageBoxButtons.YesNo, 
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                    Application.Exit();
                else return;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Dangxuat(this, new EventArgs());
        }


        // ------------- Food Section -------------
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            SanPhamBLL.Instance.AddSanPham(new SanPham
            {
                TenSP = txtNameFood.Text,
                MaDM = ((DanhMucDTO)cbDanhMucFood.SelectedItem).MaDM,
                GiaSP = Convert.ToInt32(txtGiaTienFood.Text),
            });
            LoadDgvFood();
        }
        private void btnUpdateFood_Click(object sender, EventArgs e)
        {
            //set temp info
            txtTempNameFood = txtNameFood.Text;
            txtTempIdFood = txtIDFood.Text;
            txtTempGiaTienFood = txtGiaTienFood.Text;
            tempCbDanhMucFood = (DanhMucDTO)cbDanhMucFood.SelectedItem;

            SanPhamBLL.Instance.UpdateSanPham(new SanPham
            {
                MaSP = Convert.ToInt32(txtIDFood.Text),
                TenSP = txtNameFood.Text,
                GiaSP = Convert.ToInt32(txtGiaTienFood.Text),
                MaDM = ((DanhMucDTO)cbDanhMucFood.SelectedItem).MaDM
            });
            LoadDgvFood();
        }
        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            if (dgvFood.SelectedRows[0].Index == dgvFood.Rows.Count - 1)
            {
                txtTempIdFood = dgvFood.Rows[dgvFood.Rows.Count - 2].Cells[0].Value.ToString();
                txtTempNameFood = dgvFood.Rows[dgvFood.Rows.Count - 2].Cells[1].Value.ToString();
            }
            else
            {
                txtTempIdFood = dgvFood.Rows[dgvFood.SelectedRows[0].Index - 1].Cells[0].Value.ToString();
                txtTempNameFood = dgvFood.Rows[dgvFood.SelectedRows[0].Index - 1].Cells[1].Value.ToString();
            }
            SanPhamBLL.Instance.DeleteSanPham(Convert.ToInt32(txtIDFood.Text));
            LoadDgvFood();
        }

        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            bsFood.DataSource = SanPhamBLL.Instance.SearchSanPham(txtSearchFood.Text);
        }
        private void dgvFood_MouseClick(object sender, MouseEventArgs e)
        {
            var ht = dgvFood.HitTest(e.X, e.Y);
            if (ht.Type == DataGridViewHitTestType.None) //check if user clicked on blank dgv
            {
                dgvFood.ClearSelection();
                ResetTextBoxFood();
                btnUpdateFood.Enabled = false;
            }
        }

        private void txtIDFood_TextChanged(object sender, EventArgs e)
        {
            //button add shows up when click nothing
            if (txtIDFood.Text == "")
            {
                btnUpdateFood.Enabled = false;
                btnAddFood.Enabled = true;
                btnDeleteFood.Enabled = false;
            }
            else //button delete and update are only enable when user click 1 row
            {
                btnUpdateFood.Enabled = true;
                btnAddFood.Enabled = false;
                btnDeleteFood.Enabled = true;
            }
        }

        private void dgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFood.SelectedRows[0].Cells[0].Value.ToString() == txtTempIdFood)
            {
                txtIDFood.Text = txtTempIdFood;
                txtNameFood.Text = txtTempNameFood;
                txtGiaTienFood.Text = txtTempGiaTienFood;
                cbDanhMucFood.SelectedIndex = tempCbDanhMucFood.MaDM - 1;
            }
            //set temp info
            txtTempIdFood = txtIDFood.Text;
            txtTempNameFood = txtNameFood.Text;
            txtTempGiaTienFood = txtGiaTienFood.Text;
            tempCbDanhMucFood = ((DanhMucDTO)cbDanhMucFood.SelectedItem);
        }
        private void pnFood_Click(object sender, EventArgs e)
        {
            dgvFood.ClearSelection();
            ResetTextBoxFood();
        }


        // ------------- Category Section -------------
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            DanhMucBLL.Instance.AddDanhMuc(txtNameCategory.Text);
            LoadDgvCategory();
            dgvCategory.CurrentCell.Selected = false;
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            txtTempNameCategory = txtNameCategory.Text;
            DanhMucBLL.Instance.UpdateDanhMuc(new DanhMuc 
            { 
                MaDM = Convert.ToInt32(txtIDCategory.Text), 
                TenDM = txtNameCategory.Text 
            });
            LoadDgvCategory();
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows[0].Index == dgvCategory.Rows.Count - 1)
            {
                txtTempIdCategory = dgvCategory.Rows[dgvCategory.Rows.Count - 2].Cells[0].Value.ToString();
                txtTempNameCategory = dgvCategory.Rows[dgvCategory.Rows.Count - 2].Cells[1].Value.ToString();
            }
            else
            {
                txtTempIdCategory = dgvCategory.Rows[dgvCategory.SelectedRows[0].Index - 1].Cells[0].Value.ToString();
                txtTempNameCategory = dgvCategory.Rows[dgvCategory.SelectedRows[0].Index - 1].Cells[1].Value.ToString();
            }
            DanhMucBLL.Instance.DeleteDanhMuc(Convert.ToInt32(txtIDCategory.Text));
            LoadDgvCategory(); 
        }

        private void btnSearchCategory_Click(object sender, EventArgs e)
        {
            bsCategory.DataSource = DanhMucBLL.Instance.SearchDanhMuc(txtSearchCategory.Text);
        }

        private void dgvCategory_MouseClick(object sender, MouseEventArgs e)
        {
            var ht = dgvCategory.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None) //check if user clicked on blank dgv
            {
                dgvCategory.ClearSelection();
                ResetTextBoxCategory();
                btnUpdateCategory.Enabled = false;
            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategory.SelectedRows[0].Cells[0].Value.ToString() == txtTempIdCategory)
            {
                txtIDCategory.Text = txtTempIdCategory;
                txtNameCategory.Text = txtTempNameCategory;
            }
            txtTempIdCategory = txtIDCategory.Text;
            txtTempNameCategory = txtNameCategory.Text;
        }

        private void txtIDCategory_TextChanged(object sender, EventArgs e)
        {
            //button add shows up when click nothing
            if (txtIDCategory.Text == "")
            {
                btnUpdateCategory.Enabled = false;
                btnAddCategory.Enabled = true;
                btnDeleteCategory.Enabled = false;
            }
            else //button delete and update are only enable when user click 1 row
            {
                btnUpdateCategory.Enabled = true;
                btnAddCategory.Enabled = false;
                btnDeleteCategory.Enabled = true;
            }
        }

        private void pnCategory_Click(object sender, EventArgs e)
        {
            dgvCategory.ClearSelection();
            ResetTextBoxCategory();
        }

        


        //------------- Table Section -------------

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            BanBLL.Instance.AddBan(txtNameTable.Text);
            LoadDgvTable();
            dgvTable.CurrentCell.Selected = false;
        }

        private void btnSearchTable_Click(object sender, EventArgs e)
        {
            bsTable.DataSource = BanBLL.Instance.SearchBan(txtSearchTable.Text);
        }

        private void btnUpdateTable_Click(object sender, EventArgs e)
        {
            txtTempNameTable = txtNameTable.Text;
            BanBLL.Instance.UpdateBan(new Ban{ 
                MaBan = Convert.ToInt32(txtIDTable.Text),
                TenBan = txtNameTable.Text,
                TrangThai = Convert.ToBoolean(txtTrangThaiTable.Text)
            });
            LoadDgvTable();
        }

        private void btnDelTable_Click(object sender, EventArgs e)
        {
            if (dgvTable.SelectedRows[0].Index == dgvTable.Rows.Count - 1)
            {
                txtTempIdTable = dgvTable.Rows[dgvTable.Rows.Count - 2].Cells[0].Value.ToString();
                txtTempNameTable = dgvTable.Rows[dgvTable.Rows.Count - 2].Cells[1].Value.ToString();
                txtTempTrangThaiTable = dgvTable.Rows[dgvTable.Rows.Count - 2].Cells[2].Value.ToString();
            }
            else
            {
                txtTempIdTable = dgvTable.Rows[dgvTable.SelectedRows[0].Index - 1].Cells[0].Value.ToString();
                txtTempNameTable = dgvTable.Rows[dgvTable.SelectedRows[0].Index - 1].Cells[1].Value.ToString();
                txtTempTrangThaiTable = dgvTable.Rows[dgvTable.SelectedRows[0].Index - 1].Cells[2].Value.ToString();
            }
            BanBLL.Instance.DeleteBan(Convert.ToInt32(txtIDTable.Text));
            LoadDgvTable();
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTable.SelectedRows[0].Cells[0].Value.ToString() == txtTempIdTable )
            {
                txtIDTable.Text = txtTempIdTable;
                txtNameTable.Text = txtTempNameTable;
                txtTrangThaiTable.Text = txtTempTrangThaiTable;
            }    
            txtTempIdTable = txtIDTable.Text;
            txtTempNameTable = txtNameTable.Text;
            txtTempTrangThaiTable = txtTrangThaiTable.Text;
        }

        private void dgvTable_MouseClick(object sender, MouseEventArgs e)
        {
            var ht = dgvTable.HitTest(e.X, e.Y);
            if (ht.Type == DataGridViewHitTestType.None) //check if user clicked on blank dgv
            {
                dgvTable.ClearSelection();
                ResetTextBoxTable();
                btnUpdateTable.Enabled = false;
            }
        }

        private void txtIDTable_TextChanged(object sender, EventArgs e)
        {
            if(txtIDTable.Text == "") //button add shows up when click nothing
            {
                btnAddTable.Enabled = true;
                btnUpdateTable.Enabled = false;
                btnDelTable.Enabled = false;
            }
            else //button delete and update are only enable when user click 1 row
            {
                btnAddTable.Enabled = false;
                btnUpdateTable.Enabled = true;
                btnDelTable.Enabled = true;
            }
        }

        private void pnTable_Click(object sender, EventArgs e)
        {
            dgvTable.ClearSelection();
            ResetTextBoxFood();
        }

        
    }
}
