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
    public class FileRepository : IFileRepository
    {
        private readonly FilesContext _context;
        public FileRepository(FilesContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<File>> GetFiles()
        {
            return await _context.Files.ToListAsync();
        }

        public async Task<File> GetFileById(int id)
        {
            return await _context.Files.FindAsync(id);
        }

        public async Task<File> AddFile(File file)
        {
            file.Size = file.Data.Length;
            await _context.Files.AddAsync(file);
            await _context.SaveChangesAsync();
            return file;
        }

        public async Task DeleteFileById(int id)
        {
            File file = await _context.Files.FindAsync(id);
            _context.Files.Remove(file);
            await _context.SaveChangesAsync();
        }
    }
}
