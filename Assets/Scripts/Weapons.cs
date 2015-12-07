using UnityEngine;
using System.Collections;

public class Weapons : MonoBehaviour {

    public GameObject[] weapons;
    public int currWeap;

    private int nrWeapons;

    // Use this for initialization
    void Start()
    {
        //Prepare weapons
        nrWeapons = weapons.Length;
        
        //Set weapon to the current weapon
        changeWeapon(currWeap);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 1; i <= nrWeapons; ++i)
        {
            if (Input.GetKeyDown(i + ""))
            {
                //Checks for key, then changes the weapon to the selected
                Debug.Log("Changing weapon to: " + i);
                currWeap = i - 1;
                changeWeapon(currWeap);
            }
        }
    }

    void changeWeapon(int num)
    {
        Debug.Log("Changing the weapon");
        for (int i = 0; i < nrWeapons; i++)
        {
            //Swaps to the new active chosen weapon
            if (i == num)
                weapons[i].gameObject.SetActive(true);
            else
                weapons[i].gameObject.SetActive(false);
        }
    }
}
