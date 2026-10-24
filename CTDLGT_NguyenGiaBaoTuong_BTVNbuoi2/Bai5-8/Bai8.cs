using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CTDLGT_NguyenGiaBaoTuong_BTVNbuoi2
{
    internal class Bai8
    {
        static void Main()
        {
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
            {
                string input = reader.ReadToEnd();
                string[] tokens = input.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length < 2) return;
                int idx = 0;
                // Đọc số hàng m và số cột n
                int m = int.Parse(tokens[idx++]);
                int n = int.Parse(tokens[idx++]);
                // Khởi tạo ma trận 2 chiều theo gợi ý của đề
                int[,] matrix = new int[m, n];
                // Khởi tạo 2 mảng 1 chiều để lưu tổng hàng và tổng cột
                // Dùng kiểu long để phòng hờ trường hợp tổng vượt quá giới hạn int
                long[] row = new long[m];
                long[] col = new long[n];
                // Vừa đọc dữ liệu vào ma trận, vừa cộng dồn tổng 
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        int val = int.Parse(tokens[idx++]);
                        matrix[i, j] = val;

                        row[i] += val; // Cộng dồn vào tổng của hàng thứ i
                        col[j] += val; // Cộng dồn vào tổng của cột thứ j
                    }
                }
                StringBuilder sb = new StringBuilder();
                // In ma trận chuyển vị
                // Thay vì duyệt hàng trước cột sau (i rồi j), ta duyệt cột trước hàng sau (j rồi i)
                for (int j = 0; j < n; j++)
                {
                    for (int i = 0; i < m; i++)
                    {
                        sb.Append(matrix[i, j]).Append(" ");
                    }
                    sb.AppendLine(); // Xuống dòng khi in hết 1 hàng của ma trận chuyển vị
                }
                // In tổng từng hàng của ma trận gốc
                for (int i = 0; i < m; i++)
                {
                    sb.Append(row[i]).Append(" ");
                }
                sb.AppendLine();
                // In tổng từng cột của ma trận gốc
                for (int j = 0; j < n; j++)
                {
                    sb.Append(col[j]).Append(" ");
                }
                sb.AppendLine();
                // In toàn bộ kết quả ra màn hình
                Console.Write(sb.ToString());
            }
        }
    }
}
