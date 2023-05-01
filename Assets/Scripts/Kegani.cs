using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kegani : BaseKaniUnit
{
    protected override void SetHealth()
    {
        health = 60f;
    }
    protected override void SetDamage()
    {
        damage = 14f;
    }
    protected override void SetSpeed()
    {
        speed = 0.0020f;
    }
}