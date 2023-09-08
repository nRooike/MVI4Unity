using MVI4Unity.Sample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVI4Unity
{
    public class ItemChange
    {
        public ItemChange(string _name,int _count,int _position=-1)
        {
            propName = _name;
            count = _count;
            position = _position;

        }

        public string propName;
        public int count;
        public int position=-1;

    }

    public class RoleReducer : Reducer<RoleItemCountState, RoleReducer.RoleducerMethodType>
    {

        public enum RoleducerMethodType
        {
            Init,
            AddItem,
            ReduceItem,
            Func03,
        }

        [ReducerMethod((int)RoleducerMethodType.Init, true)]
        RoleItemCountState InitiState(RoleItemCountState oldState,object @param)
        {
            RoleItemCountState itemState = new RoleItemCountState();
            List<ItemInfo> lists = itemState.itemList;
           // lists = new List<ItemInfo>(itemState.itemCount);
            for (int i = 0; i < itemState.itemCount; i++)
            {
                lists.Add( new ItemInfo());
            }
            return itemState;
        }

        [ReducerMethod((int)RoleducerMethodType.AddItem)]
        RoleItemCountState AddRoleItem (RoleItemCountState oldState, object @param)
        {
            ItemChange changeItem = @param as ItemChange;
           
                List<ItemInfo> itemList = oldState.itemList;
                for (int i = 0; i < oldState.unLockitemCount; i++)
                {
                    if (itemList[i].iconName != null)
                    {
                        if (itemList[i].iconName.Equals(changeItem.propName))
                        {
                            itemList[i].count += changeItem.count;
                            itemList[i].isUnlock = true;
                            return oldState;
                        }
                    }
                   
                }

                ItemInfo itemInfo = null;
                for (int i = 0; i < oldState.unLockitemCount; i++)
                {
                    if(itemList[i].iconName==null)
                    {
                        itemInfo = itemList[i];
                        break; 
                    }

                }
                if (itemInfo == null)
                {
                    // 背包已经满了

                }
                else {
                    itemInfo.count = changeItem.count;
                    itemInfo.iconName = changeItem.propName;

                }

                return oldState;

        }

        [ReducerMethod((int)RoleducerMethodType.ReduceItem)]
        RoleItemCountState ReduceRoleItem(RoleItemCountState oldState, object @param)
        {
            ItemChange changeItem = @param as ItemChange;

            if (changeItem.position >= 0 && changeItem.position < oldState.unLockitemCount)
            {
                ItemInfo itemInfo = oldState.itemList[changeItem.position];
                if (itemInfo == null|| itemInfo.iconName=="") return oldState;

                itemInfo.count -= changeItem.count;
                if (itemInfo.count <= 0)
                {
                    itemInfo.iconName = "";
                 
                }
            }
                return oldState;
        }

     
    }

}
