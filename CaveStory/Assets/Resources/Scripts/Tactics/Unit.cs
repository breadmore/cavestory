﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public enum UnitState { Run, Battle, Attack, Die }
    public UnitState unitState;
    RaycastHit hit;
    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private GameObject Target;
    private bool isAttack = true;
    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        FindTarget();
        StateChange();
    }

    void Move()
    {
        if (!Target)
            unitState = UnitState.Run;
        if(unitState == UnitState.Run)
            transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void FindTarget()
    {
        if (Physics.Raycast(transform.position, Vector3.right, out hit, 3.0f))
        {
            Debug.DrawRay(transform.position, Vector3.right * 3.0f, Color.blue, 0.3f);
            if (hit.transform.tag == "Player")
            {
                Target = hit.transform.gameObject;
                unitState = UnitState.Battle;
                if (isAttack == true)
                    StartCoroutine(AttackCharge());
            }
        }
    }

    void StateChange()
    {
        switch(unitState)
        {
            case UnitState.Battle:
                break;
            case UnitState.Attack:
                break;
            case UnitState.Die:
                break;
        }
    }

    IEnumerator AttackCharge()
    {
        unitState = UnitState.Attack;
        Attack();
        yield return new WaitForSeconds(1.0f);
        isAttack = true;
    }

    void Attack()
    {
        Target.GetComponent<Enemy>().DamageHP();
        unitState = UnitState.Battle;
        isAttack = false;
    }
}
