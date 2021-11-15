using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float forwardForce = 2000f;
    public List<Transform> blocks;
    public GameObject positionPos;
    public Transform prefab;
    public float BlockDistance;
    public bool isGrounded;
    float jumpHeight = 2f;


    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        isGrounded = true;
    }

    void FixedUpdate()
    {
        rigidbody.AddForce(0, 0, forwardForce * Time.deltaTime);
        MoveMove();
        //if (isGrounded)
        //{
        //    if (Input.GetButtonDown("Jump"))
        //    {
        //        Jump();

        //    }
        //}

    }
    private void Update()
    {
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Jump();

            }
        }
    }
    public void Jump()
    {
        while (isGrounded)
        {
            Debug.Log("Jump");
            rigidbody.velocity = new Vector3(0f, jumpHeight, 0f);
            isGrounded = false;
        }
    }
    public void MoveMove()
    {



        float horizontalInput = Input.GetAxis("Horizontal"); //клавиши
   
        transform.Translate(new Vector3(horizontalInput, 0, 0)  * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Block")
        {
            Destroy(collision.gameObject);
            var block = Instantiate(prefab);
            blocks.Add(block.transform);
            Vector3 pointPosition = new Vector3(0, -1, 0);
            Vector3 previousPosition = transform.position -pointPosition;
            //float sqrDistance = BlockDistance * BlockDistance;
            //Vector3 pointPosition = new Vector3(0, 1, 0);
            //Vector3 previousPosition = _transform.position - pointPosition;
            var lastBlock = blocks.Count - 1;
            transform.position = transform.position - pointPosition;
            block.position =  blocks[lastBlock].position ;
            

            //foreach (var block in blocks)
            //{
                //    if ((block.position - previousPosition).sqrMagnitude > sqrDistance)
                //    {
                
                //    }
                //    else
                //break;
            //}

            //gameObject.transform.position = previousPosition;
            block.transform.SetParent(transform);
           
        } else if(collision.gameObject.tag == "Enemy") 
        {
            
            var lastBlock = blocks.Count - 1;
            blocks[lastBlock].SetParent(null);
            blocks[lastBlock].gameObject.GetComponent<MeshRenderer>().material.color = new Color(1,1,1);
            blocks.RemoveAt(lastBlock);
            
            //Destroy(blocks[lastBlock]);
            Destroy(collision.gameObject);
            //Vector3 pointPosition = new Vector3(0, 1, 0);
            //Vector3 previousPosition = transform.position - pointPosition;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Restartlvl();
    }

    public void Restartlvl()
    {
        SceneManager.LoadScene("TestBlocks");
    }
}
