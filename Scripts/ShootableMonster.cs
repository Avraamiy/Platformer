using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableMonster :  MonoBehaviour
{
    private float tMin = 1f;
    private float tMax = 5f;
    private float rate = 2.0F;

    private Bullet bullet;

    private void Awake()
    {
        bullet = Resources.Load<Bullet>("Bullet");
    }

    private void Start()
    {
        InvokeRepeating("Shoot", rate, Random.Range( tMin, tMax));
    }

    private void Shoot()
    {
        Vector3 position = transform.position;
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        newBullet.Parent = gameObject;
        newBullet.Direction = -newBullet.transform.right;
        newBullet.tag = "enemy";
    }

  }
