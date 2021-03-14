using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public float stepRate = 0.5f;
    public float stepCoolDown;
    public AudioClip[] footstepSounds;
    int soundIndex = 0;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
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
