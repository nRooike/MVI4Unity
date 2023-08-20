using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MVI4Unity
{
    public enum FunctionNode
    { 
        Root,
        InventroyNode
    }

    public class RoleAStateBase : AStateBase
    {
        public  FunctionNode stateNode = FunctionNode.InventroyNode;

    }



    public class RoleItemCountState : RoleAStateBase
    {
      public   RoleItemCountState()
        {
            stateNode = FunctionNode.InventroyNode; ;
        }

        private int attack;
        public int Attack
        {
            get {
                return attack;
            }
            set {
                attack = value;
            }
        }

        private int defense;
        public int Defense
        {
            get {
                return defense;
            }
            set {
                defense = value;
            }
        }

        private int health;
        public int Health
        {
            get
            {
                return health;
            }
            set {
                health = value;
            }
        }

        private int count;
        public int Count
        {
            get { return count; }
            set { count = Count; }
        }

        public int itemCount = 40;
        public int unLockitemCount = 20;
        public List<ItemInfo> itemList = new List<ItemInfo>(40);

    }

    public class ContentContainerState : RoleAStateBase
    {

       /* public int itemCount=40;
        public int unLockitemCount=20;
        public List<ItemInfo> itemList=new List<ItemInfo>();
  */
    }
    /// <summary>
    /// 此处的ItemInfo理解成该槽位的信息
    /// </summary>
    public class ItemInfo
    {
        public int position;
        public string iconName;
        public int count;
       public bool isUnlock;
    }

    public class ItemState: RoleAStateBase
    {
        public ItemInfo itemInfo;
        public int position;
    }
}

