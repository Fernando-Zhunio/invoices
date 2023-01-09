using AutoMapper;
using EntityFrameworkPaginateCore;
using invoices.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace invoices.Utils
{
    public class CrudMethods : ResponsesMethods
    {
        protected readonly ApplicationDbContext context;

        public CrudMethods(ApplicationDbContext context, IMapper mapper) : base(mapper)
        {
            this.context = context;
        }

        /// <summary>
        ///  Método <c>SaveUpdate</c> para actualizar un registro en la base de datos
        /// </summary>
        /// <typeparam  name="V">Modelo de la base de datos</typeparam>
        /// <typeparam  name="T">Dto a devolver</typeparam>
        /// <returns>Devuelve un objeto con el registro actualizado o Action result not found</returns>
        async protected Task<dynamic> SaveUpdate<V, T>(int id, object data) where V : class
        {
            var entity = context.Set<V>();
            var info = await entity.FirstOrDefaultAsync((x) => (x as IBaseEntity).Id == id);
            if (info == null)
                return null;

            info = mapper.Map(data, info);
            entity.Update(info);
            await this.context.SaveChangesAsync();
            return info;
        }

        /// <summary>
        ///  Método <c>SaveStore</c> para crear un registro en la base de datos del tipo V
        /// </summary>
        /// <typeparam  name="V">Modelo de la base de datos</typeparam>
        /// <typeparam  name="T">Dto a devolver</typeparam>
        /// <param  name="data">Objeto a guardar</param>
        /// <returns>Devuelve un objeto con el registro actualizado o Action result not found</returns>
        async protected Task<dynamic> SaveStore<V, T>(T data)
         where V : class 
        {
            var entity = context.Set<V>();
            var info = mapper.Map<V>(data);
            entity.Add(info);
            await this.context.SaveChangesAsync();
            return info;
        }

        async protected Task<dynamic> SaveDelete<V>(int id) where V : class
        {
            var entity = context.Set<V>();
            var info = await entity.FirstOrDefaultAsync((x) => (x as IBaseEntity).Id == id);
            if (info == null)
                return null;

            entity.Remove(info);
            await this.context.SaveChangesAsync();
            return info;
        }

        async protected Task<dynamic> Find<T>(int id) where T : class {
            var entity = context.Set<T>();
            var info = await entity.FirstOrDefaultAsync((x) => (x as IBaseEntity).Id == id);
            return info;
        }

        async protected Task<dynamic> SearchPaginate<V, T>(
            IQueryable<V> query,
            int page = 1,
            int pageSize = 15,
            [FromQuery] string search = null,
            string namePropertySearch = null
        ) where V : class
        {
            var data = new Page<T>();
            data = await PaginateAsync<V, T>(query, page, pageSize);

            return ResponseCustom(data);
        }

        // private object getProperty<V>(object data, string nameProperty) {
        //     var type = typeof(V);
        //     var property = type.GetProperty(nameProperty);
        //     return property.GetValue(data);
        // }

        [NonAction]
        async protected Task<dynamic> PaginateAsync<V, T>(
            IQueryable<V> query,
            int page = 1,
            int pageSize = 15
        )
        {
            return await query.Select(e => mapper.Map<T>(e)).PaginateAsync(page, pageSize);
        }
    }
}
