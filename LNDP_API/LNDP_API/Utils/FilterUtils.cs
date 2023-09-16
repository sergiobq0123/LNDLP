using System.Linq.Expressions;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace TTTAPI.Utils {

    public class FilterUtils {

        public static Expression<Func<T, bool>> GetPredicate<T>(List<Filter> filters) {
            Expression<Func<T, bool>> predicate = PredicateBuilder.True<T>();
            foreach (Filter filter in filters) {
                var param = Expression.Parameter(typeof(T), "a"); // a =>
                var prop = Expression.Property(param, filter.DataKey); // a => a.ColumnName
                var value = filter.FilterInput;
                var valueInt = 0;
                bool isValueInt = int.TryParse(value, out valueInt);
                MethodCallExpression? propLower = null, valueLower = null;
                if (filter.Type.Equals("editableTextFields")) {
                    if (prop.Type.Equals(typeof(string))) {
                        propLower = Expression.Call(prop, typeof(string).GetMethod("ToLower", System.Type.EmptyTypes));
                    }
                    if (value != null && !isValueInt) {
                        valueLower = Expression.Call(Expression.Constant(value), typeof(string).GetMethod("ToLower", System.Type.EmptyTypes));
                    }
                }
                var day = prop;
                var month = prop;
                var year = prop;
                DateTime today = DateTime.UtcNow.Date;
                if (filter.Type == Filter.ContentType.DatePicker) {
                    prop = Expression.Property(prop, "Value");
                    day = Expression.Property(prop, "Day");
                    month = Expression.Property(prop, "Month");
                    year = Expression.Property(prop, "Year");
                }
                Expression call;
                switch (filter.Condition) {
                    case Filter.ConditionType.Is:
                        // a => a.ColumnName = value
                        if (filter.Type == Filter.ContentType.DropdownFields) {
                            call = Expression.Equal(prop, Expression.Convert(Expression.Constant(int.Parse(value)), prop.Type));
                        } else if (filter.Type == Filter.ContentType.DatePicker) {
                            call = Expression.And(Expression.GreaterThanOrEqual(prop, Expression.Constant(filter.StartDate)), Expression.LessThan(prop, Expression.Constant(filter.StartDate.Value.AddDays(1))));
                        } else {
                            if (isValueInt) {
                                call = Expression.Equal(prop, Expression.Convert(Expression.Constant(valueInt), prop.Type));
                            } else if (propLower != null) {
                                call = Expression.Equal(propLower, valueLower != null ? valueLower: Expression.Constant(value));
                            } else {
                                continue;
                            }
                        }
                        break;
                    case Filter.ConditionType.IsNot:
                        // a => a.ColumnName <> value
                        if (filter.Type == Filter.ContentType.DropdownFields) {
                            call = Expression.NotEqual(prop, Expression.Convert(Expression.Constant(int.Parse(value)), prop.Type));
                        } else {
                            if (isValueInt) {
                                call = Expression.NotEqual(prop, Expression.Convert(Expression.Constant(valueInt), prop.Type));
                            } else if (propLower != null) {
                                call = Expression.NotEqual(propLower, valueLower != null ? valueLower: Expression.Constant(value));
                            } else {
                                continue;
                            }
                        }
                        break;
                    case Filter.ConditionType.MoreOrEquals:
                        // a => a.ColumnName >= value
                        call = Expression.GreaterThanOrEqual(prop, Expression.Constant(filter.StartDate));
                        break;
                    case Filter.ConditionType.LessOrEquals:
                        // a => a.ColumnName <= value
                        call = Expression.LessThanOrEqual(prop, Expression.Constant(filter.StartDate));
                        break;
                    case Filter.ConditionType.Between:
                        // a => a.ColumnName >= start && a.ColumnName <= end
                        call = Expression.And(Expression.GreaterThanOrEqual(prop, Expression.Constant(filter.StartDate)), Expression.LessThanOrEqual(prop, Expression.Constant(filter.EndDate)));
                        break;
                    case Filter.ConditionType.Today:
                        // a => a.ColumnName >= Today && a.ColumnName < Tomorrow
                        call = Expression.And(Expression.GreaterThanOrEqual(prop, Expression.Constant(today)), Expression.LessThan(prop, Expression.Constant(today.AddDays(1))));
                        break;
                    case Filter.ConditionType.Yesterday:
                        // a => a.ColumnName >= Yesterday && a.ColumnName < Today
                        call = Expression.And(Expression.GreaterThanOrEqual(prop, Expression.Constant(today.AddDays(-1))), Expression.LessThan(prop, Expression.Constant(today)));
                        break;
                    case Filter.ConditionType.ThisWeek:
                        // a => a.ColumnName >= Today - 6 days && a.ColumnName <= Today
                        call = Expression.And(Expression.GreaterThanOrEqual(prop, Expression.Constant(today.AddDays(-6))), Expression.LessThan(prop, Expression.Constant(today.AddDays(1))));
                        break;
                    case Filter.ConditionType.LastWeek:
                        // a => a.ColumnName >= Today - 13 days && a.ColumnName < Today - 6 days
                        call = Expression.And(Expression.GreaterThanOrEqual(prop, Expression.Constant(today.AddDays(-13))), Expression.LessThan(prop, Expression.Constant(today.AddDays(-6))));
                        break;
                    case Filter.ConditionType.ThisMonth:
                        // a => a.ColumnName.Year = Today.Year && a.ColumnName.Month = Today.Month
                        var equalYear = Expression.Equal(year, Expression.Constant(today.Year));
                        var equalMonth = Expression.Equal(month, Expression.Constant(today.Month));
                        call = Expression.And(equalYear, equalMonth);
                        break;
                    case Filter.ConditionType.LastMonth:
                        // a => a.ColumnName.Year = Today.Year && a.ColumnName.Month = Today.Month - 1
                        equalYear = Expression.Equal(year, Expression.Constant(today.Year));
                        equalMonth = Expression.Equal(month, Expression.Constant(today.AddMonths(-1).Month));
                        call = Expression.And(equalYear, equalMonth);
                        break;
                    case Filter.ConditionType.ThisYear:
                        // a => a.ColumnName.Year = Today.Year
                        call = Expression.Equal(year, Expression.Constant(today.Year));
                        break;
                    case Filter.ConditionType.LastYear:
                        // a => a.ColumnName.Year = Today.Year - 1
                        call = Expression.Equal(year, Expression.Constant(today.AddYears(-1).Year));
                        break;
                    case Filter.ConditionType.Contains:
                    default:
                        // a => a.ColumnName.Contains(value)
                        if (value != null && isValueInt) {
                            MethodInfo methodContains = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                            MethodInfo methodToString = typeof(Convert).GetMethod("ToString", BindingFlags.Static | BindingFlags.Public, Type.DefaultBinder, new Type[] { typeof(int) }, null);
                            var stringProperty = Expression.Call(null, methodToString, Expression.Convert(prop, typeof(int)));
                            call = Expression.Call(stringProperty, methodContains, Expression.Constant(value, typeof(string)));
                        } else if (value != null && propLower != null) {
                            call = Expression.Call(propLower, "Contains", new Type[0], valueLower != null ? valueLower: Expression.Constant(value));
                        } else {
                            continue;
                        }
                        break;
                }
                predicate = predicate.And(Expression.Lambda<Func<T, bool>>(call, param));
            }
            return predicate;
        }
    }
}
