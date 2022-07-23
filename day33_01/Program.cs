using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace day33_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Data Table 생성과 Columns 만들기
            DataTable table01 = new DataTable("table01");
            var Col01 = new DataColumn("Name", typeof(string));
            table01.Columns.Add(Col01);

//PK설정하는 부분(이름을 설정했지만, 이는 SID에 해주는게 좋다)
            table01.PrimaryKey = new DataColumn[] { Col01 }; 
            
            Col01 = new DataColumn("age", typeof(int));
            table01.Columns.Add(Col01);
            Col01 = new DataColumn("phone", typeof(string));
            table01.Columns.Add(Col01);

            // Row 입력(생성)
            DataRow row = table01.NewRow();
            row["Name"] = "강동훈";
            row["age"] = 23;
            row["phone"] = "010-1234-5678";
            table01.Rows.Add(row);

            row = table01.NewRow();
            row["Name"] = "김훈";
            row["age"] = 21;
            row["phone"] = "010-3334-5448";
            table01.Rows.Add(row);

            row = table01.NewRow();
            row[0] = "김민재";
            row[1] = 12;
            row[2] = "010-1334-4448";
            table01.Rows.Add(row);

            table01.AcceptChanges();

            DataRow[] SelectedRow = table01.Select("age >= 20");        //요 부분에서 select를 수행함
            foreach (DataRow printR in SelectedRow)     //
            {
                Console.WriteLine("이름: {0}, 나이: {1}, 성별:{2}", printR[0], printR["age"], printR["phone"]);
            }
            Console.WriteLine("\n");

            //find를 활용하는 부분으로,find문은 PK를 비교하여 찾는 방식이다.
            DataRow FindRow = table01.Rows.Find("강동훈");
            if(FindRow != null)
            {
                Console.WriteLine("이름: {0}, 나이: {1}, 성별:{2}", FindRow[0], FindRow["age"], FindRow["phone"]);
            }

        }
    }
}
