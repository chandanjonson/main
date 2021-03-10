using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;

namespace ConsoleApp5
{
	public class Number
	{
		public int? Name;
		public static List<int[]> ThreeNumberSum(int[] array, int targetSum)
		{
			List<int[]> lst = new List<int[]>();
			Array.Sort(array);
			List<int> l = new List<int>();

			int left = 0;
			int right = array.Length - 1;
			for (int i = 0; i < array.Length - 2; i++)
			{
				left = i + 1;
				right = array.Length - 1;
				while (left < right)
				{
					if (targetSum == array[left] + array[right] + array[i])
					{
						int[] arr = { array[left], array[right], array[i] };
						lst.Add(arr);
						left++;
						right--;

					}

					else if (targetSum > array[left] + array[right] + array[i])
					{
						left++;
					}
					else
					{
						right--;
					}

				}

			}
			return lst;

		}

		public static bool BackspaceCompare()
		{
			string S = "ab##", T = "c#d#";
			StringBuilder s1 = new StringBuilder(S);
			StringBuilder s2 = new StringBuilder(T);
			if (S.Length != T.Length)
			{
				return false;
			}
			int i = 0;
			int j = 0;



			return (s2 == s1);
		}
		int maxlength = 0;
		public int FindMaxPeakLength(int[] nums)
		{
			int i = 1;
			while (i < nums.Length - 1)
			{
				var res = nums[i] > nums[i - 1] && nums[i] > nums[i + 1];
				if (!res)
				{
					i += 1;
					continue;
				}
				int leftidx = i - 2;
				while (leftidx >= 0 && nums[leftidx] < nums[leftidx + 1])
				{
					leftidx -= 1;
				}
				int rightidx = i + 2;
				while (rightidx < nums.Length && nums[rightidx] < nums[rightidx - 1])
				{
					rightidx += 1;
				}
				int curlength = rightidx - leftidx - 1;

				if (curlength > maxlength)
				{
					maxlength = curlength;

				}
				i = rightidx;

			}
			return maxlength;
		}

		public int[] PlusOne(int[] digits)
		{
			int c = 0;
			for (int i = digits.Length - 1; i >= 0; i--)
			{
				if (digits[i] == 9 && i == digits.Length - 1)
				{
					c = 10 / digits[i];
					digits[i] = (digits[i] + c) % 10;

				}

				else
				{
					if (i == digits.Length - 1)
					{
						digits[i] = digits[i] + 1;
					}
					else
					{
						int sum = (digits[i] + c) % 10;
						digits[i] = sum;
						c = 0;
					}
				}
			}

			if (c != 0)
			{
				int[] newarray = new int[digits.Length + 1];
				newarray[0] = 1;
				Array.Copy(digits, 0, newarray, 1, digits.Length);
				return newarray;
			}
			return digits;
		}

		public int[][] Merge(int[][] intervals)
		{

			List<int[]> lst = new List<int[]>();
			foreach (var v in intervals.OrderBy(x => x[0]))
			{
				if (lst.Count == 0 || lst[lst.Count - 1][1] < v[0])
				{
					lst.Add(v);
				}
				else
				{
					lst[lst.Count][1] = Math.Max(v[1], lst[lst.Count][1]);
				}

			}


			return lst.ToArray();
		}

		public static List<int> SpiralTraverse(int[,] array)
		{


			List<int> lst = new List<int>();
			//
			//int[,] a = new int [,];
			//
			if (array.Length == 0) return new List<int>();

			int startrow = 0;
			int endrow = array.GetLength(0) - 1;
			int startcol = 0;
			int endcol = array.GetLength(1) - 1;

			while (startrow <= endrow && startcol <= endcol)
			{
				for (int col = startcol; col <= endcol; col++)
				{
					lst.Add(array[startrow, col]);
				}

				for (int row = startrow + 1; row <= endrow; row++)
				{
					lst.Add(array[row, endcol]);
				}

				for (int col = endcol - 1; col >= startcol; col--)
				{
					if (startrow == endrow)
						break;
					lst.Add(array[endrow, col]);
				}

				for (int row = endrow - 1; row > startrow; row--)
				{
					if (startcol == endcol)
						break;
					lst.Add(array[row, startcol]);
				}

				startrow++;
				startcol++;
				endcol--;
				endrow--;

			}
			return lst;

		}

