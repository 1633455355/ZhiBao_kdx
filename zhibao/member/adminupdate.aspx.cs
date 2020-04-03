using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_adminupdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.CheckPermission(Common.Module_Admin, Common.Permission_Update, HttpContext.Current))
        {
            Response.Redirect("nopermission.aspx");
        }
        else
        {
            if (!Page.IsPostBack)
            {
                this.LoadProvince();
                this.LoadRole();
                this.LoadData();
            }
        }
    }
    private void LoadData()
    {
        if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            int id = 0;
            int.TryParse(Request.QueryString["id"],out id);
            if (id > 0)
            {
                AdminBLL ab = new AdminBLL();
                int count=0;
                 
                List<AdminModel> list=new List<AdminModel>();
                ab.GetAdminList(1, 1, id, null,null,null,null,null, out count, out list);
                if (list.Count == 1)
                {
                    AdminModel model = list[0];
                    username_txt.Text = model.AdminName;
                    if (model.Status == false)
                    {
                        status_txt.Text = "被禁止登陆";
                        status_txt.ForeColor = System.Drawing.Color.Red;
                        status_btn.Visible = true;
                    }
                    else
                    {
                        status_btn.Visible = false;
                    }
                    role_ddl.SelectedValue = model.Role.RoleId.ToString();
                    if(model.Type==AdminType.Managers)
                    {
                        relastion_ddl.SelectedValue = "admin";
                        moreinfo.Visible = false;
                        morestorefinfo.Visible = false;
                    }
                    else if(model.Type==AdminType.Dealer)
                    {
                        relastion_ddl.SelectedValue = "dealer";
                        moreinfo.Visible = true;
                        morestorefinfo.Visible = false;
                        if (!string.IsNullOrWhiteSpace(model.Dealer.DealerCompanyName))
                        {
                            name_txt.Text = model.Dealer.DealerCompanyName;
                        }
                        if (!string.IsNullOrWhiteSpace(model.Dealer.Contacts))
                        {
                            contact_txt.Text = model.Dealer.Contacts;
                        }
                        if (!string.IsNullOrWhiteSpace(model.Dealer.Position))
                        {
                            position_txt.Text = model.Dealer.Position;
                        }
                        if (!string.IsNullOrWhiteSpace(model.Dealer.Phone))
                        {
                            phone_txt.Text = model.Dealer.Phone;
                        }
                        if (!string.IsNullOrWhiteSpace(model.Dealer.Mobile))
                        {
                            mobile_txt.Text = model.Dealer.Mobile;
                        }
                        if (!string.IsNullOrWhiteSpace(model.Dealer.Fax))
                        {
                            fax_txt.Text = model.Dealer.Fax;
                        }
                        if(model.Dealer.ProvinceId!=0)
                        {
                            province_ddl.SelectedValue = model.Dealer.ProvinceId.ToString();
                            this.LoadCity(model.Dealer.ProvinceId);
                        }
                        if (model.Dealer.CityId != 0)
                        {
                            city_ddl.SelectedValue = model.Dealer.CityId.ToString();
                        }
                        if (!string.IsNullOrWhiteSpace(model.Dealer.Address))
                        {
                            address_txt.Text = model.Dealer.Address;
                        }
                        if (!string.IsNullOrWhiteSpace(model.Dealer.Zip))
                        {
                            zip_txt.Text = model.Dealer.Zip;
                        }
                        if (!string.IsNullOrWhiteSpace(model.Dealer.Email))
                        {
                            email_txt.Text = model.Dealer.Email;
                        }
                    }
                    else if(model.Type==AdminType.Stores)
                    {
                        relastion_ddl.SelectedValue = "store";
                        moreinfo.Visible = true;
                        morestorefinfo.Visible = true;
                        this.LoadDealer();
                        if (!string.IsNullOrWhiteSpace(model.Store.StoreName))
                        {
                            name_txt.Text = model.Store.StoreName;
                        }
                        if (!string.IsNullOrWhiteSpace(model.Store.Contacts))
                        {
                            contact_txt.Text = model.Store.Contacts;
                        }
                        if (!string.IsNullOrWhiteSpace(model.Store.Position))
                        {
                            position_txt.Text = model.Store.Position;
                        }
                        if (!string.IsNullOrWhiteSpace(model.Store.Phone))
                        {
                            phone_txt.Text = model.Store.Phone;
                        }
                        if (!string.IsNullOrWhiteSpace(model.Store.Mobile))
                        {
                            mobile_txt.Text = model.Store.Mobile;
                        }
                        if (!string.IsNullOrWhiteSpace(model.Store.Fax))
                        {
                            fax_txt.Text = model.Store.Fax;
                        }
                        if (model.Store.ProvinceId != 0)
                        {
                            province_ddl.SelectedValue = model.Store.ProvinceId.ToString();
                            this.LoadCity(model.Store.ProvinceId);
                        }
                        if (model.Store.CityId != 0)
                        {
                            city_ddl.SelectedValue = model.Store.CityId.ToString();
                        }
                        if (!string.IsNullOrWhiteSpace(model.Store.Address))
                        {
                            address_txt.Text = model.Store.Address;
                        }
                        if (!string.IsNullOrWhiteSpace(model.Store.Zip))
                        {
                            zip_txt.Text = model.Store.Zip;
                        }
                        if (!string.IsNullOrWhiteSpace(model.Store.Email))
                        {
                            email_txt.Text = model.Store.Email;
                        }
                        if (model.Store.DealerId != 0)
                        {
                            dealer_ddl.SelectedValue = model.Store.DealerId.ToString();
                        }
                    }
                    relastion_ddl.Enabled = false;
                }
            }
        }
    }


    private void LoadProvince()
    {
        province_ddl.Items.Add(new ListItem("", ""));
        List<ProvinceModel> list = Common.LoadProvince();
        if (list.Count > 0)
        {
            foreach (ProvinceModel model in list)
            {
                ListItem item = new ListItem();
                item.Text = model.ProvinceName;
                item.Value = model.ProvinceId.ToString();
                province_ddl.Items.Add(item);
            }
        }
    }
    private void LoadCity(int id)
    {
        city_ddl.Items.Add(new ListItem("", ""));
        List<CityModel> list = Common.LoadCityByProvinceID(id);
        if (list.Count > 0)
        {
            foreach (CityModel model in list)
            {
                ListItem item = new ListItem();
                item.Text = model.CityName;
                item.Value = model.CityId.ToString();
                city_ddl.Items.Add(item);
            }
        }
    }
    private void LoadDealer()
    {
        int total = 0;
        List<DealerModel> list = Common.GetDealerList(out total);
        dealer_ddl.Items.Add(new ListItem("", ""));
        if (list.Count > 0)
        {
            foreach (DealerModel model in list)
            {
                ListItem item = new ListItem();
                item.Text = model.DealerCompanyName;
                item.Value = model.AdminId.ToString();
                dealer_ddl.Items.Add(item);
            }
        }
    }

    private void LoadRole()
    {
        role_ddl.Items.Add(new ListItem("", ""));
        List<RoleModel> list = Common.GetRoleList();
        if (list.Count > 0)
        {
            foreach (RoleModel model in list)
            {
                ListItem item = new ListItem();
                item.Value = model.RoleId.ToString();
                item.Text = model.RoleName;
                role_ddl.Items.Add(item);
            }
        }
    }
    protected void status_btn_Click(object sender, EventArgs e)
    {
        AdminBLL ab = new AdminBLL();
        ab.RemoveAdmin(Convert.ToInt32(Request.QueryString["id"]), 1);
        status_btn.Visible = false;
        status_txt.Text = "正常登陆";

        status_txt.ForeColor = System.Drawing.Color.FromName("#393939");
    }
}