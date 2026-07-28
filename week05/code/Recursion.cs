using System.Collections.Generic;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case: If n <= 0, return 0
        if (n <= 0)
            return 0;

        // Recursive case: n^2 + sum of squares of (n-1)
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: we have built a word of the target size
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Recursive case: try adding each available letter to the word
        for (int i = 0; i < letters.Length; i++)
        {
            // Remove the chosen letter from the pool of available letters
            string remainingLetters = letters.Remove(i, 1);
            
            // Recurse with the new word and the remaining letters
            PermutationsChoose(results, remainingLetters, size, word + letters[i]);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs. 
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases
        if (s < 0)
            return 0; // Defensive check for invalid negative steps
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // Initialize the dictionary if it's the first call
        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }

        // Check if we've already solved for this 's'
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }

        // Solve using recursion and memoization
        decimal ways = CountWaysToClimb(s - 1, remember) + 
                       CountWaysToClimb(s - 2, remember) + 
                       CountWaysToClimb(s - 3, remember);
                       
        // Save the result to our dictionary before returning
        remember[s] = ways;
        
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int wildcardIndex = pattern.IndexOf('*');

        // Base case: If there are no wildcards left, add the pattern to results
        if (wildcardIndex == -1)
        {
            results.Add(pattern);
            return;
        }

        // Branch 1: Replace the first '*' with '0' and recurse
        string zeroPattern = pattern[..wildcardIndex] + "0" + pattern[(wildcardIndex + 1)..];
        WildcardBinary(zeroPattern, results);

        // Branch 2: Replace the first '*' with '1' and recurse
        string onePattern = pattern[..wildcardIndex] + "1" + pattern[(wildcardIndex + 1)..];
        WildcardBinary(onePattern, results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null) {
            currPath = new List<ValueTuple<int, int>>();
        }
        
        // Add current position to the path
        currPath.Add((x, y));

        // Base case: Check if we reached the end
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString()); // Assuming AsString() is in the provided TupleListExtensionMethods.cs
        }
        else
        {
            // Define all 4 possible directions: Right, Left, Down, Up
            (int, int)[] moves = new (int, int)[] 
            { 
                (x + 1, y), // Right
                (x - 1, y), // Left
                (x, y + 1), // Down
                (x, y - 1)  // Up
            };

            // Recursively explore all valid moves
            foreach (var move in moves)
            {
                if (maze.IsValidMove(currPath, move.Item1, move.Item2))
                {
                    SolveMaze(results, maze, move.Item1, move.Item2, currPath);
                }
            }
        }

        // Backtrack: Remove the current position before returning to the previous stack frame
        currPath.RemoveAt(currPath.Count - 1);
    }
}