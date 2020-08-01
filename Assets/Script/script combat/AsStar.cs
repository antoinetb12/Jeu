using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsStar : AlgoDeplacement
{



	void Awake()
	{
	}

	void Update()
	{
		
	}

	public override List<Case> FindPath(Vector3 startPos, Vector3 targetPos, Case[,] grid, int dimX,int dimY)
	{
		Case startNode = grid[Mathf.RoundToInt(-startPos.y), Mathf.RoundToInt(startPos.x)];
		Case targetNode = grid[Mathf.RoundToInt(-targetPos.y), Mathf.RoundToInt(targetPos.x)];
		startNode.precedent = null;
		startNode.perso = null;
		List<Case> openSet = new List<Case>();
		HashSet<Case> closedSet = new HashSet<Case>();
		openSet.Add(startNode);

		while (openSet.Count > 0)
		{
			Case node = openSet[0];
			for (int i = 1; i < openSet.Count; i++)
			{
				if (openSet[i].fCost < node.fCost || openSet[i].fCost == node.fCost)
				{
					if (openSet[i].hCost < node.hCost)
						node = openSet[i];
				}
			}

			openSet.Remove(node);
			closedSet.Add(node);

			if (node == targetNode)
			{
				return RetracePath(startNode, targetNode);
				
			}

			foreach (Case neighbour in GetNeighbours(grid,node,dimX,dimY))
			{ 
				if (neighbour.mur || (neighbour.perso!=null && neighbour!=targetNode)  || closedSet.Contains(neighbour))
				{
					continue;
				}

				int newCostToNeighbour = node.gCost + GetDistance(node, neighbour);
				if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
				{
					neighbour.gCost = newCostToNeighbour;
					neighbour.hCost = GetDistance(neighbour, targetNode);
					neighbour.precedent = node;

					if (!openSet.Contains(neighbour))
						openSet.Add(neighbour);
				}
			}
		}
		return null;
	}
	List<Case> GetNeighbours(Case[,] grid, Case c, int dimX, int dimY)
	{
		List<Case> neighbours = new List<Case>();

		for (int x = -1; x <= 1; x++)
		{
			for (int y = -1; y <= 1; y++)
			{
				if (x != 0 && y != 0)
					continue;
				else if (y == 0 && x == 0)
					continue;
				int checkX = c.getX() + x;
				int checkY = c.getY() + y;

				if (checkX >= 0 && checkX < dimX && checkY >= 0 && checkY < dimY)
				{
					neighbours.Add(grid[checkY, checkX]);
				}
			}
		}

		return neighbours;
	}

	List<Case> RetracePath(Case startNode, Case endNode)
	{
		List<Case> path = new List<Case>();
		Case currentNode = endNode;

		while (currentNode != startNode)
		{
			path.Add(currentNode);
			currentNode = currentNode.precedent;
		}
		path.Reverse();

		return path;

	}

	int GetDistance(Case nodeA, Case nodeB)
	{
		int dstX = Mathf.Abs(nodeA.getX() - nodeB.getX());
		int dstY = Mathf.Abs(nodeA.getY() - nodeB.getY());

		if (dstX > dstY)
			return 14 * dstY + 10 * (dstX - dstY);
		return 14 * dstX + 10 * (dstY - dstX);
	}
}