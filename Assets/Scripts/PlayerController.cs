using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private float angle;
    private float dt;

    private Camera mainCamera;
    private Rigidbody2D rb;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private float moveAcceleration;
    [SerializeField] private float moveSpeed;

    [SerializeField] private GunScript gun;

    [SerializeField] private float fireRate;

    public GameObject TRlimitGO;
    public GameObject BLlimitGO;

    private Vector3 TRlimit;
    private Vector2 BLlimit;

    private bool fire;
    private bool hit;
    private float timeSinceHit = 0;
    private float currentTime = 1;

    private Vector2 moveDir;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        dt = Time.fixedDeltaTime;
        rb.AddForceAtPosition(new Vector2(0, 1), new Vector2(0, 21));
        gun = GetComponentInChildren<GunScript>();

        TRlimit = TRlimitGO.transform.position;
        BLlimit = BLlimitGO.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        timeSinceHit += Time.deltaTime;
        var pos = transform.position;
        var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var dir = mousePos - pos;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        moveDir = Vector2.zero;

        if (Input.GetKey("w") && transform.position.y < TRlimit.y) moveDir.y = 1;
        else if (Input.GetKey("s") && transform.position.y > BLlimit.y) moveDir.y = -1;

        if (Input.GetKey("d") && transform.position.x < TRlimit.x) moveDir.x = 1;
        else if (Input.GetKey("a") && transform.position.x > BLlimit.x) moveDir.x = -1;

        if (Input.GetMouseButtonDown(0)) fire = true;
        else if (Input.GetMouseButtonUp(0)) fire = false;

        if (fire && currentTime > 1 / fireRate)
        {
            currentTime = 0;
            gun.Shoot();
        }
        
        if (hit)
        {
            timeSinceHit = 0;
        }

        if (timeSinceHit > 100)
        {
            // pøidat život
            timeSinceHit= 0;
        }

        moveDir.Normalize();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        hit = true;
    }
    private void FixedUpdate()
    {
        rb.rotation = Mathf.LerpAngle(rb.rotation, angle, rotationSpeed * dt);
        rb.velocity = Vector2.Lerp(rb.velocity, moveDir * moveSpeed, moveAcceleration * dt);
    }
}
