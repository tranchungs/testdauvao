using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField]
    private  Queue<Bullet> m_PoolBullet;
    private Transform bulletPrefabs;
    private int Amount;
    private void Awake()
    {
        m_PoolBullet = new Queue<Bullet>();
    }
    void Start()
    {
        
    }
    private void InstanceBullet()
    {
        for (int i = 0; i < Amount; i++)
        {
           Transform bulletIns =  Instantiate(bulletPrefabs);
            m_PoolBullet.Enqueue(bulletIns.GetComponent<Bullet>());
        }
    }
    private void GetBullet()
    {

    }
    private void ReturnBullet()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
