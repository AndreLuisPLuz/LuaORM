using System.Linq.Expressions;
using LuaORM;

Analyzer.Analyze((a, b) => a + b + a * b);

namespace LuaORM
{
    public class Analyzer
    {
        public static void Analyze(Expression<Func<int, int, int>> exp)
        {
            var parameters = exp.Parameters;
            foreach (var p in parameters)
                Console.WriteLine(p.Name);
            
            var body = exp.Body;
            Console.WriteLine(body);

            var type = body.GetType;
            var nodeType = body.NodeType;

            Console.WriteLine(type);
            Console.WriteLine(nodeType);
        }
    }
}