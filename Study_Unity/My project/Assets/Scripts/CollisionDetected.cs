using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetected : MonoBehaviour
{
    Material Mat;
    MeshRenderer Mesh;

    void Start()
    {
        Mesh = GetComponent<MeshRenderer>();
        Mat = Mesh.material;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "South_Wall")
        {
            Mat.color = new Color(0, 0, 0);
        }
        else if(collision.gameObject.name == "East_Wall")
        {
            Mat.color = new Color(0, 110, 0);
        }
        else if(collision.gameObject.name == "West_Wall")
        {
            Mat.color = new Color(255,255,255);
        }
        else if(collision.gameObject.name == "North_Wall")
        {
            Mat.color = new Color(0, 0, 255);
        }
        else
        {
            Debug.Log("The Player reached the walls");
        }

        if(collision.gameObject.name == "PUG")
        {
            Destroy(collision.gameObject, 0.5f);
        }

        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
