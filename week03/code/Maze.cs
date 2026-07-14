using System;
using System.Collections.Generic;

/// <summary>
/// Defines a maze using a dictionary.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    public void MoveLeft()
    {
        // Posição 0 do array representa a esquerda
        if (_mazeMap[(_currX, _currY)][0])
            _currX--;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    public void MoveRight()
    {
        // Posição 1 do array representa a direita
        if (_mazeMap[(_currX, _currY)][1])
            _currX++;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    public void MoveUp()
    {
        // Posição 2 do array representa cima
        if (_mazeMap[(_currX, _currY)][2])
            _currY--;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    public void MoveDown()
    {
        // Posição 3 do array representa baixo
        if (_mazeMap[(_currX, _currY)][3])
            _currY++;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}