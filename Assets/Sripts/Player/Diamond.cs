using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int gems = 1;
    public AudioSource audio;
    private Player player;
    public AudioClip gem;
    private Enemy enemy;
    private SpriteRenderer renderer;
    private BoxCollider2D collider;

    void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
        enemy = GetComponent<Enemy>();
        audio = GetComponent<AudioSource>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player");
        {
            player.diamondCount += this.gems;
            audio.PlayOneShot(AudioManager.Instance.diamondSound);
            Destroy(this.renderer);
            Destroy(this.collider);
            Destroy(this.gameObject, 1.0f);
        }

        if (other.tag == "FlameSword")
        {
            player.Health++;
            audio.PlayOneShot(AudioManager.Instance.diamondSound);
            Destroy(this.renderer);
            Destroy(this.collider);
            Destroy(this.gameObject, 1.0f);
        }
    }
}
