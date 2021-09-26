using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input from user as a string, then converts it to a char array.
            string n = Console.ReadLine().ToUpper();
            char[] pattern = n.ToCharArray();

            int outcomes = 0;

            // Dictionary containing all possible turns (INCOMPLETE).
            Dictionary<int, Dictionary<int, Dictionary<char, int[]>>> pivots = new Dictionary<int, Dictionary<int, Dictionary<char, int[]>>>()
            {
                {1, new Dictionary<int, Dictionary<char, int[]>>
                    {
                        {2, new Dictionary<char, int[]> { {'R', new int[] {0} }, { 'L', new int[] {4, 5} }, { 'S', new int[] {0} }, {'A', new int[] {3} }, {'?', new int[] {3, 4, 5, 6, 7, 8} } } },
                        {4, new Dictionary<char, int[]> { {'R', new int[] {2, 5, 8} }, { 'L', new int[] {0} }, { 'S', new int[] {0} }, {'A', new int[] {7} }, {'?', new int[] {2, 5, 6, 7, 8, 9} } } },
                        {5, new Dictionary<char, int[]> { {'R', new int[] {2} }, { 'L', new int[] {4} }, { 'S', new int[] {0} }, {'A', new int[] {9} }, {'?', new int[] {2, 4, 6, 8, 9} } } } } },

                {2, new Dictionary<int, Dictionary<char, int[]>>
                    {
                        {1, new Dictionary<char, int[]> { {'R', new int[] {4, 5, 6} }, { 'L', new int[] {0} }, { 'S', new int[] {3} }, {'A', new int[] {0} }, {'?', new int[] {3, 4, 5, 6, 7, 9} } } },
                        {3, new Dictionary<char, int[]> { {'R', new int[] {0} }, { 'L', new int[] {4, 5, 6} }, { 'S', new int[] {1} }, {'A', new int[] {0} }, {'?', new int[] {1, 4, 5, 6, 7, 9} } } },
                        {4, new Dictionary<char, int[]> { {'R', new int[] {3, 5, 6} }, { 'L', new int[] {1} }, { 'S', new int[] {0} }, {'A', new int[] {0} }, {'?', new int[] {1, 3, 5, 6, 7, 9} } } },
                        {5, new Dictionary<char, int[]> { {'R', new int[] {3, 6} }, { 'L', new int[] { 1, 4 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {6, new Dictionary<char, int[]> { {'R', new int[] {3} }, { 'L', new int[] { 1, 4, 5 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } } } },

                {3, new Dictionary<int, Dictionary<char, int[]>>
                    {
                        {2, new Dictionary<char, int[]> { {'R', new int[] {5, 6} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {5, new Dictionary<char, int[]> { {'R', new int[] {6} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {6, new Dictionary<char, int[]> { {'R', new int[] {0} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } } } },

                {4, new Dictionary<int, Dictionary<char, int[]>>
                    {
                        {1, new Dictionary<char, int[]> { {'R', new int[] {0} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {2, new Dictionary<char, int[]> { {'R', new int[] {1} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {5, new Dictionary<char, int[]> { {'R', new int[] {1, 2} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {7, new Dictionary<char, int[]> { {'R', new int[] {1, 2, 5} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {8, new Dictionary<char, int[]> { {'R', new int[] {2, 5, 8} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } } } },

                {5, new Dictionary<int, Dictionary<char, int[]>>
                    {
                        {1, new Dictionary<char, int[]> { {'R', new int[] {4, 7, 8} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {2, new Dictionary<char, int[]> { {'R', new int[] {1, 4, 7} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {3, new Dictionary<char, int[]> { {'R', new int[] {1, 2, 4} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {4, new Dictionary<char, int[]> { {'R', new int[] {7, 8, 9} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {6, new Dictionary<char, int[]> { {'R', new int[] {1, 2, 3} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {7, new Dictionary<char, int[]> { {'R', new int[] {6, 8, 9} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {8, new Dictionary<char, int[]> { {'R', new int[] {3, 6, 9} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {9, new Dictionary<char, int[]> { {'R', new int[] {2, 3, 6} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } } } },

                {6, new Dictionary<int, Dictionary<char, int[]>>
                    {
                        {2, new Dictionary<char, int[]> { {'R', new int[] {5, 8, 9} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {3, new Dictionary<char, int[]> { {'R', new int[] {2, 5, 8} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {5, new Dictionary<char, int[]> { {'R', new int[] {8, 9} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {8, new Dictionary<char, int[]> { {'R', new int[] {9} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {9, new Dictionary<char, int[]> { {'R', new int[] {0} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } } } },

                {7, new Dictionary<int, Dictionary<char, int[]>>
                    {
                        {4, new Dictionary<char, int[]> { {'R', new int[] {0} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {5, new Dictionary<char, int[]> { {'R', new int[] {4} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {8, new Dictionary<char, int[]> { {'R', new int[] {4, 5} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } } } },

                {8, new Dictionary<int, Dictionary<char, int[]>>
                    {
                        {4, new Dictionary<char, int[]> { {'R', new int[] {7} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {5, new Dictionary<char, int[]> { {'R', new int[] {4, 7} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {6, new Dictionary<char, int[]> { {'R', new int[] {4, 5, 7} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {7, new Dictionary<char, int[]> { {'R', new int[] {0} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {9, new Dictionary<char, int[]> { {'R', new int[] {4, 5, 6} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } } } },

                {9, new Dictionary<int, Dictionary<char, int[]>>
                    {
                        {5, new Dictionary<char, int[]> { {'R', new int[] {8} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {6, new Dictionary<char, int[]> { {'R', new int[] {5, 8} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } },
                        {8, new Dictionary<char, int[]> { {'R', new int[] {0} }, { 'L', new int[] { 4, 5, 6, 7 } }, { 'S', new int[] { 0 } }, {'A', new int[] {3} }, {'?', new int[] {4, 5, 6, 7, 8} } } } } } };


            // Dictionary for all first possible jumps.
            Dictionary<int, int[]> first = new Dictionary<int, int[]>()
            {
                { 1, new int[] { 2, 4, 5, 6, 7, 8 } },
                { 2, new int[] { 1, 2, 3, 4, 5, 6, 7, 9 } },
                { 3, new int[] { 2, 4, 5, 6, 7, 8 } },
                { 4, new int[] { 1, 2, 3, 4, 5, 8, 9} },
                { 5, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 } },
                { 6, new int[] { 1, 2, 3, 4, 5, 8, 9} },
                { 7, new int[] { 2, 4, 5, 6, 7, 8 } },
                { 8, new int[] { 1, 2, 3, 4, 5, 6, 7, 9 }},
                { 9, new int[] { 2, 4, 5, 6, 7, 8 } },
            };

            // Set up a stack to perform depth-first traversal.
            Stack<int> stack = new Stack<int>();

            // Loops through all nine starting pivots.
            for (int start = 1; start <= 9; start++)
            {
                bool[] visited = new bool[] { false, false, false, false, false, false, false, false, false };

                int x = start;
                int y;
                visited[x - 1] = true;
                stack.Push(x);

                foreach (int p in first[x])
                {
                    y = x;
                    x = p;
                    visited[x - 1] = true;
                    stack.Push(x);

                    int z = 0;

                    runSequence(ref x, ref y, ref outcomes, z, ref stack, pattern, visited, pivots);

                }
            }

            Console.WriteLine(outcomes);

            static void runSequence(ref int cur, ref int prev, ref int outcomes, int track, ref Stack<int> stack, char[] pattern, bool[] visited, Dictionary<int, Dictionary<int, Dictionary<char, int[]>>> pivots)
            {

                int n = 1;
                int m = pivots[cur][prev][pattern[track]].Length;

                // Console.WriteLine("m = " + m);

                foreach (int p in pivots[cur][prev][pattern[track]])
                {

                    // Set previous to the current pivot and set current to the new pivot. Add the new pivot to the stack.
                    prev = cur;
                    cur = p;
                    stack.Push(cur);

                    Console.WriteLine(cur + " " + prev + " " + stack.Peek());

                    // If the pivot has been visited before, change the current pivot to 0. Remove the already visited pivot from the stack.
                    if (visited[cur - 1] == true)
                    {
                        cur = 0;
                        stack.Pop();
                    }
                    // If not visited before, then mark it as visited.
                    else
                    {
                        visited[cur - 1] = true;

                        if (isComplete(visited) == true)
                        {
                            outcomes++;
                        }
                        else
                        {
                            // Run the method again with the next turn in the user sequence.
                            runSequence(ref cur, ref prev, ref outcomes, track + 1, ref stack, pattern, visited, pivots);
                        }

                    }

                    // If its the last possible option for the turn to make, then backtrack using the stack.

                    if (n == m)
                    {
                        visited[stack.Peek() - 1] = false;
                        stack.Pop();
                        cur = stack.Peek();
                        stack.Pop();
                        prev = stack.Peek();
                        stack.Push(cur);
                    }
                    else if (cur == 0)
                    {
                        cur = stack.Peek();
                        stack.Pop();
                        prev = stack.Peek();
                        stack.Push(cur);
                    }

                    n++;

                }

                static bool isComplete(bool[] visited)
                {
                    bool check = true;

                    foreach (bool b in visited)
                    {
                        if (b == false)
                        {
                            check = false;
                        }
                    }

                    return check;
                }
            }
        }
    }
}
