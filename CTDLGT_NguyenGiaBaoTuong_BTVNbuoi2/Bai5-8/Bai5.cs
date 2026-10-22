using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CTDLGT_NguyenGiaBaoTuong_BTVNbuoi2
{
    internal class Bai5
    {
        static void Main5()
        {
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
            {
                // Đọc toàn bộ đầu vào và lọc khoảng trắng như cũ
                string input = reader.ReadToEnd();
                string[] tokens = input.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length < 2) return;
                // Bắt buộc phải dùng kiểu long vì n lên tới 10^18, dùng int sẽ bị tràn số
                long c = long.Parse(tokens[0]);
                long n = long.Parse(tokens[1]);
                long capacity = c;
                long reallocations = 0; // Số lần cấp phát lại
                long totalCost = 0;     // Tổng chi phí sao chép
                // Nhảy cóc: Chừng nào sức chứa hiện tại (capacity) còn nhỏ hơn số phần tử cần thêm (n) thì ta tiến hành cấp phát lại và nhân đôi dung lượng.
                while (capacity < n)
                {
                    // Chi phí sao chép chính bằng sức chứa cũ (vì lúc đó mảng đã đầy)
                    totalCost += capacity;
                    // Tăng biến đếm số lần cấp phát
                    reallocations++;
                    // Cập nhật mức sức chứa mới theo đúng luật của đề
                    if (capacity == 0)
                    {
                        capacity = 4;
                    }
                    else
                    {
                        capacity *= 2;
                    }
                }
                // In ra 3 thông số bằng Console.WriteLine thay vì StreamBuilder vì chỉ cần in 3 con số
                Console.WriteLine(capacity);
                Console.WriteLine(reallocations);
                Console.WriteLine(totalCost);
            }
        }
    }
}
