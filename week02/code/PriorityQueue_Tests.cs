using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Adicionar três itens com prioridades diferentes e retirá-los.
    // Expected Result: Devem sair na ordem: maior prioridade primeiro.
    // Defect(s) Found: O código antigo não removia os itens da lista e não testava o último elemento.
    public void TestPriorityQueue_HighestPriorityRemoved()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Baixa", 1);
        priorityQueue.Enqueue("Alta", 10);
        priorityQueue.Enqueue("Media", 5);

        // O item com prioridade 10 deve sair primeiro
        Assert.AreEqual("Alta", priorityQueue.Dequeue());
        // Depois o item com prioridade 5
        Assert.AreEqual("Media", priorityQueue.Dequeue());
        // Depois o item com prioridade 1
        Assert.AreEqual("Baixa", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Adicionar itens com a MESMA prioridade.
    // Expected Result: Devem sair na ordem em que foram adicionados (FIFO).
    // Defect(s) Found: O código original usava ">=" e acabava tirando o último a entrar em vez do primeiro em caso de empate de prioridade.
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
    // Scenario: Tentar dar dequeue em uma fila vazia.
    // Expected Result: Lançar InvalidOperationException com a mensagem correta.
    // Defect(s) Found: NENHUM DEFEITO ENCONTRADO. Já funcionava corretamente.
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