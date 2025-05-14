using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

namespace KYS_Test
{ 
public class PlayerController : MonoBehaviour
{
        public PlayerMovement _movement;
        public PlayerStatus _status;


        private void Update()
        {
            MoveTest();
        }

        public void MoveTest()
        {
            // (ȸ�� ���� ��) �¿� ȸ���� ���� ���� ��ȣ��
            Vector3 camRotation = _movement.SetAimRotation();

            float moveSpeed;
            if (_status.IsAiming.Value)
            {
                moveSpeed = _status.WalkSpeed;
            }
            else
            {
                moveSpeed = _status.RunSpeed;
            }

            Vector3 moveDir = _movement.SetMove(moveSpeed);
            _status.IsMoving.Value = (moveDir != Vector3.zero);

            // TODO: ��ü���� �̵� ����(?)
        }

    }

}
