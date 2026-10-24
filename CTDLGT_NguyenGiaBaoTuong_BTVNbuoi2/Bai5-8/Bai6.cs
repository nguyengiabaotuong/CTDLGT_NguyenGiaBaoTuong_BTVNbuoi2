using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CTDLGT_NguyenGiaBaoTuong_BTVNbuoi2
{
    internal class Bai6
    {
        static void Main6()
        {
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
            {
                string input = reader.ReadToEnd();
                string[] tokens = input.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 0) return;
                int idx = 0;
                // Đọc số lượng n và mảng A
                int n = int.Parse(tokens[idx++]);
                int[] a = new int[n];
                for (int i = 0; i < n; i++)
                {
                    a[i] = int.Parse(tokens[idx++]);
                }
                // Đọc số lượng m và mảng B
                int m = int.Parse(tokens[idx++]);
                int[] b = new int[m];
                for (int i = 0; i < m; i++)
                {
                    b[i] = int.Parse(tokens[idx++]);
                }
                StringBuilder sb = new StringBuilder();
                // Khởi tạo hai con trỏ trỏ vào vị trí đầu tiên của hai mảng
                int ptrA = 0;
                int ptrB = 0;
                // Chạy song song: So sánh và lấy phần tử nhỏ hơn nhét vào chuỗi kết quả
                while (ptrA < n && ptrB < m)
                {
                    if (a[ptrA] <= b[ptrB])
                    {
                        sb.Append(a[ptrA++]).Append(" ");
                    }
                    else
                    {
                        sb.Append(b[ptrB++]).Append(" ");
                    }
                }
                // Vét cạn ảng: Nếu mảng A còn dư phần tử (mảng B đã hết), lấy toàn bộ đắp vào cuối
                while (ptrA < n)
                {
                    sb.Append(a[ptrA++]).Append(" ");
                }
                // Vét cạn mảng: Nếu mảng B còn dư phần tử (mảng A đã hết), lấy toàn bộ đắp vào cuối
                while (ptrB < m)
                {
                    sb.Append(b[ptrB++]).Append(" ");
                }
                Console.WriteLine(sb.ToString().TrimEnd());
            }
        }
    }
}
