﻿using Assets.Enemies.Scripts;

using UnityEngine;

public class rangeattack : MonoBehaviour
{
    public float speed = 10f;

    public Transform target;
    
    public int damage = 1;

    public int armorpen = 2;


    public void chase(Transform _target) {
        this.target = _target;
    }

    void Update() {
        if (this.target == null)
        {
            Destroy(this.gameObject);
            return;
        }

        Vector3 direction = this.target.position - this.transform.position;
        float distancePerFrame = this.speed * Time.deltaTime;

        this.transform.Translate(direction.normalized * distancePerFrame, Space.World);
    }

    // Deals damage to the enemies
    void OnTriggerEnter2D(Collider2D hitTarget)
    {
        if (hitTarget.gameObject.tag == "Enemy")
        {
            hitTarget.gameObject.GetComponent<Enemy_Generic>().DamageEnemy(this.damage, this.armorpen, 1, false);
            hitTarget.gameObject.GetComponent<Enemy_Generic>().StunEnemy((float)0.2);
            Destroy(this.gameObject);
        }
    }


}
