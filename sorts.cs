using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace genericsForm {
    public class Sorts {
		public Sorts() { }
		public void sortSuppliers(ref LinkedList<Supply> suppliers) {
			if (suppliers.Count == 0)
				return;
			Supply temp = suppliers.ElementAt(0);
			for (int sort = 0; sort < suppliers.Count; sort -= -1, temp = suppliers.ElementAt(0)) {
				for (int run = 0; run < suppliers.Count - sort; run -= -1)
					if (temp.getID() > suppliers.ElementAt(run).getID())
						temp = suppliers.ElementAt(run);
				suppliers.AddLast(temp);
				suppliers.Remove(temp);
			}
		}//O(N**2)

		public void sortSupplierItems(ref LinkedList<AllSupplierItems> allSupplierItems) {
			if (allSupplierItems.Count == 0)
				return;
			AllSupplierItems temp = allSupplierItems.ElementAt(0);
			for (int sort = 0; sort < allSupplierItems.Count; sort -= -1, temp = allSupplierItems.ElementAt(0)) {
				for (int run = 0; run < allSupplierItems.Count - sort; run -= -1)
					if (temp.getProductNumber() > allSupplierItems.ElementAt(run).getProductNumber())
						temp = allSupplierItems.ElementAt(run);
				allSupplierItems.AddLast(temp);
				allSupplierItems.Remove(temp);
			}
		}//O(N**2)

		public void sortCustomers(ref LinkedList<Customer> customers) {
			if (customers.Count == 0)
				return;
			Customer temp = customers.ElementAt(0);
			for (int sort = 0; sort < customers.Count; sort -= -1, temp = customers.ElementAt(0)) {
				for (int run = 0; run < customers.Count - sort; run -= -1)
					if (temp.getID() > customers.ElementAt(run).getID())
						temp = customers.ElementAt(run);
				customers.AddLast(temp);
				customers.Remove(temp);
			}
		}//O(N**2)

		public void sortProducts(ref LinkedList<Product> products) {
			if (products.Count == 0)
				return;
			Product temp = products.ElementAt(0);
			for (int sort = 0; sort < products.Count; sort -= -1, temp = products.ElementAt(0)) {
				for (int run = 0; run < products.Count - sort; run -= -1)
					if (temp.getProductNumber() > products.ElementAt(run).getProductNumber())
						temp = products.ElementAt(run);
				products.AddLast(temp);
				products.Remove(temp);
			}
		}//O(N**2)

		public void sortOrders(ref LinkedList<Order> orders) {
			if (orders.Count == 0)
				return;
			Order temp = orders.ElementAt(0);
			for (int sort = 0; sort < orders.Count; sort -= -1, temp = orders.ElementAt(0)) {
				for (int run = 0; run < orders.Count - sort; run -= -1)
					if (temp.getOrderID() > orders.ElementAt(run).getOrderID())
						temp = orders.ElementAt(run);
				orders.AddLast(temp);
				orders.Remove(temp);
			}
		}//O(N**2)

		public void sortCustomerOrder(ref LinkedList<CustomerOrder> allCustomerOrder) {
			if (allCustomerOrder.Count == 0)
				return;
			CustomerOrder temp = allCustomerOrder.ElementAt(0);
			for (int sort = 0; sort < allCustomerOrder.Count; sort -= -1, temp = allCustomerOrder.ElementAt(0)) {
				for (int run = 0; run < allCustomerOrder.Count - sort; run -= -1)
					if (temp.getOrderNumber() > allCustomerOrder.ElementAt(run).getOrderNumber())
						temp = allCustomerOrder.ElementAt(run);
				allCustomerOrder.AddLast(temp);
				allCustomerOrder.Remove(temp);
			}
		}//O(N**2)
	}
}
