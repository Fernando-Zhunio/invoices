using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using EntityFrameworkPaginateCore;
using AutoMapper;
using invoices.Models;
using Microsoft.EntityFrameworkCore;
using invoices.interfaces;

namespace invoices.Utils
{
    public class ControllerApi : ResponsesMethods
    {
        protected readonly ApplicationDbContext contest;

        public ControllerApi(ApplicationDbContext context, IMapper mapper): base(mapper)
        {
            this.contest = context;
        }


        async protected Task<dynamic> Update<T>(T model, T data) where T : class
        {
            contest.Entry(model).CurrentValues.SetValues(data);
            await contest.SaveChangesAsync();
            return model;
        }

        async protected Task<dynamic> Update<V, T>(V model, int id, T data) where V : IModel
        {
            var entity = contest.Set<V>();
            var info = await entity.FirstOrDefaultAsync( x => x.Id == id);
            if (info == null)
                return NotFound();

            info = mapper.Map(data, info);
            entity.Update(info);
            await this.contest.SaveChangesAsync();
            return Ok(mapper.Map<V>(info));
        }
        [NonAction]
        

        async protected Task<dynamic>  Paginate<V, T>(IQueryable<V> query, int page = 1, int pageSize = 15)
        {
           return await query.Select(e => mapper.Map<T>(e)).PaginateAsync(page, pageSize);
        }

        // protected dynamic Paginate<V, T>(IQueryable<V> query, int page = 1, int pageSize = 15, Sorts<T> sorts)
        // {
        //    return query.Select(e => mapper.Map<T>(e)).PaginateAsync(page, pageSize, sorts);
        // }

        // protected dynamic Paginate<V, T>(IQueryable<V> query, int page = 1, int pageSize = 15, Sorts<T> sorts, Filters<T> filters)
        // {
        //    return query.Select(e => mapper.Map<T>(e)).PaginateAsync(page, pageSize, sorts, filters);
        // }
    }
}
