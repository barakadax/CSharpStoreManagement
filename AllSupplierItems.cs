using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace genericsForm {
    public class AllSupplierItems {
        private Int32 ProductNumber;
        private string ProductName;

        //constructor:
        public AllSupplierItems(Int32 number, string name) {
            this.setProductNumber(number);
            this.setProductName(name);
        }

        public AllSupplierItems(AllSupplierItems temp) {
            this.setProductNumber(temp.getProductNumber());
            this.setProductName(temp.getProductName());
        }

        //getters:
        public Int32 getProductNumber() {
            return this.ProductNumber;
        }

        public string getProductName() {
            return this.ProductName;
        }

        //setters:
        public Boolean setProductNumber(Int32 number) {
            try {
                this.ProductNumber = number;
            }
            catch (Exception) {
                this.ProductNumber = 0;
                return true;
            }
            return false;
        }

        public Boolean setProductName(string name) {
            try {
                this.ProductName = name;
            }
            catch (Exception) {
                this.ProductName = null;
                return true;
            }
            return false;
        }

        //others:
        public override string ToString() {
            return "Product number: " + this.ProductNumber + " Product name: " + this.ProductName;
        }

        public string[] arrayString() {
            return new string[] { this.ProductNumber.ToString(), this.ProductName };
        }
    }
}
