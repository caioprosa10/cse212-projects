using System;
using System.Collections.Generic;

public class Arrays 
{
    public static double[] MultiplesOf(double number, int length)
    {
        // Step-by-step Plan:
        // 1. Create a new array of doubles with the size equal to the 'length' parameter.
        // 2. Set up a for-loop that will iterate 'length' times, starting from index 0 up to 'length - 1'.
        // 3. Inside the loop, calculate the current multiple. Since we want multiples starting from 1 
        //    (e.g., number * 1, number * 2), we multiply the 'number' by (i + 1).
        // 4. Assign this calculated multiple to the array at the current index 'i'.
        // 5. After the loop completes, return the fully populated array.

        double[] multiples = new double[length];
        
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }
        
        return multiples;
    }

    public static void RotateListRight(List<int> data, int amount)
    {
        // Step-by-step Plan:
        // 1. Find the split index where the list needs to be divided. 
        //    Since we are rotating right by 'amount', the last 'amount' of items will be moved to the front.
        //    The index to start slicing is: data.Count - amount.
        // 2. Use the GetRange() method to extract these last 'amount' items into a new sub-list (the tail).
        // 3. Use the RemoveRange() method to delete those extracted items from the end of the original 'data' list.
        // 4. Use the InsertRange() method to insert our extracted sub-list at the very beginning (index 0) 
        //    of the original 'data' list.
        // This modifies the list in place safely and efficiently.

        int splitIndex = data.Count - amount;
        List<int> tail = data.GetRange(splitIndex, amount);
        data.RemoveRange(splitIndex, amount);
        data.InsertRange(0, tail);
    }
}