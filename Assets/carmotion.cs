using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class carmotion : MonoBehaviour
{
    int point;
    bool gameOver = false;
    public int point = 0;
    // Start is called before the first frame update
    void Start()
    {
        point = 0; 
    }

    // Update is called once per frame
    void Update()
    {
    if(gameOver==false)
        GetComponent<Rigidbody>().AddForce(Vector3.left*20, ForceMode.Force);
    else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, 40, ForceMode.Force);
        }
            
        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, -40, ForceMode.Force);
        }
          if(GetComponent<Rigidbody>().position.x<= -69)
        {
            gameOver = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Invoke("restart", 3f);
            gameOver = true;
        }      
    }
     private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "block")
        {
            Invoke("restart", 1f);
            gameOver = true;

        }
        if(collision.collider.tag == "coin") 
        {
            point++;
            Destroy(collision.gameObject);

        }
        
    }
    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOver = false;
    }
}
