using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]

    private NavMeshAgent navMeshAgent;
    [SerializeField] private EnemySO enemySO;
    [SerializeField] private Transform healthBar;
    [SerializeField] private Transform pointShoot;
    [SerializeField] private BulletSO bulletSO;
    private float currentHP;
    public static event EventHandler OnEnemyDie;
    private bool isMove = true;
    private Transform targetTransform;
    public class OnTakeDameArgs : EventArgs
    {
        public float fillAmount;
    }
    private void Awake()
    {
        currentHP = enemySO.HP;
        navMeshAgent = GetComponent<NavMeshAgent>();
        targetTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGamePlaying())
        {
            if(isMove) {
                
                Movement();
            }
            
        }
        else
        {
            Destroy(gameObject);
        }
       
      
    }
    private void Movement()
    {
        navMeshAgent.destination = targetTransform.position;
        Debug.Log(transform.position);
        float distance = Vector3.Distance(transform.position,targetTransform.position);
      
        if(distance <= enemySO.distance)
        {
            navMeshAgent.speed = 0;
            isMove = false;
            Attack();
        }
    }
    public void OnTakeDame(float dame)
    {
        this.currentHP -= dame;
        if(this.currentHP <= 0)
        {

            Destroy(this.gameObject);
            // event to Player Count
            OnEnemyDie?.Invoke(this, new OnTakeDameArgs());
        }
        float value =(float) 1-( currentHP/ enemySO.HP);
        healthBar.GetComponent<HealthBar>().SetHP(value);
    }
    public void Attack()
    {
        Debug.Log("Attack");
        Transform bulletIns = Instantiate(bulletSO.prefab, pointShoot.position, Quaternion.identity);
        Vector3 Dir = targetTransform.position - transform.position;
        bulletIns.GetComponent<Bullet>().AddForce(Dir);
    }
   
}
