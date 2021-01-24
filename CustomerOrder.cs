using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace genericsForm {
    public class CustomerOrder {
        private Int32 OrderNumber;
        private Int32 ProductNumber;
        private string ProductName;
        private Int32 Amount;

        //constructor:
        public CustomerOrder(Int32 OrderNum, Int32 ProductNum, string ProductName, Int32 amount) {
            this.setOrderNumber(OrderNum);
            this.setProductNumber(ProductNum);
            this.setProductName(ProductName);
            this.setAmount(amount);
        }//O(1)

        public CustomerOrder(CustomerOrder temp) {
            this.setOrderNumber(temp.getOrderNumber());
            this.setProductNumber(temp.getProductNumber());
            this.setProductName(temp.getProductName());
            this.setAmount(temp.getAmount());
        }//O(1)

        //getters:
        public Int32 getOrderNumber() {
            return this.OrderNumber;
        }//O(1)

        public Int32 getProductNumber() {
            return this.ProductNumber;
        }//O(1)

        public string getProductName() {
            return this.ProductName;
        }//O(1)

        public Int32 getAmount() {
            return this.Amount;
        }//O(1)

        //setters:
        public Boolean setOrderNumber(Int32 number) {
            try {
                this.OrderNumber = number;
            }
            catch (Exception) {
                this.OrderNumber = 0;
                return true;
            }
            return true;
        }//O(1)

        public Boolean setProductNumber(Int32 number) {
            try {
                this.ProductNumber = number;
            } 
            catch (Exception) {
                this.ProductNumber = 0;
                return true;
            }
            return true;
        }//O(1)

        public Boolean setProductName(string name) {
            try {
                this.ProductName = name;
            } catch (Exception) {
                this.ProductName = null;
                return true;
            }
            return true;
        }//O(1)
        public Boolean setAmount(Int32 number) {
            try {
                this.Amount = number;
            } catch (Exception) {
                this.Amount = 0;
                return true;
            }
            return true;
        }//O(1)

        //others:
        public override string ToString() {
            return "Order number: " + this.OrderNumber + " Product number: " + this.ProductNumber + " Product name: " + this.ProductName + " Amount: " + this.Amount;
        }//O(1)

        public string[] arrayString() {
            return new string[] { this.OrderNumber.ToString(), this.ProductNumber.ToString(), this.ProductName, this.Amount.ToString() };
        }//O(1)
    }
}
