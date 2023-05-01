using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kurage : BaseKaniUnit
{
    public GameObject bolt;
    public GameObject shootorigin;
    int boltcount = 0;

    protected override void SetHealth()
    {
        health = 19f;
    }
    protected override void SetDamage()
    {
        damage = 50f;
    }
    protected override void SetSpeed()
    {
        speed = 0.0006f;
    }
    protected override void Attack()
    {
        if (myAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.125f &&
            myAnim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.15f &&
            boltcount < 1)
        {
            boltcount++;
            Vector3 currentPosition = shootorigin.transform.position;

            GameObject newBolt = Instantiate(bolt, currentPosition, Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
            Rigidbody2D myBody = newBolt.GetComponent<Rigidbody2D>();
            myBody.velocity = new Vector2(-4f, 0);
        }
        if (myAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f && boltcount > 0)
        {
            boltcount = 0;
        }
    }
}
