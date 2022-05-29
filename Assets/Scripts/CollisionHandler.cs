using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip crashAudio;
    [SerializeField] AudioClip successAudio;
    
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem successParticles;
    

    AudioSource audioS;


    bool isTransitioning = false;
    bool collisionDisabled = false;

    void Start()
    {

        audioS = GetComponent<AudioSource>();

    }
    void Update()
    {
        RespondToDebugKeys();
    }
    void RespondToDebugKeys()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(currentSceneIndex);
        }
        else if (Input.GetKey(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled; // toggle collision
            Debug.Log("Collision Cheatcode: " + collisionDisabled);
;        }


    }
    void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning) { return; }
        else
        {
            switch (collision.gameObject.tag)
            {
                case "Friendly":
                    break;
                case "Finish":
                    StartLandingSequence();
                    break;
                case "Fuel":
                    Debug.Log("added fuel.");
                    break;
                default:
                    if (!collisionDisabled)
                    {
                        StartCrashSequence();
                    }
                    break;


            }
        }
    }
    void StartCrashAudio() // todo fix the audio for proper timing
    {
        audioS.Stop();
        audioS.PlayOneShot(crashAudio);
    }
    void StartSuccessAudio()
    {
        audioS.Stop();
        audioS.PlayOneShot(successAudio);
    }
    void StartCrashSequence()
    {

        crashParticles.Play(); // play the crash particles
        isTransitioning = true;
        StartCrashAudio();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
        
    }

    void StartLandingSequence()
    {
        successParticles.Play(); // play the success particles
        isTransitioning = true;
        StartSuccessAudio(); // starts success audio
        GetComponent<Movement>().enabled = false; // make player can not move
        Invoke("LoadNextLevel", levelLoadDelay); // loads next level in particular delay
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        int totalNumberOfLevels = SceneManager.sceneCountInBuildSettings;
        if (nextSceneIndex == totalNumberOfLevels)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex); 
    }
   
}
