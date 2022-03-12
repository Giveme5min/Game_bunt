using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molotov_bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;


    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsSolid);

        // Debug.Log(hitInfo.collider);
        if (hitInfo.collider != null)
        {
            //      Debug.Log("hit");
            if (hitInfo.collider.CompareTag("police"))
            {
                hitInfo.collider.GetComponent<MoveObject>().TakeDamge(damage);
                //Debug.Log("shoot");
            }
            if (hitInfo.collider.CompareTag("Vodomet"))
            {
                hitInfo.collider.GetComponent<moveVodomet>().TakeDamge(damage);
            }
            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        Destroy(gameObject, lifetime);
    }
}
