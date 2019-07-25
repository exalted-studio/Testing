using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletHole;
    public LineRenderer lineRenderer;
    Rigidbody2D rb;

    // TODO: Make global somewhere?
    private int PIXEL_RATIO = 1080 / 270;

    public float fireRate = 0;
    float timeToFire;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (fireRate == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }
        }
        else
        {
            if (Input.GetMouseButton(0) && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Fire();
            }
        }

    }

    void Fire()
    {
        // float aimSpread = 0.0f;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition / PIXEL_RATIO);
        Vector2 dir = (mousePosition - transform.position).normalized;
        Debug.Log(dir);
        // Ignore collision with player (remember to apply "Player" layer to Player)
        int layerMask = ~(LayerMask.GetMask("Player"));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 100f, layerMask);

        Debug.DrawLine(transform.position, dir * 100, Color.red);

        if (hit.collider != null)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);

            // 0.25 - 1.25

            // Vector2 bulletSpot = new Vector2(hit.point.x, hit.point.y + Random.Range(0.25f, 1.25f));
            Vector2 bulletSpot = hit.point + (dir * Random.Range(1f, 4f));
            Quaternion bulletRotation = Quaternion.Euler(0, 0, Random.Range(1, 4) * 90);

            Instantiate(bulletHole, bulletSpot, Quaternion.identity);
        }
    }
}
