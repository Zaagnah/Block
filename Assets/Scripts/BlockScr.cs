using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScr : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.collider.transform.SetParent(null);
            gameObject.transform.SetParent(transform);
            Destroy(gameObject.transform);

        }
        else if (collision.gameObject.tag == "BlockRed")
        {
            Destroy(collision.gameObject.transform);
        }
    }
}
