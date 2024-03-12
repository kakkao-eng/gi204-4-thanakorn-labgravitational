using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    public Rigidbody rb;

    private float myG = 6.67f;

    public static List<Attraction> planetAttraction;

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var pAttraction in planetAttraction)
        {
            if (pAttraction != this)
            {
                Attract(pAttraction);
            }
        }
    }

    void Attract(Attraction other)
    {
      //F =G+(m1*,m2) /d^2
      Rigidbody rbOther = other.rb;
      Vector3 direction = rb.position - rbOther.position;

      float distance = direction.magnitude;

      float forceMagnitude = myG * ( rb.mass * rbOther.mass ) / Mathf.Pow(distance, 2);

      Vector3 force = direction.normalized * forceMagnitude;
      
      rbOther.AddForce( force );
      
    }

    private void OnEnable()
    {
        if (planetAttraction == null)
        {
            planetAttraction = new List<Attraction>();
        }
        
        planetAttraction.Add(this);
    }
}
