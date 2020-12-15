/*
 *File name: FloatPlatformController.cs
 *Name: Lucas Coates
 *Student ID: 101172500
 *Last modified: 12/15/2020
 *description: grows and shrinks a platform
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatformController : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public bool isActive;
    public float platformTimer;
    public float threshold;

    public PlayerBehaviour player;

    private Vector3 distance;



    // Start is called before the first frame update
    void Start()
    {

        platformTimer = 0.1f;
        platformTimer = 0;
        isActive = false;
        distance = end.position - start.position;


    }

    // Update is called once per frame
    void Update()
    {
        platformTimer += Time.deltaTime;
        _Move();
        if (isActive)
        {
            
            _Shrink();//shirnks platform
        }
        else
        {
            _Grow();//grows platform back to regular size
        }
    }

    private void _Shrink()
    {
        if (transform.localScale.x > 0.01f || transform.localScale.y > 0.01f)
        {
            transform.localScale = new Vector3(transform.localScale.x * 0.999f, transform.localScale.y * 0.999f, transform.localScale.z);//called every frame
        }
    }

    public void _Grow()
    {
        if (transform.localScale.x < 1.0f || transform.localScale.y < 1.0f)
        {
            transform.localScale = new Vector3(transform.localScale.x * 1.01f, transform.localScale.y * 1.01f, transform.localScale.z);
        }
    }
    private void _Move()//moves platform up and down to make floaty effect
    {
        var distanceX = (distance.x > 0) ? start.position.x + Mathf.PingPong(platformTimer, distance.x) : start.position.x;
        var distanceY = (distance.y > 0) ? start.position.y + Mathf.PingPong(platformTimer, distance.y) : start.position.y;

        transform.position = new Vector3(distanceX, distanceY, 0.0f);
    }

}
