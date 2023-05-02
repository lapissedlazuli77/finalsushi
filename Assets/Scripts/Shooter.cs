using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float damage = 10f;
    public bool canattack = false;
    public bool attacking = false;

    public GameObject pellet;

    float timer = 0;
    float timelimit = 1.25f;

    void Update()
    {
        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timelimit)
            {
                timer = 0;
                canattack = true;
            }
        }
        if (canattack)
        {
            canattack = false;

            Vector3 currentPosition = transform.position;

            GameObject newShot = Instantiate(pellet, currentPosition, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            Rigidbody2D myBody = newShot.GetComponent<Rigidbody2D>();
            myBody.velocity = new Vector2(4f, 0);
            newShot.GetComponent<IkuraPellet>().damage = damage;
        }
    }
}
