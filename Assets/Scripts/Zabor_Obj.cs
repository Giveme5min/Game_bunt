using UnityEngine;
using System.Collections;
public class Zabor_Obj : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float startTimeBtwShots= 1.5f;
    [SerializeField] private float  lifetime = 0.7f;
    private float timeBtwShots=1.5f;
    private bool _touch=false;
    private Vector3 thePositionUp;
    private Vector3 thePositionDown;
    private Vector3 thePositionCenter;
    private Push _push;
    private Vector2 impulse;



    public LayerMask whatIsSolid;

    

    enum Push
    {
        UP=0,
        DOWN=1,
        CENTER=2
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        thePositionUp = transform.TransformPoint(-0.35f,0.7f,0);
       // thePositionUp = transform.TransformPoint(Vector2.left * 0.7f);
        thePositionDown = transform.TransformPoint(-0.35f,-0.7f, 0);
        thePositionCenter = transform.TransformPoint(-0.35f,0, 0);


        RaycastHit2D IsCollidingCener = Physics2D.Raycast(thePositionCenter, -transform.right, 0.00001f, whatIsSolid);
        RaycastHit2D IsCollidingUp = Physics2D.Raycast(thePositionUp, -transform.right, 0.00001f, whatIsSolid);
        RaycastHit2D IsCollidingDown = Physics2D.Raycast(thePositionDown, -transform.right, 0.00001f,whatIsSolid);

        Debug.DrawRay(thePositionCenter, -transform.right * 0.5f,Color.red);
        Debug.DrawRay(thePositionUp, -transform.right * 0.5f, Color.red);
        Debug.DrawRay(thePositionDown, -transform.right * 0.5f, Color.red);

        
        if (IsCollidingCener.collider != null)
        {
           // Debug.Log(IsCollidingCener.collider.name);
        if (IsCollidingCener.collider.CompareTag("Player"))
                     {
                          //Debug.Log(IsCollidingCener.collider.name);
                            Debug.Log("Center");
                             _push = Push.CENTER;
                     }

        }

        if (IsCollidingUp.collider != null)
        {
            //Debug.Log(IsCollidingUp.collider.name);
            if (IsCollidingUp.collider.CompareTag("Player"))
            {
            //Debug.Log(IsCollidingCener.collider.name);
             Debug.Log("Up");
             _push = Push.UP;
            }
        }
        if (IsCollidingDown.collider != null)
        { 
            if (IsCollidingDown.collider.CompareTag("Player"))
            {
            //Debug.Log(IsCollidingCener.collider.name);
             Debug.Log("Down");
            _push = Push.DOWN;
            }
        }




        if (_touch == true) 
        {           
            if (timeBtwShots <= 0 )
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            timeBtwShots = startTimeBtwShots;
            _touch = false;
                Destroy(gameObject, lifetime);
            }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        switch (_push)
        {
            case Push.UP:
                impulse = new Vector2(9, -2);
                break;
            case Push.DOWN:
                impulse = new Vector2(9, 2);
                break;
            case Push.CENTER:
                impulse = new Vector2(9, 0);
                break;
        }



        if (collision.gameObject.CompareTag("Player"))
        {  
            GetComponent<Rigidbody2D>().AddForce(impulse, ForceMode2D.Impulse);
            _touch = true;
            //Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("police") && _touch == true)
        {
            collision.gameObject.GetComponent<MoveObject>().TakeDamge(10);
           // Destroy(GameObject.Find("Police"));
            Destroy(gameObject, 0.5f);

        }


        if (collision.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        }


    }
}
