using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other) {
        SceneManager.LoadScene("SampleScene");
    }
}
