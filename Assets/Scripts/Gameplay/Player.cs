using UnityEngine;

public class Player : MonoBehaviour
{

    public enum PlayerID
    {
        None,
        Player1,
        Player2
    }

    public PlayerID ThisPlayer;

    public Config.Direction CurrentDirection = Config.Direction.Right;
    public Config.Direction LastDirection = Config.Direction.Right;

    public Config.State CurrentState = Config.State.Standing;


    public bool isInvincible = false;

    public bool isTurning = false;
    private float turningSpeed = 200.0f;

    public void DoFallingUpdate()
    {
        if(this.transform.eulerAngles.z >= 7)
        {
            this.transform.Rotate(0, 0, turningSpeed * -Time.deltaTime);
        }

        else
        {
            this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y, 0);
            this.transform.Rotate(0, 180, 0);
            Updater.Instance.OnUpdate -= DoFallingUpdate;
        }
    }
    void DoUpdate()
    {
        if (this.transform.eulerAngles.z < 180)
        {
            if (this.isTurning == true)
            {
                this.transform.Rotate(0, 0, turningSpeed * Time.deltaTime);
            }
        }

        //letzter Frame der Drehung
        if (this.transform.eulerAngles.z > 180)
        {
            SoundManager.Instance.Play("GL1-248");
            Vector3 pos = this.transform.eulerAngles;
            pos.y += 180;
            pos.z = 180;
            this.transform.eulerAngles = pos;
            
			this.isTurning = false;
			this.transform.FindChild("Jumper").GetComponent<Jump>().AllowJumping = true;
            this.GetComponent<Movement>().AllowMoving = true;
            Updater.Instance.OnUpdate -= DoUpdate;
        }

    }
    
    public void SignInUpdate()
    {
        isTurning = true;
        Updater.Instance.OnUpdate += DoUpdate;
        this.transform.FindChild("Jumper"). GetComponent<Jump>().AllowJumping = false;
    }

	
    public Animator Hero { get; private set; }

    void Start()
    {
        Hero = this.transform.FindChild("hero").GetComponent<Animator>();
    }



}
