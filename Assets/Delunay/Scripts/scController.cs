using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class scController : MonoBehaviour
{

    private bool hasStarted = false;
    private bool isFinished = false;
    private bool noNeed = false;
    //List of all cells created at in start
    private ArrayList cellList = new ArrayList();

    //List of cells that have been turned into rooms
    private List<scVertexNode> roomList = new List<scVertexNode>();

    //the Delaunay Triangulation controller 
    //(Contains incremental Algorithum for construcing a Delaunay Triangulation of a set of verticies)
    private scDTController theDTController;
    private bool DTFinished = false;

    private scPrims thePrimController = new scPrims();
    private bool PrimFinished = false;
    Transform cellHolder;
    private bool doFrame = false;
    // Use this for initialization
    void Start()
    {
        if (ChangeSceneService.instance.parameter != "nouvelle partie" && SaveSystem.LoadMap() != null)
        {
            noNeed = true;
            CarteService.instance.loadMap();
            return;
        }
        theDTController = new scDTController();
        cellHolder = new GameObject("cellHolder").transform;

        for (int i = 0; i < 100; i++)
        {
            GameObject aCell = (GameObject)Instantiate(Resources.Load("Cell"));

            int xScale = Random.Range(5, 30);
            int yScale = Random.Range(5, 30);

            if (xScale % 2 != 0) { xScale += 1; }
            if (yScale % 2 != 0) { yScale += 1; }

            aCell.transform.localScale = new Vector3(xScale, xScale, aCell.transform.localScale.y);

            int xPos = Random.Range(0, 20);
            int yPos = Random.Range(0, 20);

            aCell.transform.position = new Vector3(-10 + xPos, -10 + yPos, 0);
            aCell.transform.SetParent(cellHolder);
            aCell.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

            aCell.GetComponent<scCell>().setup();
            cellList.Add(aCell);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!noNeed)
        {
            if (!hasStarted)
            {
                if (cellsStill())
                {
                    hasStarted = true;
                }
            }
            else
            {
                if (!isFinished)
                {

                    //turn large cells into rooms;
                    setRooms();

                    //initalize the triangulation
                    theDTController.setupTriangulation(roomList);

                    isFinished = true;
                }
                else
                {
                    if (!DTFinished)
                    {
                        if (!theDTController.getDTDone())
                        {
                            theDTController.Update();
                        }
                        else
                        {
                            DTFinished = true;
                            thePrimController.setUpPrims(roomList, theDTController.getTriangulation());
                        }
                    }
                    else
                    {
                        if (!PrimFinished)
                        {
                            List<GameObject> listEtape = new List<GameObject>();
                            thePrimController.Update();
                            foreach (scVertexNode aNode in roomList)
                            {
                                aNode.getParentCell().AddComponent<ScEtape>();
                                listEtape.Add(aNode.getParentCell());

                            }
                            foreach (scEdge aEdge in thePrimController.getConnections())
                            {
                                aEdge.getNode0().getParentCell().GetComponent<ScEtape>().addConnection(aEdge.getNode1().getParentCell());
                                aEdge.getNode1().getParentCell().GetComponent<ScEtape>().addConnection(aEdge.getNode0().getParentCell());
                            }
                            PrimFinished = true;
                            Debug.Log(listEtape);
                            Debug.Log(thePrimController.edgesInTree);
                            List<GameObject> dirtyObject = new List<GameObject>();
                            foreach (GameObject g in listEtape)
                            {
                                if (!g.GetComponent<ScEtape>().hasConnexion())
                                {
                                    dirtyObject.Add(g);

                                }
                            }
                            listEtape.RemoveAll(r => !r.GetComponent<ScEtape>().hasConnexion());
                            foreach (GameObject g in dirtyObject)
                            {
                                Destroy(g);
                            }
                            foreach (GameObject g in GameObject.FindGameObjectsWithTag("Lines"))
                            {
                                if (g.name == "EdgeLine")
                                {
                                    g.SetActive(false);
                                }
                            }

                            cellHolder.gameObject.SetActive(false);
                            CarteService.instance.initialiseMap(listEtape);

                        }
                    }
                }

            }
        }
    }


    //returns if all the cells have stopped moving or not
    private bool cellsStill()
    {

        bool placed = true;
        foreach (GameObject aCell in cellList)
        {
            if (!aCell.GetComponent<scCell>().getHasStopped())
            {
                placed = false;
            }
        }
        return placed;

    }

    //handles choosing which cells to turn to rooms
    private void setRooms()
    {
        foreach (GameObject aCell in cellList)
        {
            aCell.SetActive(false);
            if (aCell.transform.localScale.x > 15 || aCell.transform.localScale.y > 15)
            {
                aCell.SetActive(true);
                scVertexNode thisNode = new scVertexNode(aCell.transform.position.x, aCell.transform.position.y, aCell.gameObject);
                roomList.Add(thisNode);
            }

            Destroy(aCell.GetComponent<scCell>());
        }
    }
}