		public IList<IList<string>> IsAnagram()
		{
			string[] str = { "eat", "tea", "tan", "ate", "nat", "bat" };

			IList<IList<string>> lst = new List<IList<string>>();

			Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();

			int[] ch = new int[26];
			foreach (var s in str)
			{
				Array.Fill(ch, 0);
				foreach (var c in s)
				{
					ch[c - 'a']++;
				}
				StringBuilder sb = new StringBuilder("");
				for (int i = 0; i < 26; i++)
				{
					sb.Append("#");
					sb.Append(ch[i]);
				}

				var key = sb.ToString();
				if (!dic.ContainsKey(key))
				{
					dic.Add(key, new List<string>() { s });
				}
				else
				{
					dic[key].Add(s);
				}
			}
			foreach (var v in dic.Keys)
			{
				lst.Add(dic[v]);
			}
			return lst;


		}

		public string FrequencySort()
		{
			string s = "aaabbbbbzzzzcccccccc";
			var v = s.ToCharArray();
			Array.Sort(v);
			List<string> ls = new List<string>();
			StringBuilder current = new StringBuilder();
			current.Append(v[0]);
			for (int i = 1; i < v.Length; i++)
			{
				if (v[i] != v[i - 1])
				{
					ls.Add(current.ToString());
					current = new StringBuilder();
				}
				current.Append(v[i]);
			}
			ls.Add(current.ToString());
			var res = ls.OrderByDescending(x => x.Length);
			current.Clear();
			foreach (var l in res)
			{
				current.Append(l);
			}


			return current.ToString();

		}

		public bool IsStringUnique()
		{
			//sort the string
			string str = "aba";
			var v = str.ToCharArray();
			Array.Reverse(v);
			var res = new string(v);
			Console.WriteLine(res);
			char[] ch = str.ToCharArray();
			Array.Sort(ch);

			return str == res;
		}

		public string StringFiller()
		{
			string str = "Mr jOHN sMITH   ";
			StringBuilder sb = new StringBuilder();
			str = str.Trim();
			foreach (var v in str)
			{
				if (v == 32)
				{
					sb.Append("%20");
				}
				else
				{
					sb.Append(v);
				}
			}
			return sb.ToString();
		}
		public bool OneEditOperation()
		{
			string str1 = "pale";
			string str2 = "ple";

			if ((str1.Length - str2.Length) > 1) return false;
			//get the bigger and smaller string
			string s1 = (str1.Length > str2.Length) ? str2 : str1;
			string s2 = (str1.Length > str2.Length) ? str1 : str2;
			int index1 = 0;
			int index2 = 0;
			bool ifdifffound = false;
			while (index2 < s2.Length && index1 < s1.Length)
			{
				if (s1[index1] != s2[index2])
				{
					if (ifdifffound)
					{
						return false;
					}
					ifdifffound = true;
					if (s1.Length == s2.Length)
					{
						index1++;
					}
				}
				else
				{
					index1++;
				}
				index2++;
			}
			return true;
		}

		public string CompressString()
		{
			string str = "abc";

			//we can increase the time complexity by using stringbuilder

			int count = 0;
			int conti = 0;
			for (int i = 0; i < str.Length; i++)
			{
				count++;
				if (i + 1 >= str.Length || str[i] != str[i + 1])
				{
					conti += 1 + count.ToString().Length;
					count = 0;
				}
			}

			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < str.Length; i++)
			{
				count++;
				if (count > 8)
				{
					sb.Append(count);
					sb.Append(str[i]);
					count = 0;
					continue;

				}
				if (i + 1 >= str.Length || str[i] != str[i + 1])
				{
					sb.Append(count);
					sb.Append(str[i]);

					count = 0;
				}
			}

			return sb.ToString();
		}
		public static string CaesarCypherEncryptor(string str, int key)
		{
			string alpabet = "abcdefghijklmnopqrstuvwxyz";
			var newkey = key % 26;
			char[] res = new char[str.Length];
			for (int i = 0; i < str.Length; i++)
			{
				res[i] = helper(str[i], newkey, alpabet);
			}
			return new string(res);


		}

