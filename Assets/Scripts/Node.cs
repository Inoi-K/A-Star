using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {

    public bool walkable; // false для препятствий
    public Vector3 worldPosition; // расположение в мире
    public int gridX; // расположение в сетке (матрице) по Х
    public int gridY; // расположение в сетке (матрице) по Y
    public int movementPenalty; // вес

    public int gCost;
    public int hCost;
    public Node parent;

    public Node(bool _walkable, Vector3 _worldPosition, int _gridX, int _gridY, int _penalty) {
        walkable = _walkable;
        worldPosition = _worldPosition;
        gridX = _gridX;
        gridY = _gridY;
        movementPenalty = _penalty;
    }

    public int fCost {
        get {
            return gCost + hCost;
        }
    }
}
