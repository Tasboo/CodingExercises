using System;
using System.Collections.Generic;

namespace RemoveDupe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Remove Duplicate Nodes");
            var ints = new int[]{1,2,8,1,5,3,2,2,4};
            var list = SetLinkedList(ints);
            Console.WriteLine("Inital linked list:");
            PrintLinkedList(list);
            Console.WriteLine("Remove duplicates with hashset:");
            RemoveDuplicatesWithHashSet(list);
            PrintLinkedList(list);
            list = SetLinkedList(ints);
            Console.WriteLine("Re-initalize linked list:");
            PrintLinkedList(list);
            Console.WriteLine("Remove duplicates without hashset:");
            RemoteDuplicatesWithoutHashSet(list);
            PrintLinkedList(list);

        }

        public static void RemoveDuplicatesWithHashSet(Node node)
        {
            HashSet<int> hs = new HashSet<int>();
            Node current = node;
            Node prev = null;
            while(current != null)
            {
                if(!hs.Add(current.value))
                {
                    if(prev != null)
                    {
                        prev.next = current.next;
                    }
                }
                else
                {
                    prev = current;
                }
                current = current.next;
            }
        }

        public static void RemoteDuplicatesWithoutHashSet(Node node)
        {
            Node head = node;
            Node current = node;
            Node prev = null;
            while(head != null)
            {
                current = head.next;
                while(current != null)
                {
                    if(head.value == current.value)
                    {
                        if(prev != null)
                        {
                            prev.next = current.next;
                        }
                    }
                    else
                    {
                        prev = current;
                    }
                    current = current.next;
                }
                head = head.next;
            }
        }
        public static Node SetLinkedList(int[] values)
        {
            Node root = null;
            Node current;
            Node prev = null;
            for(var i = 0; i < values.Length; i++)
            {   
                current = new Node(values[i]);
                if(prev != null){
                    prev.next = current;
                }
                else
                {
                    root = current;
                }
                prev = current;
                current = prev.next;
            }
            return root;
        }

        public static void PrintLinkedList(Node node)
        {
            var output = "";
            while(node != null)
            {
                if(output != ""){
                    output += " -> ";
                }
                output += node.value.ToString();
                node = node.next;
            }
            Console.WriteLine($"Linked list: {output}");
        }
    }

    public class Node
    {
        public int value {get;set;}
        public Node next {get;set;}

        public Node(int val)
        {
            value = val;
        }
    }
}
