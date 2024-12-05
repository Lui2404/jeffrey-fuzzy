using UnityEngine;

public class Bullet : MonoBehaviour
{

    public UnityEngine.Vector2 direction = new UnityEngine.Vector2(1,0);
    public float speed = 2;

    public UnityEngine.Vector2 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 1.5f); 
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed;
    }


    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;



        if (pos.y >= 9.89f)
        {
            Destroy(gameObject);
        }
        // Bottom
        if (pos.y <= -9.38f)
        {
            Destroy(gameObject);
        }
        // Left
        if (pos.x <= -14.69f)
        {
            Destroy(gameObject);
        }
        // Right
        if (pos.x >= 14.69f)
        {
            Destroy(gameObject);
        }
        transform.position = pos;
    }
}
