using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

[RequireComponent(typeof(Grid))]
public class Pathfinding : MonoBehaviour {

    public Transform seeker, target;

    Grid grid;

    private void Awake() {
        grid = GetComponent<Grid>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            grid.CreateGrid();
            FindPath(seeker.position, target.position);
        }
            
    }

    void FindPath(Vector3 startPos, Vector3 targetPos) {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();

        openSet.Add(startNode);

        while (openSet.Count > 0) {
            Node currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; ++i)
                if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)
                    currentNode = openSet[i];

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode == targetNode) {
                sw.Stop();
                print("Путь с длиной " + targetNode.fCost + " найден за " + sw.ElapsedMilliseconds + " мс");
                RetracePath(startNode, targetNode); // Графически отображаем путь
                return;
            }

            foreach (Node neighbour in grid.GetNeighbours(currentNode)) { // Соседи - смежные элементы, включая диагональ, в матрице
                if (!neighbour.walkable || closedSet.Contains(neighbour))
                    continue;

                int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour) + neighbour.movementPenalty;
                if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour)) {
                    neighbour.gCost = newMovementCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, targetNode);
                    neighbour.parent = currentNode;

                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);
                }
            }
        }
    }

    void RetracePath(Node startNode, Node endNode) {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode){
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();

        grid.path = path;
    }

    int GetDistance(Node nodeA, Node nodeB) {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        // умножаем расстояние на 10, чтобы работать в целых числах
        return 14 * Mathf.Min(dstX, dstY) + 10 * Mathf.Abs(dstX - dstY); // 14 ~ sqrt(2) * 10 - движение по диагонали                           - diagonal move. Multiply by 10 to get rid of float values
    }
}
