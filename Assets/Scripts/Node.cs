using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {

    public bool walkable; // false ��� �����������
    public Vector3 worldPosition; // ������������ � ����
    public int gridX; // ������������ � ����� (�������) �� �
    public int gridY; // ������������ � ����� (�������) �� Y
    public int movementPenalty; // ���

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
