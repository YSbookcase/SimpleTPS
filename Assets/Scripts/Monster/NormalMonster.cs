using DesignPattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NormalMonster : Monster, IDamagable
{
    private bool _isActivateControl = true;
    private bool _canTracking = true;

    [SerializeField] private int MaxHP;

    private ObservableProperty<int> CurrentHP; 

    private ObservableProperty<bool> IsMoving = new();

    private ObservableProperty<bool> IsAttacking = new();

    private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform _targetTransform;

    private void Awake()
    {
        Init();
    }
    private void Update()
    {
        HandleControl();
    }



    private void Init()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        //_navMeshAgent.isStopped = true;
    }

    private void HandleControl()
    {
        if (!_isActivateControl)
        {
            return;
        }

        HandleMove();
    }


    private void HandleMove()
    {
        if (_targetTransform == null) return;

        

        if (_canTracking)
        {
            _navMeshAgent.SetDestination(_targetTransform.position);
         
        }
       
        _navMeshAgent.isStopped = !_canTracking;
        IsMoving.Value = _canTracking;

    }
    
 


    public void TakeDamage(int value)
    {
        // ������ ���� ����
    }
}
