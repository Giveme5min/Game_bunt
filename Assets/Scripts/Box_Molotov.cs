using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Molotov : MonoBehaviour
{

    private float speed = 5f;


    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeMolotov(1);
            Destroy(gameObject);
        }
    }



    }
