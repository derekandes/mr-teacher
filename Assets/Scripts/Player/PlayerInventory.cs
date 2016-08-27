using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerInventory : MonoBehaviour
{
    public Transform slot0, slot1, slot2, slot3;
    private SpriteRenderer rSlot0, rSlot1, rSlot2, rSlot3;
    public int[] slotId = { -1, -1, -1, -1 };
    public Pickup thisPickup = null;
    private float stackOffset;
    private Transform character;
    public float stackSpacing = .02f;
    public float stackBounce = 1.5f;
    public Transform particle;
    private ParticleSystem ps = null;
    AudioSource a;
    public AudioClip pickupSound;
    public AudioClip tossSound;

    private bool levelEndToss = false;

	void Awake ()
	{
        character = transform.Find("Character");

        slot0 = transform.Find("Inventory/Slot0");
        slot1 = transform.Find("Inventory/Slot1");
        slot2 = transform.Find("Inventory/Slot2");
        slot3 = transform.Find("Inventory/Slot3");

        rSlot0 = slot0.GetComponent<SpriteRenderer>();
        rSlot1 = slot1.GetComponent<SpriteRenderer>();
        rSlot2 = slot2.GetComponent<SpriteRenderer>();
        rSlot3 = slot3.GetComponent<SpriteRenderer>();

        a = GetComponent<AudioSource>();

        if (particle != null)
        {
            ps = particle.GetComponent<ParticleSystem>();
        }
    }

    void Update()
    {
        //make inventory stack bounce with character
        stackOffset = stackSpacing + (character.localPosition.y / stackBounce);

        //adjust inventory slot positions based on sprites being used
        SetSlotTransforms();

        if (GameManager.instance.levelEnded)
        {
            if (!levelEndToss)
            {
                TossAll();
                levelEndToss = true;
            }

            return;
        }

        //when B is pressed, toss all pickups held and clear sprites
        if (Input.GetButtonDown("B"))
        {
            TossAll();
        }
    }

    public void Pickup (int id)
    {   
        //if inventory full, return
        if (slotId[3] != -1)
        {
            return;
        }

        //if slot 0 empty, set to id
        if (slotId[0] < 0)
        {
            slotId[0] = id;
            SetSprite(slot0, slotId[0]);

            //play sound
            PlayPickupSound();
        }
        //check is slot 1 empty
        else if (slotId[1] < 0)
        {
            //if so, set slot 1 to slot 0
            slotId[1] = slotId[0];
            SetSprite(slot1, slotId[1]);
            //and slot 0 to id
            slotId[0] = id;
            SetSprite(slot0, slotId[0]);

            //play sound
            PlayPickupSound();
        }
        //else check if slot 2 empty
        else if (slotId[2] < 0)
        {
            //if so, set slot 2 to slot 1
            slotId[2] = slotId[1];
            SetSprite(slot2, slotId[2]);
            //and slot 1 to slot 0
            slotId[1] = slotId[0];
            SetSprite(slot1, slotId[1]);
            //and slot 0 to id
            slotId[0] = id;
            SetSprite(slot0, slotId[0]);

            //play sound
            PlayPickupSound();
        }
        //else check if slot 3 empty
        else if (slotId[3] < 0)
        {
            //if so, set slot 3 to slot 1
            slotId[3] = slotId[2];
            SetSprite(slot3, slotId[3]);
            //and slot 2 to slot 1
            slotId[2] = slotId[1];
            SetSprite(slot2, slotId[2]);
            //and slot 1 to slot 0
            slotId[1] = slotId[0];
            SetSprite(slot1, slotId[1]);
            //and slot 0 to id
            slotId[0] = id;
            SetSprite(slot0, slotId[0]);

            //play sound
            PlayPickupSound();
        }
    }

    //remove object in slot 0, move other objects down a slot
    public void Give()
    {
        //slot 0 = slot 1
        slotId[0] = slotId[1];
        SetSprite(slot0, slotId[0]);

        //slot 1 = slot 2
        slotId[1] = slotId[2];
        SetSprite(slot1, slotId[1]);

        //slot 2 = slot 3
        slotId[2] = slotId[3];
        SetSprite(slot2, slotId[2]);

        //slot 3 = -1
        slotId[3] = -1;
        SetSprite(slot3, slotId[3]);
    }

    void SetSprite(Transform slot, int id)
    {
        if(id == -1)
        {
            ClearSprite(slot);
            return;
        }

        //get pickup from id
        foreach (Pickup pickup in PickupManager.instance.pickups)
        {
            if (pickup.id == id)
            {
                thisPickup = pickup;
            }
        }

        if (thisPickup != null)
        {
            //load sprite   
            SpriteRenderer slotSprite = slot.GetComponent<SpriteRenderer>();
            slotSprite.sprite = Resources.Load <Sprite> (thisPickup.sprite);

            //set scale
            slot.localScale = new Vector3(thisPickup.xScale, thisPickup.yScale, 1);
        }
    }

    void ClearSprite(Transform slot)
    {
        SpriteRenderer slotSprite = slot.GetComponent<SpriteRenderer>();
        slotSprite.sprite = null;
    }

    void TossAll()
    {
        // do particle + score
        if (ps != null)
        {
            if (slotId[0] != -1)
            {
                ps.Play();
                PlayTossSound();
                GameManager.instance.throws += 1;
            }
        }

        // toss!
        if (slotId[0] != -1)
        {
            Toss(slot0, slotId[0]);
            slotId[0] = -1;
            ClearSprite(slot0);
        }
        if (slotId[1] != -1)
        {
            Toss(slot1, slotId[1]);
            slotId[1] = -1;
            ClearSprite(slot1);
        }
        if (slotId[2] != -1)
        {
            Toss(slot2, slotId[2]);
            slotId[2] = -1;
            ClearSprite(slot2);
        }
        if (slotId[3] != -1)
        {
            Toss(slot3, slotId[3]);
            slotId[3] = -1;
            ClearSprite(slot3);
        }
    }

    void Toss(Transform slot, int id)
    {
        //get pickup from id
        foreach (Pickup pickup in PickupManager.instance.pickups)
        {
            if (pickup.id == id)
            {
                thisPickup = pickup;
            }
        }

        float xForce = Random.Range(200, 400);
        float yForce = Random.Range(1000, 1500);
        if (Random.Range(0, 2) == 1) xForce = -xForce;

        string name = "Prefabs/" + thisPickup.name;
        Rigidbody2D instance = Instantiate(Resources.Load(name, typeof(Rigidbody2D))) as Rigidbody2D;

        //if pickup moves, disable movement
        KidMovement movement = instance.gameObject.GetComponent<KidMovement>();
        if (movement != null)
        {
            movement.enabled = false;
        }

        instance.isKinematic = false;
        instance.simulated = true;
        instance.gameObject.GetComponent<PickupLand>().onGround = false;
        instance.gameObject.transform.position = slot.position;
        instance.AddForce(new Vector2(xForce, yForce));
    }

    void SetSlotTransforms()
    {
        // grab current sprites
        Sprite s0 = rSlot0.sprite;
        Sprite s1 = rSlot1.sprite;
        Sprite s2 = rSlot2.sprite;
        Sprite s3 = rSlot3.sprite;

        // if there something in s1, set slot1 position
        if (s1 != null)
        {
            slot1.localPosition = new Vector3(slot1.localPosition.x,
                slot0.localPosition.y + (((s0.bounds.extents.y * slot0.localScale.y) * 2)) + stackOffset,
                slot1.localPosition.z);
        }

        // if there something in s2, set slot2 position
        if (s2 != null)
        {
            slot2.localPosition = new Vector3(slot2.localPosition.x,
                slot1.localPosition.y + (((s1.bounds.extents.y * slot1.localScale.y) * 2)) + stackOffset,
                slot2.localPosition.z);
        }

        // if there something in s3, set slot3 position
        if (s3 != null)
        {
            slot3.localPosition = new Vector3(slot3.localPosition.x,
                slot2.localPosition.y + (((s2.bounds.extents.y * slot2.localScale.y) * 2)) + stackOffset,
                slot3.localPosition.z);
        }
    }

    void PlayPickupSound()
    {
        //play pickup sound
        a.clip = pickupSound;
        a.pitch = Random.Range(0.8f, 1.2f);
        a.loop = false;
        a.Play();
    }

    void PlayTossSound()
    {
        //play toss sound
        a.clip = tossSound;
        a.loop = false;
        a.Play();
    }
}
