using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CTDLGT_NguyenGiaBaoTuong_BTVNbuoi2
{
    internal class Bai7
    {
        static void Main()
        {
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
            {
                string input = reader.ReadToEnd();
                string[] tokens = input.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 0) return;
                int idx = 0;
                int n = int.Parse(tokens[idx++]);
                // Sử dụng List để chứa các phần tử không bị trùng lặp
                List<int> uniqueList = new List<int>();
                for (int i = 0; i < n; i++)
                {
                    int val = int.Parse(tokens[idx++]);
                    // Nếu danh sách chưa chứa giá trị này thì mới thêm vào
                    if (!uniqueList.Contains(val))
                    {
                        uniqueList.Add(val);
                    }
                }
                StringBuilder sb = new StringBuilder();
                // In ra số lượng phần tử còn lại (chính là kích thước của List)
                sb.AppendLine(uniqueList.Count.ToString());
                // In ra các phần tử
                foreach (int i in uniqueList)
                {
                    sb.Append(i).Append(" ");
                }
                Console.Write(sb.ToString());
            }
        }
    }
}
