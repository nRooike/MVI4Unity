using MVI4Unity.Sample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVI4Unity
{
    public class RoleReducer : Reducer<RoleItemCountState, RoleReducer.RoleducerMethodType>
    {

        public enum RoleducerMethodType
        {
            Init,
            Func01,
            Func02,
            Func03,
        }

        [ReducerMethod((int)RoleducerMethodType.Init, true)]
        RoleItemCountState InitiState(RoleItemCountState oldState,object @param)
        {
            RoleItemCountState itemState = new RoleItemCountState();
            itemState.Attack = 20;
            itemState.Defense = 10;
            itemState.Health = 100;
            return itemState;
        }

        [ReducerMethod((int)RoleducerMethodType.Func01, true)]
        RoleItemCountState Function1 (RoleItemCountState oldState, object @param)
        {
            oldState.Health -= 10;
            return oldState;
        }

        [ReducerMethod((int)RoleducerMethodType.Func02, true)]
        RoleItemCountState Function2(RoleItemCountState oldState, object @param)
        {
            oldState.Health += 10;
            return oldState;
        }

        [ReducerMethod((int)RoleducerMethodType.Func03, true)]
        RoleItemCountState Function3(RoleItemCountState oldState, object @param)
        {
            oldState.Attack += 10;
            oldState.Defense += 10;
            return oldState;
        }
    }

}
