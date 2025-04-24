using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWeapon : MonoBehaviour
{
    // l'ID de l'arme actuelle
    private int weaponID = 0;
    [SerializeField]
    // Liste de nos armes (Objet qui se trouve dans la main du personnage)
    public List<GameObject> weaponList = new List<GameObject>();
    // Mmbre de notre personnage
    public GameObject bodyPart;

    // Update is called once per frame
    void Start()
    {
        if (transform.childCount > 0)
        {
            weaponID = gameObject.GetComponentInChildren<ItemOnObject>().item.itemID;
        }
    }
    void Update()
    {
        if (transform.childCount > 0)
        {
            weaponID = gameObject.GetComponentInChildren<ItemOnObject>().item.itemID;
        }
        // Verification si une arme est ajouter a un slot 
        else
        {
             weaponID = 0;
            for (int i = 0; i < weaponList.Count; i++)
            {
                  weaponList[i].SetActive(false);
            }
        }
        // si le jeu detecte plusieurs armes dans la main du personnage on les desactive toute sauf celle qui est vraiment equipee
        // if(bodyPart.transform.childCount > 1)
        // {
        //     for (int i = 0; i < weaponList.Count ; i++)
        //     {
        //         weaponList[i].SetActive(false);
        //     }
        // }
         // l'epee
        if (weaponID == 1 && transform.childCount > 0)
        {
            Debug.Log("Enter Epee");
            for (int i = 0; i < weaponList.Count; i++)
            {
                if (i == 0)
                {
                    weaponList[i].SetActive(true);
                }
            }
        }
        // bracer
        // if (weaponID == 3 && transform.childCount > 0)
        // {
        //     Debug.Log("Enter Bracer");
        //     for (int i = 1; i < weaponList.Count; i++)
        //     {
        //         if (i == 1)
        //         {
        //             weaponList[i].SetActive(true);
        //         }
        //     }
        // }

    }
}
