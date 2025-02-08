/*using UnityEngine;

public class Unit : MonoBehaviour
{
    
    void Start()
    {
        UnitSelections.Instance.unitList.Add(this.gameObject);
    }

    
    void OnDestroy()
    {
        UnitSelections.Instance.unitList.Remove(this.gameObject);
    }

    [Header("Unit Basic Stats")]
    public int attack;
    public int cost;
    public int health;
}
*/

using UnityEngine;

public class Unit : MonoBehaviour
{
    // ... other code here ...

    [Header("Unit Combat Stats")]
    public int attack;
    public int health;
   


    void Start()
    {
        UnitSelections.Instance.unitList.Add(this.gameObject);
    }

    

    void OnDestroy()
    {
        UnitSelections.Instance.unitList.Remove(this.gameObject);
    }
    // Attack another unit
    public void Attack(enemy target)
    {
        target.TakeDamage(attack);
    }

    // Take damage from another unit's attack
    public void TakeDamage(int damage)
    {
        health -= damage;

        // Check if the unit has been defeated
        if (health <= 0)
        {
            Die();
        }
    }

    // Called when the unit's health drops to or below zero
    public void Die()
    {
        // Destroy the unit game object
        Destroy(gameObject);
    }
}