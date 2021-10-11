using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace HMMJ.Helpers
{
    public static class PaginationHelper
    {
        public static PageOfList<T> ToPage<T>(this IQueryable<T> query, int? page = null, int? size = null)
        {
            int pageIndex = page ?? 1;
            int pageSize = size ?? query.Count();

            var count = query.Count();
            var items = count == 0 ? (new List<T>()).AsEnumerable() : query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return new PageOfList<T>(items, pageIndex, pageSize, count);
        }

        public static PageOfList<T> ToPage<T>(this IEnumerable<T> query, int? page = null, int? size = null)
        {
            int pageIndex = page ?? 1;
            int pageSize = size ?? query.Count();
            return new PageOfList<T>(query.Skip((pageIndex - 1) * pageSize).Take(pageSize), pageIndex, pageSize, query.Count());
        }

        public static IQueryable<TEntity> Includes<TEntity>(this IQueryable<TEntity> res, Expression<Func<TEntity, object>>[] includes)
             where TEntity : class
        {
            return includes.Aggregate(res, (current, include) => current.Include(include));
        }

        public static IQueryable<TEntity> Includes<TEntity>(this DbSet<TEntity> res, Expression<Func<TEntity, object>>[] includes)
            where TEntity : class
        {
            IQueryable<TEntity> items = res;

            if (includes?.Any() ?? false)
                return items.Includes(includes);
            return res;
        }
    }

    public class PageOfList<T> : List<T>, IPageOfList<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalItemCount { get; set; }
        public int TotalPageCount
        {
            get { return (int)Math.Ceiling(this.TotalItemCount / (double)this.PageSize); }
        }

        public int StartIndex
        {
            get { return (this.PageIndex - 1) * this.PageSize + 1; }
        }

        public int EndIndex
        {
            get { return StartIndex + base.Count - 1; }
        }

        public bool IsPaged => this.TotalPageCount > 1;

        public PageOfList() { }
        public PageOfList(IEnumerable<T> items, int pageIndex, int pageSize, int totalItemCount)
        {
            AddRange(items);
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalItemCount = totalItemCount;
        }
    }

    public interface IPageOfList<T> : IList<T>, IPaginated
    {
        void ForEach(Action<T> a);
    }

    public interface IPaginated
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
        int TotalPageCount { get; }
        int TotalItemCount { get; }

        int StartIndex { get; }
        int EndIndex { get; }

        bool IsPaged { get; }
    }
}
