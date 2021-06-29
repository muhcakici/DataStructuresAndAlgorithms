using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsApp.Cycle
{
    public class CycleDetector<T>
    {
        public bool HasCycle(IDiGraph<T> graph)
        {
            var visiting = new HashSet<T>();
            var visited = new HashSet<T>();
            foreach (var vertex in graph.VerticesAsEnumareble)
            {

            }

        }
    }
}