		public static char helper(char v, int newkey, string alpabet)
		{
			return alpabet[(v - 'a' +newkey) % 26];
		}

		public void Isubstring(string s1 , string s2)
		{

			//str= "chandan is good boy!!!"
			StringBuilder sb = new StringBuilder();
			char[] ch = new char[s1.Length];

	
			
			
		}
		public string removeDups()
		{
			string S = "aabbbccdddedfhgaaa";
			string alphabet = "abcdefghijklmnopqrstuvwxyz";
			int[] ch = new int [26];
			StringBuilder sb = new StringBuilder();
			foreach(var v in  S)
			{
				ch[v - 'a']++;
			}
			S = "";
			for(int i =0; i< ch.Length;i++)
			{
				if(ch[i] !=0)
				{
					S += alphabet[i];
				}
			}

			return S;
		}
		public List<string> GenerarteAllPossibleSubstring()
		{
			string st = "abaxyzzyxf";

			List<string> ls = new List<string>();
			for(int i =0; i < st.Length; i ++)
			{
				for(int j =1;j <= st.Length -i; j++)
				{
					var current = st.Substring(i, j);
					var ispal = IsPalindron(current);
					if(ispal)
					{
						ls.Add(current);
					}
				}
			}
			var cur = ls.OrderByDescending(x => x.Length);
			Console.WriteLine(cur.First());
			return ls;
		}
		public bool IsPalindron(string str)
		{
			char[] ch = str.ToCharArray();
			Array.Reverse(ch);
			return new string(ch) == str;
		}
		public string LargestsubstringWithoutRepettion()
		{
			string str = "aaab";
			int[] ch = new int[128];
			int left = 0;
			int right = 0;
			int res = 0;
			while(right <str.Length)
			{
				var current = str[right];
				ch[current]++;
				while (ch[current] >1)
				{
					char l = str[left];
					ch[l]--;
					left++;
				}

				res = Math.Max(res, right - left + 1);


				right++;
			}
			Console.WriteLine(res);

			return " ";
		}


		public void LargestsubstringWithoutRepettion(string str)
		{
			Dictionary<char,int> dic = new Dictionary<char,int>();
			int startindx = 0;
			int[] longest = { 0, 1 };


			var d = dic.Min();


			for(int j =0; j < str.Length; j++)
			{
				char c = str[j];

				if(dic.ContainsKey(c))
				{

					startindx = Math.Max(startindx, dic[c] + 1);

				}
				if(longest[1] - longest[0] < j +1 -startindx)
				{
					longest = new int[] { startindx, j + 1 };
				}
				dic[c] = j;

			}
			string res = str.Substring(longest[0], longest[1] - longest[0]);
			Console.WriteLine(res);
		}

		public void FindMaxLenSum()
		{
			int[] arr = { 1,7,4,3,1,2,1,5,1};
			int left = 0;
			int right = 0;
			int csum = 0;
			int res = 0;
			int targetsum = 7;
			int largest = 0;
			int[] subarray = new int []{ 0, 1 };
			while (right <arr.Length)
			{
				 csum += arr[right];

				while(csum > targetsum )
				{
					csum -= arr[left];
					left++;
				}

				if(csum == targetsum)
				{
					res = Math.Max(res, right - left + 1);
					if(res > largest)
					{
						largest = res;
						subarray = new int[] { left, right + 1 };
					}
				}


				right++;
			}

			Console.WriteLine(res);
		}

		public int LengthOfLongestSubstringTwoDistinct(string s)
		{
			int left = 0;
			int right = 0;
			int maxlen = 0;
			Dictionary<char, int> dic = new Dictionary<char, int>();

			while(right <s.Length)
			{
				if (!dic.ContainsKey(s[right]))
				{
					dic.Add(s[right], right);
				}
				else
				{
					dic[s[right]] = right;
				}

				if(dic.Count  == 3)
				{
					var v = dic.Min(x => x.Value);
					var index = v;

					dic.Remove(s[index]);

					left = index +1;

				}
				maxlen = Math.Max(maxlen, right - left + 1);

				right++;
			}
			return maxlen;
		}


	}
}
