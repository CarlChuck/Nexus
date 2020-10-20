using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerController : MonoBehaviour
{
    //Player speed variable
    public float speed;

    //for dodge
    private float stamina;
    private float timer;
    [SerializeField] private GameObject dodgeParticles = default;
    
    public Animator anim;
    private CharacterController controller;
    [SerializeField] private Player player = default;
    public float dodgeCoolDown;
    public float dodgeTimer;
    public bool dodgeBool = false;

    private MainControls mControls;

    //Raycast
    private RaycastHit rayHit;
    private int layerHit;

    //Selected object
    public GameObject gSelected;

    //Layer hit delegate
    public delegate void OnLayerChange(int layer);
    public event OnLayerChange onLayerChange;

    private void Awake()
    {
        Player player = Player.instance;
        mControls = player.GetControls();
    }
    private void OnEnable()
    {
        mControls.PlayerControls.Enable();
    }
    private void OnDisable()
    {
        mControls.PlayerControls.Disable();
    }
    void Start()
    {
        speed = 6f; //TODO
        gSelected = null;
        controller = GetComponent<CharacterController>();
        stamina = 1f;
        timer = 0.4f;
    }

    void Update()
    {
        //LayerMasks for raycast
        int floorLayerMask = 1 << 20;

        //Dodge timer
        float time = Time.deltaTime;
        timer -= time;

        //Movement variables
        var movementInput = mControls.PlayerControls.Movement.ReadValue<Vector2>();
        Vector3 movement = new Vector3(movementInput.x, 0f, movementInput.y);
        Ray ray = Camera.main.ScreenPointToRay(mControls.PlayerControls.Look.ReadValue<Vector2>());
        Vector3 facing = new Vector3(rayHit.point.x, transform.position.y, rayHit.point.z);
        movement = movement * speed * (((player.movement.GetValue() + player.HasSwiftnessBoon() - player.HasSnareHex()) / 100) * player.HasPinHex());

        //Apply Gravity and Normalize
        movement.y -= 100f * Time.deltaTime;
        //movement.Normalize();

        //Movement
        if (dodgeBool == false)
        {
            controller.Move(movement * Time.deltaTime);
        }
        else if (dodgeBool == true)
        {
            controller.Move(movement * Time.deltaTime * 1.8f);
        }

        //Get Player Facing Angle
        float facingAngle = Mathf.Atan2(transform.position.x - rayHit.point.x, transform.position.z - rayHit.point.z) * 180 / Mathf.PI;

        //Face mouse cursor
        if (Physics.Raycast(ray, out rayHit, Mathf.Infinity, floorLayerMask))
        {
            transform.LookAt(facing);
        }

        //animations based on facing/move direction
        AnimatePlayer(facingAngle, movementInput.x, movementInput.y);


        LayerChange();//calls layerChangeObservers delegate        

     
    }
    public void OnDodge()
    {
        if (timer <= 0)
        {
            timer = stamina;
            player.globalTimer = 0.5f;

            //Set Dodge Variables
            StartCoroutine(DodgeShift());
        }
    }

    IEnumerator DodgeShift()
    {
        dodgeBool = true;
        dodgeParticles.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        dodgeBool = false;
        dodgeParticles.SetActive(false);
    }

    private void AnimatePlayer(float angle, float moveHorizontal, float moveVertical)
    {
        float rightW = 0;
        float forwardW = 0;
        float rightS = 0;
        float forwardS = 0;
        float rightD = 0;
        float forwardD = 0;
        float rightA = 0;
        float forwardA = 0;

        if (moveVertical > 0.1)//W Pressed
        {
            if (angle > -90 && angle < 90)//Back
            {
                if (angle < 0)
                {
                    forwardW = -angle;
                }
                else
                {
                    forwardW = angle;
                }
                forwardW = (forwardW - 90) / 90;
            }
            if (angle > 90 && angle < 180)//Forward
            {
                forwardW = (angle - 90) / 90;
            }
            if (angle < -90 && angle > -180)//Forward
            {
                forwardW = -angle;
                forwardW = (forwardW - 90) / 90;
            }
            if (angle > 0 && angle < 180)//Left
            {
                if (angle > 90)
                {
                    rightW = 180 - angle;
                }
                else
                {
                    rightW = angle;
                }
                rightW /= -90;
            }
            if (angle < 0 && angle > -180)//Right
            {
                if (angle < -90)
                {
                    rightW = 180 + angle;
                }
                else
                {
                    rightW = -angle;
                }
                rightW = -rightW / -90;
            }
        }
        if (moveVertical < -0.1)//S Pressed
        {
            if (angle > -90 && angle < 90)//Forward
            {
                if (angle < 0)
                {
                    forwardS = -angle;
                }
                else
                {
                    forwardS = angle;
                }
                forwardS = (forwardS - 90) / 90;
                forwardS = -forwardS;
            }
            if (angle > 90 && angle < 180)//Back
            {
                forwardS = (angle - 90) / 90;
                forwardS = -forwardS;
            }
            if (angle < -90 && angle > -180)//Back
            {
                forwardS = -angle;
                forwardS = (forwardS - 90) / 90;
                forwardS = -forwardS;
            }
            if (angle > 0 && angle < 180)//Right
            {
                if (angle > 90)
                {
                    rightS = 180 - angle;
                }
                else
                {
                    rightS = angle;
                }
                rightS = -rightS / -90;
            }
            if (angle < 0 && angle > -180)//Left
            {
                if (angle < -90)
                {
                    rightS = 180 + angle;
                }
                else
                {
                    rightS = -angle;
                }
                rightS /= -90;
            }
        }
        if (moveHorizontal > 0.1)//D Pressed
        {
            if (angle > -90 && angle < 90)//Right
            {
                if (angle < 0)
                {
                    rightD = -angle;
                }
                else
                {
                    rightD = angle;
                }
                rightD = (rightD - 90) / 90;
                rightD = -rightD;
            }
            if (angle > 90 && angle < 180)//Left
            {
                rightD = (angle - 90) / 90;
                rightD = -rightD;
            }
            if (angle < -90 && angle > -180)//Left
            {
                rightD = -angle;
                rightD = (rightD - 90) / 90;
                rightD = -rightD;
            }
            if (angle > 0 && angle < 180)//Back
            {
                if (angle > 90)
                {
                    forwardD = 180 - angle;
                }
                else
                {
                    forwardD = angle;
                }
                forwardD = -forwardD / 90;
            }
            if (angle < 0 && angle > -180)//Forward
            {
                if (angle < -90)
                {
                    forwardD = 180 + angle;
                }
                else
                {
                    forwardD = -angle;
                }
                forwardD /= 90;
            }
        }
        if (moveHorizontal < -0.1)//A Pressed
        {
            if (angle > -90 && angle < 90)//Right
            {
                if (angle < 0)
                {
                    rightA = -angle;
                }
                else
                {
                    rightA = angle;
                }
                rightA = (rightA - 90) / 90;
            }
            if (angle > 90 && angle < 180)//Left
            {
                rightA = (angle - 90) / 90;
            }
            if (angle < -90 && angle > -180)//Left
            {
                rightA = -angle;
                rightA = (rightA - 90) / 90;
            }
            if (angle > 0 && angle < 180)//Forward
            {
                if (angle > 90)
                {
                    forwardA = 180 - angle;
                }
                else
                {
                    forwardA = angle;
                }
                forwardA /= 90;
            }
            if (angle < 0 && angle > -180)//Back
            {
                if (angle < -90)
                {
                    forwardA = 180 + angle;
                }
                else
                {
                    forwardA = -angle;
                }
                forwardA = -forwardA / 90;
            }
        }
        rightW *= 2;
        forwardW *= 2;
        rightS *= 2;
        forwardS *= 2;
        rightD *= 2;
        forwardD *= 2;
        rightA *= 2;
        forwardA *= 2;
        float forward = Mathf.Clamp((forwardW + forwardS + forwardD + forwardA), -1, 1);
        float right = Mathf.Clamp((rightW + rightS + rightD + rightA), -1, 1);
        float forwardMovement = forward * 5.66f;
        float sideMovement = right * 5.66f;
        anim.SetFloat("ForwardMovement", forwardMovement);
        anim.SetFloat("SideMovement", sideMovement);
    }
    private void LayerChange()
    {
        if (layerHit != ReturnLayer())
        {
            onLayerChange(ReturnLayer());
            layerHit = ReturnLayer();
        }
    }

    void GetInteraction()
    {
        GameObject interactedObject = rayHit.collider.gameObject;
        if (interactedObject.tag == "Interactable")
        {
            gSelected = interactedObject;

            if (Vector3.Distance(transform.position, gSelected.transform.position) < gSelected.GetComponent<Interactable>().radius)
            {
                gSelected.GetComponent<Interactable>().interact();
            }
        }
    }

    public int ReturnLayer()
    {
        if (rayHit.transform != null)
        {
            return rayHit.transform.gameObject.layer;
        }
        else
        {
            return 0;
        }
    }

    public void OnWeapon1()
    {
        if (player.inventoryOpen == false)
        {
            WeaponManager wManager = WeaponManager.instance;
            if (player.globalTimer <= 0 && player.weapon1Timer <= 0)
            {
                wManager.Attack1();
                if (player.inventory.rHand != null)
                {
                    player.AddGlobalCoolDown();
                    player.AddWeaponCooldown(1);
                }
            }
        }
    }
    public void OnWeapon2()
    {
        if (player.inventoryOpen == false)
        {
            WeaponManager wManager = WeaponManager.instance;
            if (player.globalTimer <= 0 && player.weapon2Timer <= 0)
            {
                wManager.Attack2();
                if (player.inventory.rHand != null)
                {
                    player.AddGlobalCoolDown();
                    player.AddWeaponCooldown(2);
                }
            }
        }
    }
    public void OnWeapon3()
    {
        if (player.inventoryOpen == false)
        {
            WeaponManager wManager = WeaponManager.instance;
            if (player.globalTimer <= 0 && player.weapon3Timer <= 0)
            {
                wManager.Attack3();
                if (player.inventory.lHand != null)
                {
                    player.AddGlobalCoolDown();
                    player.AddWeaponCooldown(3);
                }
                else if (player.inventory.rHand != null)
                {
                    if (player.inventory.rHand.handedness == Handed.TwoHanded)
                    {
                        player.AddGlobalCoolDown();
                        player.AddWeaponCooldown(3);
                    }
                }
            }
        }
    }
    public void OnWeapon4()
    {
        if (player.inventoryOpen == false)
        {
            WeaponManager wManager = WeaponManager.instance;
            if (player.globalTimer <= 0 && player.weapon4Timer <= 0)
            {
                wManager.Attack4();
                if (player.inventory.lHand != null)
                {
                    player.AddGlobalCoolDown();
                    player.AddWeaponCooldown(4);
                }
                else if (player.inventory.rHand != null)
                {
                    if (player.inventory.rHand.handedness == Handed.TwoHanded)
                    {
                        player.AddGlobalCoolDown();
                        player.AddWeaponCooldown(4);
                    }
                }
            }
        }
    }
    public void OnWeapon3Up()
    {
        anim.SetBool("ShieldBlock", false);
    }
    public void OnWeapon4Up()
    {
        anim.SetBool("ShieldBlock", false);
    }

    public void OnUtility5()
    {
        player.classMechanic.OnButton5();
    }
    public void OnUtility6()
    {
        player.classMechanic.OnButton6();
    }
    public void OnUtility7()
    {
        player.classMechanic.OnButton7();
    }
    public void OnUtility8()
    {
        player.classMechanic.OnButton8();
    }
    public void OnUtility9()
    {
        player.classMechanic.OnButton9();
    }
    public void OnUtility10()
    {
        player.classMechanic.OnButton10();
    }
    public void OnUtility11()
    {
        player.classMechanic.OnButton11();
    }
    public void OnUtility12()
    {
        player.classMechanic.OnButton12();
    }

    public void OnInventory()
    {
        Inventory inv = Inventory.instance;
        inv.OnInventoryPressed();
    }
    public void OnCharSheet()
    {

    }
    public void OnOptions()
    {

    }
    public void OnEscape()
    {        
        player.inventory.ClosePanel(player.inventory.inventoryPane);
        //MissionTerminal.instance.CloseWindow();
        DialogueSystem.Instance.dialoguePanel.SetActive(false);
        player.inventoryOpen = false;
    }    
    //To use interactable objects, place a script that subclasses interactable and overrides the interact() function
    public void OnInteraction()
    {        
        //TODO Interaction
        if (EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();
        }
    }
}


