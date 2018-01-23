using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IEnemy
{
    void GetDamage(float damage);
    void SetDamage(float damage);
    void Die();
    void Move(float speed);
}

