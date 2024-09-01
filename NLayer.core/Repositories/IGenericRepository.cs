using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);//_context.Students.Where(x => x.Id == id);
        IQueryable<T> GetAll();//_context.Students.ToList();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);//_context.Students.Where(expression);
        //Programin ici:
        //Student student = GetByIdAsnc(134);
        //Student student = Where(x => x.Id = 134);
        //List<Student> students = GetAll();
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);//bool BasariliOgrenciVar = _context.Exams.AnyAsync(x => x.FirstExamNote > 90);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        // Interface nedir neden interface class lar tanimlanir?
        // Generic class nedir = T?
        // List nedir?

        // public StudentRepository : IGenericRepository<Student>
        // {
            //Add(Student entity)
            
        
        
        //   Where()
        //   {
                //EF kodlari yazilacak.
                //EF nin kendine ait where metotu var bizim yerimize where li sorgu olusturan.
                //cmd.execute("SElect where satini yaz", baglanti);
                //cmd.execute("SElect where satini yaz", baglanti);
                //list<Student> students = _context.Students.Where(x => x.OgrenciAdi == "Ilyas").ToList();
                //
        //   }
        //}
    }
}
