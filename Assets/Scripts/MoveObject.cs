using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private bool _lineYplayer = false;
    private Transform target;

    public int health;
    public float speed = 1.5f;
    public GameObject parentObject;
    public float delay;

    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    void FixedUpdate()
    {    
        //  transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (transform.position.x < -21.45)
            Destroy(gameObject);
        if (transform.position.x < -6)
        {
            _lineYplayer = true;
            transform.Translate(Vector3.left * Time.deltaTime * speed);

          }
        if (health<=0)
            Destroy(gameObject);

       
        if (Vector2.Distance(transform.position, target.position)>4f && _lineYplayer == false)
        {
                      
            transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * delay);
            // transform.position = new Vector3(gameObject.transform.position.x, (Mathf.Lerp(transform.position.y, parentObject.transform.position.y, Time.deltaTime * delay)), 0);
        }
        else 
            transform.Translate(Vector3.left * Time.deltaTime * speed);




    }

    public void TakeDamge(int damage)
    {
        health -= damage;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
