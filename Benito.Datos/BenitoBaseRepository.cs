
using Benito.Model;
using Benito.Model.Entities.Despensa;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.SqlServer.Server;
using Microsoft.VisualBasic;

namespace Benito.Datos
{
    public class BenitoBaseRepository<T> : IBenitoBaseRepository<T> where T : BenitoBaseEntity
    {
        private readonly BenitoDbContext _context;

        public BenitoBaseRepository(BenitoDbContext context)
        {
            _context = context;
        }

        // END: abpxx6d04wxr

        // BEGIN: be15d9bcejpp
        public async Task<bool> Delete(Guid id)
        {
            try
            {
                _context.Remove(id);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<T> Get(Guid id)
        {
            // obtiene un objeto de tipo T por su Guid
            try
            {
                return await _context.FindAsync<T>(id) ?? throw new KeyNotFoundException("No existe el objeto");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new KeyNotFoundException("No existe el objeto");
            }
        }

        public async Task<T> Get(int id)
        {
            try
            {
                return await _context.FindAsync<T>(id) ?? throw new KeyNotFoundException("No existe el objeto");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new KeyNotFoundException("No existe el objeto");
            }
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return Task.FromResult(_context.Set<T>().AsEnumerable());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new KeyNotFoundException("No existe el objeto");
            }
        }

        public Task<T> Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                entity.FecModifica = DateTime.Now;
                entity.UsuModifica = Guid.NewGuid();


                _context.SaveChanges();
                return Task.FromResult(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new KeyNotFoundException("No existe el objeto");
            }
        }

        public async Task<T> AddAsync(T entity)
        {
            using (var context = new BenitoDbContext())
            {
                    // cambia el tipo de entity a Item
                    var item = (BenitoBaseEntity) Convert.ChangeType(entity, typeof(BenitoBaseEntity));
                    item.Id = Guid.NewGuid();
                    item.FecCrea = DateTime.Now;
                    item.UsuCrea = Guid.NewGuid();
                    context.Set<T>().Add(entity);
                    
                    
                    context.SaveChanges();
                    return entity!;
              
            }
        }

        public Task CallSp(string spName, object[] parameters)
        {
            using (var context = new BenitoDbContext())
            {
                   // llama al procedimiento almacenado y retorna el listado de objetos de tipo T
                   // setea parametros spName y parameters por defecto  
                    var r = context.Set<T>().FromSqlRaw(spName, parameters);
                    return Task.FromResult(r);
                    
            }
        }

        public Task<bool> CallSpNonQuery(string spName, object[] parameters)
        {
            try {
                using (var context = new BenitoDbContext())
                {
                        // llama al procedimiento almacenado
                        var r = context.Database.ExecuteSqlRaw("execute nombre_sp @param1, @param2", spName, 1);
                        context.SaveChanges();
                        return Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Task.FromResult(false);
            }
        }
    }
}
