using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public float walkStepRate = 0.55f;
    private float runStepRate;
    private float stepRate;
    public float stepCoolDown;
    public AudioClip[] footstepSounds;
    int soundIndex = 0;

    AudioSource audioSource;
    PlayerMovement playerMovement;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        runStepRate = walkStepRate / playerMovement.runMultiplier;
    }


    // Update is called once per frame
    void Update()
    {
        if (playerMovement.isRunning)
        {
            stepRate = runStepRate;
        } else
        {
            stepRate = walkStepRate;
        }

        stepCoolDown -= Time.deltaTime;
        if ((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && stepCoolDown < 0f)
        {
            audioSource.clip = footstepSounds[soundIndex];
            audioSource.PlayOneShot(audioSource.clip);

            soundIndex++;

            if (soundIndex >= footstepSounds.Length)
            {
                soundIndex = 0;
            }
            stepCoolDown = stepRate;
        }
    }
}
