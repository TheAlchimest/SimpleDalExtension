using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDalExtension
{
    public static class ParametersReaderExtensions
    {
        private static readonly string expressionCannotBeNullMessage = "The expression cannot be null.";
        private static readonly string invalidExpressionMessage = "Invalid expression.";

        public static string GetMemberName<T>(this T instance, Expression<Func<T, object>> expression)
        {
            return GetMemberName(expression.Body);
        }

        public static CustomDbParameterList GetMemberParameters<T>(this T instance, params Expression<Func<T, object>>[] expressions)
        {
            string name = null;
            object value;
            CustomDbParameterList plist = new CustomDbParameterList();
            PropertyInfo prop;
            foreach (var cExpression in expressions)
            {
                name = GetMemberName(cExpression.Body);
                if (cExpression.Body is MemberExpression)
                {
                    prop = (PropertyInfo)((MemberExpression)cExpression.Body).Member;
                }
                else
                {
                    var op = ((UnaryExpression)cExpression.Body).Operand;
                    prop= (PropertyInfo)((MemberExpression)op).Member;
                }
               // prop = (PropertyInfo)((MemberExpression)cExpression.Body).Member;
                value = prop.GetValue(instance);
                plist.Add(name, value);
                
                /*p = new SqlParameter(name, value);
                parameters.Add(p);*/
            }
             return plist; 
        }

        public static string GetMemberName<T>(this T instance, Expression<Action<T>> expression)
        {
            return GetMemberName(expression.Body);
        }

        private static string GetMemberName(Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentException(expressionCannotBeNullMessage);
            }

            if (expression is MemberExpression)
            {
                // Reference type property or field
                var memberExpression = (MemberExpression)expression;
                return memberExpression.Member.Name;
            }

            if (expression is MethodCallExpression)
            {
                // Reference type method
                var methodCallExpression = (MethodCallExpression)expression;
                return methodCallExpression.Method.Name;
            }

            if (expression is UnaryExpression)
            {
                // Property, field of method returning value type
                var unaryExpression = (UnaryExpression)expression;
                return GetMemberName(unaryExpression);
            }

            throw new ArgumentException(invalidExpressionMessage);
        }

        private static string GetMemberName(UnaryExpression unaryExpression)
        {
            if (unaryExpression.Operand is MethodCallExpression)
            {
                var methodExpression = (MethodCallExpression)unaryExpression.Operand;
                return methodExpression.Method.Name;
            }

            return ((MemberExpression)unaryExpression.Operand).Member.Name;
        }
    }
}
