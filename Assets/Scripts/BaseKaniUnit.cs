using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseKaniUnit : MonoBehaviour
{
    public float health;
    public float damage;
    public float speed;

    Animator myAnim;
    public StateMachine stateMachine;

    public Detector detector;

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
    }
    #endregion

    protected virtual void SetHealth()
    {
        health = 100f;
    }

    protected virtual void SetDamage()
    {
        damage = 100f;
    }
    protected virtual void SetSpeed()
    {
        speed = 1f;
    }
}
