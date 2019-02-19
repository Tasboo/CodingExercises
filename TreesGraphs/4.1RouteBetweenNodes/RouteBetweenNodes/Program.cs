using System;
using System.Collections;
using System.Collections.Generic;

namespace RouteBetweenNodes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Toute Between Nodes");

            var n0 = new GraphNode(0);
            var n1 = new GraphNode(1);
            var n2 = new GraphNode(2);
            var n3 = new GraphNode(3);
            var n4 = new GraphNode(4);
            var n5 = new GraphNode(5);

            n0.AddChild(n1);

            n1.AddChild(n2);
            n1.AddChild(n3);

            n2.AddChild(n3);
            n2.AddChild(n4);
            n2.AddChild(n1);

            n3.AddChild(n2);

            n4.AddChild(n3);

            n5.AddChild(n4);

            
            Console.WriteLine($"Expect route between node 1 and 5 to be true: {HasRoute(n1,n5)}");
            Console.WriteLine($"Expect route between node 0 and 5 to be false: {HasRoute(n0,n5)}");

        }

        public static bool HasRoute(GraphNode a, GraphNode b)
        {
            return(HasRouteToValue(a, b.val) || HasRouteToValue(b, a.val));
        }

        public static bool HasRouteToValue(GraphNode root, int val)
        {
            var q = new Queue<GraphNode>();
            var hs = new HashSet<int>();
            hs.Add(root.val);
            q.Enqueue(root);
            while(q.Count > 0){
                var n = q.Dequeue();
                if(n.val == val)
                    return true;
                foreach(var c in n.children){
                    if(hs.Add(c.val)){
                        q.Enqueue(c);
                    }
                }
            }
            return false;
        }
    }

    public class GraphNode{
        public int val;
        public List<GraphNode> children;

        public GraphNode(int v){
            val = v;
            children = new List<GraphNode>();
        }

        public void AddChild(GraphNode node){
            if(node.val == val)
                throw new Exception("Cannot have a child of itself");
            children.Add(node);
        }

    }
}
