﻿namespace Assets.Scripts
{
    using DG.Tweening;

    using UnityEngine;

    [RequireComponent(typeof(Collider2D))]
    public class Destructible : MonoBehaviour
    {
        [SerializeField]
        [Range(0, 10)]
        private int durability;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Bullet"))
            {
                this.durability--;
                GameObject.Destroy(other.gameObject);

                if (this.durability <= 0)
                {
                    GameObject.Destroy(this.gameObject);
                }

                this.transform.DOShakePosition(1.0f, 0.3f);
            }
        }
    }
}