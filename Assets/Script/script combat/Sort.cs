using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(RayonAction))]
public class Sort : MonoBehaviour
{
    public string nom;
    public int pdd = 1;
    public int range = 1;
    public int cout = 3;
    public bool besoinLdv=true;
    public int rangeMin = 1;
    public int niveau=1;
    public RayonAction rayonAction;
    public List<GameObject> effet;
    // Start is called before the first frame update
    private void OnMouseUp()
    {
        ControleurCombat.instance.selectionneSort(this);
    }
    private void Start()
    {
        rayonAction= GetComponent<RayonAction>();
    }
    public List<Position> GetRayon(Vector3 startPos, Case targetCase, Case[,] grid, int dimX, int dimY)
    {
        return rayonAction.GetRayon(startPos, targetCase, grid, dimX, dimY);
    }

}
