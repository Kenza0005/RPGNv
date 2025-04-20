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


    // Update is called once per frame
    void Update()
    {
        // Verification si une arme est ajouter a un slot 
        if (transform.childCount > 0)
        {
            weaponID = gameObject.GetComponentInChildren<ItemOnObject>().item.itemID;
        }
        else
        {
            weaponID = 0;
            for (int i = 1; i < weaponList.Count; i++)
            {
                 weaponList[1].SetActive(true);
            }
        }
         // l'epee
        if (weaponID == 1 && transform.childCount > 0)
        {
            for (int i = 0; i < weaponList.Count; i++)
            {
                if (i == 0)
                {
                    weaponList[0].SetActive(true);
                }
            }
        }
        // bracer
        if (weaponID == 2 && transform.childCount > 0)
        {
            for (int i = 1; i < weaponList.Count; i++)
            {
                if (i == 1)
                {
                    weaponList[1].SetActive(true);
                }
            }
        }

    }
}
