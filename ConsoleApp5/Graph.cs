using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
	public class Graph
	{
		readonly Dictionary<int, List<int>> graph;
		private readonly int vertex;
		public Graph(int vertex)
		{
			this.vertex = vertex;
			graph = new Dictionary<int, List<int>>();
			for(int i =0; i < vertex;i++)
			{
				graph.Add(i, new List<int>());
			}

		}

		public void AddEdge(int s , int d)
		{
			graph[s].Add(d);
		}

		public void dfs()
		{
			bool[] visited = new bool[vertex];

					DFSUtilRecursive(visited, 2);

		}

		private void DFSUtilRecursive(bool[] visited, int i)
		{
			visited[i] = true;
			lst.Add(i);
			foreach(var v in graph[i])
			{
				if(visited[v] == false)
				{
					DFSUtilRecursive(visited, v);
				}
			}
		}

		List<int> lst = new List<int>();

		private void DfsTrversal(bool[] visited, int i)
		{
			visited[i] = true;
			Stack<int> stack = new Stack<int>();
			stack.Push(i);
			while(stack.Count >0)
			{
				var current = stack.Peek();
				lst.Add(current);
				stack.Pop();
				foreach(var v in graph[current])
				{
					if(visited[v] ==  false)
					{
						stack.Push(v);
						visited[v] = true;
					}
				}

			}
			return;
		}

		public enum state { unvisted =0,visited =1,visiting =2};

		public bool DfsCyscle()
		{
			int[] arr = new int[vertex];
			bool iscycle = false;
			for (int i = 0; i < vertex;i ++)
			{
				arr[i] = 0;
			}
			for (int i = 0; i < vertex; i++)
			{
				if (arr[i] == 0)
				{
					iscycle = findcyccleingarph(arr, i);
				}
			}
			return iscycle;
		}


		public void bfs()
		{
			bool[] visted = new bool[vertex];

			Array.Fill(visted, false);

			for(int i = 0; i < vertex; i++)
			{
				if(visted[i] == false)
				{
					BFShelper(i, visted);
				}
			}
		}

		public void BFShelper(int i, bool[] visted)
		{
			Queue<int> q = new Queue<int> ();

			q.Enqueue(i);
			visted[i] = true;
			while(q.Count >0)
			{
				var current = q.Peek();
				lst.Add(current);
				q.Dequeue();
				foreach(var v in graph[current])
				{
					if(visted[v] == false)
					{
						q.Enqueue(v);
					}
					visted[v] = true;
				}
			}
			foreach(var v in lst)
			{
				Console.WriteLine(v);
			}
		}

		public bool findcyccleingarph(int[] arr, int i)
		{
			Stack<int> stack = new Stack<int>();
			stack.Push(i);
			arr[i] = 1;
			while(stack.Count > 0)
			{
				var current = stack.Pop();
				arr[current] = 1;
				foreach(var v in graph[current])
				{
					if(arr[v] ==2)
					{
						return true;
					}
					if(arr[v] ==0)

					{
						stack.Push(v);
					}
				}
				arr[current] = 2;
			}
			return false;
		}

		static  int count;
		public static List<int> RiverSizes(int[,] matrix)
		{
			// Write your code here.
			int endrow = matrix.GetLength(0);
			int endcol = matrix.GetLength(1);
			bool[,] visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
			List<int> lst = new List<int>();
			for(int i =0; i < endrow; i++)
			{
				for(int j = 0; j < endcol; j++)
				{
					if (visited[i, j] == false && matrix[i, j] == 1)
					{
						count++;
						IterativeApproch(matrix, visited, i, j,lst);
						lst.Add(count);
						count = 0;
					}
				}
			}

			return lst;
		}
		
		public static void IterativeApproch(int[,] matrix, bool[,] visited, int i, int j,List<int> lst)
		{

			Stack<int[]> stack = new Stack<int[]>();
			int currentsize = 0;
			stack.Push(new int[] { i, j });
			while(stack.Count >0)
			{
				var current = stack.Pop();
				i = current[0];
				j = current[1];
				if (visited[i, j] == true)
					continue;
				visited[i, j] = true;
				if (matrix[i, j] == 0)
					continue;

				currentsize++;
				List<int[]> neighbours = GetNeighbour(matrix, i, j,visited);
				foreach(var neighbour in neighbours)
				{
					stack.Push(neighbour);
				}
			}
			if(currentsize >0)
			{
				lst.Add(currentsize);
			}
		}

		private static List<int[]> GetNeighbour(int[,] matrix, int i, int j, bool[,] visited)
		{
			List<int[]> ls = new List<int[]>();
			if(i >0 && visited[i-1,j] == false)
			{
				ls.Add(new int[] { i - 1, j });

			}
			if (i < matrix.GetLength(0)-1 && visited[i + 1, j] == false)
			{
				ls.Add(new int[] { i + 1, j });

			}
			if (j > 0 && visited[i, j -1] == false)
			{
				ls.Add(new int[] { i  , j -1});

			}
			if (j <  matrix.GetLength(1) - 1 && visited[i , j +1] == false)
			{
				ls.Add(new int[] { i , j +1});

			}
			return ls;
		}

		public static void helper(int[,] matrix, bool[,] visited, int i, int j)
		{
			visited[i, j] = true;
			
			if( isValid(matrix,i,j+1) && visited[i, j + 1] == false &&  matrix[i, j + 1] ==1)
			{
				count++;
				helper(matrix, visited, i, j+1);
			}
			if ( isValid(matrix, i+1, j) && visited[i + 1, j] == false &&  matrix[i+1, j] == 1)
			{
				count++;
				helper(matrix, visited, i+1, j);
			}
		}

		public int[][] RemoveIslands(int[][] matrix)
		{
			// Write your code here.

			bool[,] coonectedtoborder = new bool[matrix.Length, matrix[0].Length];
			for(int i =0; i < matrix.Length;i++)
			{
				coonectedtoborder[i, matrix[0].Length - 1] = false;

			}
			for(int row = 0; row < matrix.Length;row++)
			{
				for(int col =0; col < matrix[row].Length;col++)
				{
					bool isrowbounary = row == 0 || row == matrix.Length - 1;
					bool iscolboundary = col == 0 || col == matrix[row].Length - 1;
					bool isborder = iscolboundary || isrowbounary;

					if(!isborder)
					{
						continue;
					}

					if(matrix[row][col] !=1)
					{
						continue;
					}

					findonesconnectedborder(matrix, coonectedtoborder, row, col);
				}

			}

			for(int i =1; i < matrix.Length -1;i++)
			{
				for(int j =1;j < matrix.Length -1; j++)
				{
					if(coonectedtoborder[i,j])
					{
						continue;
					}
					matrix[i][j] = 0;
				}
			}

			return matrix;
		}

		private void findonesconnectedborder(int[][] matrix, bool[,] coonectedtoborder, int row, int col)
		{
			Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
			stack.Push(new Tuple<int, int>( row, col ));
			while(stack.Count > 0)
			{
				var current = stack.Pop();
				var currentrow = current.Item1;
				var currentcol = current.Item2;
				bool isvisted = coonectedtoborder[currentrow, currentcol];
				if(isvisted)
				{
					continue;
				}
				coonectedtoborder[currentrow, currentcol] = true;
				List<Tuple<int, int>> ls = GetListOfNeighbour(matrix, currentrow, currentcol);
				foreach(var neighbour in ls)
				{
					stack.Push(neighbour);
				}
					
			}

		}

		private List<Tuple<int, int>> GetListOfNeighbour(int[][] matrix, int currentrow, int currentcol)
		{
			int rowlength = matrix.Length;
			int collength = matrix[currentrow].Length;
			List<Tuple<int, int>> lst = new List<Tuple<int, int>>(0);
			if(currentrow-1 >= 0 )
			{
				lst.Add(new Tuple<int, int>(currentrow - 1, currentcol));
			}
			if(currentrow+1 < rowlength)
			{
				lst.Add(new Tuple<int, int>(currentrow + 1, currentcol));
			}

			if(currentcol -1 >=0)
			{
				lst.Add(new Tuple<int, int>(currentrow , currentcol-1));
			}
			if (currentcol + 1 < collength)
			{
				lst.Add(new Tuple<int, int>(currentrow, currentcol + 1));
			}
			return lst;
		}

		private static bool isValid(int[,] matrix, int i, int j)
		{
			return (i >= 0 && i < matrix.GetLength(0) && j >= 0 && j < matrix.GetLength(1));
		}


	}
}
