﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class scPrims {

	private Hashtable vertexTable = new Hashtable();
	
	private List<scVertexNode> allNodes;
	private List<scEdge> allEdges;
	
	public List<scEdge> edgesInTree = new List<scEdge>();
	private List<scVertexNode> nodesInTree = new List<scVertexNode>();
	private int pourcentEnPlus = 10;
	public void Update () {
		foreach(scEdge aEdge in edgesInTree){
			aEdge.drawEdge();	
		}
	}
	
	public void setUpPrims(List<scVertexNode> _verticies ,List<scEdge> _edges){
		
		allNodes = _verticies;
		allEdges = _edges;
		
		foreach(scEdge aEdge in _edges){
			
			if (!vertexTable.ContainsKey(aEdge.getNode0())){
				List<scVertexNode> temp = new List<scVertexNode>();
				temp.Add(aEdge.getNode1());
				vertexTable.Add(aEdge.getNode0(),temp);	
			}else{
				List<scVertexNode> temp = (List<scVertexNode>) vertexTable[aEdge.getNode0()];
				
				if (!temp.Contains(aEdge.getNode1())){
					temp.Add(aEdge.getNode1());
					vertexTable[aEdge.getNode0()] = temp;
				}
				
			}
			
			if (!vertexTable.ContainsKey(aEdge.getNode1())){
				List<scVertexNode> temp = new List<scVertexNode>();
				temp.Add(aEdge.getNode0());
				vertexTable.Add(aEdge.getNode1(),temp);	
			}else{
				List<scVertexNode> temp = (List<scVertexNode>) vertexTable[aEdge.getNode1()];
				
				if (!temp.Contains(aEdge.getNode0())){
					temp.Add(aEdge.getNode0());
					vertexTable[aEdge.getNode1()] = temp;
				}
			}
				
		}
		
		startPrims();
		
		List<scEdge> poolList = new List<scEdge>();
		
		foreach(scEdge edges in allEdges){
			if (!edgesInTree.Contains(edges)){
				poolList.Add(edges);	
			}
		}

		int perc = (poolList.Count * pourcentEnPlus) /100;
		
		for(int i =0; i < perc; i++){
			int index = Random.Range(0,poolList.Count);
			
			edgesInTree.Add(poolList[index]);
			poolList.RemoveAt(index);
		}

		
	}
	
	private void startPrims(){
		int count = Random.Range(0,allNodes.Count);
		scVertexNode theNode=null;
		//scVertexNode theNode = allNodes[count];
		foreach (scVertexNode sc in vertexTable.Keys)
		{
			theNode = sc;
			break;
		}
		nodesInTree.Add(theNode);
		findNext();
	}
	
	private void findNext(){
		
		scVertexNode oldNode = null;
		scVertexNode closesNode = null;
		float closesDistance = 0;
		
		
		foreach(scVertexNode aNode1 in nodesInTree){

			List<scVertexNode> connectedNodes = (List<scVertexNode>) vertexTable[aNode1];

			foreach(scVertexNode aNode in connectedNodes){
				if (!nodesInTree.Contains(aNode)){
					float tempDst = Vector2.Distance(aNode.getParentCell().transform.position, aNode1.getParentCell().transform.position);
					if (closesNode != null){
						if (tempDst < closesDistance){
							closesDistance = tempDst;
							closesNode = aNode;
							oldNode = aNode1;
						}
					}else{
						closesNode = aNode;
						closesDistance = tempDst;
						oldNode = aNode1;
					}
				}
			}
		}
		if (closesNode != null)
		{

		
		nodesInTree.Add(closesNode);
		
		foreach(scEdge aEdge in allEdges){
			if (aEdge.edgeContainsVertex(oldNode) && aEdge.edgeContainsVertex(closesNode)){
				aEdge.setDrawColor(new Color(0,255,0,255));
				edgesInTree.Add(aEdge);
			}
		}
		}
		if (nodesInTree.Count == vertexTable.Count){
			return;	
		}else{
			findNext();	
		}
	}
	
	public void stopEdgeDraw(){
		GameObject[] allLines = (GameObject[]) GameObject.FindGameObjectsWithTag("Lines");
		
		foreach(GameObject aLine in allLines){
			GameObject.Destroy(aLine);	
		}
	}
	
	public List<scEdge> getConnections(){
		return edgesInTree;	
	}
}
