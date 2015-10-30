using UnityEngine;
using System.Collections;

public class Weapons : MonoBehaviour {

    public GameObject[] weapons;
    public int currWeap;

    private int nrWeapons;

    // Use this for initialization
    void Start()
    {
        nrWeapons = weapons.Length;
        changeWeapon(currWeap);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 1; i <= nrWeapons; ++i)
        {
            if (Input.GetKeyDown("" + i))
            {
                currWeap = i - 1;

                changeWeapon(currWeap);
            }
        }
    }

    void changeWeapon(int num)
    {
        for (int i = 0; i < nrWeapons; i++)
        {
            if (i == num)
                weapons[i].gameObject.SetActive(true);
            else
                weapons[i].gameObject.SetActive(false);
        }
    }
}
