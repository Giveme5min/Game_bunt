using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Voda : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;


    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, -transform.right, distance, whatIsSolid);
        Debug.DrawRay(transform.position, -transform.right * 0.7f, Color.red);
        // Debug.Log(hitInfo.collider);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                Debug.Log("PLAYER");
                hitInfo.collider.GetComponent<Player>().TakeDamge(1);
                
            }
            
            Destroy(gameObject);
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);
        Destroy(gameObject, lifetime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zabor"))
        {
            Destroy(gameObject);
        }
    }


}
