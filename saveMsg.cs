using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace genericsForm {
    public partial class saveMsg : Form {
        public saveMsg() {
            InitializeComponent();
            savelbl.Text = "Thanks for saving.\nYour orders will be in your\ndocuments folder.\nThe DB was cleaned for new future orders.";
        }//O(1)

        private void conBtn_Click(object sender, EventArgs e) {
            this.Close();
        }//O(1)
    }
}
