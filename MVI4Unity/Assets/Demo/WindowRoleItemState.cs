using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MVI4Unity
{
    public class RoleItemCountState :AStateBase
    {
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

        public List<RoleItem> roleItems; 
    }

    public class Item
    {
        public string name;
        public int iconIndex;
        public int count;
    }

    public class RoleItem
    {
        public Item item;
        public int inventoryIndex;

    }
}

