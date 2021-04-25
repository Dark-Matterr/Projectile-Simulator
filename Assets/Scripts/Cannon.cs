using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    public Rigidbody2D bulletPrefabs;
    public Transform shootingPoint;
    public int initialSpeed = 20, initialHeight = 0;
    public float initialAngle = 0f, initialGravity = 9.81f;
    private Camera cam;
    private bool fire = false;
    //
    float timer;
    bool shoot = false;

    LineRenderer line;
    Rigidbody2D obj;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        timer = 0f;
        line = GameObject.Find("Line").GetComponent<LineRenderer>();

        line.startWidth = 0.05f;
        line.endWidth =0.05f;

        line.positionCount = 1;
        line.SetPosition(0, shootingPoint.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fire)
        {
            shoot = false;
            line.positionCount = 1;
            line.SetPosition(0, shootingPoint.position);

            Vector2 Vo = CalculateVelocity(Mathf.Round(initialAngle),initialGravity, initialSpeed, 1f);
            obj = Instantiate(bulletPrefabs, shootingPoint.position, Quaternion.identity);
            obj.velocity = Vo;
            fire = false;
            shoot = true;
        }

        if (shoot) {
            int count = line.positionCount;
            line.positionCount = count + 1;
            line.SetPosition(count, obj.transform.position);
            timer += 0.01f;
        }

    }

    void OnMouseDrag()
    {
        float rotateSpeed = 5f;
        initialAngle = CalculateAngle();
        Quaternion rotation = Quaternion.AngleAxis(initialAngle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime); 
    }

    public void CannonFire()
    {
        fire = true;
    }

    float CalculateAngle()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Clamp(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, -90, 90);
        return angle;
    }

    Vector2 CalculateVelocity(float angle, float gravity, int initialSpeed, float time)
    {
        float rad = (angle * (Mathf.PI)) / 180;
        float vfx = initialSpeed * Mathf.Cos(rad);
        float vfy = initialSpeed * Mathf.Sin(rad);

        float x = vfx * time;
        float y = (vfy * time) - 0.5f * (Mathf.Abs(gravity) * (time * time));
        Vector2 localVelocity = new Vector2(x, y);
        Vector2 globalVelocity = transform.TransformDirection(localVelocity);
        return localVelocity;
    }
}
