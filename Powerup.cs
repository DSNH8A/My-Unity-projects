using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
    {
    private float speed = 3.0f;
    private Player triple;
    [SerializeField]
    private int powerUpID;
    [SerializeField]
    private AudioClip audioClip;

    void Start()
    {
       
    }


    void Update()
    {
        StartCoroutine(DestroyRoutine());
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(audioClip, transform.position);

            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
               
                switch (powerUpID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedPowerUp();
                        break;
                    case 2:
                        player.ShieldPowerUp();
                        break;
                    default:
                        Debug.Log("No boosters");
                        break;
                }

            }
            Destroy(this.gameObject);
        }
    }

    IEnumerator DestroyRoutine()
    { 
        yield return new WaitForSeconds(5.0f);
        Destroy(this.gameObject);
            
    }
}
