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
    private Animator _NMosterAnimator;

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
        _NMosterAnimator = GetComponent<Animator>();
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

        // 이동 방향 벡터 구하기
        Vector3 moveDirection = _navMeshAgent.velocity;

        // 애니메이션에 이동 상태 설정
        if (moveDirection.magnitude > 0.1f)
        {
         
            // 이동 방향을 애니메이션 파라미터에 전달
            _NMosterAnimator.SetFloat("X", moveDirection.x);
            _NMosterAnimator.SetFloat("Z", moveDirection.z);
        }
       



    }




    public void TakeDamage(int value)
    {
        // 데미지 판정 구현
        // 체력 깎고
        // 체력이 0 이하가 되면 Dead 처리
        Debug.Log($"{gameObject.name} : {value} 데미지 입음");
    }

    public void SubscribeEvents()
    {

    }

    public void UnsubscribeEvents()
    {

    }

   // private void SetMoveAnimation(bool value) => _NMosterAnimator.SetBool("canTracking", value);
   // private void SetAttackAnimation(bool value) => _NMosterAnimator.SetBool("IsAttack", value);

}
