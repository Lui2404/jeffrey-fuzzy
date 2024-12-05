using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class Ship : MonoBehaviour
{

    
    Gun[] guns;
                    // PLAYER MOVEMENT
    float moveSpeed = 10;

    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;

    bool shoot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       guns = transform.GetComponentsInChildren<Gun>();
    }

    // Update is called once per frame

    // ito yung key bindings sa keyboard WASD tyaka Arrows
    void Update()
    {
        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode. A);
        moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

        shoot = Input.GetKeyDown(KeyCode.Space);
        if (shoot)
        {
            shoot = false;
            foreach(Gun gun in guns)
            {
                gun.Shoot();
            }
        }
    }

        // d ako gumamit ng if else statments dito para hindi humihinto kapag dalawang button pinndot.
    private void FixedUpdate()
    {
        UnityEngine.Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.fixedDeltaTime;
        UnityEngine.Vector2 move = UnityEngine.Vector2.zero;
        
        if (moveUp)
        {
            move.y += moveAmount;
        }

        if (moveDown)
        {
            move.y -= moveAmount;
        }

        if (moveLeft)
        {
            move.x -= moveAmount;
        }

        if (moveRight)
        {
            move.x += moveAmount;
        }

        // naglagay ako pythagorean theorem para equal yung movement speed kahit diagonal.
        float moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y *move.y);
        if (moveMagnitude > moveAmount)
        {
            float ratio = moveAmount / moveMagnitude;
            move *= ratio;
        }
        
        pos += move;
        // BOUNDARIES

        // Top
        if (pos.y >= 7.83f)
        {
            pos.y = 7.83f;
        }
        // Bottom
        if (pos.y <= -7.83f)
        {
            pos.y = -7.83f;
        }
        // Left
        if (pos.x <= -14.69f)
        {
            pos.x = -14.69f;
        }
        // Right
        if (pos.x >= 14.69f)
        {
            pos.x = 14.69f;
        }
        transform.position = pos;
    }
}