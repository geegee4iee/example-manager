using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExampleManager.ExpressionTree
{
    [ExampleClass]
    class ExpressionExamples
    {
        static void Main()
        {
            Expression<Func<int, int>> addFive = (n) => n + 5;

            if (addFive.NodeType == ExpressionType.Lambda)
            {
                var lambdaExp = (LambdaExpression)addFive;
                var parameter = lambdaExp.Parameters.First();

                Console.WriteLine(addFive.Body.NodeType);
            }

            var a = addFive.Compile();
        }
    }
}
