using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterE : MonoBehaviour
{
    public float damage = 10f;
    public bool canattack = false;
    public bool attacking = false;

    public GameObject bolt;

    float timer = 0;
    float timelimit = 4.8f;

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

            GameObject newBolt = Instantiate(bolt, currentPosition, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            Rigidbody2D myBody = newBolt.GetComponent<Rigidbody2D>();
            myBody.velocity = new Vector2(-4f, 0);
            newBolt.GetComponent<KurageBolt>().damage = damage;
        }
    }
}
