using Application.Filters;
using Orders_WabApi.Entity;

namespace EntityFramework;

public static class UserExtentions
{
    public static IQueryable<User> Filter(this IQueryable<User> query, UserFilter userFilter)
    {
        if(!string.IsNullOrEmpty(userFilter.Name))
            query =  query.Where(o => o.Name == userFilter.Name);
        
        return query;
    }
    
    
}