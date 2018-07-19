using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.DataStructure.LinkedList
{
    [ExampleClass]
    class ReverseDoublyLinkedList
    {
        class DoublyLinkedListNode
        {
            public int data;
            public DoublyLinkedListNode next;
            public DoublyLinkedListNode prev;

            public DoublyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
                this.prev = null;
            }
        }

        class DoublyLinkedList
        {
            public DoublyLinkedListNode head;
            public DoublyLinkedListNode tail;

            public DoublyLinkedList()
            {
                this.head = null;
                this.tail = null;
            }

            public void InsertNode(int nodeData)
            {
                DoublyLinkedListNode node = new DoublyLinkedListNode(nodeData);

                if (this.head == null)
                {
                    this.head = node;
                }
                else
                {
                    this.tail.next = node;
                    node.prev = this.tail;
                }

                this.tail = node;
            }
        }
        
        static DoublyLinkedListNode reverseDoublyLinkedList(DoublyLinkedListNode head)
        {
            DoublyLinkedListNode next = null;
            DoublyLinkedListNode prev = null;
            var curr = head;

            while (curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr.prev = next;

                curr = next;
            }
            head = prev;
            return head;
        }
        static void Main()
        {
            var linkedList = new DoublyLinkedList();
            linkedList.InsertNode(1);
            linkedList.InsertNode(2);
            linkedList.InsertNode(3);
            linkedList.InsertNode(4);

            var reversedList = reverseDoublyLinkedList(linkedList.head);
        }
    }
}
