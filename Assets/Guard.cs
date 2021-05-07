using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Guard : MonoBehaviour
{
    public float pointA;
    public float pointB;
    public GameObject guard;
    public float speed;
    public float counter = 0;

    

    private bool stopped = false;
    private bool lookRight = true;
    public SpriteRenderer yot;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, 2);
        if (hit.collider)
        {
            Debug.Log("Hit");
            string obj = hit.collider.name;
            if(obj == "Player")
            {
                SceneManager.LoadScene("GameOver");
                Debug.Log("YOU CRAZY SON OF A BITCH!!");
            }
        }


        //Raycating
        if(lookRight == true)
        {
            
            Vector3 right = transform.TransformDirection(Vector3.right) *2;
            Debug.DrawRay(transform.position, right, Color.green);
        }
        if(lookRight == false)
        {
            
            Vector3 left = transform.TransformDirection(Vector3.left) * 2;
            Debug.DrawRay(transform.position, left, Color.green);
        }
        



        
        if (stopped == false)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        


        if (guard.transform.position.x <= pointA)
        {
            speed = .5f;
            counter += 1;
            stopped = true;

            if(counter == 50)
            {
                stopped = false;
                counter = 0;
                yot.flipX = false;
                lookRight = true;
            }
        }
       if(guard.transform.position.x >= pointB)
        {
            speed = -.5f;
            counter += 1;
            stopped = true;

            if (counter == 50)
            {
                stopped = false;
                counter = 0;
                yot.flipX = true;
                lookRight = false;
            }
        }
        
    }

    
}
