using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace genericsForm {
    public class SaveOrders {
        private Excel.Application excel;
        private Excel.Workbook workbook;
        private Excel.Worksheet worksheet;
        private enum numbers {Title = 1, orderID = 1, productNumber, productName, customerID, customerName, amount, lineFilled = 1, start};

        //constructor
        public  SaveOrders() {
            this.excel = new Excel.Application();
            this.workbook = excel.Workbooks.Add(Type.Missing);
            this.worksheet = this.workbook.Worksheets[1];
        }//O(1)

        public void Save(LinkedList<Order> orders) {    //creates and configures the file, add titles to columns
            this.excel.Visible = false;
            this.excel.DisplayAlerts = false;
            this.worksheet.Name = "Orders";
            this.worksheet.Cells[numbers.Title, numbers.orderID].Value2 = "Order ID";
            this.worksheet.Cells[numbers.Title, numbers.productNumber].Value2 = "Product Number";
            this.worksheet.Cells[numbers.Title, numbers.productName].Value2 = "Product Name";
            this.worksheet.Cells[numbers.Title, numbers.customerID].Value2 = "Customer ID";
            this.worksheet.Cells[numbers.Title, numbers.customerName].Value2 = "Customer Name";
            this.worksheet.Cells[numbers.Title, numbers.amount].Value2 = "Quantity";
            fill(orders);
            this.worksheet.Columns.AutoFit();
            this.workbook.SaveAs("Orders " + DateTime.Now.ToString("dd-MM-yyyy"));
            this.workbook.Close();
            saveMsg save = new saveMsg();
            save.ShowDialog();
            save = null;
        }//O(1)

        public void fill(LinkedList<Order> orders) {    //fill each order in a row
            for (int line = (int)numbers.start; line <= orders.Count + (int)numbers.lineFilled; line -= -1) {
                this.worksheet.Cells[line, numbers.orderID].Value2 = orders.ElementAt(line - (int)numbers.start).getOrderID().ToString();
                this.worksheet.Cells[line, numbers.productNumber].Value2 = orders.ElementAt(line - (int)numbers.start).getProductNumber().ToString();
                this.worksheet.Cells[line, numbers.productName].Value2 = orders.ElementAt(line - (int)numbers.start).getProductName();
                this.worksheet.Cells[line, numbers.customerID].Value2 = orders.ElementAt(line - (int)numbers.start).getCustomerID().ToString();
                this.worksheet.Cells[line, numbers.customerName].Value2 = orders.ElementAt(line - (int)numbers.start).getCustomerName();
                this.worksheet.Cells[line, numbers.amount].Value2 = orders.ElementAt(line - (int)numbers.start).getAmount().ToString();
            }
        }//O(N)
    }
}
