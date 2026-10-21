using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CTDLGT_NguyenGiaBaoTuong_BTVNbuoi2
{
    internal class Bai3
    {
        static void Main3()
        {
            // Sử dụng StreamReader để đọc dữ liệu siêu tốc từ hệ thống
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
            {
                // ĐỌC VÀ LỌC DỮ LIỆU
                string input = reader.ReadToEnd();
                // Tách các từ khóa, tự động loại bỏ khoảng trắng và dòng rỗng thừa
                string[] tokens = input.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 0) return;
                int idx = 0; // Con trỏ để duyệt từng từ khóa
                int n = int.Parse(tokens[idx++]);
                // KHỞI TẠO MẢNG
                int[] data = new int[4005]; // Sức chứa đủ cho 2000 gốc + 2000 chèn
                int count = n; // Số lượng phần tử hiện tại
                // Nhập mảng ban đầu
                for (int i = 0; i < n; i++)
                {
                    data[i] = int.Parse(tokens[idx++]);
                }
                int q = int.Parse(tokens[idx++]);
                StringBuilder output = new StringBuilder();
                // XỬ LÝ q THAO TÁC
                for (int i = 0; i < q; i++)
                {
                    string type = tokens[idx++];
                    if (type == "I") // Thao tác Chèn
                    {
                        int index = int.Parse(tokens[idx++]);
                        int value = int.Parse(tokens[idx++]);
                        // Kiểm tra vị trí chèn hợp lệ (từ 0 đến count)
                        if (index < 0 || index > count)
                        {
                            output.AppendLine("INVALID");
                        }
                        else
                        {
                            // Dịch phải để tạo ô trống tại index
                            for (int j = count; j > index; j--)
                            {
                                data[j] = data[j - 1];
                            }
                            data[index] = value;
                            count++;
                        }
                    }
                    else if (type == "D") // Thao tác Xóa
                    {
                        int index = int.Parse(tokens[idx++]);
                        // Kiểm tra vị trí xóa hợp lệ (từ 0 đến count - 1)
                        if (index < 0 || index >= count)
                        {
                            output.AppendLine("INVALID");
                        }
                        else
                        {
                            // Dịch trái để lấp ô bị xóa
                            for (int j = index; j < count - 1; j++)
                            {
                                data[j] = data[j + 1];
                            }
                            count--;
                        }
                    }
                }
                // XUẤT KẾT QUẢ
                // In số lượng phần tử ra dòng đầu (bắt buộc)
                output.AppendLine(count.ToString());
                if (count == 0)
                {
                    output.AppendLine("EMPTY");
                }
                else
                {
                    // In mảng
                    for (int i = 0; i < count; i++)
                    {
                        output.Append(data[i]).Append(" ");
                    }
                    output.AppendLine();
                }
                // In toàn bộ ra màn hình
                Console.Write(output.ToString());
            }
        }
    }
}
