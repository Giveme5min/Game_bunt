using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float startTimeBtwMolotov;
    [SerializeField] private float startTimeBtwShots;
    [SerializeField] private int life = 3;

    private float timeBtwShots;
    private float timeBtwMolotov;

    public GameObject _molotov;
    public int _haveMolotov;
    public GameObject bullet;
    public Transform shotPoint;





    void Start()
    {
        _haveMolotov=0;
    }

    void Update()
    {
        float ver = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(0, ver, 0);
        gameObject.transform.Translate(dir.normalized * Time.deltaTime * speed);
///////////////////////kerpich////////////////////////////////
        if(timeBtwShots<=0)
        { 
            if (Input.GetMouseButton(0))
            {
             Instantiate(bullet, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        ////////////////////////Molotov///////////////////////////////////

        if (timeBtwMolotov <= 0 && _haveMolotov>0)
        {
            if (Input.GetMouseButton(1))
            {
                Instantiate(_molotov, shotPoint.position, transform.rotation);
                timeBtwMolotov = startTimeBtwMolotov;
                _haveMolotov = _haveMolotov-1;
            }
        }
        else
        {
            timeBtwMolotov -= Time.deltaTime;
        }

        

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("police")|| collision.gameObject.CompareTag("Vodomet")) && life == 1)
        {
            Destroy(gameObject);
            life -= 1;
        }
        if ((collision.gameObject.CompareTag("police") || collision.gameObject.CompareTag("Vodomet")) && life == 2)
        {
            Destroy(GameObject.Find("Player (1)"));
            life -= 1;
        }
        if ((collision.gameObject.CompareTag("police") || collision.gameObject.CompareTag("Vodomet")) && life==3) 
        {
            Destroy(GameObject.Find("Player (2)"));
            life -= 1;
        } 
    }

    public void TakeDamge(int damage)
    {
        life -= damage;

        if (life == 2)
            Destroy(GameObject.Find("Player (2)"));

        if (life == 1)
            Destroy(GameObject.Find("Player (1)"));

        if (life == 0)
            Destroy(gameObject);

    }
    public void TakeMolotov(int molotov)
    {
        _haveMolotov += molotov;
    }

}
