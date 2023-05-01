using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseKaniUnit : MonoBehaviour
{
    public float health = 1f;
    public float damage = 1f;
    public float speed = 1f;

    public Animator myAnim;
    public StateMachine stateMachine;

    public Detector detector;
    public HitboxE hitbox;

    void AssembleStateMachine()
    {
        stateMachine = new StateMachine(Advancing, Attacking);
        stateMachine.ChangeState("Advancing");
    }

    void Start()
    {
        myAnim = GetComponent<Animator>();

        SetHealth();
        SetDamage();
        SetSpeed();
    }

    // Start is called before the first frame update
    private void Awake()
    {
        AssembleStateMachine();
    }

    // Update is called once per frame
    void Update()
    {
        this.stateMachine.Execute();
        if (detector.inrange)
        {
            stateMachine.ChangeState("Attacking");
            myAnim.SetBool("isAttacking", true);
        }
        else
        {
            myAnim.SetBool("isAttacking", false);
        }
        if (transform.position.x <= -4f)
        {
            Destroy(gameObject);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    #region states
    void Advancing()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x -= speed;
        transform.position = currentPosition;
    }
    void Attacking()
    {
        Vector3 currentPosition = transform.position;
        transform.position = currentPosition;
        Attack();
    }
    #endregion

    protected virtual void SetHealth()
    {
        health = 100f;
    }

    protected virtual void SetDamage()
    {
        damage = 100f;
        hitbox.damage = damage;
    }
    protected virtual void SetSpeed()
    {
        speed = 1f;
    }
    protected virtual void Attack()
    {
        if (myAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.125f && myAnim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.375f)
        {
            hitbox.gameObject.SetActive(true);
        }
        else if (myAnim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.125f && myAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.375f)
        {
            hitbox.gameObject.SetActive(false);
        }
    }
}
