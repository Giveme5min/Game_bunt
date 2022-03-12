using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveVodomet : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private float[] directions = new float[0];
    private float timeBtwShots;
    private Vector3 oldPosition;
    private float distanceX = 10f;
    private int score=150;


    public GameObject bulletObj;
    public Transform shotPoint;
    public float startTimeBtwShots;    

    void Start()
    {
        oldPosition = transform.position;
    }
    void FixedUpdate()
    {
////////////////////////////////////Движение/////////////////////////////////////////////////////
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (oldPosition.x-transform.position.x>= distanceX)
        {         
            transform.Translate(Vector3.left * Time.deltaTime * -3f);
            score-=1;
            if(score<=0)
            {
                oldPosition = transform.position;
            }
        }
///////////////////////////////////Стрельба////////////////////////////////////////////////////////////

     
            if (timeBtwShots <= 0)
            {
            GameObject bullet = Instantiate<GameObject>(bulletObj);
            Instantiate(bullet, shotPoint.position, transform.rotation);
            // Instantiate(bulletObj, shotPoint.position, transform.rotation);
            timeBtwShots = startTimeBtwShots;           
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
     
//////////////////////////////////Жизнь/////////////////////////////////////////////////////

        if (transform.position.x < -21.45)
            Destroy(gameObject);
        if (health <= 0)
            Destroy(gameObject);


    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamge(int damage)
    {
        health -= damage;
    }


}
