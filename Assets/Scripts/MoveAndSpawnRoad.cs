
using UnityEngine;
using UnityEditor;

public class MoveAndSpawnRoad : MonoBehaviour
{
    public float speed = 5f;
    public GameObject road;
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (transform.position.x < -24f)
        {
            Instantiate(road, new Vector3(35.1f, 0, 0), Quaternion.identity);        
             Destroy(gameObject);

        }
            

    }


}
