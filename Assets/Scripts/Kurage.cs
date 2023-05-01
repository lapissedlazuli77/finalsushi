using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kurage : BaseKaniUnit
{
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
}
