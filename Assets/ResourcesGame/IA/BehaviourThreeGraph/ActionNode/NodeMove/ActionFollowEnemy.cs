using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/Move")]
public class ActionFollowEnemy : ActionNodeVehicle
{
    public override void OnAwake()
    {
        base.OnAwake();
    }
    public override TaskStatus OnUpdate()
    {
        if(_IACharacterVehiculo.health.IsDead)
            return TaskStatus.Failure;

        SwitchUnit();

        return TaskStatus.Success;

    }
    void SwitchUnit()
    {


        switch (_UnitGame)
        {
            case UnitGame.Thief:
                if(_IACharacterVehiculo is IACharacterVehiculoZombie)
                {
                    ((IACharacterVehiculoZombie)_IACharacterVehiculo).MoveToEnemy();
                    ((IACharacterVehiculoZombie)_IACharacterVehiculo).LookEnemy();
                }

                break;
            case UnitGame.Soldier:
                if (_IACharacterVehiculo is IACharacterVehiculoSoldier)
                {
                    ((IACharacterVehiculoSoldier)_IACharacterVehiculo).MoveToEnemy();
                    ((IACharacterVehiculoSoldier)_IACharacterVehiculo).LookEnemy();
                }
                break;
            case UnitGame.None:
                break;
            default:
                break;
        }



    }

}