using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CTDLGT_NguyenGiaBaoTuong_BTVNbuoi2
{
    internal class Bai1
    {
        static void Main1()
        {
            // Sử dụng StreamReader để đọc dữ liệu đầu vào
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
            {
                string line1 = reader.ReadLine();
                if (string.IsNullOrEmpty(line1)) return;
                int n = int.Parse(line1);
                if (n == 0) return;
                string line2 = reader.ReadLine();
                if (string.IsNullOrEmpty(line2)) return;
                // Tách chuỗi thành mảng các phần tử dựa trên khoảng trắng
                string[] parts = line2.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                // Khởi tạo các giá trị ban đầu bằng phần tử đầu tiên của mảng
                int temp = int.Parse(parts[0]);
                int max = temp;
                int min = temp;
                // Dùng kiểu long cho tổng để không bị tràn khi cộng 100000 phần tử có giá trị tới 10^9
                long sum = temp;
                // Duyệt mảng một vòng duy nhất để tìm min, max và tính tổng
                for (int i = 1; i < n; i++)
                {
                    int val = int.Parse(parts[i]);
                    sum += val;

                    if (val > max) max = val;
                    if (val < min) min = val;
                }
                // Tính trung bình dùng kiểu decimal và làm tròn lên theo quy tắc AwayFromZero
                decimal avg = Math.Round((decimal)sum / n, 2, MidpointRounding.AwayFromZero);
                // In kết quả theo đúng thứ tự: Max, Min, Tổng, Trung bình cộng
                Console.WriteLine(max);
                Console.WriteLine(min);
                Console.WriteLine(sum);
                // Định dạng chuỗi "0.00" để luôn hiển thị đúng 2 chữ số sau dấu phẩy 
                Console.WriteLine(avg.ToString("0.00"));
            }
        }
    }
}


