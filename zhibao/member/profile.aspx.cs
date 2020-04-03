using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class member_profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadProvince();
            this.LoadRole();
            this.LoadData();
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
    private void LoadData()
    {
        AdminModel model = Common.GetLoginAdmin(HttpContext.Current);
        if (model!=null)
        {
            username_txt.Text = model.AdminName;
            role_ddl.SelectedValue = model.Role.RoleId.ToString();
            role_ddl.Enabled = false;
            if (model.Type == AdminType.Managers)
            {
                relastion_ddl.SelectedValue = "admin";
                moreinfo.Visible = false;
                morestorefinfo.Visible = false;
            }
            else if (model.Type == AdminType.Dealer)
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
                if (model.Dealer.ProvinceId != 0)
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
            else if (model.Type == AdminType.Stores)
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
                dealer_ddl.Enabled = false;
            }
            relastion_ddl.Enabled = false;
        }
    }
}