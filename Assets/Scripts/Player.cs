using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;

    public Joystick joystick;

    // SErializeFields are editable in Unity :)
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    Vector2 minBounds;
    Vector2 maxBounds;

    Shooter shooter;

    void Awake()
    {
        shooter = GetComponent<Shooter>();
    }


    void Start()
    {
        InitBounds();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main; // camera tagged with the main flag
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Move()
    {
        // Time.deltaTime for framerate independent.
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector3 deltaJoystick = joystick.Direction * moveSpeed * Time.deltaTime;

        if (Mathf.Abs(deltaJoystick.x + deltaJoystick.y) > Mathf.Abs(delta.x + delta.y))
        {
            delta = deltaJoystick;
        }

        Vector2 newPos = new Vector2();
        // if(newPos.x + delta.x > maxBounds.x )
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);

        transform.position = newPos;
    }


    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        // Debug.Log(rawInput);
    }

    //InputValue available because we set the Input type to "value"
    void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }

    public void Fire()
    {
        shooter.isFiring = true;
    }

    public void StopFire()
    {
        shooter.isFiring = false;
    }
}
