﻿using UnityEngine;
using System.Collections;

public class slash : MonoBehaviour {

    bool seen = false;
    Renderer rend;
    public int type = 1;
    float timer = 0.1f;
    GameObject pl;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        pl = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), pl.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), pl.GetComponent<CircleCollider2D>());

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (rend.isVisible)
            seen = true;

        if (seen && !rend.isVisible)
            Destroy(gameObject);

        if (timer <= 0)
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.tag == "Enemy")
            Destroy(gameObject);
        else
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), c.gameObject.GetComponent<Collider2D>());
        }
    }
}
