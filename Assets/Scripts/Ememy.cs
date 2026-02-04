using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ememy : MonoBehaviour
{
    public float maxSpeed;
    public float minSpeed;
    private float speed;
    public int damage;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        speed= UnityEngine.Random.Range(minSpeed, maxSpeed);
        
        try
        {
            player = GameObject.Find("Player").GetComponent<Player>();
        }
        catch (NullReferenceException ex)
        {
            ex.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (hitObject.tag == "Player")
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
        if(hitObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }

}
