using System;

namespace StackMin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var ints = new int[]{ 3, -12, 200, 8, 17, 34, -2, -19, 90 };
            var stack = new MyStack();
            foreach(var i in ints){
                Console.WriteLine($"Adding the number {i} to the stack");
                stack.Push(i);
            }
            Console.WriteLine($"Minimum value should be -19: {stack.Min()}");
            stack.Pop();
            stack.Pop();
            stack.Pop();
            Console.WriteLine($"Popped the stack a few times.  New min should be -12: {stack.Min()}");
        }
    }

    public class MyStack
    {
        public class StackNode{
            public int data;
            public StackNode next;
            public int min;
            public StackNode(int d){
                data = d;
                min = d;
            }
        }
        public StackNode Top;
        public void Push(int data){
            var newNode = new StackNode(data);
            newNode.next = Top;
            Top = newNode;
            if(newNode.next != null && newNode.next.min < newNode.min){
                newNode.min = newNode.next.min;
            }
        }
        public int Pop(){
            int val = Top.data;
            Top = Top.next;
            return val;
        }
        public int Min(){
            return Top.min;
        }
    }
}
