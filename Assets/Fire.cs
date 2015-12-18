using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{
    public ParticleSystem fire;
    public EnemyHealth enemyHP;
    Collision FireArea;
    bool shooting;
    // Use this for initialization
    void Start()
    {
        fire.Clear();
        fire.Pause();
        shooting = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            fire.Play();
            shooting = true;

        }
        else if (Input.GetMouseButtonUp(1))
        {
            fire.Pause();
            fire.Clear();
            shooting = false;
        }

    }
    void OnCollisionEnter(Collision col)
    {
        if (shooting) {
            if (col.gameObject.name == "Enemies") {
                enemyHP.TakeDamage(10);
            }
        }

    }
}
