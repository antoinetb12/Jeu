using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarteService : MonoBehaviour
{
    public static CarteService instance = null;
    List<Niveau> listNiveau=null;
    DottedLineService dottedLineService;
    List<NiveauEntity> listNiveauEntity;
    public NiveauEntity niveauSelectionnee=null;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        dottedLineService = GetComponent<DottedLineService>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void lanceNiveau(Niveau niveau)
    {
        this.niveauSelectionnee = listNiveauEntity.Find((n) => n.x == niveau.transform.position.x && n.y == niveau.transform.position.y && n.z == niveau.transform.position.z); ;
        ChangeSceneService.instance.ChangeScene("Combat");
    }

    void addEtape(List<GameObject> listDejaVu, List<GameObject> listInput, ScEtape etape,Niveau niveau)
    {
        etape.niveauAssocie = niveau;

        foreach (GameObject g in etape.getConnexion())
        {
            if (!listDejaVu.Contains(g) && !listInput.Contains(g))
            {
                listInput.Add(g);
                g.GetComponent<ScEtape>().etape= etape.etape+1;
                g.GetComponent<ScEtape>().etapeParent = etape;
            }
            if (g.GetComponent<ScEtape>().niveauAssocie != null)
            {
                niveau.addConnection(g.GetComponent<ScEtape>().niveauAssocie);
            }
            
            g.GetComponent<ScEtape>().niveauParent = niveau;
        }
    }
    public void initialiseMap(List<GameObject> list)
    {
        if (listNiveau != null)
        {
            Debug.Log(listNiveau[0]);
            return;
        }
        listNiveau = new List<Niveau>();
        List<GameObject> listDejaVu = new List<GameObject>();
        List<GameObject> aUtilise = new List<GameObject>();
        GameObject niveauG;
        Niveau niveau;
        int id=0;
        GameObject etapeChoose;
        GameObject niveauContainer = GameObject.Find("NiveauContainer");
        GameObject premiereEtape = list[0];
        GameObject derniereEtape = list[0];
        foreach (GameObject g in list)
        {
            if (g.transform.position.y < premiereEtape.transform.position.y)
            {
                premiereEtape = g;
            }
            if (g.transform.position.y > derniereEtape.transform.position.y)
            {
                derniereEtape = g;
            }
        }
        aUtilise.Add(premiereEtape);

        while (aUtilise.Count!=0)
        {
            etapeChoose = aUtilise[0];
            aUtilise.RemoveAt(0);
            niveauG = (GameObject)Instantiate(Resources.Load("niveau"));
            niveauG.transform.SetParent(niveauContainer.transform);
            niveau = niveauG.GetComponent<Niveau>();
            listNiveau.Add(niveau);
            niveau.id = id;
            if (etapeChoose.Equals(derniereEtape))
            {
                niveauG.SetActive(true);
                // niveauG.SetActive(false);

                niveauG.transform.localScale = new Vector3(etapeChoose.transform.localScale.x, etapeChoose.transform.localScale.y, etapeChoose.transform.localScale.z);
                niveauG.transform.position = new Vector3(etapeChoose.transform.position.x , etapeChoose.transform.position.y*2, 0);
                niveau.setDifficulte(2);
                niveau.Etape = etapeChoose.GetComponent<ScEtape>().etape;
            }
            else if (etapeChoose.transform.localScale.x <= 25 || etapeChoose.Equals(premiereEtape))
            {
                niveauG.SetActive(true);
                // niveauG.SetActive(false);

                niveauG.transform.localScale = new Vector3(etapeChoose.transform.localScale.x, etapeChoose.transform.localScale.y, etapeChoose.transform.localScale.z);
                niveauG.transform.position = new Vector3(etapeChoose.transform.position.x , etapeChoose.transform.position.y*2, 0);
                niveau.setDifficulte(0);
                niveau.Etape = etapeChoose.GetComponent<ScEtape>().etape;
            }
            else
            {
                niveauG.SetActive(true);
                // niveauG.SetActive(false);

                niveauG.transform.localScale = new Vector3(etapeChoose.transform.localScale.x, etapeChoose.transform.localScale.y, etapeChoose.transform.localScale.z);
                niveauG.transform.position = new Vector3(etapeChoose.transform.position.x , etapeChoose.transform.position.y*2, 0);
                niveau.setDifficulte(1);
                niveau.Etape = etapeChoose.GetComponent<ScEtape>().etape;
            }
            if (etapeChoose.GetComponent<ScEtape>().niveauParent != null)
            {
                etapeChoose.GetComponent<ScEtape>().niveauParent.addConnection(niveau);
                //niveau.addConnection(etapeChoose.GetComponent<ScEtape>().niveauParent.gameObject);
            }
            if (etapeChoose.Equals(premiereEtape))
            {
                niveau.Visible = true;
                niveauG.SetActive(true);
            }
            addEtape(listDejaVu, aUtilise, etapeChoose.GetComponent<ScEtape>(), niveau);
            listDejaVu.Add(etapeChoose);
            foreach (GameObject g in etapeChoose.GetComponent<ScEtape>().getConnexion())
            {
                if (listDejaVu.Contains(g))
                {
                    dottedLineService.DrawDottedLine(g.GetComponent<ScEtape>().niveauAssocie.transform.position, niveauG.transform.position);

                }
                

              
            }
            id++;
        }

        dottedLineService.Render();
        saveMap();
        ChangeSceneService.instance.finChargement();

    }
    public void saveMap()
    {
        List<GameObject> listDejaVu = new List<GameObject>();
        List<Niveau> aUtilise = new List<Niveau>();
        
        listNiveauEntity = new List<NiveauEntity>();
        NiveauEntity niveauESelectionne;
        aUtilise.Add(listNiveau[0]);
        foreach(Niveau niveau in listNiveau)
        {
            listNiveauEntity.Add(new NiveauEntity(niveau.id,niveau.Visite, niveau.Visible, niveau.Difficulte, niveau.Etape, niveau.transform.position.x, niveau.transform.position.y, niveau.transform.position.z));          
        }
        foreach(Niveau niveau in listNiveau)
        {
            niveauESelectionne = listNiveauEntity.Find((n) => n.id==niveau.id);
            foreach(Niveau niveauC in niveau.niveauConnecte)
            {

                niveauESelectionne.addConnection(listNiveauEntity.Find((n) => n.id == niveauC.id));
            }
        }
        SaveSystem.SaveMap(listNiveauEntity);
    }
    public void loadMap()
    {
        if (listNiveauEntity == null) { 
            listNiveauEntity=SaveSystem.LoadMap();
        }
        List<NiveauEntity> listDejaVu = new List<NiveauEntity>();
        List<NiveauEntity> aUtilise = new List<NiveauEntity>();

        listNiveau = new List<Niveau>();
        Niveau niveauSelectionne;
        Niveau niveau = null;
        GameObject niveauG;
        aUtilise.Add(listNiveauEntity[0]);
        GameObject niveauContainer = GameObject.Find("NiveauContainer");

        foreach (NiveauEntity niveauEntity in listNiveauEntity)
        {
            niveauG = (GameObject)Instantiate(Resources.Load("niveau"));
            niveauG.SetActive(true);
            niveauG.transform.SetParent(niveauContainer.transform);
            niveau = niveauG.GetComponent<Niveau>();
            listNiveau.Add(niveau);
            niveauEntity.setValue(niveau);
            //listNiveauEntity.Add(new NiveauEntity(niveau.Visite, niveau.Visible, niveau.Difficulte, niveau.Etape, niveauG.transform.position.x, niveauG.transform.position.y, niveauG.transform.position.z));
        }
        foreach (NiveauEntity niveauEntity in listNiveauEntity)
        {
            niveauSelectionne = listNiveau.Find((niveauGa) => niveauEntity.id == niveauGa.id);
            foreach (NiveauEntity niveauE in niveauEntity.niveauConnecte)
            {
                niveau.addConnection(listNiveau.Find((gNiveau) => niveauE.x == gNiveau.transform.position.x && niveauE.y == gNiveau.transform.position.y && niveauE.z == gNiveau.transform.position.z));
            }
        }
        ChangeSceneService.instance.finChargement();

    }
}
