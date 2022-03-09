using ClosedXML;
using ClosedXML.Excel;
using System.Collections.Generic;

namespace myAPI.teacher
{
    public class Teacher
    {
        public string name { get; set; } //1,1 (row,column) in excel
        public string material { get; set; }//1,2 (row,column) in excel
        //public int phone { get; set; } //1,3 (row,column) in excel
        //public int price { get; set; } //1,4 (row,column) in excel
        public string phone { get; set; } //1,3 (row,column) in excel
        public string price { get; set; } //1,4 (row,column) in excel
        private IXLWorkbook getWB()
        {
            IXLWorkbook wb = new XLWorkbook("data.xlsx");
            return wb;
        }

        //constr
        //public Teacher() { }

        public int counter()
        {
            IXLWorkbook wb = new XLWorkbook("data.xlsx");
            IXLWorksheet worksheet = wb.Worksheet(1);
            int count = 0;
            foreach (var row in worksheet.Rows())
            {
                count++;
            }
            return count;
        }


        public List<Teacher> GetAllTeachers() {
            IXLWorkbook wb = new XLWorkbook("data.xlsx");
            IXLWorksheet ws = wb.Worksheet(1);
            List<Teacher> allTeachers = new List<Teacher>();
            for (int i = 0,row = 2; i < counter(); i++ ,row++)
            {
                Teacher t = new Teacher();
                t.name = ws.Cell(row, 1).Value.ToString();
                t.material = ws.Cell(row, 2).Value.ToString();
                //t.phone = Convert.ToInt32(ws.Cell(row, 3).Value);
                //t.price = Convert.ToInt32(ws.Cell(row, 4).Value);
                t.phone = ws.Cell(row, 3).Value.ToString();
                t.price = ws.Cell(row, 4).Value.ToString();
                
                if(t.name != "")
                {
                    allTeachers.Add(t);
                }
            }       
            return allTeachers;
        }
        
        public void addTeacher(Teacher t)
        {
            IXLWorkbook wb = new XLWorkbook("data.xlsx");
            IXLWorksheet ws = wb.Worksheet(1);
            int row = counter() + 1;

            if (t.name != "" && t.material != "") 
            {
                ws.Cell(row, 1).Value = t.name;
                ws.Cell(row, 2).Value = t.material;
                ws.Cell(row, 3).Value = t.phone;
                ws.Cell(row, 4).Value = t.price;
                wb.Save();
            }
        }
    }
}
