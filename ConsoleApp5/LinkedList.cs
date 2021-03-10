using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
	public class Node
	{
		public int Data;
		public Node next;

		public Node(int Data)
		{
			this.Data = Data;
			this.next = null;
		}
	}

	public class LinkedList
	{
		//create two type of Node
		private Node head = null;
		private Node Tail = null;

		///
		///insert function
		///by passing data as parameter

		public void Insert(int Data)
		{
			//first check whether head is null or not
			Node newnode = new Node(Data);
			Node cur = head;
			if (head == null)
			{
				head = newnode;
				Tail = newnode;
				Tail.next = null;
			}
			else
			{
				Tail.next = newnode;
				Tail = newnode;
				Tail.next = null;
			}
		}

		///Suppose we want to traverse the linkedList
		///TraverseLinkedList
		public void TraverseLinkedList()
		{
			var temp = ReverseList(head);

			while (temp != null)
			{
				Console.WriteLine(temp.Data);
				temp = temp.next;
			}
			var res = LengthOfNode();
			Console.WriteLine($"Total Length of linked lsit{res}");
		}

		public int LengthOfNode()
		{

			int count = 0;
			Node temp = head;
			while (temp != null)
			{
				count++;
				temp = temp.next;
			}
			return count;

		}

		public Node DeleteDuplicateReord()
		{
			Node first = head;
			Node newnode = new Node(-1);
			newnode = first;
			Node second = head.next;
			while (first != null && second != null)
			{
				if (first.Data == second.Data)
				{
					while (second != null && first.Data == second.Data)
					{
						second = second.next;
					}
					first.next = second;
					first = second;
					if (first != null)
					{
						second = first.next;
					}
				}
				else
				{
					first = second;
					second = second.next;
				}
			}
			return newnode;
		}

		public void DeleteKthNodeFromEnd()
		{
			int k = 10;
			//first get the length of node
			int count = LengthOfNode();
			int d = count - k;
			Console.WriteLine();
			Node cur = head;
			Node prev = null;
			if (d == 0)
			{
				head = head.next;
			}
			else
			{
				while (cur != null)
				{
					if (d == 0)
					{
						prev.next = cur.next;
						cur.next = null;
						break;
					}
					prev = cur;
					cur = cur.next;
					d--;
				}
			}
		}

		public void DeleteNode(int Data)
		{
			Node cur = head;
			Node prev = null;
			if (head == null)
			{
				return;
			}

			while (cur != null)
			{
				if (Data == head.Data)
				{
					head = head.next;
					break;
				}

				else if (cur.Data == Data)
				{
					if (cur.Data == Tail.Data)
					{
						Tail = prev;
						Tail.next = null;
						break;
					}
					else
					{
						prev.next = cur.next;
						cur.next = null;
						break;
					}
				}
				prev = cur;
				cur = cur.next;

			}
		}

		public static Node SumOfLinkedLists(Node L1, Node L2)
		{
			Node dummy = new Node(-1);
			Node cur = dummy;
			Node first = L1;
			Node second = L2;
			int c = 0;
			while (first != null && second != null)
			{

				int sum = first.Data + second.Data + c;
				c = sum / 10;
				int num = sum % 10;
				Node newnode = new Node(num);
				cur.next = newnode;
				cur = newnode;
				first = first.next;
				second = second.next;
			}
			//now try to add remaining node 
			while (first != null)
			{
				int sum = first.Data + c;
				Node newnode = new Node(sum);
				cur.next = newnode;
				cur = newnode;
			}

			return dummy.next;
		}

		public void DeleteDuplicatedusortedList()
		{
			HashSet<int> s = new HashSet<int>();
			Node cur = head;
			Node prev = null;
			while (cur != null)
			{
				if (s.Contains(cur.Data))
				{
					prev.next = cur.next;

				}
				else
				{
					s.Add(cur.Data);
					prev = cur;
				}
				cur = cur.next;
			}
		}

		class Index
		{
			public int val = 0;

		}
		public Node FindKthElementInLinkedList(Node head, int k)
		{
			Index p = new Index();

			return helperFindKthElementInLinkedList(head, k, p);
		}

		private Node helperFindKthElementInLinkedList(Node head, int k, Index p)
		{
			if (head == null)
			{
				return null;
			}

			var node = helperFindKthElementInLinkedList(head.next, k, p);
			Console.WriteLine($"printing value of p{p.val}");
			p.val += 1;

			if (p.val == k)
			{
				return head;
			}
			return node;
		}


		public void RemoveMiddleElement()
		{
			Node first = head;
			Node second = head;

			while (second.next != null)
			{

				second = second.next.next;
				if (second == null)
					break;
				first = first.next;
			}

		}

		public Node ReverseList(Node head)
		{

			//first base condition
			if (head.next == null)
				return head;


			Node temp = ReverseList(head.next);
			head.next.next = head;
			head.next = null;

			return temp;
		}
		public bool isreversed()
		{
			Stack<int> st = new Stack<int>();
			//craete two pointer first as slow node and next fast node 
			Node slow = head;
			Node fast = head;
			while (fast != null && fast.next != null)
			{
				st.Push(slow.Data);
				slow = slow.next;
				fast = fast.next.next;
			}
			//if ist odd
			if (fast != null)
			{
				slow = slow.next;
			}

			while (slow != null)
			{
				int val = st.Pop();
				if (val != slow.Data)
					return false;
				slow = slow.next;
			}


			return true;
		}


		public Node OddEvenList()
		{

			Node dummy = new Node(-1);
			Node first = head;
			Node second = head.next;
			Node cur = dummy;
			while (first != null)
			{
				cur.next = first;
				cur = first;
				if (first.next == null)
					break;
				first = first.next.next;
			}
			while (second != null)
			{
				cur.next = second;
				cur = second;
				second = second.next.next;
			}
			return dummy.next;

		}


	}
}
