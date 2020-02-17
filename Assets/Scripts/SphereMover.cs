﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class SphereMover : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody _rb; 
    public GameObject explosionPrefab;
    public Slider sliderInstance;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        //for (int i = 0; i < 4; i++)
        //{
        //    Instantiate(gameObject);
        //}


        RandomMove();
    }

    [SerializeField]
    private static int Max_Speed = 30;
    // Update is called once per frame
    void Update()
    {
        //Max_Speed = (int)slider.value;

        _rb.velocity = Max_Speed * (_rb.velocity.normalized);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);

        // other code which destroys the player
    }
    private void RandomMove()
    {
        int x = Random.Range(-Max_Speed, Max_Speed);
        int y = Random.Range(-Max_Speed, Max_Speed);
        int z = Random.Range(-Max_Speed, Max_Speed);

        _rb.velocity = new Vector3(x, y, z);
    }

    public void CurrentSpeed(float value)
    {
        if (Max_Speed == 0)
        {
            var foundObj = FindObjectsOfTypeAll(typeof(SphereMover));
            foreach (SphereMover item in foundObj)
            {
                item.Faster();
            }
        }
        Max_Speed = (int)value;
    }

    public void Slower()
    {
        if (Max_Speed - 5 > 0)
        {
            Max_Speed -= 5;
        }
        else
        {
            Max_Speed = 0;
        }
    }
    public void Faster()
    {
        Max_Speed += 5;

        if (_rb.velocity.normalized == _rb.velocity.normalized*0)
            RandomMove();
    }

    public void SpawnNew()
    {
        Instantiate(gameObject);
    }

    public void Remove()
    {
        Destroy(gameObject);
    }

}
