﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour {

    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;
    GameObject director;

    // Use this for initialization
    void Start () {
        this.director = GameObject.Find("GameDirector");
        this.aud = GetComponent<AudioSource>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Apple")
        {
            this.director.GetComponent<GameDirector>().GetApple();
            this.aud.PlayOneShot(this.appleSE);
        }
        else
        {
            this.director.GetComponent<GameDirector>().GetBomb();
            this.aud.PlayOneShot(this.bombSE);
        }
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
		
	}
}
