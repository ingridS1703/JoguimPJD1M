        using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;

public class player : MonoBehaviour
{
    public int velocidade = 5;
    public int forcaPulo = 7;
    public bool noChao = false;
    Rigidbody rb;
    private AudioSource source;
    
    
    void Start()
    {
        Debug.Log("start");
        TryGetComponent(out rb);
        TryGetComponent(out source);
    }
    
  
      private void OnCollisionEnter(Collision collision)
        {
            if (!noChao && collision.gameObject.tag == "Chão")
            {
                noChao = true;
            }
        }
    
    void Update()
    {
        Debug.Log(message: "update");
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(x:h, y:0, z:v);
        rb.AddForce(direcao * (velocidade * Time.deltaTime), ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.Space) && noChao == true)
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            //pulo
            source.Play();
            
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChao = false;
        }
        
        
        
        
        
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

