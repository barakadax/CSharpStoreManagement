using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace genericsForm {
    public class Customer {
        private Int32 ID;
        private string FirstName;
        private string LastName;
        private string Phone;
        private string City;

        //constructor:
        public Customer(Int32 id, string firstName, string lastName, string phone, string city) {
            this.setID(id);
            this.setFirstName(firstName);
            this.setLastName(lastName);
            this.setPhone(phone);
            this.setCity(city);
        }//O(1)

        public Customer(Customer temp) {
            this.setID(temp.getID());
            this.setFirstName(temp.getFirstName());
            this.setLastName(temp.getLastName());
            this.setPhone(temp.getPhone());
            this.setCity(temp.getCity());
        }//O(1)

        //getters:
        public Int32 getID() {
            return this.ID;
        }//O(1)

        public string getFirstName() {
            return this.FirstName;
        }//O(1)

        public string getLastName() {
            return this.LastName;
        }//O(1)

        public string getPhone() {
            return this.Phone;
        }//O(1)

        public string getCity() {
            return this.City;
        }//O(1)

        //setters:
        public Boolean setID(Int32 id) {
            try {
                this.ID = id;
            }
            catch (Exception) {
                this.ID = 0;
                return true;
            }
            return false;
        }//O(1)

        public Boolean setFirstName(string name) {
            try {
                this.FirstName = name;
            }
            catch (Exception) {
                this.FirstName = null;
                return true;
            }
            return false;
        }//O(1)

        public Boolean setLastName(string name) {
            try {
                this.LastName = name;
            }
            catch (Exception) {
                this.LastName = null;
                return true;
            }
            return false;
        }//O(1)

        public Boolean setPhone(string phone) {
            try {
                this.Phone = phone;
            }
            catch (Exception) {
                this.Phone = null;
                return true;
            }
            return false;
        }//O(1)

        public Boolean setCity(string city) {
            try {
                this.City = city;
            }
            catch (Exception) {
                this.City = null;
                return true;
            }
            return false;
        }//O(1)

        //others:
        public override string ToString() {
            return "ID: " + this.ID + " Name: " + this.FirstName + " " + this.LastName + " Phone: " + this.Phone + " City: " + this.City;
        }//O(1)

        public string[] arrayString() {
            return new string[] { this.ID.ToString(), this.FirstName, this.LastName, this.Phone.ToString(), this.City };
        }//O(1)
    }
}
