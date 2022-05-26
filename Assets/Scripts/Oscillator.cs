using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor; // range adds slider to serialize field on unity , helps you to simulate 
    [SerializeField] float period = 2f;
    const float tau = Mathf.PI * 2;
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon ) // float values can not be same you know why 
        {
            Debug.Log("period can not be equal to zero.");
        }
        else
        {
            float cycles = Time.time / period; // continually increases time
            float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1
            Debug.Log(cycles);
            Debug.Log(rawSinWave);
            movementFactor = (rawSinWave * +1f) / 2f;// -1,1 to 0,2  and then when u divide it to 2 its [0,1]

            Vector3 offset = movementVector * movementFactor;
            transform.position = startingPosition + offset;
        }
    }
}
