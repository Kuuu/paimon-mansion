using UnityEngine;

public class HeadBobber : MonoBehaviour
{
    public float walkBobbingSpeed = 12f;
    private float runBobbingSpeed;
    private float bobbingSpeed;
    public float bobbingAmount = 0.05f;
    PlayerMovement playerMovement;

    float defaultPosY = 0;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        defaultPosY = transform.localPosition.y;
        playerMovement = transform.parent.GetComponent<PlayerMovement>();
        runBobbingSpeed = walkBobbingSpeed * playerMovement.runMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.isRunning)
        {
            bobbingSpeed = runBobbingSpeed;
        } else
        {
            bobbingSpeed = walkBobbingSpeed;
        }

        if (Mathf.Abs(playerMovement.GetMovement().x) > 0.1f || Mathf.Abs(playerMovement.GetMovement().z) > 0.1f)
        {
            //Player is moving
            timer += Time.deltaTime * bobbingSpeed;
            transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobbingAmount, transform.localPosition.z);
            
        }
        else
        {
            //Idle
            timer = 0;
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * bobbingSpeed), transform.localPosition.z);
        }
    }
}