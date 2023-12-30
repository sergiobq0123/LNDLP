using System.Linq.Expressions;
using System.Reflection;

namespace LNDP_API.Filters
{
    public class FilterUtils
    {

        /// <summary>
        /// Gets an expression to filter a table using a list of filters
        /// </summary>
        /// <typeparam name="T">Table to be filtered</typeparam>
        /// <param name="filters">List of filters to apply to the table</param>
        /// <returns>An expression with all the filters applied</returns>
        public static Expression<Func<T, bool>> GetPredicate<T>(List<Filter>? filters)
        {
            Expression<Func<T, bool>> predicate = PredicateBuilder.True<T>();
            if (filters == null)
            {
                return predicate;
            }
            foreach (Filter filter in filters)
            {
                var param = Expression.Parameter(typeof(T), "a"); // a =>
                var prop = GetPropertyExpression<T>(param, filter);
                var values = filter.FilterInput;

                if (prop == null)
                {
                    continue;
                }

                if (values == null && filter.Type == Filter.ContentType.DateText || filter.Type == Filter.ContentType.DatePicker)
                {
                    var call = BuildFilterExpression(filter, param, prop, null);
                    predicate = predicate.And(Expression.Lambda<Func<T, bool>>(call, param));
                    continue;
                }
                var valuesPredicate = PredicateBuilder.False<T>();
                foreach (var value in values)
                {
                    var call = BuildFilterExpression(filter, param, prop, value);
                    if (call != null)
                    {
                        valuesPredicate = valuesPredicate.Or(Expression.Lambda<Func<T, bool>>(call, param));
                    }
                }
                predicate = predicate.And(valuesPredicate);
            }
            return predicate;
        }

