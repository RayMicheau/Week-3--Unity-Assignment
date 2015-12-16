using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    //Speed of projectiles
    public float speed;

    //rigidbody of projectile
    public Rigidbody projectile;
    
    //where they shoot from
    public Transform shootPoint;
    
    //The light!
    public Light flashlight;

    //Brought over from weapons script
    public int currWeap;
    private int nrWeapons;
    public GameObject[] weapons;
    public Rigidbody[] bullets;

    //START AND PREPARE THE THINGS!
    void Start() {
        flashlight.enabled = false;

        //Prepare weapons
        nrWeapons = weapons.Length;

        //Set weapon to the current weapon
        changeWeapon(currWeap);
    }

    // Update is called once per frame
    void Update() {
        //Input stuff!
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            FlashLightToggle();
        }
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

    //Flashlight toggle!
    void FlashLightToggle() {
            if (!flashlight.enabled)
            {
                flashlight.enabled = true;
            }
            else if (flashlight.enabled)
            {
                flashlight.enabled = false;
            }
    }

    //Method to change weapon based on the button chosen
    //Setting active weapon to inactive
    //activating the next
    //and changing the projectile to the proper one
    void changeWeapon(int num)
    {
        Debug.Log("Changing the weapon");
        for (int i = 0; i < nrWeapons; i++)
        {
            //Swaps to the new active chosen weapon
            if (i == num)
            {
                weapons[i].gameObject.SetActive(true);
                projectile = bullets[i];
            }
            else
            {
                weapons[i].gameObject.SetActive(false);
            }
        }
    }

    void Shoot()
    {
        Rigidbody instantiateProj = Instantiate(projectile, shootPoint.transform.position, shootPoint.transform.rotation) as Rigidbody;
        instantiateProj.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        Destroy(instantiateProj.gameObject, 1.0f);
    }

}
