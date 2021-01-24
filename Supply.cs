using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace genericsForm {
    public class Supply {
        private Int32 ID;
        private string FirstName;
        private string LastName;
        private string Mail;

        //constructor:
        public Supply(Int32 id, string fName, string lName, string mail) {
            this.setID(id);
            this.setFName(fName);
            this.setLName(lName);
            this.setMail(mail);
        }//O(1)

        public Supply(Supply temp) {
            this.setID(temp.getID());
            this.setFName(temp.getFName());
            this.setLName(temp.getLName());
            this.setMail(temp.getMail());
        }//O(1)

        //getters:
        public Int32 getID() {
            return this.ID;
        }//O(1)

        public string getFName() {
            return this.FirstName;
        }//O(1)

        public string getLName() {
            return this.LastName;
        }//O(1)

        public string getMail() {
            return this.Mail;
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

        public Boolean setFName(string name) {
            try {
                this.FirstName = name;
            }
            catch (Exception) {
                this.FirstName = null;
                return true;
            }
            return false;
        }//O(1)

        public Boolean setLName(string name) {
            try {
                this.LastName = name;
            }
            catch (Exception) {
                this.LastName = null;
                return true;
            }
            return false;
        }//O(1)

        public Boolean setMail(string mail) {
            try {
                this.Mail = mail;
            }
            catch (Exception) {
                this.Mail = null;
                return true;
            }
            return false;
        }//O(1)

        //others:
        public override string ToString() {
            return "ID: " + this.ID + " Name: " + this.FirstName + " " + this.LastName + " Mail: " + this.Mail;
        }//O(1)

        public string[] arrayString() {
            return new string[] { this.ID.ToString(), this.FirstName, this.LastName, this.Mail };
        }//O(1)
    }
}
