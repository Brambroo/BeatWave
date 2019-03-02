using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    public float vel;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(StartGame.path);
    }

    // Update is called once per frame
    void Update()
    {
        vel = this.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        //TODO Stop player from jumping mid-air
        if(this.gameObject.transform.position.y < 0)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 2.5f, this.gameObject.transform.position.z);
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if(this.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 1)
            {
                this.GetComponent<Rigidbody>().AddForce(new Vector2(0, -40), ForceMode.Impulse);
            }
            else if(!(this.gameObject.transform.position.y > 3))
            {
                this.GetComponent<Rigidbody>().AddForce(new Vector2(0, 10), ForceMode.Impulse);

            }
        }
    }
}
