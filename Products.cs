using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace genericsForm {
    public partial class Products : Form {

        public Products() {
            InitializeComponent();
			supStatusMsglbl.Text = "";
			cusStatusMsglbl.Text = "";
			proStatusMsglbl.Text = "";
			orderStatusMsglbl.Text = "";
			listViewOrders.FullRowSelect = true;
			listViewProducts.FullRowSelect = true;
			listViewCusOrder.FullRowSelect = true;
			listViewCustomers.FullRowSelect = true;
			listViewSuppliers.FullRowSelect = true;
			listViewSupplierItems.FullRowSelect = true;
			fillOrders();
			fillSuppliers();
			fillCustomers();
			fillListProducts();
		}//O(1)

		//Products related:
		private void fillListProducts() {	//cleans & fills from DB the list view
			listViewProducts.Items.Clear();
			DBhandler DBUse = new DBhandler();
			LinkedList<Product> products = new LinkedList<Product>();
			DBUse.checkProducts(ref products);
			for (int run = 0; run < products.Count; run -= -1)
				listViewProducts.Items.Add(new ListViewItem(products.ElementAt(run).arrayString()));
			DBUse = null;
			products = null;
		}//O(N)

		private void productClearTxt() {	//cleans all text boxes
			proNumtxt.Text = "";
			proNametxt.Text = "";
			proSupIDtxt.Text = "";
			proSupMailtxt.Text = "";
			proSupNametxt.Text = "";
		}//O(1)

		private void listViewProducts_MouseClick(object sender, MouseEventArgs e) {		//takes the first row select and fill
			proNumtxt.Text = listViewProducts.SelectedItems[0].SubItems[0].Text;		//text boxes by those values
			proNametxt.Text = listViewProducts.SelectedItems[0].SubItems[1].Text;
			proSupIDtxt.Text = listViewProducts.SelectedItems[0].SubItems[2].Text;
			proSupNametxt.Text = listViewProducts.SelectedItems[0].SubItems[3].Text;
			proSupMailtxt.Text = listViewProducts.SelectedItems[0].SubItems[4].Text;
		}//O(1)

		private void proClear_Click(object sender, EventArgs e) {						//clears only the textboxes and status
			productClearTxt();
			proStatusMsglbl.Text = "";
		}//O(1)

		private void proBtnAdd_Click(object sender, EventArgs e) {						//add/update a product, changed after submition
			proStatusMsglbl.Text = string.Empty;
			DBhandler DBUse = new DBhandler();
			int product = 0, supplier = 0;												//making sure all values are correct
			proStatusMsglbl.Text += proNumtxt.Text.Trim().Length == 0 ? "Missing Product Number.\n" :  "";
			proStatusMsglbl.Text += proNametxt.Text.Trim().Length == 0 ? "Missing Product Name.\n" : "";
			proStatusMsglbl.Text += proSupIDtxt.Text.Trim().Length == 0 ? "Missing Supplier ID.\n" : "";
			proStatusMsglbl.Text += !int.TryParse(proNumtxt.Text, out product) && proNumtxt.Text.Trim().Length != 0 ? "Not a number for Product number.\n" : "";
			proStatusMsglbl.Text += !int.TryParse(proSupIDtxt.Text, out supplier) && proSupIDtxt.Text.Trim().Length != 0 ? "Not a number for Supplier ID.\n" : "";
			proStatusMsglbl.Text += DBUse.supplierExists(supplier) && supplier != 0 ? "Supplier doesn't exits\n" : "";
			proStatusMsglbl.Text += product != 0 && DBUse.isProductOrderd(product) ? "Product is ordered.\nNeed to delivere or cancel order first." : ""; //change added after submition date
			if (proStatusMsglbl.Text.Length == 0) {
				DBUse.addProduct(product, proNametxt.Text.Trim(), supplier);
				fillListProducts();											//Clears and refill the listview after added/updated
			}
			productClearTxt();
			DBUse = null;
		}//O(1)

		private void proBtnRef_Click(object sender, EventArgs e) {			//just like clear but also resets the listview
			productClearTxt();
			fillListProducts();
			proStatusMsglbl.Text = "";
		}//O(1)

		private void proBtnDel_Click(object sender, EventArgs e) {			//deleted a products, if product doesn't exsits does
			proStatusMsglbl.Text = "";
			DBhandler DBUse = new DBhandler();
			int product = 0;
			proStatusMsglbl.Text += proNumtxt.Text.Trim().Length == 0 ? "Missing Product Number.\n" : "";
			proStatusMsglbl.Text += !int.TryParse(proNumtxt.Text, out product) && proNumtxt.Text.Trim().Length != 0 ? "Not a number for Product number.\n" : "";
			proStatusMsglbl.Text += product != 0 && DBUse.isProductOrderd(product) ? "Product is ordered.\nNeed to delivere or cancel order first." : "";
			if (proStatusMsglbl.Text.Length == 0) {
				DBUse.deleteProduct(product);
				fillListProducts();
			}
			productClearTxt();
			DBUse = null;
		}//O(1)

		//Orders related:
		private void fillOrders() {
			listViewOrders.Items.Clear();
			DBhandler DBUse = new DBhandler();
			LinkedList<Order> orders = new LinkedList<Order>();
			DBUse.checkOrders(ref orders);
			for (int run = 0; run < orders.Count; run -= -1)
				listViewOrders.Items.Add(new ListViewItem(orders.ElementAt(run).arrayString()));
			DBUse = null;
			orders = null;
		}//O(N)

		private void listViewOrders_MouseClick(object sender, MouseEventArgs e) {
			orderIDtxt.Text = listViewOrders.SelectedItems[0].SubItems[0].Text;
			orderProNumtxt.Text = listViewOrders.SelectedItems[0].SubItems[1].Text;
			orderProNametxt.Text = listViewOrders.SelectedItems[0].SubItems[2].Text;
			orderCusIDtxt.Text = listViewOrders.SelectedItems[0].SubItems[3].Text;
			orderCusNametxt.Text = listViewOrders.SelectedItems[0].SubItems[4].Text;
			orderAmounttxt.Text = listViewOrders.SelectedItems[0].SubItems[5].Text;
		}//O(1)

		private void ordersClearTxt() {
			orderIDtxt.Text = "";
			orderProNumtxt.Text = "";
			orderProNametxt.Text = "";
			orderCusIDtxt.Text = "";
			orderCusNametxt.Text = "";
			orderAmounttxt.Text = "";
		}//O(1)

		private void orderBtnClear_Click(object sender, EventArgs e) {
			ordersClearTxt();
			orderStatusMsglbl.Text = "";
		}//O(1)

		private void orderBtnRef_Click(object sender, EventArgs e) {
			ordersClearTxt();
			orderStatusMsglbl.Text = "";
			fillOrders();
		}//O(1)

		private void orderBtnAdd_Click(object sender, EventArgs e) {
			orderStatusMsglbl.Text = "";
			DBhandler DBUse = new DBhandler();
			int product = 0, customer = 0, amount = 0;
			orderStatusMsglbl.Text += orderProNumtxt.Text.Trim().Length == 0 ? "Missing Product Number.\n" : "";
			orderStatusMsglbl.Text += orderCusIDtxt.Text.Trim().Length == 0 ? "Missing Customer ID.\n" : "";
			orderStatusMsglbl.Text += orderAmounttxt.Text.Trim().Length == 0 ? "Missing Quantity.\n" : "";
			orderStatusMsglbl.Text += !int.TryParse(orderProNumtxt.Text, out product) && orderProNumtxt.Text.Trim().Length != 0 ? "Not a number for Product number.\n" : "";
			orderStatusMsglbl.Text += !int.TryParse(orderCusIDtxt.Text, out customer) && orderCusIDtxt.Text.Trim().Length != 0 ? "Not a number for Customer ID.\n" : "";
			orderStatusMsglbl.Text += !int.TryParse(orderAmounttxt.Text, out amount) && orderAmounttxt.Text.Trim().Length != 0 ? "Not a number for Quantity.\n" : "";
			orderStatusMsglbl.Text += customer != 0 && DBUse.isCustomerExists(customer) ? "Customer doesn't exsits.\n" : "";
			orderStatusMsglbl.Text += product != 0 && DBUse.isProductExists(product) ? "Product doesn't exsits.\n" : "";
			if (orderStatusMsglbl.Text.Length == 0) {
				DBUse.addOrder(product, customer, amount);
				fillOrders();
			}
			ordersClearTxt();
			DBUse = null;
		}//O(1)

		private void orderBtnUp_Click(object sender, EventArgs e) {
			orderStatusMsglbl.Text = "";
			DBhandler DBUse = new DBhandler();
			int order = 0, amount = 0;
			orderStatusMsglbl.Text += orderIDtxt.Text.Trim().Length == 0 ? "Missing Order Number.\n" : "";
			orderStatusMsglbl.Text += orderAmounttxt.Text.Trim().Length == 0 ? "Missing Quantity.\n" : "";
			orderStatusMsglbl.Text += !int.TryParse(orderIDtxt.Text, out order) && orderIDtxt.Text.Trim().Length != 0 ? "Not a number for Order ID.\n" : "";
			orderStatusMsglbl.Text += !int.TryParse(orderAmounttxt.Text, out amount) && orderAmounttxt.Text.Trim().Length != 0 ? "Not a number for Quantity.\n" : "";
			if (orderStatusMsglbl.Text.Length == 0) {
				DBUse.updateOrder(order, amount);		//if there is no order for the input number nothing happenes
				fillOrders();
			}
			ordersClearTxt();
			DBUse = null;
		}//O(1)

		private void orderBtnDel_Click(object sender, EventArgs e) {
			orderStatusMsglbl.Text = "";
			DBhandler DBUse = new DBhandler();
			int product = 0;
			orderStatusMsglbl.Text += orderIDtxt.Text.Trim().Length == 0 ? "Missing Order ID.\n" : "";
			orderStatusMsglbl.Text += !int.TryParse(orderIDtxt.Text, out product) && orderIDtxt.Text.Trim().Length != 0 ? "Not a number for Order ID.\n" : "";
			if (orderStatusMsglbl.Text.Length == 0) {
				DBUse.deleteOrder(product);
				fillOrders();
			}
			ordersClearTxt();
			DBUse = null;
		}//O(1)

		private void orderBtnSave_Click(object sender, EventArgs e) {	//saves in excel file and deleted all orders from DB
			DBhandler DBUse = new DBhandler();
			SaveOrders orders2save = new SaveOrders();
			LinkedList<Order> orders = new LinkedList<Order>();
			DBUse.checkOrders(ref orders);
			orders2save.Save(orders);
			deleteAllOrders(ref orders, DBUse);
			//add auto fill because this is a project
			DBUse = null;
			orders = null;
			orders2save = null;
		}//O(1)

		private void deleteAllOrders(ref LinkedList<Order> orders, DBhandler DBUse) {	//deletes all orders from DB
			while (orders.Count != 0) {
				DBUse.deleteOrder(orders.ElementAt(0).getOrderID());
				orders.RemoveFirst();
			}
		}//O(N)

		//Customer related:
		private void fillCustomers() {
			listViewCustomers.Items.Clear();
			DBhandler DBUse = new DBhandler();
			LinkedList<Customer> customers = new LinkedList<Customer>();
			DBUse.checkCustomers(ref customers);
			for (int run = 0; run < customers.Count; run -= -1)
				listViewCustomers.Items.Add(new ListViewItem(customers.ElementAt(run).arrayString()));
			DBUse = null;
			customers = null;
		}//O(N)

		private void listViewCustomers_MouseClick(object sender, MouseEventArgs e) {
			cusIDtxt.Text = listViewCustomers.SelectedItems[0].SubItems[0].Text;
			cusFNametxt.Text = listViewCustomers.SelectedItems[0].SubItems[1].Text;
			cusLNametxt.Text = listViewCustomers.SelectedItems[0].SubItems[2].Text;
			cusPhonetxt.Text = listViewCustomers.SelectedItems[0].SubItems[3].Text;
			cusCitytxt.Text = listViewCustomers.SelectedItems[0].SubItems[4].Text;
		}//O(1)

		private void fillCusOrder(int id) {
			listViewCusOrder.Items.Clear();
			DBhandler DBUse = new DBhandler();
			LinkedList<CustomerOrder> allCustomerOrder = new LinkedList<CustomerOrder>();
			DBUse.customerOrder(ref allCustomerOrder, id);
			for (int run = 0; run < allCustomerOrder.Count; run -= -1)
				listViewCusOrder.Items.Add(new ListViewItem(allCustomerOrder.ElementAt(run).arrayString()));
			DBUse = null;
			allCustomerOrder = null;
		}//O(N)

		private void listViewCusOrder_MouseClick(object sender, MouseEventArgs e) {
			cusOrderNumtxt.Text = listViewCusOrder.SelectedItems[0].SubItems[0].Text;
			cusProNumtxt.Text = listViewCusOrder.SelectedItems[0].SubItems[1].Text;
			cusProNametxt.Text = listViewCusOrder.SelectedItems[0].SubItems[2].Text;
			cusOrderAmounttxt.Text = listViewCusOrder.SelectedItems[0].SubItems[3].Text;
		}//O(1)

		private void customerClearTxt() {
			cusIDtxt.Text = "";
			cusCitytxt.Text = "";
			cusFNametxt.Text = "";
			cusLNametxt.Text = "";
			cusPhonetxt.Text = "";
			cusProNumtxt.Text = "";
			cusProNametxt.Text = "";
			cusOrderNumtxt.Text = "";
			cusOrderAmounttxt.Text = "";
		}

		private void cusBtnClear_Click(object sender, EventArgs e) {
			customerClearTxt();
			cusStatusMsglbl.Text = "";
		}

		private void cusBtnAdd_Click(object sender, EventArgs e) {
			cusStatusMsglbl.Text = "";
			DBhandler DBUse = new DBhandler();
			int id = 0;
			cusStatusMsglbl.Text += cusIDtxt.Text.Trim().Length == 0 ? "Missing Customer ID.\n" : "";
			cusStatusMsglbl.Text += cusFNametxt.Text.Trim().Length == 0 ? "Missing First name.\n" : "";
			cusStatusMsglbl.Text += cusLNametxt.Text.Trim().Length == 0 ? "Missing Last name.\n" : "";
			cusStatusMsglbl.Text += cusPhonetxt.Text.Trim().Length == 0 ? "Missing Phone number.\n" : "";
			cusStatusMsglbl.Text += cusCitytxt.Text.Trim().Length == 0 ? "Missing City name.\n" : "";
			cusStatusMsglbl.Text += !int.TryParse(cusIDtxt.Text, out id) && cusIDtxt.Text.Trim().Length != 0 ? "Not a number for ID.\n" : "";
			if (cusStatusMsglbl.Text.Length == 0) {
				DBUse.addCustomer(id, cusFNametxt.Text.Trim(), cusLNametxt.Text.Trim(), cusPhonetxt.Text.Trim(), cusCitytxt.Text.Trim());
				fillCustomers();
			}
			DBUse = null;
			customerClearTxt();
		}//O(1)

		private void cusBtnCheck_Click(object sender, EventArgs e) {
			cusStatusMsglbl.Text = "";
			int id = 0;
			cusStatusMsglbl.Text += cusIDtxt.Text.Trim().Length == 0 ? "Missing Customer ID.\n" : "";
			cusStatusMsglbl.Text += !int.TryParse(cusIDtxt.Text, out id) && cusIDtxt.Text.Trim().Length != 0 ? "Not a number for ID.\n" : "";
			if (cusStatusMsglbl.Text.Length == 0)
				fillCusOrder(id);
			customerClearTxt();
		}//O(1)

		private void cusBtnRef_Click(object sender, EventArgs e) {
			cusStatusMsglbl.Text = "";
			customerClearTxt();
			fillCustomers();
		}//O(1)

		private void cusBtnDel_Click(object sender, EventArgs e) {
			cusStatusMsglbl.Text = "";
			DBhandler DBUse = new DBhandler();
			int id = 0;
			cusStatusMsglbl.Text += cusIDtxt.Text.Trim().Length == 0 ? "Missing Customer ID.\n" : "";
			cusStatusMsglbl.Text += !int.TryParse(cusIDtxt.Text, out id) && cusIDtxt.Text.Trim().Length != 0 ? "Not a number for ID.\n" : "";
			cusStatusMsglbl.Text += id != 0 && DBUse.isCustomerOrdered(id) ? "Customer can't be deleted.\nCustomer got order/s.\n" : "";
			if (cusStatusMsglbl.Text.Length == 0) {
				DBUse.deleteCustomer(id);
				fillCustomers();
			}
			DBUse = null;
			customerClearTxt();
		}//O(1)

		//Suppliers related:
		private void fillSuppliers() {
			listViewSuppliers.Items.Clear();
			DBhandler DBUse = new DBhandler();
			LinkedList<Supply> suppliers = new LinkedList<Supply>();
			DBUse.checkSuppliers(ref suppliers);
			for (int run = 0; run < suppliers.Count; run -= -1)
				listViewSuppliers.Items.Add(new ListViewItem(suppliers.ElementAt(run).arrayString()));
			DBUse = null;
			suppliers = null;
		}//O(N)

		private void listViewSuppliers_MouseClick(object sender, MouseEventArgs e) {
			supIDtxt.Text = listViewSuppliers.SelectedItems[0].SubItems[0].Text;
			supFNametxt.Text = listViewSuppliers.SelectedItems[0].SubItems[1].Text;
			supLNametxt.Text = listViewSuppliers.SelectedItems[0].SubItems[2].Text;
			supMailtxt.Text = listViewSuppliers.SelectedItems[0].SubItems[3].Text;
		}//O(1)

		private void fillSupplierItems(int someone) {
			listViewSupplierItems.Items.Clear();
			DBhandler DBUse = new DBhandler();
			LinkedList<AllSupplierItems> allSupplierItems = new LinkedList<AllSupplierItems>();
			DBUse.allSupplierItems(ref allSupplierItems, someone);
			for (int run = 0; run < allSupplierItems.Count; run -= -1)
				listViewSupplierItems.Items.Add(new ListViewItem(allSupplierItems.ElementAt(run).arrayString()));
			DBUse = null;
			allSupplierItems = null;
		}//O(N)

		private void listViewSupplierItems_MouseClick(object sender, MouseEventArgs e) {
			supProNumtxt.Text = listViewSupplierItems.SelectedItems[0].SubItems[0].Text;
			supProNametxt.Text = listViewSupplierItems.SelectedItems[0].SubItems[1].Text;
		}//O(1)

		private void supplierClearTxt() {
			supIDtxt.Text = "";
			supFNametxt.Text = "";
			supLNametxt.Text = "";
			supMailtxt.Text = "";
			supProNumtxt.Text = "";
			supProNametxt.Text = "";
		}//O(1)

		private void supBtnClear_Click(object sender, EventArgs e) {
			supplierClearTxt();
			supStatusMsglbl.Text = "";
		}//O(1)

		private void supBtnRef_Click(object sender, EventArgs e) {
			supplierClearTxt();
			supStatusMsglbl.Text = "";
			fillSuppliers();
		}//O(1)

		private void supBtnAdd_Click(object sender, EventArgs e) {
			supStatusMsglbl.Text = "";
			DBhandler DBUse = new DBhandler();
			int id = 0;
			supStatusMsglbl.Text += supIDtxt.Text.Trim().Length == 0 ? "Missing Supplier ID.\n" : "";
			supStatusMsglbl.Text += supFNametxt.Text.Trim().Length == 0 ? "Missing First name.\n" : "";
			supStatusMsglbl.Text += supLNametxt.Text.Trim().Length == 0 ? "Missing Last name.\n" : "";
			supStatusMsglbl.Text += supMailtxt.Text.Trim().Length == 0 ? "Missing Mail.\n" : "";
			supStatusMsglbl.Text += !int.TryParse(supIDtxt.Text, out id) && supIDtxt.Text.Trim().Length != 0 ? "Not a number for ID.\n" : "";
			if (supStatusMsglbl.Text.Length == 0) {
				DBUse.addSupplier(id, supFNametxt.Text.Trim(), supLNametxt.Text.Trim(), supMailtxt.Text.Trim());
				fillSuppliers();
			}
			DBUse = null;
			supplierClearTxt();
		}//O(1)

		private void supBtnCheck_Click(object sender, EventArgs e) {
			supStatusMsglbl.Text = "";
			int id = 0;
			supStatusMsglbl.Text += supIDtxt.Text.Trim().Length == 0 ? "Missing Supplier ID.\n" : "";
			supStatusMsglbl.Text += !int.TryParse(supIDtxt.Text, out id) && supIDtxt.Text.Trim().Length != 0 ? "Not a number for ID.\n" : "";
			if (id != 0)
				fillSupplierItems(id);
			supplierClearTxt();
		}

		private void supBtnDel_Click(object sender, EventArgs e) {
			supStatusMsglbl.Text = "";
			DBhandler DBUse = new DBhandler();
			int id = 0;
			supStatusMsglbl.Text += supIDtxt.Text.Trim().Length == 0 ? "Missing Supplier ID.\n" : "";
			supStatusMsglbl.Text += !int.TryParse(supIDtxt.Text, out id) && supIDtxt.Text.Trim().Length != 0 ? "Not a number for ID.\n" : "";
			supStatusMsglbl.Text += id != 0 && DBUse.isSupplierGotItems(id) ? "Supplier got items can't.\nBe deleted.\n" : "";
			if (supStatusMsglbl.Text.Length == 0) {
				DBUse.deleteSupplier(id);
				fillSuppliers();
			}
			DBUse = null;
			supplierClearTxt();
		}//O(1)
	}
}
