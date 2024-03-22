using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletSO BulletSO;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void AddForce(Vector3 dir)
    {
        // need Vecto Dir
        rb.AddForce(dir * BulletSO.speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.OnTakeDame(BulletSO.RangeDame);
            Destroy(gameObject);
        }
        else
        {
            
            if(collision.transform.TryGetComponent<PlayerController>(out PlayerController player))
            {
                player.OnTakeDame(BulletSO.RangeDame);
                Destroy(gameObject);
            }
        }
    }
}
