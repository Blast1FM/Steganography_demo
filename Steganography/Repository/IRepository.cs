using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Steganography.Repository
{
    public interface IRepository
    {
        Task<byte[]> LoadImage(string path); // ��������� ������ (����) � ���������� ������ ������
        Task<string> SaveImage(byte[] imageData); // ��������� ������ ������ � ���������� ������ (����)
    }

    public class Repositoty2 : IRepository
    {
        public async Task<byte[]> LoadImage(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("���� �� ������", path);
            }

            return await File.ReadAllBytesAsync(path);
        }

        public async Task<string> SaveImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
            {
                throw new ArgumentException("������ ����������� �����");
            }

            string path = Path.Combine("path_to_save_directory", $"{Guid.NewGuid()}.png");
            await File.WriteAllBytesAsync(path, imageData);

            return path;
        }
    }
}
