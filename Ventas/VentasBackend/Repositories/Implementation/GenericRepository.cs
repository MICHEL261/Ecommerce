using Microsoft.EntityFrameworkCore;
using Ventas.Shared.Responses;
using VentasBackend.Data;
using VentasBackend.Repositories.Interfaces;

namespace VentasBackend.Repositories.Implementation;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{

    private readonly DataContext _context;
    private readonly DbSet<T> _entity;

    public GenericRepository(DataContext context)
    {
        _context = context;
        _entity=context.Set<T>();
        
    }
    public virtual async Task<ActionResponse<T>> AddAsync(T entity)
    {
        _context.Add(entity);
        try
        {
            await _context.SaveChangesAsync();
            return new ActionResponse<T>
            {
                WasSuccess = true,
                Result = entity
            };
        }
        catch (DbUpdateException)
        {
            return DbUpdateExceptionActionResponse();
        }
        catch (Exception exception)
        {
            return ExceptionActionResponse(exception);
        }
    }


    public virtual async Task<ActionResponse<T>> DeleteAsync(int id)
    {
        var row = await _entity.FindAsync(id);
        if (row == null) {
            return new ActionResponse<T>
            {
                WasSuccess = false,
                Message = "No se encontro el registro que deseas eliminar."
            };
        }
        _context.Remove(row);
        try
        {
            await _context.SaveChangesAsync();
            return new ActionResponse<T>
            {
                WasSuccess = true,
                
            };
        }
        catch
        {
            return new ActionResponse<T>
            {
                WasSuccess = false,
                Message = "No se puede borrar, porque tiene registros relacionados"
            };
        }

    }
    public virtual async Task<ActionResponse<T>> GetAsync(int id)
    {
        var row = await _entity.FindAsync(id);
        if (row != null)
        {
            return new ActionResponse<T>
            {
                WasSuccess = true,
                Result = row
            };
        }
        return new ActionResponse<T>
        {
            WasSuccess = false,
            Message = "Registro no encontrado"
        };
    }

    public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync()
    {
        return new ActionResponse<IEnumerable<T>>
        {
            WasSuccess = true,
            Result = await _entity.ToListAsync()
        };
    }

    public virtual async Task<ActionResponse<T>> UpdateAsync(T entity)
    {
        try
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return new ActionResponse<T>
            {
                WasSuccess = true,
                Result = entity
            };
        }
        catch (DbUpdateException)
        {
            return DbUpdateExceptionActionResponse();
        }
        catch (Exception exception)
        {
            return ExceptionActionResponse(exception);
        }
    }

    private ActionResponse<T> ExceptionActionResponse(Exception exception)
    {
        return new ActionResponse<T>
        {
            WasSuccess = false,
            Message = exception.Message
        };
    }

    private ActionResponse<T> DbUpdateExceptionActionResponse()
    {
        return new ActionResponse<T>
        {
            WasSuccess = false,
            Message = "Ya existe el registro que estas intentando crear."
        };
    }
}
