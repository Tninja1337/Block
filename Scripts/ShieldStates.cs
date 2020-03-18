using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldStates : MonoBehaviour
{
    //Set up variables, damage cooldown bool, and behaviour
    public int shieldState; //Use 0 for Wood, 1 for Metal, 2 for Phase
    public GameObject shield;
    private int shieldDamage = 0;
    private bool cooldown = false;
    Behaviour halo;

    //Set up sound source
    public AudioSource[] audioSources;

    void Start()
    {
        //Set up a halo behavior to control halo activation ie. when wood shield is hit by fire arrow
        Behaviour halo = (Behaviour)GetComponent("Halo");
        halo.enabled = false;

    }

    void Update()
    {
        //Destroys the shield if it has been damaged thrice
        if (shieldDamage == 3)
        {
            this.gameObject.SetActive(false);
        }


    }

    void OnTriggerEnter(Collider other)
    {
        //Each shield has a weakness. If fire arrows hit the wood shield and the cooldown is no longer active, 
        //the shield halo activates, the cooldown starts, and DamageReset() starts
        if (other.gameObject.tag == "FireArrow" && shieldState == 0 && cooldown == false)
        {
            Debug.Log("Shield burnt!");
            Behaviour halo = (Behaviour)GetComponent("Halo");
            halo.enabled = true;
            cooldown = true;
            //Play the Hit and the Fire Sound
            foreach (var audioSource in audioSources)
                {
                    if (audioSource.isPlaying) return;
                    audioSource.pitch = 1.0f + Random.Range(-.1f, .1f);
                    audioSource.volume = 1.0f - Random.Range(0.0f, .25f);
                     audioSource.Play();
                }
            StartCoroutine(DamageReset());
        }
        else if (other.gameObject.tag == "Arrow" || other.gameObject.tag == "IceArrow")
        {
            //Play the Hit Sound
            audioSources[1].Play();
        }

        //Same but for the Metal Shield and Ice Arrows
        if (other.gameObject.tag == "IceArrow" && shieldState == 1 && cooldown == false)
        {
            Debug.Log("Shield frozen!");
            Behaviour halo = (Behaviour)GetComponent("Halo");
            halo.enabled = true;
            cooldown = true;
            //Play the Hit and the Ice Sound
            foreach (var audioSource in audioSources)
            {
                if (audioSource.isPlaying) return;
                audioSource.pitch = 1.0f + Random.Range(-.1f, .1f);
                audioSource.volume = 1.0f - Random.Range(0.0f, .25f);
                audioSource.Play();
            }
            StartCoroutine(DamageReset());
        }
        else if (other.gameObject.tag == "Arrow" || other.gameObject.tag == "FireArrow")
        {
            //Play the Hit Sound
            audioSources[1].Play();
        }

        //The Mirror Shield is a little different. All arrows damage it, but it is the only one capable of blocking Phase Arrows.
        if ((other.gameObject.tag == "Arrow"|| other.gameObject.tag == "FireArrow"|| other.gameObject.tag == "IceArrow" ) && shieldState == 2 && cooldown == false)
        {
            Debug.Log("Shield cracked!");
            cooldown = true;
            //Play the Hit Sound
            audioSources[1].Play();
            StartCoroutine(DamageReset());
        }
        //When the mirror shield absorbs a phase arrow, it activates it's halo and uses a different coroutine.
        else if (other.gameObject.tag == "PhaseArrow" && shieldState == 2)
        {
            Debug.Log("Phase Arrow Absorbed!");
            Behaviour halo = (Behaviour)GetComponent("Halo");
            halo.enabled = true;
            //Play the Portal Sound
            audioSources[0].Play();
            StartCoroutine(MirrorReset());
        }

    }

    IEnumerator DamageReset()
    {
        //After three seconds of waiting, the shield damage finalizes, the halo effect ends, and the cooldown resets
        yield return new WaitForSeconds(3);
        shieldDamage += 1;
        Debug.Log("Damage dealt: " + shieldDamage);
        Behaviour halo = (Behaviour)GetComponent("Halo");
        halo.enabled = false;
        cooldown = false;
    }

    IEnumerator MirrorReset()
    {
        //After two seconds of glowing, the halo effect ends
        yield return new WaitForSeconds(2);
        Behaviour halo = (Behaviour)GetComponent("Halo");
        halo.enabled = false;
    }
}
