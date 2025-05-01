using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckItem : MonoBehaviour
{
    // l'ID de l'arme actuelle
    private int itemID = 0;
    [SerializeField]
    // Liste de nos armes (Objet qui se trouve dans la main du personnage)
    public List<GameObject> itemList = new List<GameObject>();
    // Mmbre de notre personnage
    public GameObject bodyPart;

    // Update is called once per frame
    void Start()
    {
        if (transform.childCount > 0)
        {
            itemID = gameObject.GetComponentInChildren<ItemOnObject>().item.itemID;
        }
    }
    void Update()
    {
        if (transform.childCount > 0)
        {
            itemID = gameObject.GetComponentInChildren<ItemOnObject>().item.itemID;
        }
        // Verification si une arme est ajouter a un slot 
        else
        {
             itemID = 0;
            for (int i = 0; i < itemList.Count; i++)
            {
                  itemList[i].SetActive(false);
            }
        }
        // si le jeu detecte plusieurs armes dans la main du personnage on les desactive toute sauf celle qui est vraiment equipee
        if(bodyPart.transform.childCount > 1)
        {
            for (int i = 0; i < itemList.Count ; i++)
            {
                itemList[i].SetActive(false);
            }
        }
         // l'epee
        if (itemID == 1 && transform.childCount > 0)
        {
            Debug.Log("Enter Epee");
            for (int i = 0; i < itemList.Count; i++)
            {
                if (i == 0)
                {
                     Debug.Log("Enter Epee active !!");
                    itemList[i].SetActive(true);
                }
            }
        }
        //Le halmet (le casque)
        if (itemID == 2 && transform.childCount > 0)
        {
            Debug.Log("Enter Bracer");
            for (int i = 0; i < itemList.Count; i++)
            {
                if (i == 0)
                {
                    itemList[i].SetActive(true);
                }
                
            }
        }


        //bracer
        if (itemID == 3 && transform.childCount > 0)
        {
            Debug.Log("Enter Bracer");
            for (int i = 0; i < itemList.Count; i++)
            {
                if (i == 0 || i == 1)
                {
                    itemList[i].SetActive(true);
                }
                
            }
        }
        
    }
}
