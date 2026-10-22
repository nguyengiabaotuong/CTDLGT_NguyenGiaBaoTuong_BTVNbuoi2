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
                // Hút toàn bộ dữ liệu và lọc sạch mọi khoảng trắng/xuống dòng thừa
                string input = reader.ReadToEnd();
                string[] tokens = input.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 0) return;
                int idx = 0; 
                // Lấy n
                int n = int.Parse(tokens[idx++]);
                if (n == 0) return;
                // Lấy phần tử đầu tiên làm mốc
                int temp = int.Parse(tokens[idx++]);
                int max = temp;
                int min = temp;
                long sum = temp;
                // Chạy vòng lặp từ 1 đến n-1 để xét các phần tử còn lại
                for (int i = 1; i < n; i++)
                {
                    int val = int.Parse(tokens[idx++]);
                    sum += val;

                    if (val > max) max = val;
                    if (val < min) min = val;
                }
                // Tính toán và xuất kết quả
                decimal avg = Math.Round((decimal)sum / n, 2, MidpointRounding.AwayFromZero);
                Console.WriteLine(max);
                Console.WriteLine(min);
                Console.WriteLine(sum);
                Console.WriteLine(avg.ToString("0.00"));
            }
        }
    }
}


