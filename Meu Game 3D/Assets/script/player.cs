        using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;

public class player : MonoBehaviour
{
    public int velocidade = 10;
    Rigidbody rb;
    public int forcaPulo = 10;
    public bool noChao = false;
   
    void Start()
    {
        Debug.Log("start");
        TryGetComponent(out rb);
    }

  
      private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "chão")
            {
                noChao = true;
            }
        }
    
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(x:h, y:0, z:v);
        rb.AddForce(direcao * (velocidade * Time.deltaTime), ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.Space) && noChao == true)
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
        }
            
        if (transform.position.y < -5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

