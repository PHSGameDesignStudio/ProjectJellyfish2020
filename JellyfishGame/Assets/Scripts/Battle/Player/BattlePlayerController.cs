using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayerController : MonoBehaviour
{
    
    //public float speed = 5; commented this out bc Player.cs

    //public float dashSpeed = 15;
    //bool isDashing;
    //public float dashCooldown = 0.07f;
    //public float dashEnabledCooldown = 3f;
    //public float dashEnabledTimer = 0;
    //public float dashTimer;
    public float cooldown = 0.5f;
    float cooldownTimer;
    Vector2 vel;
    public float boundlimit = 4;
    void Start()
    {
        transform.parent.GetComponent<BattlePlayer>().UpdateHPUI();
    }

    // Update is called once per frame
    void Update()
    {
        var s = Player.GetSpeed();
        vel = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        transform.position += (Vector3)vel * Time.deltaTime * s;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -boundlimit, boundlimit), Mathf.Clamp(transform.position.y, -boundlimit, boundlimit));
        cooldownTimer -= Time.deltaTime;
        // update player hp slider

        
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (cooldownTimer <= 0)
        {
            print("COLLIDING");
            switch (collision.tag)
            {
                case "Hostile":
                    var player = transform.parent.GetComponent<BattlePlayer>();

                    // Damaging player [consider battle dmg depending on entity or if player wearing armor / defense]
                    print("HOSTILE!!!");
                    player.SetHP(player.GetHP() - 1);
                    HP1UP.MakeAt("-1", player.transform.position, Color.red);
                    SFXManager.ResetSFX("PlayerHit");

                    // Updating the HP UI box
                    player.UpdateHPUI();

                    // Resetting cooldown
                    cooldownTimer = cooldown;
                    break;
            }
        }
    }
}
