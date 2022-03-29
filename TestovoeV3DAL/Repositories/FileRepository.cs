using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestovoeV3DAL.EF;
using TestovoeV3DAL.Entities;
using TestovoeV3DAL.Interfaces;

namespace TestovoeV3DAL.Repositories
{
    /// <summary>
    /// Репозиторий для работы с файлами
    /// </summary>
    public class FileRepository : IFileRepository
    {
        /// <summary>
        /// Контекст бд
        /// </summary>
        private readonly FilesContext _context;
        public FileRepository(FilesContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Получить все файлы с бд
        /// </summary>
        /// <returns> Список файлов </returns>
        public async Task<IEnumerable<File>> GetFiles()
        {
            return await _context.Files.ToListAsync();
        }
        /// <summary>
        /// Получить файл по id
        /// </summary>
        /// <param name="id"> Id файла в бд</param>
        /// <returns> Файл по полученому id </returns>
        public async Task<File> GetFileById(int id)
        {
            return await _context.Files.FindAsync(id);
        }
        /// <summary>
        /// Добавить файл в бд
        /// </summary>
        /// <param name="file"> Файл для добавления в бд </param>
        /// <returns> Добавленный в бд файл</returns>
        public async Task<File> AddFile(File file)
        {
            file.Size = file.Data.Length;
            await _context.Files.AddAsync(file);
            await _context.SaveChangesAsync();
            return file;
        }
        /// <summary>
        /// Удалить файл из бд по id
        /// </summary>
        /// <param name="id"> Id файла в бд</param>
        /// <returns></returns>
        public async Task DeleteFileById(int id)
        {
            File file = await _context.Files.FindAsync(id);
            _context.Files.Remove(file);
            await _context.SaveChangesAsync();
        }
    }
}
