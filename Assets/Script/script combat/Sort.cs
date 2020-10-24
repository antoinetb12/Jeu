using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RayonAction))]
public class Sort : MonoBehaviour, IPointerClickHandler
{
    public string nom;
    public int pdd = 1;
    public int range = 1;
    public int cout = 3;
    public bool besoinLdv=true;
    public int cooldown = 2;
    public int rangeMin = 1;
    public int tourAvantUtilisation = 0;
    public int niveau=1;
    public TypeSort typeSort=TypeSort.feu;
    public RayonAction rayonAction;
    public Effet effet;
    private Personnage detenteur;

    private void Awake()
    {
        Debug.Log("on laod effet");
        effet = GetComponent<Effet>();
    }
    public Personnage Detenteur { get => detenteur; set => detenteur = value; }

    // Start is called before the first frame update
    
    public void OnPointerClick(PointerEventData eventData)
    {
        ControleurCombat.instance.selectionneSort(this);
    }
    private void Start()
    {
        rayonAction= GetComponent<RayonAction>();
    }
    public List<Position> GetRayon(Vector3 startPos, Case targetCase, Case[,] grid, int dimX, int dimY)
    {
        if (rayonAction == null)
        {
            rayonAction = GetComponent<RayonAction>();
        }
        return rayonAction.GetRayon(startPos, targetCase, grid, dimX, dimY);
    }
    public bool disponible(Personnage j)
    {
        Debug.Log(name + ", " + tourAvantUtilisation);
        return j.getPa() >= cout && tourAvantUtilisation == 0;
    }
}
public enum TypeSort
{
    feu,eau,vent,terre
}