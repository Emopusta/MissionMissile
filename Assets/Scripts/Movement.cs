using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] float rotateThrust = 80f;
    [SerializeField] int fuelDecreaseLevel = 1;
    [SerializeField] FuelBar fb;
    [SerializeField] int addFuelAmount = 1000;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftSideEngineParticles;
    [SerializeField] ParticleSystem rightSideEngineParticles;


    Rigidbody rb;
    AudioSource audioS;
    int fuel = 10000;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fuel")
        {
            fuel += addFuelAmount;
        }
        Destroy(other.gameObject);
    }
    float degree;
    

    void Start()
    {
        rb= GetComponent<Rigidbody>();
        audioS = GetComponent<AudioSource>();
        audioS.Stop();
       
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        fb.SetFuel(fuel);
        
    }
    
    void ThrusterAudio()
    {
        if (Input.GetKeyDown(KeyCode.W) && audioS.isPlaying != true)
        {
            audioS.PlayOneShot(mainEngine);
        }
        else if (Input.GetKeyUp(KeyCode.W) && audioS.isPlaying == true)
        {
            audioS.Stop();
        }
    }

    
    void ProcessThrust()
    {
        //ThrusterAudio();

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && fuel>0)
        {
            StartThrusting();
            fuel = fuel - fuelDecreaseLevel;
            
        }
        else
        {
            StopThrusting();
        }

    }
    void ProcessRotation()
    {

        if (Input.GetKey(KeyCode.D))
        {
            StartRotatingRight();

        }
        else if (Input.GetKey(KeyCode.A))
        {
            StartRotatingLeft();
        }
        else
        {
            StopRotating();
        }

    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioS.isPlaying)
        {
            //audioS.Play();
            audioS.PlayOneShot(mainEngine);
            
        }
        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
            
        }
    }
    void StopThrusting()
    {
        audioS.Stop();
        mainEngineParticles.Stop();
        
    }
    

    void StartRotatingRight()
    {
        ApplyRotation(-rotateThrust);
        if (!rightSideEngineParticles.isPlaying)
        {
            rightSideEngineParticles.Play();
        }
    }

    void StartRotatingLeft()
    {
        //rb.MoveRotation(Quaternion.Euler(0, 0, degree += rotateThrust));
        ApplyRotation(rotateThrust);
        if (!leftSideEngineParticles.isPlaying)
        {
            leftSideEngineParticles.Play();
        }
    }

    void StopRotating()
    {
        rightSideEngineParticles.Stop();
        leftSideEngineParticles.Stop();
    }

    void ApplyRotation(float rotationWay)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationWay * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can't take over -- to do : set this in collisionhandler
       
    }

}
