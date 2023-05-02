using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ikura : BaseSakanaUnit
{
    public Shooter shooter;

    #region states
    protected override void Advancing()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x += speed;
        transform.position = currentPosition;
        shooter.attacking = false;
    }
    protected override void Attacking()
    {
        Vector3 currentPosition = transform.position;
        transform.position = currentPosition;
        shooter.attacking = true;
    }
    #endregion

    protected override void SetHealth()
    {
        health = 42f;
    }
    protected override void SetDamage()
    {
        damage = 23f;
        shooter.damage = damage;
    }
    protected override void SetSpeed()
    {
        speed = 0.0021f;
    }
    public void Damaged(float dama)
    {
        health -= dama;
    }
}
