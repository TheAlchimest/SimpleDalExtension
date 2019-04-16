using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFContextExtension
{
    public static class ParametersReaderExtensions
    {
        private static readonly string expressionCannotBeNullMessage = "The expression cannot be null.";
        private static readonly string invalidExpressionMessage = "Invalid expression.";
        /*
         public static string GetName<T>(Expression<Func<T>> e)
{
    var member = (MemberExpression)e.Body;
    return member.Member.Name;
}
             
             */
        public static string GetMemberName<T>(this T instance, Expression<Func<T, object>> expression)
        {
            return GetMemberName(expression.Body);
        }
      /*  public static T GetMemberValue<T>(this T instance, Expression<Func<T, object>> expression)
        {
            var value = expression.Compile()();
            return value;
        }*/
     //   public static List<SqlParameter> GetMemberParameters<T>(this T instance, params Expression<Func<T,object>>[] expressions)
        public static List<SqlParameter> GetMemberParameters<T>(this T instance, params Expression<Func<T, object>>[] expressions)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string name = null;
            object value ;
            SqlParameter p = new SqlParameter();

            foreach (var cExpression in expressions)
            {
                name = GetMemberName(cExpression.Body);
                PropertyInfo prop = (PropertyInfo)((MemberExpression)cExpression.Body).Member;
                value = prop.GetValue(instance);
                p = new SqlParameter(name, value);
                parameters.Add(p);
            }

            return parameters;
            //------------------------------------------------------
            List<string> memberNames = new List<string>();
            foreach (var cExpression in expressions)
            {
                //-------------------------------------------------------
                
            }
            //------------------------------------------------------
            return memberNames;
            //------------------------------------------------------
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
