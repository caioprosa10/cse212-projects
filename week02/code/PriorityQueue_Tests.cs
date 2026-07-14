using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities and dequeue them.
    // Expected Result: They should be dequeued in order of highest priority first.
    // Defect(s) Found: The original code did not check the last item in the queue because the loop condition was `_queue.Count - 1`. Also, the dequeued item was never actually removed from the list.
    public void TestPriorityQueue_HighestPriorityRemoved()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Baixa", 1);
        priorityQueue.Enqueue("Alta", 10);
        priorityQueue.Enqueue("Media", 5);

        // The item with priority 10 should come out first
        Assert.AreEqual("Alta", priorityQueue.Dequeue());
        // Then the item with priority 5
        Assert.AreEqual("Media", priorityQueue.Dequeue());
        // Then the item with priority 1
        Assert.AreEqual("Baixa", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items with the SAME priority.
    // Expected Result: They should be dequeued in the order they were added (FIFO).
    // Defect(s) Found: The original code used ">=" instead of ">" when comparing priorities. This caused it to return the newest item instead of the oldest one when priorities were tied, breaking the FIFO rule.
    public void TestPriorityQueue_FIFOOnTie()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Primeiro", 5);
        priorityQueue.Enqueue("Segundo", 5);
        priorityQueue.Enqueue("Terceiro", 5);

        Assert.AreEqual("Primeiro", priorityQueue.Dequeue());
        Assert.AreEqual("Segundo", priorityQueue.Dequeue());
        Assert.AreEqual("Terceiro", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: Should throw an InvalidOperationException with the correct message.
    // Defect(s) Found: No defect found. The original code already threw the correct exception.
    public void TestPriorityQueue_EmptyThrowsException()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception of type {e.GetType()} caught: {e.Message}");
        }
    }
}