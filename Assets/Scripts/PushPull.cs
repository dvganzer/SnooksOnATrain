using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPull : MonoBehaviour
{
    public float distance = 1f;
    public LayerMask boxMask;
    public GameObject Sbox;
    public GameObject Mbox;
    public GameObject Lbox;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
       RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);
        if(hit.collider != null && Input.GetKeyDown(KeyCode.E))
        {
            Sbox = hit.collider.gameObject;
            Mbox = hit.collider.gameObject;
            Lbox = hit.collider.gameObject;

            Sbox.GetComponent<boxpull>().beingPushed = true;
            Mbox.GetComponent<boxpull>().beingPushed = true;
            Lbox.GetComponent<boxpull>().beingPushed = true;

            Sbox.GetComponent<FixedJoint2D>().enabled = true;
            Sbox.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            Mbox.GetComponent<FixedJoint2D>().enabled = true;
            Mbox.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            Lbox.GetComponent<FixedJoint2D>().enabled = true;
            Lbox.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            Sbox.GetComponent<boxpull>().beingPushed = false;
            Mbox.GetComponent<boxpull>().beingPushed = false;
            Lbox.GetComponent<boxpull>().beingPushed = false;

            Sbox.GetComponent<FixedJoint2D>().enabled = false;
            Mbox.GetComponent<FixedJoint2D>().enabled = false;
            Lbox.GetComponent<FixedJoint2D>().enabled = false;
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x*distance);
    }
}
