using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length; //Length of current sprite
    private float startPos;
    [SerializeField] private GameObject cam;
    [SerializeField] private float parallaxEffect;

    private void Start()
    {
        length = gameObject.GetComponent<SpriteRenderer>().bounds.size.x; //Length of sprite 
        startPos = transform.position.x;
    }
    private void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect)); //Current position of object
        float distance = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (temp > startPos + length)
        {
            startPos += length;
        }
        else if (temp < startPos - length)
        {
            startPos -= length;
        }
    }
}
