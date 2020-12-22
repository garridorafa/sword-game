using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 direction;

    public float livingTime = 3f;
    public Color initialColor = Color.white;
    public Color finalColor;

    private SpriteRenderer _renderer;
    private float _staringTime;

    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Save initial time
        _staringTime = Time.time;

        // Destroy bullet after some time
        Destroy(this.gameObject, livingTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move object
        Vector2 movement = direction.normalized * speed * Time.deltaTime;
        transform.Translate(movement); //transform.position = new Vector2(transform.position.x + movement.x, transform.position.y + movement.y);

        // Change bullet's color over time
        float _timeSinceStarted = Time.time - _staringTime;
        float _percentageCompleted = _timeSinceStarted / livingTime;

        _renderer.color = Color.Lerp(initialColor, finalColor, _percentageCompleted);
    }
}
