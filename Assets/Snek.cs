using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snek : MonoBehaviour
{
    private Rigidbody2D slitherySnek;
    public GameObject Plyr;
    public Vector2 target;
    public PolygonCollider2D boxcollider;

    public float speed;

    private void Start()
    {
        slitherySnek= this.gameObject.GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    private bool IsGrounded()
    {
        RaycastHit2D raycasthit2d = Physics2D.BoxCast(boxcollider.bounds.center, boxcollider.bounds.size, 0f, Vector2.down, .1f);
        Debug.Log(raycasthit2d.collider);
        return raycasthit2d.collider != null;
    }

    // Update is called once per frame
    void Update()
    {
        target = Plyr.transform.position;

        //if (IsGrounded() == true)
        //{
            slitherySnek.AddForce((Plyr.transform.position - transform.position)* speed);
        //}
        

        if(slitherySnek.velocity.x > 6)
        {
            slitherySnek.velocity = new Vector2(7, 0);
        }
        if(slitherySnek.velocity.x < -6)
        {
            slitherySnek.velocity = new Vector2(-7, 0);
        }

        //Gravity
        if(slitherySnek.velocity.y > 0)
        {
            slitherySnek.velocity = new Vector2(0, -.5f);
        }
    }
}
