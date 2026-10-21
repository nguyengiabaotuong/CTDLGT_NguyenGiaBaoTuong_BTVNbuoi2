using System;
using System.Collections.Generic;
using System.Text;
using System.IO; 

namespace CTDLGT_NguyenGiaBaoTuong_BTVNbuoi2
{
    internal class Bai4
    {
        static void Main()
        {
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
            {
                // Hút toàn bộ dữ liệu và loại bỏ khoảng trắng dư thừa
                string input = reader.ReadToEnd();
                string[] tokens = input.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 0) return;
                int idx = 0;
                // Đọc số lượng lệnh q
                int q = int.Parse(tokens[idx++]);
                // Khởi tạo mảng mô phỏng List. Do q tối đa 2000 
                int[] data = new int[2005];
                int count = 0;
                StringBuilder output = new StringBuilder();
                // Xử lý q lệnh
                for (int i = 0; i < q; i++)
                {
                    string cmd = tokens[idx++];
                    if (cmd == "Add")
                    {
                        int v = int.Parse(tokens[idx++]);
                        data[count++] = v; // Thêm vào cuối và tăng số lượng
                    }
                    else if (cmd == "Insert")
                    {
                        int p = int.Parse(tokens[idx++]);
                        int v = int.Parse(tokens[idx++]);
                        // Insert cho phép p == count (chèn vào đuôi)
                        if (p < 0 || p > count)
                        {
                            output.AppendLine("ERROR");
                        }
                        else
                        {
                            // Dịch phải
                            for (int j = count; j > p; j--)
                            {
                                data[j] = data[j - 1];
                            }
                            data[p] = v;
                            count++;
                        }
                    }
                    else if (cmd == "RemoveAt")
                    {
                        int p = int.Parse(tokens[idx++]);
                        // RemoveAt không cho phép p == count
                        if (p < 0 || p >= count)
                        {
                            output.AppendLine("ERROR");
                        }
                        else
                        {
                            // Dịch trái
                            for (int j = p; j < count - 1; j++)
                            {
                                data[j] = data[j + 1];
                            }
                            count--;
                        }
                    }
                    else if (cmd == "Remove")
                    {
                        int v = int.Parse(tokens[idx++]);
                        int foundIdx = -1;
                        // Tìm vị trí xuất hiện đầu tiên
                        for (int j = 0; j < count; j++)
                        {
                            if (data[j] == v)
                            {
                                foundIdx = j;
                                break;
                            }
                        }
                        if (foundIdx != -1)
                        {
                            // Xóa bằng cách dịch trái
                            for (int j = foundIdx; j < count - 1; j++)
                            {
                                data[j] = data[j + 1];
                            }
                            count--;
                            output.AppendLine("true");
                        }
                        else
                        {
                            output.AppendLine("false");
                        }
                    }
                    else if (cmd == "IndexOf")
                    {
                        int v = int.Parse(tokens[idx++]);
                        int foundIdx = -1;
                        for (int j = 0; j < count; j++)
                        {
                            if (data[j] == v)
                            {
                                foundIdx = j;
                                break;
                            }
                        }
                        output.AppendLine(foundIdx.ToString());
                    }
                    else if (cmd == "Contains")
                    {
                        int v = int.Parse(tokens[idx++]);
                        bool isFound = false;

                        for (int j = 0; j < count; j++)
                        {
                            if (data[j] == v)
                            {
                                isFound = true;
                                break;
                            }
                        }
                        // C# in boolean ra True/False viết hoa chữ đầu, nhưng OJ yêu cầu in true/false viết thường
                        output.AppendLine(isFound ? "true" : "false");
                    }
                    else if (cmd == "Count")
                    {
                        output.AppendLine(count.ToString());
                    }
                    else if (cmd == "Clear")
                    {
                        count = 0; // Đưa số lượng về 0, mảng sẽ tự động bị ghi đè khi Add mới
                    }
                }
                // In danh sách sau khi hoàn tất tất cả thao tác
                if (count == 0)
                {
                    output.AppendLine("EMPTY");
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        output.Append(data[i]).Append(" ");
                    }
                    output.AppendLine();
                }
                // Đẩy kết quả ra màn hình
                Console.Write(output.ToString());
            }
        }
    }
}
