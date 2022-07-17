using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ballmove : MonoBehaviour
{
    Rigidbody rb;
     int force = 2;
     int jumpforce = 4;
    private bool isTouching = false;
    public int counter;
    public Text Points;
    public AudioSource audioo;
    public AudioClip audioclip;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Points.text = "Points :"+ counter;
    }

    // Update is called once per frame
    void Update()
    {
        float Hmove = Input.GetAxis("Horizontal");
        float Vmove = Input.GetAxis("Vertical");
        
        Vector3 ballmove = new Vector3(Hmove,0.0f,Vmove);

        rb.AddForce(ballmove * force);

        if (Input.GetKey(KeyCode.Space) && isTouching == true){
            Vector3 balljump = new Vector3(0.0f,20.0f,0.0f);
            rb.AddForce(balljump*jumpforce);
        }
        
        
    }
    private void OnCollisionExit(Collision other) {
        isTouching = false;
    }
    private void OnCollisionEnter(Collision other) {
        isTouching = true;
    }
    

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("coins")){
            other.gameObject.SetActive(false);
            counter++;
            Points.text = "Points :"+counter;
            audioo.PlayOneShot(audioclip);
        }
        if(counter == 4){
            SceneManager.LoadScene("Finish");
        }
    }
}
