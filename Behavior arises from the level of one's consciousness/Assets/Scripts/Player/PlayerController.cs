using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static Vector3 position;
    public bool sneaking = false;
    public static Transform playerTransform;

    public float turnSmooring = 15.0f;
    public float speedDampTime = 0.1f;

    Rigidbody rb;
    private void Awake()
    {
        playerTransform = transform;
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            sneaking = true;
        }
        else
            sneaking = false;

        if ((horizontal != 0 || vertical != 0) && !sneaking)
        {
            PlayerSoundSubject.NotifyObservers(SoundType.WALKING);
        }
        MovementManagement(horizontal, vertical);
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        //Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        //if (Input.GetKeyDown(KeyCode.LeftControl))
        //{
        //    sneaking = true;
        //}
        //if (Input.GetKeyUp(KeyCode.LeftControl))
        //{
        //    sneaking = false;
        //}

        //if (input != Vector3.zero && !sneaking)
        //{
        //    PlayerSoundSubject.NotifyObservers(SoundType.WALKING);
        //}
    }

    void MovementManagement(float horizontal, float vertical)
    {
        if(horizontal != 0.0f || vertical != 0.0f)
        {
            Rotating(horizontal, vertical);
            // anim.SetFloat("Speed", 5.5f, speedDampTime, Time.deltaTime);
        }
    }

    void Rotating(float horizontal, float vertical)
    {
        Vector3 targetDirection = new Vector3(horizontal, 0.0f, vertical);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        Quaternion newRotation = Quaternion.Lerp(rb.rotation, targetRotation, turnSmooring * Time.deltaTime);
        rb.MoveRotation(newRotation);
    }

    void AudioManagment(bool shout)
    {
        // check if the animtion is the motion state.
        // if(anim.GetCurrentAnimatorStateInfo(0).nameHash == hash.locomotionState)
        // {
        //      if(!audio.isPlaying)
        //      {
        //          audio.Play();
        //      }
        //  }
        //  else
        //  {
        //      audio.Stop();
        //  }

        //  if(shout)
        //  {
        //      AudioSource.PlayClipAtPoint(shoutingClip, transform.position);
        //  }
    }
}
