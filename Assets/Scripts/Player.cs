using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public TextMeshPro helt;
    public Text healtText;
    private float input;    
    public float speed;
    Rigidbody2D rb;
    Animator anim;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healtText.text = health.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        
        if(input != 0)
        {
          anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        
    }

    void FixedUpdate()
    {
        //Cuvam kako se igrac krece 0 ako stoji, 1 ako ide desno, -1 ako ide levo
        input = Input.GetAxisRaw("Horizontal");

        //Pomeranje igraca levo desno 
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
        if (health == 0)
        {

        }


    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        healtText.text = health.ToString();
        if (health <= 0)
        {

            Destroy(gameObject);
            SceneManager.LoadScene("Menu");

        }
    }
}
