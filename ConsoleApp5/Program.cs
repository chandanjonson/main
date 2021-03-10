using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
	class Program
	{

		static void Main(string[] args)
		{

			Tree tree = new Tree();
			
			//tree.root.left = new TreeNode(8);
			//tree.root.left.left = new TreeNode(4);
			//tree.root.left.right = new TreeNode(9);
			//tree.root.right = new TreeNode(12);
			//tree.root.right.left = new TreeNode(15);
			//tree.root.right.right = new TreeNode(7);
			//tree.root.left.left = new TreeNode(5);
			//tree.root.left.right = new TreeNode(6);
			//tree.root.left.right.left = new TreeNode(8);
			//tree.root.left.right.right = new TreeNode(12);
			tree.Traverse();


			Console.ReadKey();
		}
	}
}
