using System.Linq.Expressions;
using System.Reflection;

namespace LNDP_API.Filters
{
    public static class SortingUtils
    {
        public static IQueryable<T> ApplySorting<T>(IQueryable<T> query, string sortBy, string sortOrder)
        {
            var entityType = typeof(T);
            var parameter = Expression.Parameter(entityType, "x");
            Expression orderByExpression = parameter;

            // Split the sortBy parameter to handle navigation properties
            var properties = sortBy.Split('.');
            foreach (var property in properties)
            {
                var propertyInfo = entityType.GetProperty(property, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (propertyInfo == null)
                {
                    throw new ArgumentException($"Property {property} not found in type {entityType.Name}");
                }

                orderByExpression = Expression.Property(orderByExpression, propertyInfo);
                entityType = propertyInfo.PropertyType;
            }

            var lambda = Expression.Lambda(orderByExpression, parameter);

            // Create an expression for the OrderBy or OrderByDescending method
            var methodName = sortOrder.ToLower() == "desc" ? "OrderByDescending" : "OrderBy";

            var orderByExpressionWithType = Expression.Call(
                typeof(Queryable),
                methodName,
                new[] { typeof(T), lambda.Body.Type },
                query.Expression,
                Expression.Quote(lambda)
            );

            // Apply the sorting expression to the query
            return query.Provider.CreateQuery<T>(orderByExpressionWithType);
        }
    }
}