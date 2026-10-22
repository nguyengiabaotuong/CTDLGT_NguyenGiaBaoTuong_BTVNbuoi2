using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CTDLGT_NguyenGiaBaoTuong_BTVNbuoi2
{
    internal class Bai2
    {
        static void Main2()
        {
            // Mở luồng đọc chuẩn để xử lý dữ liệu lớn siêu tốc
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
            {
                // Đọc dòng 1: chứa n và k
                string line1 = reader.ReadLine();
                if (string.IsNullOrEmpty(line1)) return;
                string[] nk = line1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int n = int.Parse(nk[0]);
                // k có thể lên tới 10^9 nên dùng long để đọc, sau đó áp dụng gợi ý k % n
                long k_input = long.Parse(nk[1]);
                int k = (int)(k_input % n);
                // Đọc dòng 2: chứa các phần tử của mảng
                string line2 = reader.ReadLine();
                if (string.IsNullOrEmpty(line2)) return;
                string[] parts = line2.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                // Sử dụng StringBuilder để nối chuỗi kết quả
                StringBuilder sb = new StringBuilder();
                // Áp dụng công thức gợi ý: phần tử ở vị trí i sau khi xoay chính là phần tử gốc ở vị trí (i - k + n) % n
                for (int i = 0; i < n; i++)
                {
                    int originalIndex = (i - k + n) % n;
                    sb.Append(parts[originalIndex]).Append(" ");
                }
                // In toàn bộ chuỗi kết quả ra màn hình trong 1 lần duy nhất
                Console.WriteLine(sb.ToString().TrimEnd());
            }
        }
    }
}
