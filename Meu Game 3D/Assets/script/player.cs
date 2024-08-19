        using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Callbacks;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update");
    float x = Input.GetAxis("Horizontal");
    float y = Input.GetAxis("Vertical");
    UnityEngine.Vector3 direcao = new UnityEngine.Vector3(x, 0, y);
    rb.AddForce(direcao * velocidade * Time.deltaTime, ForceMode.Impulse)
    }
}
