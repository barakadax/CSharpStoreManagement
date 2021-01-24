using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace genericsForm {
    public class Product {
        private Int32 ProductNumber;
        private string ProductName;
        private string SupplierName;
        private Int32 SupplierID;
        private string Mail;

        //constructor:
        public Product(Int32 productNumber, string productName, string supplierName, Int32 supplierID, string mail) {
            this.setProductNumber(productNumber);
            this.setProductName(productName);
            this.setSupplierName(supplierName);
            this.setSupplierID(supplierID);
            this.setMail(mail);
        }

        public Product(Product temp) {
            this.setProductNumber(temp.getProductNumber());
            this.setProductName(temp.getProductName());
            this.setSupplierName(temp.getSupplierName());
            this.setSupplierID(temp.getSupplierID());
            this.setMail(temp.getMail());
        }

        //getters:
        public Int32 getProductNumber() {
            return this.ProductNumber;
        }

        public string getProductName() {
            return this.ProductName;
        }

        public string getSupplierName() {
            return this.SupplierName;
        }

        public Int32 getSupplierID() {
            return this.SupplierID;
        }

        public string getMail() {
            return this.Mail;
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

        public Boolean setSupplierName(string name) {
            try {
                this.SupplierName = name;
            }
            catch (Exception) {
                this.SupplierName = null;
                return true;
            }
            return false;
        }

        public Boolean setSupplierID(Int32 number) {
            try {
                this.SupplierID = number;
            }
            catch (Exception) {
                this.SupplierID = 0;
                return true;
            }
            return false;
        }

        public Boolean setMail(string mail) {
            try {
                this.Mail = mail;
            }
            catch (Exception) {
                this.Mail = null;
                return true;
            }
            return false;
        }

        //others:
        public override string ToString() {
            return "Product number: " + this.ProductNumber + " Product name: " + this.ProductName + " Supplier ID: " + this.SupplierID + " Supplier name: " + this.SupplierName + " Mail: " + this.Mail;
        }

        public string[] arrayString() {
            return new string[] { this.ProductNumber.ToString(), this.ProductName, this.SupplierID.ToString(), this.SupplierName, this.Mail };
        }
    }
}
