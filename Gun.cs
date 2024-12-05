using UnityEngine;

public class Gun : MonoBehaviour
{

    public Bullet bullet;
    UnityEngine.Vector2 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = (transform.localRotation * UnityEngine.Vector2.right).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Shoot()
    {
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        Bullet goBullet = go.GetComponent<Bullet>();
        goBullet.direction = direction;
    }
}