        private static Expression GetPropertyExpression<T>(ParameterExpression param, Filter filter)
        {
            var entityType = typeof(T);
            var properties = filter.DataKey.Split('.');
            Expression filterExpression = param;
            foreach (var property in properties)
            {
                var propertyInfo = entityType.GetProperty(property, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (propertyInfo == null)
                {
                    throw new ArgumentException($"Property {property} not found in type {entityType.Name}");
                }

                filterExpression = Expression.Property(filterExpression, propertyInfo);
                entityType = propertyInfo.PropertyType;
            }
            return filterExpression;
        }

        private static Expression? BuildFilterExpression(Filter filter, ParameterExpression param, Expression prop, string value)
        {
            bool isValueNumber = prop.Type.Equals(typeof(int?)) || prop.Type.Equals(typeof(float?)) || prop.Type.Equals(typeof(int)) || prop.Type.Equals(typeof(float));
            Expression? propLower = null, valueLower = null;

            if (filter.Type.Equals("editableTextFields") || filter.Type.Equals("plainText"))
            {
                propLower = GetToLowerExpression(prop);
                valueLower = GetToLowerExpression(Expression.Constant(value));
            }

            DateTime today = DateTime.UtcNow.Date;
            Expression call = filter.Condition switch
            {
                Filter.ConditionType.Is => BuildIsConditionExpression(filter, prop, value, isValueNumber, propLower, valueLower),
                Filter.ConditionType.IsNot => BuildIsNotConditionExpression(filter, prop, value, isValueNumber, propLower, valueLower),
                Filter.ConditionType.MoreOrEquals => BuildMoreOrEqualsConditionExpression(filter, prop),
                Filter.ConditionType.LessOrEquals => BuildLessOrEqualsConditionExpression(filter, prop),
                Filter.ConditionType.Between => BuildBetweenConditionExpression(filter, prop),
                Filter.ConditionType.Today => BuildTodayConditionExpression(prop, today),
                Filter.ConditionType.Yesterday => BuildYesterdayConditionExpression(prop, today),
                Filter.ConditionType.ThisWeek => BuildThisWeekConditionExpression(prop, today),
                Filter.ConditionType.LastWeek => BuildLastWeekConditionExpression(prop, today),
                Filter.ConditionType.ThisMonth => BuildThisMonthConditionExpression(prop, today),
                Filter.ConditionType.LastMonth => BuildLastMonthConditionExpression(prop, today),
                Filter.ConditionType.ThisYear => BuildThisYearConditionExpression(prop, today),
                Filter.ConditionType.LastYear => BuildLastYearConditionExpression(prop, today),
                Filter.ConditionType.Contains or _ => BuildContainsConditionExpression(prop, value, isValueNumber, propLower, valueLower),
            };

            return call;
        }

        private static Expression GetToLowerExpression(Expression expression)
        {
            if (expression.Type.Equals(typeof(string)))
            {
                return Expression.Call(expression, typeof(string).GetMethod("ToLower", Type.EmptyTypes));
            }
            return expression;
        }

        private static Expression BuildIsConditionExpression(Filter filter, Expression prop, string value, bool isValueNumber, Expression? propLower, Expression? valueLower)
        {
            if (filter.Type == Filter.ContentType.DropdownFields)
            {
                return Expression.Equal(prop, Expression.Convert(Expression.Constant(int.Parse(value)), prop.Type));
            }

            if (filter.Type == Filter.ContentType.DatePicker || filter.Type == Filter.ContentType.DateText)
            {
                var startDateExpression = Expression.Constant(filter.StartDate.Value);
                var nullableStartDateExpression = Expression.Convert(startDateExpression, prop.Type);
                var nullableLessDateExpression = Expression.Convert(Expression.Constant(filter.StartDate.Value.AddDays(1)), prop.Type);

                return Expression.And(
                    Expression.GreaterThanOrEqual(prop, nullableStartDateExpression),
                    Expression.LessThan(prop, nullableLessDateExpression)
                );
            }

            if (isValueNumber)
            {
                return Expression.Equal(prop, Expression.Convert(Expression.Constant(GetValueNumber(value, prop.Type)), prop.Type));
            }
            return Expression.Equal(propLower ?? prop, valueLower ?? Expression.Constant(value));
        }

        private static Expression BuildIsNotConditionExpression(Filter filter, Expression prop, string value, bool isValueNumber, Expression? propLower, Expression? valueLower)
        {
            if (filter.Type == Filter.ContentType.DropdownFields)
            {
                return Expression.NotEqual(prop, Expression.Convert(Expression.Constant(int.Parse(value)), prop.Type));
            }

            if (isValueNumber)
            {
                return Expression.NotEqual(prop, Expression.Convert(Expression.Constant(GetValueNumber(value, prop.Type)), prop.Type));
            }

            return Expression.NotEqual(propLower ?? prop, valueLower ?? Expression.Constant(value));
        }

        private static Expression BuildMoreOrEqualsConditionExpression(Filter filter, Expression prop)
        {
            return Expression.GreaterThanOrEqual(prop, Expression.Constant(filter.StartDate));
        }

        private static Expression BuildLessOrEqualsConditionExpression(Filter filter, Expression prop)
        {
            return Expression.LessThanOrEqual(prop, Expression.Constant(filter.StartDate));
        }

        private static Expression BuildBetweenConditionExpression(Filter filter, Expression prop)
        {
            // a => a.ColumnName >= start && a.ColumnName <= end
            return Expression.And(
                Expression.GreaterThanOrEqual(prop, Expression.Constant(filter.StartDate)),
                Expression.LessThanOrEqual(prop, Expression.Constant(filter.EndDate)));
        }

        private static Expression BuildTodayConditionExpression(Expression prop, DateTime today)
        {
            // a => a.ColumnName >= Today && a.ColumnName < Tomorrow
            return Expression.And(
                Expression.GreaterThanOrEqual(prop, Expression.Constant(today)),
                Expression.LessThan(prop, Expression.Constant(today.AddDays(1))));
        }

        private static Expression BuildYesterdayConditionExpression(Expression prop, DateTime today)
        {
            // a => a.ColumnName >= Yesterday && a.ColumnName < Today
            return Expression.And(
                Expression.GreaterThanOrEqual(prop, Expression.Constant(today.AddDays(-1))),
                Expression.LessThan(prop, Expression.Constant(today)));
        }

        private static Expression BuildThisWeekConditionExpression(Expression prop, DateTime today)
        {
            // a => a.ColumnName >= Today - 6 days && a.ColumnName <= Today
            return Expression.And(
                Expression.GreaterThanOrEqual(prop, Expression.Constant(today.AddDays(-6))),
                Expression.LessThan(prop, Expression.Constant(today.AddDays(1))));
        }

        private static Expression BuildLastWeekConditionExpression(Expression prop, DateTime today)
        {
            // a => a.ColumnName >= Today - 13 days && a.ColumnName < Today - 6 days
            return Expression.And(
                Expression.GreaterThanOrEqual(prop, Expression.Constant(today.AddDays(-13))),
                Expression.LessThan(prop, Expression.Constant(today.AddDays(-6))));
        }

        private static Expression BuildThisMonthConditionExpression(Expression prop, DateTime today)
        {
            var year = Expression.Property(prop, "Year");
            var month = Expression.Property(prop, "Month");

            // a => a.ColumnName.Year = Today.Year && a.ColumnName.Month = Today.Month
            var equalYear = Expression.Equal(year, Expression.Constant(today.Year));
            var equalMonth = Expression.Equal(month, Expression.Constant(today.Month));
            return Expression.And(equalYear, equalMonth);
        }

        private static Expression BuildLastMonthConditionExpression(Expression prop, DateTime today)
        {
            var year = Expression.Property(prop, "Year");
            var month = Expression.Property(prop, "Month");

            // a => a.ColumnName.Year = Today.Year && a.ColumnName.Month = Today.Month - 1
            var equalYear = Expression.Equal(year, Expression.Constant(today.Year));
            var equalMonth = Expression.Equal(month, Expression.Constant(today.AddMonths(-1).Month));
            return Expression.And(equalYear, equalMonth);
        }

        private static Expression BuildThisYearConditionExpression(Expression prop, DateTime today)
        {
            var year = Expression.Property(prop, "Year");

            // a => a.ColumnName.Year = Today.Year
            return Expression.Equal(year, Expression.Constant(today.Year));
        }

        private static Expression BuildLastYearConditionExpression(Expression prop, DateTime today)
        {
            var year = Expression.Property(prop, "Year");

            // a => a.ColumnName.Year = Today.Year - 1
            return Expression.Equal(year, Expression.Constant(today.AddYears(-1).Year));
        }

        private static Expression BuildContainsConditionExpression(Expression prop, string value, bool isValueNumber, Expression propLower, Expression valueLower)
        {
            Expression propertyAccess;
            if (!isValueNumber && prop.Type == typeof(string))
            {
                // Make the comparison case-insensitive for string properties
                MethodInfo stringContainsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                propertyAccess = Expression.Call(propLower, stringContainsMethod, valueLower);
            }
            else
            {
                // For numeric or other types, compare as-is
                propertyAccess = Expression.Equal(prop, Expression.Constant(value, prop.Type));
            }

            // Create an expression to check if the value is not null and the property comparison is true
            Expression condition = Expression.AndAlso(
                Expression.NotEqual(Expression.Constant(value, prop.Type), Expression.Constant(null)),
                propertyAccess
            );

            return condition;
        }

        private static object? GetValueNumber(string? value, Type type)
        {
            if (value == null || value == "")
            {
                return null;
            }
            if (type.Equals(typeof(int?)) || type.Equals(typeof(int)))
            {
                return value != null ? int.Parse(value) : null;
            }
            else if (type.Equals(typeof(float?)) || type.Equals(typeof(float)))
            {
                return value != null ? float.Parse(value) : null;
            }
            else
            {
                return value;
            }
        }
    }
}
