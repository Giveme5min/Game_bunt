using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerTale : MonoBehaviour
{

    public GameObject parentObject;
    public float delay=5f;
 
    void Update()
    {
        transform.position = new Vector3(gameObject.transform.position.x, (Mathf.Lerp(transform.position.y, parentObject.transform.position.y, Time.deltaTime * delay)),0);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("police"))
        {
            Destroy(gameObject);
        }
    }
}
