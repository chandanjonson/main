using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp5
{
	public class TreeNode
	{
		public int data;

		public TreeNode left;
		public TreeNode right;
		public TreeNode next;
		public int count;
		public TreeNode(int data)
		{
			this.data = data;
		}
		public TreeNode(int data, int count)
		{
			this.data = data;
			this.count = count;
		}

	}

	public class Tree
	{
		public TreeNode root;
		public string splitter = ",";
		public string end = "x";
		public int depth { get; set; }
		public Tree()
		{
			root = null;
		}

		public void Inorder(TreeNode node)
		{

			if (node == null)
			{
				return;
			}

			//traverse left
			Inorder(node.left);
			Console.WriteLine(node.data);
			Inorder(node.right);
		}

		public IList<IList<int>> PreorderTraversal(TreeNode root)
		{

			//write helper method
			return HelperFuncPreorderTraversal(root);

		}

		public IList<IList<int>> HelperFuncPreorderTraversal(TreeNode root)
		{
			//crate stack

			var lst = new List<List<int>>();

			Stack<TreeNode> stack = new Stack<TreeNode>();

			stack.Push(root);

			while (stack.Count > 0)
			{

				var current = stack.Peek();
				stack.Pop();

				lst.Add(new List<int>());

				if (current.right != null)
				{
					stack.Push(current.right);
				}

				if (current.left != null)
				{
					stack.Push(current.left);
				}
			}

			return (IList<IList<int>>)lst;


		}

		public IList<int> InorderTraversal(TreeNode root)
		{
			//write helper method
			return HelperFuncInorderTraversal(root);
		}

		private IList<int> HelperFuncInorderTraversal(TreeNode root)
		{
			Stack<TreeNode> stack = new Stack<TreeNode>();

			IList<int> lst = new List<int>();


			var cur = root;
			while (cur != null || stack.Count > 0)
			{

				while (cur != null)
				{

					stack.Push(cur);

					cur = cur.left;
				}

				cur = stack.Pop();
				lst.Add(cur.data);
				cur = cur.right;

			}


			return lst;

		}


		public List<List<int>> LevelOrder(TreeNode root)
		{
			return HelperLevelOrder(root);

		}

		public List<List<int>> HelperLevelOrder(TreeNode root)
		{
			var lst = new List<List<int>>();

			Queue<TreeNode> queue = new Queue<TreeNode>();

			queue.Enqueue(root);

			//implement qeue
			int level = 0;
			var l = new List<int>();

			while (queue.Count > 0)
			{
				lst.Add(new List<int>());

				int size = queue.Count;

				for (int i = 0; i < size; i++)
				{
					var current = queue.Dequeue();

					lst[level].Add(current.data);

					if (current.left != null) queue.Enqueue(current.left);

					if (current.right != null) queue.Enqueue(current.right);

				}

				level += 1;

			}

			return lst;

		}

		public int MaxDepth(TreeNode root)
		{
			return helperMaxDepth(root, 0);

		}

		public int helperMaxDepth(TreeNode root, int i)
		{

			if (root.left == null && root.right == null)
			{
				return depth = Math.Max(depth, i);
			}

			helperMaxDepth(root.left, i + 1);


			helperMaxDepth(root.right, i + 1);


			return depth;

		}

		public bool HasPathSum(TreeNode root, int sum)
		{

			return HelperathSum(root, sum);
		}

		public bool HelperathSum(TreeNode root, int sum)
		{


			if (root == null)
			{
				return false;
			}
			sum -= root.data;

			if (root.left == null && root.right == null)
			{
				return (sum == 0);
			}

			return
				HelperathSum(root.left, sum) ||
				HelperathSum(root.right, sum);

		}


		public void PrintKthNode(TreeNode root, int k)
		{

			//base condition
			if (root == null)
			{
				return;
			}

			if (k == 0)
			{
				Console.WriteLine(root.data);
				return;
			}
			PrintKthNode(root.left, k - 1);
			PrintKthNode(root.right, k - 1);

		}


		public int NumberOfNodes(TreeNode root)
		{
			return HelperNumberOfNodes(root);
		}

		public int HelperNumberOfNodes(TreeNode root)
		{
			if (root == null)
			{
				return 0;
			}
			return 1 + HelperNumberOfNodes(root.left) +
			HelperNumberOfNodes(root.right);

		}

		public int MaxPathSum(TreeNode root)
		{
			int res = H1elperMaxathSum(root);

			return res;
		}
		int max = Int32.MinValue;
		public int HelperMaxathSum(TreeNode root)
		{

			if (root == null)
			{
				return 0;
			}

			int left_gain = Math.Max(HelperMaxathSum(root.left), 0);
			int right_gain = Math.Max(HelperMaxathSum(root.right), 0);

			int newpathsum = root.data + left_gain + right_gain;

			max = Math.Max(max, newpathsum);

			return root.data + left_gain + right_gain;

		}
		int res = Int32.MinValue;
		public int H1elperMaxathSum(TreeNode root)
		{

			if (root == null)
			{
				return 0;
			}

			max = Math.Max((root.data + H1elperMaxathSum(root.left)), (root.data + H1elperMaxathSum(root.right)));

			if (max > res)
			{
				res = max;
			}

			return max;
		}

		public IList<IList<int>> LevelOrderBottom(TreeNode root)
		{
			return HelperLevelOrderBottom(root);
		}

		private IList<IList<int>> HelperLevelOrderBottom(TreeNode root)
		{

			IList<IList<int>> lst = new List<IList<int>>();

			Stack<List<int>> stack = new Stack<List<int>>();

			Queue<TreeNode> queue = new Queue<TreeNode>();

			queue.Enqueue(root);
			while (queue.Count > 0)
			{
				int size = queue.Count;
				List<int> l = new List<int>();
				for (int i = 0; i < size; i++)
				{
					var curent = queue.Dequeue();

					l.Add(curent.data);

					if (curent.left != null) queue.Enqueue(curent.left);
					if (curent.right != null) queue.Enqueue(curent.right);

				}
				stack.Push(l);
			}

			while (stack.Count > 0)
			{
				lst.Add(stack.Pop());
			}

			return lst;

		}

		public TreeNode InvertBinaryTree(TreeNode root)
		{

			return HelperInvertBinaryTree(root);

		}

		public TreeNode HelperInvertBinaryTree(TreeNode root)
		{
			if (root == null)
			{
				return null;
			}

			var left = HelperInvertBinaryTree(root.left);
			var right = HelperInvertBinaryTree(root.right);

			root.left = right;
			root.right = left;

			return root;

		}

		Dictionary<TreeNode, TreeNode> dic = new Dictionary<TreeNode, TreeNode>();
		public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
		{
			return HelperLowestCommonAncestor(root, p, q, dic);


		}

		private TreeNode HelperLowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q, Dictionary<TreeNode, TreeNode> dic)
		{

			Queue<TreeNode> nodes = new Queue<TreeNode>();
			dic.Add(root, null);
			nodes.Enqueue(root);
			while (!dic.ContainsKey(p) || !dic.ContainsKey(q))
			{
				var current = nodes.Dequeue();

				if (current.left != null)
				{
					nodes.Enqueue(current.left);
					dic.Add(current.left, current);
				}
				if (current.right != null)
				{
					nodes.Enqueue(current.right);
					dic.Add(current.right, current);
				}

			}

			HashSet<TreeNode> set = new HashSet<TreeNode>();

			while (p != null)
			{
				set.Add(p);
				p = dic[p];
			}

			while (!set.Contains(q))
			{
				q = dic[q];


			}
			return q;

		}

		private void HelprtFillDic(TreeNode root, TreeNode par)
		{


			if (root == null)
			{
				return;
			}
			dic.Add(root, par);

			HelprtFillDic(root.left, root);
			HelprtFillDic(root.right, root);

		}

		List<int> KthNodesFromTarget(TreeNode root, int k)
		{
			HelperKthNodesFromTarget(root, k);

			return kthlst;
		}
		List<int> kthlst = new List<int>();
		public List<int> HelperKthNodesFromTarget(TreeNode root, int k)
		{

			if (root == null)
				return kthlst;

			if (k == 0)
			{
				kthlst.Add(root.data);
			}

			HelperKthNodesFromTarget(root.left, k - 1);

			HelperKthNodesFromTarget(root.right, k - 1);

			return kthlst;
		}
		public List<int> HelperKthNodesFromTargetUpper(TreeNode root, TreeNode target, int k)
		{
			HelprtFillDic(root, null);


			Queue<Tuple<TreeNode, int>> tuples = new Queue<Tuple<TreeNode, int>>();
			//intailization of first queue
			tuples.Enqueue(new Tuple<TreeNode, int>(target, 0));
			HashSet<TreeNode> SEEN = new HashSet<TreeNode>();
			SEEN.Add(target);
			while (tuples.Count > 0)
			{
				var cur = tuples.Dequeue();
				int currentdist = cur.Item2;
				var node = cur.Item1;
				if (currentdist == k)
				{
					kthlst.Add(cur.Item1.data);
					foreach (var data in tuples)
					{
						kthlst.Add(data.Item1.data);

					}
					return kthlst;
				}

				List<TreeNode> ls = new List<TreeNode>();

				ls.Add(node.left);
				ls.Add(node.right);
				ls.Add(dic[node]);
				foreach (var v in ls)
				{
					if (v == null) continue;
					if (!SEEN.Contains(v))
					{
						SEEN.Add(v);
						tuples.Enqueue(new Tuple<TreeNode, int>(v, currentdist + 1));
					}
				}

			}

			return kthlst;

		}
		int diameter = 0;
		int maxDiameter = 0;
		public int FindDiameter(TreeNode root)
		{
			if (root == null)
			{
				return 0;
			}
			int left = FindDiameter(root.left);
			int right = FindDiameter(root.right);

			diameter = left + right + 1;

			if (maxDiameter < diameter)
			{
				maxDiameter = diameter;
			}

			return Math.Max(left, right) + 1;

		}
		List<int> lst = new List<int>();
		public int kthsmallest(TreeNode A, int B)
		{


			if (A == null)
			{
				return 0;
			}
			helper(A);
			return lst[B - 1];
		}

		Dictionary<int, int> d = new Dictionary<int, int>();



		void helper(TreeNode A)
		{

			if (A == null)
			{
				return;
			}


			helper(A.left);
			lst.Add(A.data);
			helper(A.right);
		}


		public void printbounary(TreeNode root)
		{
			if (root == null)
				return;

			Heloperprintbounary(root);
			RHeloperprintbounary(root.right);
			Heloperprintbottom(root);

		}

		private void Heloperprintbottom(TreeNode root)
		{
			if (root == null)
			{
				return;
			}
			if (root.left == null && root.right == null)
			{
				Console.WriteLine(root.data);
			}
			Heloperprintbottom(root.left);
			Heloperprintbottom(root.right);
		}

		public void Heloperprintbounary(TreeNode root)
		{
			if (root == null)
			{
				return;
			}
			if (root.left != null && root.right != null)
			{
				Console.WriteLine(root.data);
			}

			if (root.left == null)
				Heloperprintbounary(root.right);
			Heloperprintbounary(root.left);
		}

		public void RHeloperprintbounary(TreeNode root)
		{
			if (root == null)
			{
				return;
			}
			if (root.left != null && root.right != null)
			{
				Console.WriteLine(root.data);
			}

			if (root.right == null)
				RHeloperprintbounary(root.left);
			RHeloperprintbounary(root.right);
		}

		public void bottomviewofnodes(TreeNode root)
		{
			Dictionary<int, List<(int, int)>> map = new Dictionary<int, List<(int, int)>>();
			helperbottomviewofnodes(root, 0, 0, map);

			var omap = map.OrderBy(x => x.Key).ToArray();

			IList<IList<int>> res = new List<IList<int>>();

			for (int i = 0; i < omap.Length; i++)
			{
				var r = omap[i].Value.OrderBy(x => x.Item2).Select(x => x.Item1).ToList();
				res.Add(r);
			}
		}

		void helperbottomviewofnodes(TreeNode root, int diatnace, int level, Dictionary<int, List<(int, int)>> map)
		{
			if (root == null)
				return;

			if (!map.ContainsKey(diatnace))
			{
				map.Add(diatnace, new List<(int, int)> { (root.data, level) });
			}
			else
			{

				map[diatnace].Add((root.data, level));

			}
			helperbottomviewofnodes(root.left, diatnace - 1, level + 1, map);
			helperbottomviewofnodes(root.right, diatnace + 1, level + 1, map);
		}

		public void printSameNode(TreeNode root)
		{
			HelperPrintSameNode(root);
			Console.WriteLine(count1);
		}
		int count1 = 0;
		private bool HelperPrintSameNode(TreeNode root)
		{
			if (root.left == null && root.right == null)
			{
				count1++;
				return true;
			}
			bool istrue = true;

			istrue = HelperPrintSameNode(root.left) && HelperPrintSameNode(root.right) && istrue && (root.left.data == root.data);

			if (!istrue) return false;
			count1++;
			return true;
		}

		Dictionary<int, int> dic2 = new Dictionary<int, int>();
		int current = 0;
		public TreeNode BuildTree1(int[] inorder, int[] postorder)
		{
			for (int i = 0; i < inorder.Length; i++)
			{
				dic2.Add(inorder[i], i);

			}
			current = inorder.Length - 1;
			return HelperBuildTree(inorder, postorder, 0, inorder.Length - 1);
		}

		public TreeNode HelperBuildTree(int[] inorder, int[] postorder, int start, int end)
		{
			if (start > end)
			{
				return null;
			}

			TreeNode node = new TreeNode(postorder[current]);

			current--;

			int idx = dic2[node.data];
			node.right = HelperBuildTree(inorder, postorder, idx + 1, end);
			node.left = HelperBuildTree(inorder, postorder, start, idx - 1);

			return node;

		}

		public TreeNode BuildTree(int[] preorder, int[] inorder)
		{

			for (int i = 0; i < inorder.Length; i++)
			{
				dic2.Add(inorder[i], i);
			}

			return Helper(preorder, 0, preorder.Length - 1);


		}

		public TreeNode Helper(int[] preorder, int start, int end)
		{
			//base condition
			if (start > end)
			{

				return null;
			}

			TreeNode node = new TreeNode(preorder[current]);
			current++;
			Console.Write(current);
			int idx = dic2[node.data];

			node.left = Helper(preorder, start, idx - 1);

			node.right = Helper(preorder, idx + 1, end);

			return node;

		}

		StringBuilder sb = new StringBuilder();
		public string serialize(TreeNode root)
		{

			helperserialize(root);
			return sb.ToString();

		}

		public void helperserialize(TreeNode root)
		{
			if (root == null)
			{
				sb.Append(end).Append(splitter);
				return;
			}
			sb.Append(root.data).Append(splitter);

			helperserialize(root.left);
			helperserialize(root.right);

		}

		// Decodes your encoded data to tree.
		public TreeNode deserialize(string str)
		{
			Queue<string> q = new Queue<string>();
			var res = str.Split(splitter);
			foreach (var v in res)
			{
				q.Enqueue(v);
			}

			var rot = BuildDserailize(q);
			return rot;
		}

		private TreeNode BuildDserailize(Queue<string> q)
		{
			var current = q.Dequeue();
			if (current == end)
			{
				return null;
			}
			TreeNode node = new TreeNode(Convert.ToInt32(current));

			node.left = BuildDserailize(q);
			node.right = BuildDserailize(q);
			return node;
		}
		public int FindClosestdataueInBst(TreeNode root, int target)
		{
			// Write your code here.

			var e = lst.GetEnumerator();


			res = serachinright(root, target);
			return res;
		}
		int mindataue = Int32.MaxValue;
		int res1 = 0;
		public int serachinright(TreeNode tree, int target)
		{
			if (tree == null)
			{
				return res1;
			}
			if (lst.Contains(target))

				if (mindataue > Math.Abs(target - tree.data))
				{
					mindataue = Math.Abs(target - tree.data);
					res1 = tree.data;
				}

			serachinright(tree.right, target);
			serachinright(tree.left, target);
			return res1;
		}
		public TreeNode InsertIntoBST(TreeNode root, int data)
		{
			return helper(root, data, null);

		}
		public TreeNode helper(TreeNode root, int item, TreeNode par)
		{
			if (root == null)
			{
				TreeNode node = new TreeNode(item);
				return node;
			}
			if (item <= root.data)
			{
				var node = helper(root.left, item, root);
				root.left = node;
			}
			else
			{
				var node = helper(root.right, item, root);
				root.right = node;
			}

			return root;
		}
		public TreeNode DeleteNode(TreeNode root, int key)
		{
			return helperdel(root, key, null);
		}
		public TreeNode helperdel(TreeNode root, int key, TreeNode par)
		{
			if (root == null)
			{
				return null;
			}

			if (root.data == key && root.left == null && root.right == null)
			{
				Console.Write(root.data);
				if (par.data > key) par.left = root.left ?? root.right;
				else
					par.right = root.right ?? root.left;
			}

			else if (root.data == key && (root.left == null || root.right == null))
			{

				if (par.data > key) par.left = root.left ?? root.right;
				else
					par.right = root.right ?? root.left;
			}
			//find the suceesor of given node
			else if ((root.data == key && root.left != null && root.right != null))
			{

				var node = findsucessor(root);
				var cur = root;

			}

			if (root.data < key)
			{
				Console.Write(root.data);
				helperdel(root.right, key, root);
				Console.Write(root.data);
			}
			if (root.data > key)
			{
				helperdel(root.left, key, root);
			}

			return root;
		}

		public TreeNode findsucessor(TreeNode root)
		{
			TreeNode cur = root;
			cur = cur.right;
			TreeNode candi = null;
			while (cur != null)
			{
				candi = cur;
				cur = cur.left;
			}
			return candi;
		}

		public TreeNode Insertlargest(TreeNode root, int val)
		{

			if (root == null)
			{
				TreeNode node = new TreeNode(val, 1);
				return node;
			}
			else if (root.data > val)
			{
				root.left = Insertlargest(root.left, val);
				root.count++;
			}
			else if (root.data <= val)
			{
				root.right = Insertlargest(root.right, val);
				root.count++;
			}

			return root;

		}
		public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
		{
			int len = nums.Length;
			if (len == 0)
				return false;
			if (t < 0 || k <= 0)
				return false;

			var windowSet = new SortedSet<long>();
			
			for (int i = 0; i < len; i++)
			{
				if (i > k)
					windowSet.Remove(nums[i - k - 1]);
				if (windowSet.GetViewBetween((long)nums[i] - t, (long)nums[i] + t).Count > 0)
					return true;
				windowSet.Add(nums[i]);
			}
			return false;
		}
		public void Traverse()
		{
			var windowSet = new SortedSet<long>();
			
			int [] nums = { 5,2,6,1,7,4,3};
			foreach(var val in nums)
			{
				 root = Insertlargest(root, val);
			}
			
			Console.WriteLine(res1);
		}

	}
}
	
