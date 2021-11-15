using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLvl : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
       Restartlvl();
    }

    public void Restartlvl()
    {
        SceneManager.LoadScene("TestBlocks");
    }
}
