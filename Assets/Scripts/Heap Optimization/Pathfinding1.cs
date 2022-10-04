/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

[RequireComponent(typeof(Grid))]
public class PathfindingHeap : MonoBehaviour
{
    public Transform seeker, target;

    Grid grid;

    private void Awake() {
        grid = GetComponent<Grid>();
    }

    private void Update() {
        FindPath(seeker.position, target.position);
        //if (Input.GetButtonDown("Jump"))
            
    }

    void FindPath(Vector3 startPos, Vector3 targetPos) {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        NodeHeap startNode = grid.NodeFromWorldPoint(startPos);
        NodeHeap targetNode = grid.NodeFromWorldPoint(targetPos);

        Heap<NodeHeap> openSet = new Heap<NodeHeap>(grid.MaxSize);
        HashSet<NodeHeap> closedSet = new HashSet<NodeHeap>();

        openSet.Add(startNode);

        while (openSet.Count > 0) {
            NodeHeap currentNode = openSet.RemoveFirst();
            *//*NodeHeap currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; ++i) {
                if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost) {
                    currentNode = openSet[i];
                }
            }

            openSet.Remove(currentNode);*//*
            closedSet.Add(currentNode);

            if (currentNode == targetNode) {
                sw.Stop();
                print("Path found: " + sw.ElapsedMilliseconds + " ms");
                RetracePath(startNode, targetNode);
                return;
            }

            foreach (NodeHeap neighbour in grid.GetNeighbours(currentNode)) {
                if (!neighbour.walkable || closedSet.Contains(neighbour))
                    continue;

                int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour) + neighbour.movementPenalty;
                if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour)) {
                    neighbour.gCost = newMovementCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, targetNode);
                    neighbour.parent = currentNode;

                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);
                    else
                        openSet.UpdateItem(neighbour);
                }
            }
        }
    }

    void RetracePath(NodeHeap startNode, NodeHeap endNode) {
        List<NodeHeap> path = new List<NodeHeap>();
        NodeHeap currentNode = endNode;

        while (currentNode != startNode){
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();

        grid.path = path;
    }

    int GetDistance(NodeHeap nodeA, NodeHeap nodeB) {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        return 14 * Mathf.Min(dstX, dstY) + 10 * Mathf.Abs(dstX - dstY); // 14 ~ sqrt(2) * 10 - diagonal move. Multiply by 10 to get rid of float values
    }
}
*/