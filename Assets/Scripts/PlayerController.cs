using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private BulletSO bulletSO;
    [SerializeField] private Transform pointShoot;
   
    [SerializeField] private Transform healthBar;
    [SerializeField] private Text txtPointAward;

    private int countKill;
    private float currentHP;
    // Start is called before the first frame update
    private float timeCount;
    private void Awake()
    {
        countKill = 0;
        currentHP = playerSO.HP;
    }
    void Start()
    {
        Enemy.OnEnemyDie += Enemy_OnEnemyDie;
    }

    private void Enemy_OnEnemyDie(object sender, EventArgs e)
    {
        countKill++;
        txtPointAward.text = countKill.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGamePlaying())
        {
            timeCount += Time.deltaTime;
            Attack();
            HandleAiming();

        }

    }
    private void Attack()
    {
        if(timeCount> playerSO.SpeedAttack && Input.GetMouseButtonDown(1))
        {

            timeCount = 0; // reset time 
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
 
                Transform bulletIns = Instantiate(bulletSO.prefab, pointShoot.position, Quaternion.identity);
                Vector3 hitPoint = new Vector3(hit.point.x, pointShoot.position.y, hit.point.z);
                Vector3 Dir = hitPoint - pointShoot.position;
                bulletIns.GetComponent<Bullet>().AddForce(Dir);
                // nếu nó đã hủy thì sao ?????
                if (bulletIns != null)
                {
                    Destroy(bulletIns.gameObject, 3f);
                }
            }




        }
    }
    private void HandleAiming()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            Vector3 hitPoint = new Vector3(hit.point.x, pointShoot.position.y, hit.point.z);
            Vector3 Dir = hitPoint - pointShoot.position;
            transform.LookAt(Dir);

        }

    }
    public void OnTakeDame(float damege)
    {
        this.currentHP -= damege;
      
        float fillAmout =1- (float)(currentHP / playerSO.HP);
        Debug.Log(fillAmout);
        healthBar.GetComponent<HealthBar>().SetHP(fillAmout);
        if (currentHP < 0)
        {
          
            GameManager.Instance.SetGameState(State.GameOver);
        }
    }
    
}
