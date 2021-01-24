using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace genericsForm {
    public class Order {
        private Int32 OrderID;
        private Int32 ProductNumber;
        private string ProductName;
        private Int32 CustomerID;
        private string CustomerName;
        private Int32 Amount;

        //constructor:
        public Order(Int32 orderID, Int32 productNumber, string productName, Int32 customerID, string customerName, Int32 amount) {
            this.setOrderID(orderID);
            this.setProductNumber(productNumber);
            this.setProductName(productName);
            this.setCustomerID(customerID);
            this.setCustomerName(customerName);
            this.setAmount(amount);
        }//O(1)

        public Order(Order temp) {
            this.setOrderID(temp.getOrderID());
            this.setProductNumber(temp.getProductNumber());
            this.setProductName(temp.getProductName());
            this.setCustomerID(temp.getCustomerID());
            this.setCustomerName(temp.getCustomerName());
            this.setAmount(temp.getAmount());
        }//O(1)

        //getters:
        public Int32 getOrderID() {
            return this.OrderID;
        }//O(1)

        public Int32 getProductNumber() {
            return this.ProductNumber;
        }//O(1)

        public string getProductName() {
            return this.ProductName;
        }//O(1)

        public Int32 getCustomerID() {
            return this.CustomerID;
        }//O(1)

        public string getCustomerName() {
            return this.CustomerName;
        }//O(1)

        public Int32 getAmount() {
            return this.Amount;
        }//O(1)

        //setters:
        public Boolean setOrderID(Int32 number) {
            try {
                this.OrderID = number;
            }
            catch (Exception) {
                this.OrderID = 0;
                return true;
            }
            return false;
        }//O(1)

        public Boolean setProductNumber(Int32 number) {
            try {
                this.ProductNumber = number;
            }
            catch (Exception) {
                this.ProductNumber = 0;
                return true;
            }
            return false;
        }//O(1)

        public Boolean setProductName(string name) {
            try {
                this.ProductName = name;
            }
            catch (Exception) {
                this.ProductName = null;
                return true;
            }
            return false;
        }//O(1)

        public Boolean setCustomerID(Int32 number) {
            try {
                this.CustomerID = number;
            }
            catch (Exception) {
                this.CustomerID = 0;
                return true;
            }
            return false;
        }//O(1)

        public Boolean setCustomerName(string name) {
            try {
                this.CustomerName = name;
            }
            catch (Exception) {
                this.CustomerName = null;
                return true;
            }
            return false;
        }//O(1)

        public Boolean setAmount(Int32 amount) {
            try {
                this.Amount = amount;
            }
            catch (Exception) {
                this.Amount = 0;
                return true;
            }
            return false;
        }//O(1)

        //others:
        public override string ToString() {
            return "Order number: " + this.OrderID + " Product number: " + this.ProductNumber + " Product name: " + this.ProductName + " Customer ID: " + this.CustomerID + " Customer name: " + this.CustomerName + " amount: " + this.Amount;
        }//O(1)

        public string[] arrayString() {
            return new string[] { this.OrderID.ToString(), this.ProductNumber.ToString(), this.ProductName, this.CustomerID.ToString(), this.CustomerName, this.Amount.ToString() };
        }//O(1)
    }
}
