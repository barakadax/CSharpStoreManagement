using Npgsql;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace genericsForm {
    public class DBhandler {
        private Npgsql.NpgsqlConnection con;
        private Sorts sort;

        //constructors:
        public DBhandler() {
            this.con = new NpgsqlConnection("secret");
            this.con.Open();
            this.sort = new Sorts();
        }//O(1)

        public DBhandler(string host, string username, string password, string DB) {    //connection to other postgresql
            this.con = new NpgsqlConnection(String.Format("Server={0};Username={1};Database={2};Password={3};SSLMode=Prefer", host, username, DB, password));
            this.con.Open();
            this.sort = new Sorts();
        }//O(1)

        //Supplier functions:
        public void addSupplier(int id, string first, string last, string mail) {  //add & update supplier
            using (Npgsql.NpgsqlCommand execute = new NpgsqlCommand("INSERT INTO \"Suppliers\"(\"ID\", \"First name\", \"Last name\", \"Mail\") VALUES (@ID, @First, @Last, @Mail) ON CONFLICT(\"ID\") DO UPDATE SET \"First name\" = @First, \"Last name\" = @Last, \"Mail\" = @Mail", this.con)) {
                execute.Parameters.AddWithValue("ID", id);
                execute.Parameters.AddWithValue("First", first);
                execute.Parameters.AddWithValue("Last", last);
                execute.Parameters.AddWithValue("Mail", mail);
                execute.ExecuteNonQuery();
            }
        }//O(1)

        public void checkSuppliers(ref LinkedList<Supply> suppliers) {                //get all suppliers
            while (suppliers.Count != 0)
                suppliers.RemoveFirst();
            using (Npgsql.NpgsqlCommand execute = new NpgsqlCommand("SELECT * FROM \"Suppliers\"", this.con))
                using (Npgsql.NpgsqlDataReader reader = execute.ExecuteReader())
                    while (reader.Read())
                        suppliers.AddLast(new Supply(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
            this.sort.sortSuppliers(ref suppliers);
        }//O(N)

        public void deleteSupplier(int id) {                //delete supplier if not found will do nothing
            using (Npgsql.NpgsqlCommand execute = new NpgsqlCommand("DELETE FROM \"Suppliers\" WHERE \"ID\" = @ID", this.con)) {
                execute.Parameters.AddWithValue("ID", id);
                execute.ExecuteNonQuery();
            }   
        }//O(1)

        public void allSupplierItems(ref LinkedList<AllSupplierItems> allSupplierItems, int id) { //shows all products from that seller
            while (allSupplierItems.Count != 0)
                allSupplierItems.RemoveFirst();
            using (Npgsql.NpgsqlCommand execute = new NpgsqlCommand("SELECT * FROM \"Products\" WHERE \"Supplier\" = @ID", this.con)) {
                execute.Parameters.AddWithValue("ID", id);
                using (Npgsql.NpgsqlDataReader reader = execute.ExecuteReader())
                    while (reader.Read())
                        allSupplierItems.AddLast(new AllSupplierItems(reader.GetInt32(0), reader.GetString(1)));
            }
            this.sort.sortSupplierItems(ref allSupplierItems);
        }//O(N)

        public bool supplierExists(int id) {                            //checks if supplier exists and return true if doesn't exists
            using (Npgsql.NpgsqlCommand execute = new NpgsqlCommand("SELECT COUNT(*) FROM \"Suppliers\" WHERE \"ID\" = @ID", this.con)) {
                execute.Parameters.AddWithValue("ID", id);
                using (Npgsql.NpgsqlDataReader reader = execute.ExecuteReader())
                    while (reader.Read())
                        id = reader.GetInt32(0);
            }
            return id == 0;
        }//O(1)

        public bool isSupplierGotItems(int id) {                        //check is supplier got items, return true if does
            using (Npgsql.NpgsqlCommand execute = new NpgsqlCommand("SELECT COUNT(*) FROM \"Products\" WHERE \"Supplier\" = @ID", this.con)) {
                execute.Parameters.AddWithValue("ID", id);
                using (Npgsql.NpgsqlDataReader reader = execute.ExecuteReader())
                    while (reader.Read())
                        id = reader.GetInt32(0);
            }
            return id != 0;
        }//O(1)

        //customer functions:
        public void addCustomer(int id, string first, string last, string phone, string city) { //adds - update customer
            using (Npgsql.NpgsqlCommand execute = new NpgsqlCommand("INSERT INTO \"Customers\"(\"ID\", \"First name\", \"Last name\", \"Phone\", \"City\") VALUES (@ID, @First, @Last, @Phone, @City) ON CONFLICT(\"ID\") DO UPDATE SET \"First name\" = @First, \"Last name\" = @Last, \"Phone\" = @Phone, \"City\" = @City", this.con)) {
                execute.Parameters.AddWithValue("ID", id);
                execute.Parameters.AddWithValue("First", first);
                execute.Parameters.AddWithValue("Last", last);
                execute.Parameters.AddWithValue("Phone", phone);
                execute.Parameters.AddWithValue("City", city);
                execute.ExecuteNonQuery();
            } 
        }//O(1)

        public void checkCustomers(ref LinkedList<Customer> customers) {
            while (customers.Count != 0)
                customers.RemoveFirst();
            using (Npgsql.NpgsqlCommand execute = new NpgsqlCommand("SELECT * FROM \"Customers\"", this.con))
                using (Npgsql.NpgsqlDataReader reader = execute.ExecuteReader())
                    while (reader.Read())
                        customers.AddLast(new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
            this.sort.sortCustomers(ref customers);
        }//O(N)

        public void deleteCustomer(int id) {
            using (Npgsql.NpgsqlCommand execute = new NpgsqlCommand("DELETE FROM \"Customers\" WHERE \"ID\" = @ID", this.con)) {
                execute.Parameters.AddWithValue("ID", id);
                execute.ExecuteNonQuery();
            }
        }//O(1)

        public bool isCustomerOrdered(int id) {                 //checks if customer has an open order, if does reuturn true
            using (Npgsql.NpgsqlCommand execute = new NpgsqlCommand("SELECT COUNT(*) FROM \"Orderd\" WHERE \"Customer ID\" = @ID", this.con)) {
                execute.Parameters.AddWithValue("ID", id);
                using (Npgsql.NpgsqlDataReader reader = execute.ExecuteReader())
                    while (reader.Read())
                        id = reader.GetInt32(0);
            }
            return id != 0;
        }//O(1)

        public bool isCustomerExists(int id) {      //check if customer exists, returns true if doesn't exists
            using (Npgsql.NpgsqlCommand execute = new NpgsqlCommand("SELECT COUNT(*) FROM \"Customers\" WHERE \"ID\" = @ID", this.con)) {
                execute.Parameters.AddWithValue("ID", id);
                using (Npgsql.NpgsqlDataReader reader = execute.ExecuteReader())
                    while (reader.Read())
                        id = reader.GetInt32(0);
            }
            return id == 0;
        }//O(1)

        //products:
        public void addProduct(int id, string name, int supplier) {
            using (Npgsql.NpgsqlCommand execute = new NpgsqlCommand("INSERT INTO \"Products\"(\"Product number\", \"Name\", \"Supplier\") VALUES (@ID, @Name, @Supplier) ON CONFLICT(\"Product number\") DO UPDATE SET \"Name\" = @Name, \"Supplier\" = @Supplier", this.con)) {
                execute.Parameters.AddWithValue("ID", id);
                execute.Parameters.AddWithValue("Name", name);
                execute.Parameters.AddWithValue("Supplier", supplier);
                execute.ExecuteNonQuery();
            }
        }//O(1)

        public void checkProducts(ref LinkedList<Product> products) {
            while (products.Count != 0)
                products.RemoveFirst();
            using (Npgsql.NpgsqlCommand execute = new NpgsqlCommand("SELECT \"Product number\", \"Name\", \"First name\" || ' ' || \"Last name\" as \"supplier\", \"ID\", \"Mail\" FROM \"Products\" JOIN \"Suppliers\" ON \"Products\".\"Supplier\" = \"Suppliers\".\"ID\"", this.con))
                using (Npgsql.NpgsqlDataReader reader = execute.ExecuteReader())
                    while (reader.Read())
                        products.AddLast(new Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4)));
            this.sort.sortProducts(ref products);
        }//O(N)

        public void deleteProduct(int id) {
            using (Npgsql.NpgsqlCommand execute = new NpgsqlCommand("DELETE FROM \"Products\" WHERE \"Product number\" = @ID", this.con)) {
                execute.Parameters.AddWithValue("ID", id);
                execute.ExecuteNonQuery();
            }
        }//O(1)

        public bool isProductOrderd(int id) {       //check if product is oredred, if oredred returns true
            using (Npgsql.NpgsqlCommand execute = new NpgsqlCommand("SELECT COUNT(*) FROM \"Orderd\" WHERE \"Product Number\" = @ID", this.con)) {
                execute.Parameters.AddWithValue("ID", id);
                using (Npgsql.NpgsqlDataReader reader = execute.ExecuteReader())
                    while (reader.Read())
                        id = reader.GetInt32(0);
            }
            return id != 0;
        }//O(1)

        public bool isProductExists(int id) {   //check if product exists, if doesn't returns true
            using (Npgsql.NpgsqlCommand execute = new NpgsqlCommand("SELECT COUNT(*) FROM \"Products\" WHERE \"Product number\" = @ID", this.con)) {
                execute.Parameters.AddWithValue("ID", id);
                using (Npgsql.NpgsqlDataReader reader = execute.ExecuteReader())
                    while (reader.Read())
                        id = reader.GetInt32(0);
            }
            return id == 0;
        }//O(1)

        //orders:
        public void addOrder(int product, int customer, int amount) {
            int count = 0;                  //auto order pk
            using (Npgsql.NpgsqlCommand execute = new NpgsqlCommand("SELECT COUNT(*) FROM \"Orderd\"", this.con))
                using (Npgsql.NpgsqlDataReader reader = execute.ExecuteReader())
                    while (reader.Read())   //count query result always 1 row, so it's one iteration
                        count = reader.GetInt32(0) + 1;
            using (Npgsql.NpgsqlCommand execute = new NpgsqlCommand("INSERT INTO \"Orderd\"(\"Order ID\", \"Product Number\", \"Customer ID\", \"Quantity\") VALUES (@PK, @ProID, @CusID, @quantity)", this.con)) {
                execute.Parameters.AddWithValue("PK", count);
                execute.Parameters.AddWithValue("ProID", product);
                execute.Parameters.AddWithValue("CusID", customer);
                execute.Parameters.AddWithValue("quantity", amount);
                execute.ExecuteNonQuery();
            }
        }//O(1)

        public void checkOrders(ref LinkedList<Order> orders) {
            while (orders.Count != 0)
                orders.RemoveFirst();
            using (Npgsql.NpgsqlCommand execute = new NpgsqlCommand("SELECT DISTINCT \"Order ID\", \"Product Number\", \"Products\".\"Name\", \"Customer ID\", \"First name\" || ' ' || \"Last name\" as \"Customer name\" , \"Quantity\" FROM \"Orderd\" JOIN \"Products\" ON \"Orderd\".\"Product Number\" = \"Products\".\"Product number\" JOIN \"Customers\" ON \"Orderd\".\"Customer ID\" = \"Customers\".\"ID\"", this.con))
                using (Npgsql.NpgsqlDataReader reader = execute.ExecuteReader())
                    while (reader.Read())
                        orders.AddLast(new Order(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetInt32(5)));
            this.sort.sortOrders(ref orders);
        }//O(N)

        public void deleteOrder(int id) {
            using (Npgsql.NpgsqlCommand execute = new NpgsqlCommand("DELETE FROM \"Orderd\" WHERE \"Order ID\" = @ID", this.con)) {
                execute.Parameters.AddWithValue("ID", id);
                execute.ExecuteNonQuery();
            }
        }//O(1)

        public void updateOrder(int id, int amount) {
            using (Npgsql.NpgsqlCommand execute = new NpgsqlCommand("UPDATE \"Orderd\" SET \"Quantity\" = @quantity WHERE \"Order ID\" = @ID", this.con)) {
                execute.Parameters.AddWithValue("ID", id);
                execute.Parameters.AddWithValue("quantity", amount);
                execute.ExecuteNonQuery();
            }
        }//O(1)

        public void customerOrder(ref LinkedList<CustomerOrder> allCustomerOrder, int id) { //get all customer orders
            while (allCustomerOrder.Count != 0)
                allCustomerOrder.RemoveFirst();
            using (Npgsql.NpgsqlCommand execute = new NpgsqlCommand("SELECT \"Order ID\", \"Product Number\", \"Name\", \"Quantity\" FROM \"Orderd\" JOIN \"Products\" ON \"Orderd\".\"Product Number\" = \"Products\".\"Product number\" WHERE \"Customer ID\" = @ID", this.con)) {
                execute.Parameters.AddWithValue("ID", id);
                using (Npgsql.NpgsqlDataReader reader = execute.ExecuteReader())
                    while (reader.Read())
                        allCustomerOrder.AddLast(new CustomerOrder(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3)));
            }
            this.sort.sortCustomerOrder(ref allCustomerOrder);
        }//O(N)
    }
}
