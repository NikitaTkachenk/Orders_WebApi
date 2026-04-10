using Application.Filters;
using Orders_WabApi.Entity;

namespace EntityFramework.Repository;

public static class OrderExtentions
{
    public static IQueryable<Order> FilterByName(this IQueryable<Order> query, OrderFilter orderFilter)
    {
        if (!string.IsNullOrEmpty(orderFilter.Name))
            query = query.Where(x => x.Name == orderFilter.Name);
   
        return query;
    }

    public static IQueryable<Order> FilterFromDateTo(this IQueryable<Order> query, OrderFilter orderFilter)
    {
        if(orderFilter.FromDate != null)
            query = query.Where(x => x.OrderDate >= orderFilter.FromDate);
        
        if(orderFilter.ToDate != null)
            query = query.Where(x => x.OrderDate <= orderFilter.ToDate);
            
        return query;
    }
}