using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public List<Transform> blocks;
    public GameObject positionPos;
    public Transform prefab;
     Vector3 position;
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            Destroy(collision.gameObject);
                //collision.collider.transform.SetParent(transform);
                
          
            var block =  Instantiate(prefab);
            blocks.Add(block.transform);

            //transform.position = new Vector3(0, 1, 0);
            
        }

        //private void OnCollisionExit(Collision collision)
        //{
        //    if (collision.gameObject.tag == "Block")
        //    {
        //        collision.collider.transform.SetParent(null);
        //    }
        //}
    }
   
}
