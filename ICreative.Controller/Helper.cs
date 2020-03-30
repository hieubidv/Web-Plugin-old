
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;
using System.Linq.Expressions;
using ICreative.Services.ViewModels;
using ICreative.Controllers.ViewModels;
using ICreative.Controllers.ViewModels.Security;
using System.Security.Cryptography;
namespace ICreative.Controllers
{
    public static class Helper
    {
        public static string[] ConvertCollectionToStringArray(IList<PermissionView> permissions)
        {
            List<string> rights = new List<string>();

            rights.Add("Guest");
            foreach (PermissionView permission in permissions)
            {
                rights.Add(permission.PermissionName);
            }

            return rights.ToArray();
        }

        public static IEnumerable<T> GenerateIndex<T>(IEnumerable<T> items)
        {
            List<T> output = new List<T>();
            PropertyInfo indexProp = null;
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                if (prop.Name == "Index" && prop.PropertyType == typeof(int))
                {
                    indexProp = prop;
                    break;
                }
            }
            int index = 0;
            if (indexProp != null)
            {
                foreach (T item in items)
                {
                    index++;
                    indexProp.SetValue(item, index, null);
                    output.Add(item);
                }
                return output;
            }
            else
            {
                return items;
            }
        }


        public static string ToCsv<T>(string separator, IEnumerable<T> objectlist,List<string> fieldNames)
        {
            Type t = typeof(T);
            FieldInfo[] alllfields = t.GetFields(BindingFlags.NonPublic| BindingFlags.Instance);

            List<FieldInfo> fields = new List<FieldInfo>();
            foreach(FieldInfo f in alllfields)
            {
                if (fieldNames.Contains(f.Name.Remove(f.Name.Length - 16, 16).Remove(0, 1)))
                {
                    fields.Add(f);
                }
            }
            string header = String.Join(separator, fields.Select(f => f.Name.Remove(f.Name.Length - 16, 16).Remove(0, 1)).ToArray());

            StringBuilder csvdata = new StringBuilder();
            csvdata.AppendLine(header);

            foreach (var o in objectlist)
                csvdata.AppendLine(ToCsvFields(separator, fields, o));

            return csvdata.ToString();
        }

        private static string ToCsvFields(string separator,  List<FieldInfo> fields, object o)
        {
            StringBuilder linie = new StringBuilder();

            foreach (var f in fields)
            {
                if (linie.Length > 0)
                    linie.Append(separator);

                var x = f.GetValue(o);

                if (x != null)
                    linie.Append(x.ToString());
            }

            return linie.ToString();
        }


        public static string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();

                for(int i= 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString());
                }
                return sb.ToString();
            }
        }

        public static Expression<Func<T, bool>> GetSearchExpression<T>(string[] propertyNames, string propertyValue)
        {
            Expression compoundExp = null;

            PropertyInfo[] propertyInfos = typeof(T).GetProperties();

            var parameterExp = Expression.Parameter(typeof(T), "type");
            foreach (var prop in propertyNames)
            {
                var propType = typeof(string);
                 foreach (PropertyInfo propInfo in propertyInfos)
                {
                    if (propInfo.Name == prop)
                    {
                        propType = propInfo.PropertyType;
                        break;
                    }
                }
                Expression lamdaExp = null;
                if (propType == typeof(string))
                {
                    var propertyExp = Expression.Property(parameterExp, prop);
                    LabelTarget returnTarget = Expression.Label(typeof(bool));
                    MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    var someValue = Expression.Constant(propertyValue, typeof(string));
                    var containsMethodExp = Expression.Call(propertyExp, method, someValue);
                    Expression test = Expression.Equal(propertyExp, Expression.Constant(null));
                    Expression iffalse = Expression.Return(returnTarget, containsMethodExp);
                    Expression iftrue = Expression.Return(returnTarget, Expression.Constant(false));
                  
                    lamdaExp = Expression.Block(Expression.IfThenElse(test, iftrue, iffalse),
                                              Expression.Label(returnTarget, Expression.Constant(false)));
                }
                else
                {
                    var propertyExp = Expression.Property(parameterExp, prop);
                    LabelTarget returnTarget = Expression.Label(typeof(bool));
                    var propertyExp2 = Expression.Call(propertyExp, "ToString", Type.EmptyTypes);
                    MethodInfo method2 = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    var someValue = Expression.Constant(propertyValue, typeof(string));
                    var containsMethodExp = Expression.Call(propertyExp2, method2, someValue);

                    Expression test = Expression.Equal(propertyExp, Expression.Default(propType));
                    Expression iffalse = Expression.Return(returnTarget, containsMethodExp);
                    Expression iftrue = Expression.Return(returnTarget, Expression.Constant(false));

                    lamdaExp = Expression.Block(Expression.IfThenElse(test, iftrue, iffalse),
                                              Expression.Label(returnTarget, Expression.Constant(false)));
                }
                if (compoundExp != null)
                {
                    compoundExp =Expression.Or(compoundExp, lamdaExp);
                }
                else
                {
                    compoundExp = lamdaExp;
                }                
            }
            return Expression.Lambda<Func<T, bool>>(compoundExp, parameterExp); ;
        }

        public static List<RightView> ConvertRolesToRights(IList<RoleView> roles)
        {
            List<RightView> rights = new List<RightView>();
            foreach(RoleView role in roles)
            {
                foreach(PermissionView permission in role.Permissions)
                {
                    var existRight = rights.Where(u => (u.ActionName == permission.ActionName && u.ControllerName == permission.ControllerName)).FirstOrDefault();
                    if (existRight == null)
                    {
                        rights.Add(new RightView() { ControllerName = permission.ControllerName, ActionName = permission.ActionName });
                    }
                }
            }
            return rights;
        }
        public static IEnumerable<T> SortingData<T>(IEnumerable<T> users, SortExpression sortExpression)
        {
            if (sortExpression != null)
            {
                PropertyInfo sortBy = typeof(T).GetProperty(sortExpression.SortBy);
                if (sortExpression.SortDirection == ListSortDirection.Ascending)
                {
                    users = users.OrderBy(u => sortBy.GetValue(u, null));
                }
                else
                {
                    users = users.OrderByDescending(u => sortBy.GetValue(u, null));
                }
            }
            else
            {
              //  PropertyInfo sortBy = typeof(T).GetProperty("UserId");
              //  users = users.OrderBy(u => sortBy.GetValue(u, null));
            }
            return users;
        }


        public static void SetSortDirection(SortSetting sortSetting)
        {
            if (sortSetting.SortExpression == sortSetting.LastSortExpression)
            {
                if (sortSetting.SortDirection == ListSortDirection.Ascending)
                    sortSetting.SortDirection = ListSortDirection.Descending;
                else
                    sortSetting.SortDirection = ListSortDirection.Ascending;
            }
            else
            {
                sortSetting.SortDirection = sortSetting.SortDirectionNew;
            }
        }


        public static WebPagerItemCollection CreatePagerItems(WebPager pager)
        {
          //  pager.SetPagerProperties(string.Empty);

            WebPagerItemCollection Pages = new WebPagerItemCollection(
              pager.TotalRecords,
              pager.PageSize,
              pager.PageIndex);
              pager.TotalPages = Pages.PageCount;

            return Pages;
        }

    }
}
