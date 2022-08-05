using FastFoodManagement.BLL;
using FastFoodManagement.DTO;
using FastFoodManagement.VIEW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastFoodManagement
{
    public partial class Order : Form
    {
        demoPBL3 db = new demoPBL3();

        public int soluongban = 0;

        public bool isThoat = true;
        NhanVien nv = new NhanVien();

        private int IdBan;

        private Button btnBanLast;
        private CBBItemBan itemBan;

        BindingSource bsCategory = new BindingSource();
        BindingSource bsFood = new BindingSource();
        BindingSource bsTable = new BindingSource();
        BindingSource bsOrder = new BindingSource();
        BindingSource bsAccount = new BindingSource();

        private List<Button> listBan = new List<Button>();
        Dictionary<string, int> mapTable = new Dictionary<string, int>();

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
        private int tempIdBan;

        private string txtTempIdNhanVien;
        private string txtTempTenNhanVien;
        private string txtTempDiaChiNhanVien;
        private string txtTempSDTNhanVien;
        private string txtTempUsername;
        private string txtTempPassword;
        private CbbItemChucVu cbTempCbChucVu;

        public Order(NhanVien nv)
        {
            InitializeComponent();
            LoadAllComponent();
            this.nv = nv;
        }
        private void Order_Load(object sender, EventArgs e)
        {
            //QL~0, NV~1
            if (nv.ChucVu == 0)
            {
                lbPerson.Text = nv.TenNV + " - Quản Lý";

                btnAccount.Visible = true;
                btnFood.Visible = true;
                btnTable.Visible = true;
                btnRevenue.Visible = true;
                btnDanhmuc.Visible = true;
                //vo hieu hoa chuhc nang Accout
                btnAddAccount.Visible = true;
                
                btnDeleteAccount.Visible = true;
                btnUpdateAccount.Visible = true;
                

                //vo hieu hoa chuc nang Table
                btnAddTable.Visible = true;
                btnDelTable.Visible = true;
                
                btnUpdateTable.Visible = true;

                //Vo hieu hoa chuc nang Category
                btnAddCategory.Visible = true;
                btnDeleteCategory.Visible = true;
                btnUpdateCategory.Visible = true;
                

                //Vo hieu hoa chuc nang Food
                btnAddFood.Visible = true;
                btnDeleteFood.Visible = true;
                
                btnUpdateFood.Visible = true;

            }
            if (nv.ChucVu != 0)
            {

                lbPerson.Text = nv.TenNV + " - Nhân Viên";

                btnAccount.Visible = false;
                btnFood.Visible = false;
                btnTable.Visible = false;
                btnRevenue.Visible = false;
                btnDanhmuc.Visible = false;
                // Vo hieu hoa chuc nang Accout
                dgvAccount.Columns["Password"].Visible = false;
                btnAddAccount.Visible = false;
                
                btnDeleteAccount.Visible = false;
                btnUpdateAccount.Visible = false;
                txtPassword.Visible = false;
                label22.Visible = false;

                //vo hieu hoa chuc nang Table
                btnAddTable.Visible = false;
                btnDelTable.Visible = false;
                
                btnUpdateTable.Visible = false;

                //vo hieu hoa chuc nang Category
                btnAddCategory.Visible = false;
                btnDeleteCategory.Visible = false;
                btnUpdateCategory.Visible = false;
                

                //vo hieu hoa chuc nang Food
                btnAddFood.Visible = false;
                btnDeleteFood.Visible = false;
                
                btnUpdateFood.Visible = false;
            }
        }

        private void LoadAllComponent()
        {
            dgvCategory.DataSource = bsCategory;
            dgvFood.DataSource = bsFood;
            dgvTable.DataSource = bsTable;
            dgvOrder.DataSource = bsOrder;
            dgvAccount.DataSource = bsAccount;

           

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

            //Order
            //LoadButtonTable();
            LoadDgvOrder();

            LoadFormOrderComponent();


            //Acount
            LoadItemsCbAccount();
            LoadDgvAccount();
            AddAccountBinding();
        }



        #region Menu Section
        private void btnHome_Click_1(object sender, EventArgs e)
        {
            panelHome.Visible = true;
            panelOrder.Visible = false;
            panelFood.Visible = false;
            panelCategory.Visible = false;
            panelTable.Visible = false;
            panelAccount.Visible = false;
            panelRevenue.Visible = false;
        }
        private void btnOrder_Click_1(object sender, EventArgs e)
        {
            panelOrder.Visible = true;
            panelHome.Visible = false;
            panelFood.Visible = false;
            panelCategory.Visible = false;
            panelTable.Visible = false;
            panelAccount.Visible = false;
            btnChuyenBan.Enabled = false;
            panelRevenue.Visible = false;
            if(string.IsNullOrEmpty(lbltenbancuabill.Text))
            {
                btnThemMon.Enabled = false;
            }    
            LoadDgvOrder();

            LoadBtnBan();
            typeof(FlowLayoutPanel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            flTable, new object[] { true });
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
            panelRevenue.Visible = false;
            //dgvFood.CurrentCell.Selected = false;
            ClearSelectedCell(dgvFood);
            ResetTextBoxFood();
            cbDanhMucFood.Items.Clear();
            LoadItemsCbDanhMuc();
        }

        void ClearSelectedCell(DataGridView dgv)
        {
            if(dgv.Rows.Count > 0)
                dgv.CurrentCell.Selected = false;
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
            panelRevenue.Visible = false;
            //dgvCategory.CurrentCell.Selected = false;
            ClearSelectedCell(dgvCategory);
            ResetTextBoxCategory();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            
            panelTable.Visible = true;
            panelHome.Visible = false;
            panelOrder.Visible = false;
            panelFood.Visible = false;
            panelCategory.Visible = false;
            panelAccount.Visible = false;
            panelRevenue.Visible = false;
            //dgvTable.CurrentCell.Selected = false;
            ClearSelectedCell(dgvTable);
            ResetTextBoxTable();
            LoadDgvTable();
        }
        private void btnAccount_Click(object sender, EventArgs e)
        {
            panelAccount.Visible = true;
            panelHome.Visible = false;
            panelOrder.Visible = false;
            panelFood.Visible = false;
            panelCategory.Visible = false;
            panelTable.Visible = false;
            panelRevenue.Visible = false;
            //dgvAccount.CurrentCell.Selected = false;
            ClearSelectedCell(dgvAccount);
            ResetTextBoxAccount();
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            panelRevenue.Visible = true;
            panelHome.Visible = false;
            panelOrder.Visible = false;
            panelFood.Visible = false;
            panelCategory.Visible = false;
            panelTable.Visible = false;
            panelAccount.Visible = false;

            dgvRevenue.DataSource = 0;
            //display blank chart
            chart1.Series[0].Color = Color.Transparent;
            lbSoTienDoanhThu.Text = null;
        }
        #endregion

 
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
        #region Food Section
        private void LoadDgvFood()
        {
            bsFood.DataSource = SanPhamBLL.Instance.GetAllSanPham();
            ResetTextBoxFood();
            //dgvFood.CurrentCell.Selected = false;
            ClearSelectedCell(dgvFood);
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
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            SanPham temp = db.SanPhams.Where(p => p.TenSP == txtNameFood.Text).FirstOrDefault();
            if(temp==null) //SP mới
            {
                if (txtNameFood.Text == "" || cbDanhMucFood.SelectedIndex == -1 || txtGiaTienFood.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ thông tin!",
                                        "Warning",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                }
                else
                {
                    if (txtGiaTienFood.Text.Any(char.IsLetter) == true)
                    {
                        MessageBox.Show("Giá tiền không hợp lệ! Vui lòng nhập lại",
                                            "Warning",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                    }
                    else
                    {
                        SanPhamBLL.Instance.AddSanPham(new SanPham
                        {
                            TenSP = txtNameFood.Text,
                            MaDM = ((DanhMucDTO)cbDanhMucFood.SelectedItem).MaDM,
                            GiaSP = Convert.ToInt32(txtGiaTienFood.Text),
                        });
                        LoadDgvFood();
                        
                    }
                    
                }
            }
            else
            {
                if (txtNameFood.Text == temp.TenSP)
                {
                    switch (temp.IsDelete)
                    {
                        case false:
                            MessageBox.Show("Món ăn đã tồn tại! Vui lòng nhập món khác", "Warning",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                            break;
                        case true:
                            temp.IsDelete = false;
                            db.SaveChanges();
                            LoadDgvFood();
                            LoadItemsCbDanhMuc();
                            break;
                    }
                }
            }
        }
        private void btnUpdateFood_Click(object sender, EventArgs e)
        {
            SanPham temp = db.SanPhams.Where(p => p.TenSP == txtNameFood.Text).FirstOrDefault();
            if (txtNameFood.Text == "" || cbDanhMucFood.SelectedIndex == -1 || txtGiaTienFood.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin!",
                                    "Warning",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
            }
            else if (txtNameFood.Text == temp.TenSP && temp.IsDelete == false && txtIDFood.Text!=temp.MaSP.ToString())
            {
                MessageBox.Show("Sản phẩm đã tồn tại!Vui lòng nhập lại",
                                    "Warning",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                LoadDgvFood();
                LoadItemsCbDanhMuc();
            }
            else if (txtGiaTienFood.Text.Any(char.IsLetter)==true)
            {
                MessageBox.Show("Giá tiền không hợp lệ! Vui lòng nhập lại",
                                    "Warning",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                txtGiaTienFood.Text = "";
            }
            else
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
                btnFood_Click_1(sender, e);
            }
            
            
        }
        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            if (dgvFood.SelectedRows[0].Index == dgvFood.Rows.Count - 1)
            {
                txtTempIdFood = dgvFood.Rows[dgvFood.Rows.Count - 2].Cells[0].Value.ToString();
                txtTempNameFood = dgvFood.Rows[dgvFood.Rows.Count - 2].Cells[1].Value.ToString();
                tempCbDanhMucFood.TenDM = dgvFood.Rows[dgvFood.Rows.Count - 2].Cells[2].Value.ToString();
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
                foreach (var i in cbDanhMucFood.Items)
                {
                    if (i.ToString() == tempCbDanhMucFood.TenDM)
                    {
                        cbDanhMucFood.SelectedItem = i;
                        break;
                    }
                }

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
        #endregion

        // ------------- Category Section -------------
        #region Category Section
        private void LoadItemsCbDanhMuc()
        {
            cbDanhMucFood.Items.AddRange(DanhMucBLL.Instance.GetAllDanhMuc().ToArray());
            if(cbDanhMucFood.Items.Count > 0)
                cbDanhMucFood.SelectedIndex = 0;
        }
        private void AddCategoryBinding()
        {
            txtIDCategory.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "MaDM", true, DataSourceUpdateMode.Never));
            txtNameCategory.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "TenDM", true, DataSourceUpdateMode.Never));
        }
        private void LoadDgvCategory()
        {
            bsCategory.DataSource = DanhMucBLL.Instance.GetAllDanhMuc();
            ResetTextBoxCategory();
            //dgvCategory.CurrentCell.Selected = false;
            ClearSelectedCell(dgvCategory);
        }
        private void ResetTextBoxCategory()
        {
            txtNameCategory.Text = "";
            txtIDCategory.Text = "";
            txtSearchCategory.Text = "";
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            DanhMuc temp = db.DanhMucs.Where(p => p.TenDM == txtNameCategory.Text).FirstOrDefault();
            if (temp == null)
            {
                if (txtNameCategory.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ thông tin danh mục!",
                                        "Warning",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                }
                else
                {
                    DanhMucBLL.Instance.AddDanhMuc(txtNameCategory.Text);
                    LoadDgvCategory();
                    dgvCategory.CurrentCell.Selected = false;
                }
            }
            else
            {
                if (txtNameCategory.Text == temp.TenDM)
                {
                    switch (temp.IsDelete)
                    {
                        case false:
                            MessageBox.Show("Danh mục đã tồn tại! Vui lòng nhập tên khác", "Warning",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                            break;
                        case true:
                            temp.IsDelete = false;
                            db.SaveChanges();
                            LoadDgvCategory();
                            break;
                    }
                }
            }
            
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            DanhMuc temp = db.DanhMucs.Where(p => p.TenDM == txtNameCategory.Text).FirstOrDefault();
            if (txtNameCategory.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin!",
                                    "Warning",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
            }
            else if (temp!=null && txtNameCategory.Text == temp.TenDM && temp.IsDelete == false && txtIDCategory.Text != temp.MaDM.ToString())
            {
                MessageBox.Show("Danh mục đã tồn tại!Vui lòng nhập lại",
                                    "Warning",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                LoadDgvCategory();
            }
            else
            {
                txtTempNameCategory = txtNameCategory.Text;
                DanhMucBLL.Instance.UpdateDanhMuc(new DanhMuc
                {
                    MaDM = Convert.ToInt32(txtIDCategory.Text),
                    TenDM = txtNameCategory.Text
                });
              btnDanhmuc_Click(sender, e);
            }
            
        }
        // Fix cai Del Category
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
        #endregion



        //------------- Table Section -------------
        #region Table Section
        private void LoadBtnBan()
        {
            int soluongban = OrderBLL.Instance.DemBan();
            string[] tenban = OrderBLL.Instance.getAllTableName();
            flTable.Controls.Clear();
            int dem = 0;
            for (int i = 0; i < soluongban; i++)
            {
                if (dem == soluongban)
                    break;
                else
                {
                    Button bnBan = new Button();
                    bnBan.Text = tenban[dem].ToString();
                    bnBan.AutoSize = false;
                    bnBan.Dock = DockStyle.None;
                    bnBan.TextAlign = ContentAlignment.MiddleCenter;
                    bnBan.Width = bnBan.Height = 90;
                    bnBan.Font = new Font("Source Sans Pro", 10, FontStyle.Bold);
                    bnBan.ForeColor = Color.White;

                    if (OrderBLL.Instance.CheckTrangThaiBan(tenban[dem]))
                    {
                        bnBan.BackColor = Color.OrangeRed;
                    }
                    else
                    {
                        bnBan.BackColor = Color.LimeGreen;
                    }

                    bnBan.FlatStyle = FlatStyle.Standard;
                    flTable.Controls.Add(bnBan);
                    listBan.Add(bnBan);
                    bnBan.Click += bnBan_Click;

                    dem++;
                }

            }
        }
        private void LoadDgvTable()
        {
            bsTable.DataSource = BanBLL.Instance.GetAllBan();
            ResetTextBoxTable();
            //dgvTable.CurrentCell.Selected = false;
            ClearSelectedCell(dgvTable);
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
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            Ban temp = db.Bans.Where(p => p.TenBan == txtNameTable.Text).FirstOrDefault();
            if (temp == null)
            {
                if (txtNameTable.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ thông tin bàn!",
                                        "Warning",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                }
                else
                {

                    BanBLL.Instance.AddBan(txtNameTable.Text);
                    LoadDgvTable();
                    dgvTable.CurrentCell.Selected = false;
                }
            }
            else
            {
                if (txtNameTable.Text == temp.TenBan)
                {
                    switch (temp.IsDelete)
                    {
                        case false:
                            MessageBox.Show("Bàn đã tồn tại! Vui lòng nhập tên khác", "Warning",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                            break;
                        case true:
                            temp.IsDelete = false;
                            db.SaveChanges();
                            LoadDgvTable();
                            break;
                    }
                }
            }
                
        }

        private void btnSearchTable_Click(object sender, EventArgs e)
        {
            bsTable.DataSource = BanBLL.Instance.SearchBan(txtSearchTable.Text);
        }

        private void btnUpdateTable_Click(object sender, EventArgs e)
        {
            Ban temp = db.Bans.Where(p => p.TenBan == txtNameTable.Text).FirstOrDefault();
            if (txtNameTable.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin!",
                                    "Warning",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
            }
            else if (txtNameTable.Text == temp.TenBan && temp.IsDelete == false && txtIDTable.Text != temp.MaBan.ToString())
            {
                MessageBox.Show("Bàn đã tồn tại!Vui lòng nhập lại",
                                    "Warning",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                LoadDgvTable();
            }
            else
            {
                txtTempNameTable = txtNameTable.Text;
                BanBLL.Instance.UpdateBan(new Ban
                {
                    MaBan = Convert.ToInt32(txtIDTable.Text),
                    TenBan = txtNameTable.Text,
                    TrangThai = Convert.ToBoolean(txtTrangThaiTable.Text)
                });
                btnTable_Click(sender, e);
            }
            
        }

        private void btnDelTable_Click(object sender, EventArgs e)
        {
            if(txtTrangThaiTable.Text == "True")
            {
                MessageBox.Show("Bàn đang có người, không thể xóa");
                return;
            }
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
            if (dgvTable.SelectedRows[0].Cells[0].Value.ToString() == txtTempIdTable)
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
            if (txtIDTable.Text == "") //button add shows up when click nothing
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

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword passwordform = new ChangePassword(nv);
            passwordform.Show();
            passwordform.d = new ChangePassword.MyDel(isChange);
        }
        public void isChange(bool check = false)
        {
            if (check == true)
            {
                Dangxuat(this, new EventArgs());
            }
        }
        #endregion

        //------------- Order Section -------------
        #region Order Section
        private void LoadFormOrderComponent()
        {
            btnThanhToan.Enabled = false;
            btnClearAll.Enabled = false;
        }
        void LoadDgvOrder()
        {
            bsOrder.DataSource = SanPhamBLL.Instance.GetAllSanPham();
            //ResetTextBoxFood();
            //dgvFood.CurrentCell.Selected = false;
            if (dgvOrder.Rows.Count == 0)
            {
                btnThemMon.Visible = false;
            }
        }


        private void bnBan_Click(object sender, EventArgs e)
        {
            btnThemMon.Enabled = true;
            Button bnBan = sender as Button;
            lbltenbancuabill.Text = bnBan.Text;
            List<BanDTO> bans = OrderBLL.Instance.GetAllTable();
            
            for (int i = 0; i < bans.Count; i++)
            {
                mapTable[bans[i].TenBan] = bans[i].MaBan;
            }
            if (mapTable[bnBan.Text] != 0)
            {
                IdBan = mapTable[bnBan.Text];
            }


            LoadDgvBill();
            btnBanLast = bnBan;
            SetVisibleBtnIfHaveData();
            LoadTongTienBill();
            cbChuyenBan.Items.Clear();
            LoadCBBItemBan();
            RemoveCbItemCurrentTable();

            cbChuyenBan.SelectedIndex = -1;
            btnChuyenBan.Enabled = false;
        }

        private void RemoveCbItemCurrentTable()
        {
            foreach (CBBItemBan i in cbChuyenBan.Items)
            {
                if (i.Text == btnBanLast.Text)
                {
                    cbChuyenBan.Items.Remove(i);
                    break;
                }

            }
        }

        private void LoadTongTienBill()
        {
            int tongTien = 0;
            foreach (DataGridViewRow i in dgvBill.Rows)
            {
                tongTien += Convert.ToInt32(i.Cells["ThanhTien"].Value);
            }
            lbNumThanhTien.Text = tongTien.ToString() + " đ";
        }

        private void LoadDgvBill()
        {
            int IdHoaDon = OrderBLL.Instance.FindIdHoaDonOfBan(IdBan);
            dgvBill.DataSource = OrderBLL.Instance.GetAllHDCTByIdHoaDon(IdHoaDon);
            dgvBill.Columns["MaSP"].Visible = false;
            dgvBill.Columns["MaHDCT"].Visible = false;  
            SetAlignmentItem();
        }

        private void SetAlignmentItem()
        {
            ////dgvBill.Columns["STT"].Width = 32;
            //dgvBill.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBill.Columns["TenSP"].Width = 100;
            dgvBill.Columns["SL"].Width = 24;
            dgvBill.Columns["SL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBill.Columns["SL"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            
            int idHoaDonOfBan = OrderBLL.Instance.FindIdHoaDonOfBan(IdBan);
            OrderBLL.Instance.ThanhToanHoaDon(idHoaDonOfBan, Convert.ToInt32(lbNumThanhTien.Text.Remove(lbNumThanhTien.Text.Length - 2)));
            LoadDgvBill();
            OrderBLL.Instance.SetTrangThaiBan(IdBan, false);
            SetVisibleBtnIfHaveData();
            LoadBtnBan();
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (OrderBLL.Instance.CheckTrangThaiBanWithHoaDon(IdBan)) OrderBLL.Instance.AddHoaDon(IdBan, nv.MaNV);
            int idHoaDonOfBan = OrderBLL.Instance.FindIdHoaDonOfBan(IdBan);
            OrderBLL.Instance.AddHoaDonChiTiet(new HoaDonChiTiet
            {
                MaHD = idHoaDonOfBan,
                MaSP = Convert.ToInt32(dgvOrder.SelectedRows[0].Cells["MaSP"].Value),
                SoLuong = Convert.ToInt32(numSoLuong.Value),
                GiaTien = Convert.ToInt32(dgvOrder.SelectedRows[0].Cells["Gia"].Value),
            });
            LoadDgvBill();


            numSoLuong.Value = 1;

            OrderBLL.Instance.SetTrangThaiBan(IdBan, true);

            SetVisibleBtnIfHaveData();
            LoadTongTienBill();
            LoadBtnBan();
            RemoveCbItemCurrentTable();
        }

        private void SetVisibleBtnIfHaveData()
        {
            if (dgvBill.Rows.Count == 0)
            {
                btnThanhToan.Enabled = false;
                btnClearAll.Enabled = false;
                lbNumThanhTien.Text = "0 đ";
                cbChuyenBan.Enabled = false;
            }
            else
            {
                btnThanhToan.Enabled = true;
                btnClearAll.Enabled = true;
                cbChuyenBan.Enabled = true;
            }

        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            OrderBLL.Instance.DeleteHoaDonChiTiet(IdBan);
            int idHoaDonOfBan = OrderBLL.Instance.FindIdHoaDonOfBan(IdBan);
            LoadDgvBill();
            
            SetVisibleBtnIfHaveData();
            OrderBLL.Instance.SetTrangThaiBan(IdBan, false);
            lbNumThanhTien.Text = "0 đ";
            LoadBtnBan();
        }

        private void LoadCBBItemBan()
        {
            cbChuyenBan.Items.AddRange(BanBLL.Instance.GetAllCBBItemBan().ToArray());
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            if (OrderBLL.Instance.CheckTrangThaiBan(cbChuyenBan.SelectedItem.ToString()))
            {
                    
                    foreach (DataGridViewRow i in dgvBill.SelectedRows)
                    {

                        OrderBLL.Instance.AddHoaDonChiTiet(new HoaDonChiTiet
                        {
                            MaHD = OrderBLL.Instance.FindIdHoaDonOfBan(mapTable[cbChuyenBan.SelectedItem.ToString()]),
                            MaSP = Convert.ToInt32(i.Cells["MaSP"].Value),
                            SoLuong = Convert.ToInt32(i.Cells["SL"].Value),
                            GiaTien = Convert.ToInt32(i.Cells["ThanhTien"].Value),
                        });
                        OrderBLL.Instance.DeleteOneHoaDonChiTiet(Convert.ToInt32(i.Cells["MaHDCT"].Value));
                    }
                if (dgvBill.SelectedRows.Count == dgvBill.Rows.Count)
                {
                    OrderBLL.Instance.SetTrangThaiBan(IdBan, false);
                }
                else
                {
                    //OrderBLL.Instance.SetTrangThaiBan(IdBan, true);
                    
                }
            }
            else
            {
                if(dgvBill.SelectedRows.Count == dgvBill.Rows.Count)
                    OrderBLL.Instance.ChuyenBan(OrderBLL.Instance.FindIdHoaDonOfBan(IdBan),
                    ((CBBItemBan)cbChuyenBan.SelectedItem).Value, IdBan);
                else
                {
                    OrderBLL.Instance.AddHoaDon(mapTable[cbChuyenBan.SelectedItem.ToString()], nv.MaNV);
                    foreach (DataGridViewRow i in dgvBill.SelectedRows)
                    {

                        OrderBLL.Instance.AddHoaDonChiTiet(new HoaDonChiTiet
                        {
                            MaHD = OrderBLL.Instance.FindIdHoaDonOfBan(mapTable[cbChuyenBan.SelectedItem.ToString()]),
                            MaSP = Convert.ToInt32(i.Cells["MaSP"].Value),
                            SoLuong = Convert.ToInt32(i.Cells["SL"].Value),
                            
                            GiaTien = Convert.ToInt32(i.Cells["ThanhTien"].Value),
                        });
                        OrderBLL.Instance.DeleteOneHoaDonChiTiet(Convert.ToInt32(i.Cells["MaHDCT"].Value));
                    }
                }
            }
            LoadDgvBill();


            SetVisibleBtnIfHaveData();
            LoadBtnBan();        
        }

        private void SetColorBtnBan()
        {
            if (dgvBill.Rows.Count > 0)
            {
                btnBanLast.BackColor = Color.OrangeRed;
            }
            else
            {
                btnBanLast.BackColor = Color.LimeGreen;
            }
        }

        private void cbChuyenBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChuyenBan.SelectedIndex != -1)
            {
                btnChuyenBan.Enabled = true;
            }
        }
#endregion

        //------------- Acoount Section -------------
        #region Account Section
        private void LoadDgvAccount()
        {
            bsAccount.DataSource = AccountBLL.Instance.GetAllAccount();
            ResetTextBoxAccount();
            dgvAccount.CurrentCell.Selected = false;

        }

        private void LoadItemsCbAccount()
        {
            cbChucVuNhanVien.Items.AddRange(AccountBLL.Instance.GetAllChucVu().ToArray());
            cbChucVuNhanVien.SelectedIndex = 0;
        }

        private void ResetTextBoxAccount()
        {
            txtIDNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtDiaChiNhanVien.Text = "";
            txtSDTNhanVien.Text = "";
            cbChucVuNhanVien.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
        private void pnAccount_Click(object sender, EventArgs e)
        {
            dgvAccount.ClearSelection();
            ResetTextBoxAccount();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            NhanVien temp = db.NhanViens.Where(p => p.Account.Username == txtUsername.Text||p.SDT == txtSDTNhanVien.Text).FirstOrDefault();
            if (temp == null) //SP mới
            {
                if (txtTenNhanVien.Text == "" || txtDiaChiNhanVien.Text == "" || txtSDTNhanVien.Text == "" || cbChucVuNhanVien.SelectedIndex == -1 || txtUsername.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ thông tin!",
                                        "Warning",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                }
                else
                {
                    if (txtSDTNhanVien.Text.Any(char.IsLetter) == true)
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập lại",
                                            "Warning",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                    }
                    else
                    {
                        AccountBLL.Instance.AddAccount(new NhanVien
                        {

                            TenNV = txtTenNhanVien.Text,
                            DiaChi = txtDiaChiNhanVien.Text,
                            SDT = txtSDTNhanVien.Text,
                            ChucVu = ((CbbItemChucVu)cbChucVuNhanVien.SelectedItem).MaCV,
                            Account = new Account
                            {
                                Username = txtUsername.Text,
                                PassWord = txtPassword.Text,
                            }

                        });
                        LoadDgvAccount();

                    }

                }
            }
            else
            {
                if(txtSDTNhanVien.Text == temp.SDT || txtUsername.Text == temp.Account.Username)
                {
                    switch (temp.Account.IsDelete)
                    {
                        case false:
                            MessageBox.Show("Tài khoản đã tồn tại! Vui lòng nhập lại", "Warning",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                            break;
                        case true:
                            temp.Account.IsDelete = false;
                            db.SaveChanges();
                            LoadDgvAccount();
                            LoadItemsCbAccount();
                            break;
                    }
                }
            }
            
            
        }


        

        private void dgvAccount_MouseClick(object sender, MouseEventArgs e)
        {
            var ht = dgvAccount.HitTest(e.X, e.Y);
            if (ht.Type == DataGridViewHitTestType.None) //check if user clicked on blank dgv
            {
                dgvAccount.ClearSelection();
                ResetTextBoxAccount();
                btnUpdateAccount.Enabled = false;
            }
        }

        private void AddAccountBinding()
        {
            txtIDNhanVien.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "MaNV", true, DataSourceUpdateMode.Never));
            txtTenNhanVien.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "TenNV", true, DataSourceUpdateMode.Never));
            txtDiaChiNhanVien.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
            txtSDTNhanVien.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "SDT", true, DataSourceUpdateMode.Never));
            cbChucVuNhanVien.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "ChucVu", true, DataSourceUpdateMode.Never));
            txtUsername.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "Username", true, DataSourceUpdateMode.Never));
            txtPassword.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "Password", true, DataSourceUpdateMode.Never));
        }

        private void txtIDNhanVien_TextChanged(object sender, EventArgs e)
        {
            //button add shows up when click nothing
            if (txtIDNhanVien.Text == "")
            {
                btnUpdateAccount.Enabled = false;
                btnAddAccount.Enabled = true;
                btnDeleteAccount.Enabled = false;
            }
            else //button delete and update are only enable when user click 1 row
            {
                btnUpdateAccount.Enabled = true;
                btnAddAccount.Enabled = false;
                btnDeleteAccount.Enabled = true;
            }
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAccount.SelectedRows[0].Cells[0].Value.ToString() == txtTempIdNhanVien)
            {
                txtIDNhanVien.Text = txtTempIdNhanVien;
                txtTenNhanVien.Text = txtTempTenNhanVien;
                txtDiaChiNhanVien.Text = txtTempDiaChiNhanVien;
                cbChucVuNhanVien.Text = cbTempCbChucVu.TenCV;
                txtSDTNhanVien.Text = txtTempSDTNhanVien;
                txtUsername.Text = txtTempUsername;
                txtPassword.Text = txtTempPassword;
            }
            //set temp info
            txtTempIdNhanVien = txtIDNhanVien.Text;
            txtTempTenNhanVien = txtTenNhanVien.Text;
            txtTempDiaChiNhanVien = txtDiaChiNhanVien.Text;
            cbTempCbChucVu = ((CbbItemChucVu)cbChucVuNhanVien.SelectedItem);
            txtTempSDTNhanVien = txtSDTNhanVien.Text;
            txtTempUsername = txtUsername.Text;
            txtTempPassword = txtPassword.Text;
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            NhanVien temp = db.NhanViens.Where(p => p.Account.Username == txtUsername.Text || p.SDT == txtSDTNhanVien.Text).FirstOrDefault();
            if (txtTenNhanVien.Text == "" || txtDiaChiNhanVien.Text == "" || txtSDTNhanVien.Text == "" || cbChucVuNhanVien.SelectedIndex == -1 || txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin!",
                                    "Warning",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
            }
            else if ((txtSDTNhanVien.Text == temp.SDT||txtUsername.Text == temp.Account.Username) && temp.Account.IsDelete == false && txtIDNhanVien.Text != temp.MaNV.ToString())
            {
                MessageBox.Show("Tài khoản đã tồn tại!Vui lòng nhập lại",
                                    "Warning",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                LoadDgvAccount();

            }
            else if (txtSDTNhanVien.Text.Any(char.IsLetter) == true)
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập lại",
                                    "Warning",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                txtSDTNhanVien.Text = "";
            }
            else
            {
                //set temp info
                txtTempTenNhanVien = txtTenNhanVien.Text;
                txtTempIdNhanVien = txtIDNhanVien.Text;
                txtTempDiaChiNhanVien = txtDiaChiNhanVien.Text;
                cbTempCbChucVu = (CbbItemChucVu)cbChucVuNhanVien.SelectedItem;
                txtTempSDTNhanVien = txtSDTNhanVien.Text;
                txtTempUsername = txtUsername.Text;
                txtTempPassword = txtPassword.Text;
                AccountBLL.Instance.UpdateAccount(new NhanVien
                {
                    MaNV = Convert.ToInt32(txtIDNhanVien.Text),
                    TenNV = txtTenNhanVien.Text,
                    DiaChi = txtDiaChiNhanVien.Text,
                    SDT = txtSDTNhanVien.Text,
                    ChucVu = ((CbbItemChucVu)cbChucVuNhanVien.SelectedItem).MaCV,
                    Account = new Account
                    {
                        Username = txtUsername.Text,
                        PassWord = txtPassword.Text,
                    }
                });
                btnAccount_Click(sender, e);
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (dgvAccount.SelectedRows[0].Index == dgvAccount.Rows.Count - 1)
            {
                txtTempIdNhanVien = dgvAccount.Rows[dgvAccount.Rows.Count - 2].Cells[0].Value.ToString();
                txtTempTenNhanVien = dgvAccount.Rows[dgvAccount.Rows.Count - 2].Cells[1].Value.ToString();
                txtTempDiaChiNhanVien = dgvAccount.Rows[dgvAccount.Rows.Count - 2].Cells[2].Value.ToString();
                txtTempSDTNhanVien = dgvAccount.Rows[dgvAccount.Rows.Count - 2].Cells[3].Value.ToString();
                cbTempCbChucVu.TenCV = dgvAccount.Rows[dgvAccount.Rows.Count -2].Cells[4].Value.ToString();
                txtTempUsername = dgvAccount.Rows[dgvAccount.Rows.Count - 2].Cells[5].Value.ToString();
                txtTempPassword = dgvAccount.Rows[dgvAccount.Rows.Count - 2].Cells[6].Value.ToString();
            }
            else
            {
                txtTempIdNhanVien = dgvAccount.Rows[dgvAccount.SelectedRows[0].Index].Cells[0].Value.ToString();
                txtTempTenNhanVien = dgvAccount.Rows[dgvAccount.SelectedRows[0].Index].Cells[1].Value.ToString();
                txtTempDiaChiNhanVien = dgvAccount.Rows[dgvAccount.SelectedRows[0].Index].Cells[2].Value.ToString();
                txtTempSDTNhanVien = dgvAccount.Rows[dgvAccount.SelectedRows[0].Index].Cells[3].Value.ToString();
                cbTempCbChucVu.TenCV = dgvAccount.Rows[dgvAccount.SelectedRows[0].Index].Cells[4].Value.ToString();
                txtTempUsername = dgvAccount.Rows[dgvAccount.SelectedRows[0].Index].Cells[5].Value.ToString();
                txtTempPassword = dgvAccount.Rows[dgvAccount.SelectedRows[0].Index].Cells[6].Value.ToString();
            }
            AccountBLL.Instance.DeleteAccount(Convert.ToInt32(txtIDNhanVien.Text));
            LoadDgvAccount();

        }

        private void pnAccount_Click(object sender, MouseEventArgs e)
        {
            dgvAccount.ClearSelection();
            ResetTextBoxAccount();
        }

        private void btnSearchAccount_Click(object sender, EventArgs e)
        {
            bsAccount.DataSource = AccountBLL.Instance.SearchAccount(txtSearchAccount.Text);
        }





        #endregion


        //------------- Revenue Section -------------
        #region Revenue Section
        private void LoadDgvRevenue()
        {
            dgvRevenue.DataSource = HoaDonBLL.Instance.GetFromDateToDate(dateTimePickerFrom.Value, dateTimePickerTo.Value);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadDgvRevenue();
            chart1.DataSource = HoaDonBLL.Instance.GetDoanhThuFromDateToDate(dateTimePickerFrom.Value, dateTimePickerTo.Value);
            chart1.Series["DoanhThu"].XValueMember = "DateFrom";
            chart1.Series["DoanhThu"].YValueMembers = "TongTien";
            chart1.Series[0].Color = Color.Tomato;
            chart1.Invalidate();
            int tongTien = 0;
            foreach (DataGridViewRow i in dgvRevenue.Rows)
            {
                tongTien += Convert.ToInt32(i.Cells[3].Value);
            }
            lbSoTienDoanhThu.Text = tongTien.ToString() + " đ";
            lbSoTienDoanhThu.Font = new Font("Gill Sans Ultra Bold", 16, FontStyle.Bold);

        }
        #endregion

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            ChangePassword f = new ChangePassword(nv);
            f.Show();
            f.d = isChange;
        }

        private void dgvRevenue_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvRevenue_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int maHD = Convert.ToInt32(dgvRevenue.SelectedRows[0].Cells["MaHD"].Value);
            Bill b = new Bill(maHD);
            b.Show();
        }
    }
}
