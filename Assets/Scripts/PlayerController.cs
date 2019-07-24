using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LineRenderer lineRenderer;
    Rigidbody2D rb;

    // TODO: Make global somewhere?
    private int PIXEL_RATIO = 1080 / 270;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition / PIXEL_RATIO);
        Vector2 dir = (mousePosition - transform.position).normalized;

        // Ignore collision with player (remember to apply "Player" layer to Player)
        int layerMask = ~(LayerMask.GetMask("Player"));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 100f, layerMask);

        if (hit.collider != null)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);
        }
    }
}
