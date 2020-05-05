using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyProperties : ScriptableObject
{
    private floorManager floorProperties;
    public projectileBehaviorTypes.projectileBehavior[] enemyBehavior;
    public enum CheckState { _Roaming, _MoveTowardsTarget};
    public enum IsAttacking { _Attacking, _NotAttacking};
    public enum DamageType { _fire, _water, _air, _earth, _light, _dark };
    public struct Debuffs { public bool burn; public bool wet; public bool freeze; public bool root; };
    public Debuffs enemyDebuffs;
    public DamageType elementalType;
    public IsAttacking isAttacking;
    public CheckState checkState;
    //public string enemyName;
    public new string name;
    public string description;
    public float damage;
    private float health;
    public float maxHealth;
    public float score;
    public float projectileInterval;
    public float movementSpeed;
    public float damageScaleModifier;
    public float attackRadius;
    public float lookRadius;
    public float stoppingDistance;
    public float roamDistance_Min;
    public float roamDistance_Max;
    private Image healthBar;

    GameObject thisEnemy;
    Transform target;
    NavMeshAgent agentController;
    Vector3 startingPosition;
    Vector3 roamPosition;

    public EnemyProperties(GameObject _thisObject, Vector3 _setStartingPosition)
    {
        //SetGameObjectOfSelf(_thisObject);
        InitializeProperties(_thisObject, _setStartingPosition);
        //SetStartingPosition(_setStartingPosition);
    }

    public void InitializeProperties (GameObject _thisObject, Vector3 _setStartingPosition)
    {
        SetGameObjectOfSelf(_thisObject);

        startingPosition = _setStartingPosition;
        thisEnemy.gameObject.transform.position = _setStartingPosition;

        if (!(agentController = thisEnemy.GetComponent<NavMeshAgent>()))
        {
            Debug.LogWarningFormat("Found no {0} attached to {1}", typeof(NavMeshAgent).Name, thisEnemy.name);
        }
        else
        {
            agentController.speed = movementSpeed;
            agentController.stoppingDistance = stoppingDistance;
        }

            startingPosition = thisEnemy.transform.position;
        GetRoamingPosition();
        floorProperties = GameObject.Find("GameManager").GetComponent<floorManager>();
        target = PlayerManager.instance.player.transform;

        InitializeGraphics();
    }

    private void InitializeGraphics()
    {
        health = maxHealth;
        healthBar = thisEnemy.GetComponentInChildren<Canvas>().GetComponentInChildren<Image>();
    }

    public void SetGameObjectOfSelf (GameObject thisObject)
    {
        thisEnemy = thisObject;
    }

    public void GetRoamingPosition()
    {
        roamPosition = GetRandomDir();
    }

    public bool CheckRoamPosition()
    {
        if (Vector3.Distance(thisEnemy.transform.position, roamPosition) < agentController.stoppingDistance)
            return true;
        return false;
    }

    private Vector3 GetRandomDir()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        Vector3 direction = startingPosition + new Vector3(x, 0f, y).normalized * Random.Range(roamDistance_Min, roamDistance_Max);
        return direction;
    }

    public void MoveToTarget()
    {
        float distance = Vector3.Distance(target.position, thisEnemy.transform.position);

        if (distance <= lookRadius)
        {
            agentController.SetDestination(target.position);
        }

        if (distance <= agentController.stoppingDistance)
        {
            LookAtTarget();
        }
    }

    public void MoveToRoam()
    {
        float distance = Vector3.Distance(roamPosition, thisEnemy.transform.position);


            agentController.SetDestination(roamPosition);

        if (distance <= agentController.stoppingDistance)
        {
            LookAtTarget();
        }
    }

    private void LookAtTarget()
    {
        Vector3 direction = (target.position - thisEnemy.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        thisEnemy.transform.rotation = Quaternion.Slerp(thisEnemy.transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void DoDamage(float _damage)
    {
        health -= _damage;
        healthBar.fillAmount = health / maxHealth;
    }
    
    public bool IsDead ()
    {
        if (health <= 0)
        {
            GameObject.Destroy(thisEnemy);
            return true;
        }
        else return false;
    }

}
