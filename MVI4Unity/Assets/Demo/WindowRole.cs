using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MVI4Unity 
{
    public class WindowRole : AWindow
    {
        [AWindowCom("Attack")]
        public Text attckTxt;

        [AWindowCom("Defense")]
        public Text defenseTxt;

        [AWindowCom("Health")]
        public Text healthTxt;

        [AWindowCom("Tittle")]
        public Text titleTxt;

        [AWindowCom("ColseButton")]
        public Button closeBtn;

        [AWindowCom("ItemContain")]
        public Transform itemContain;

        [AWindowCom("hDBtn")]
        public Button addDBtn;

        [AWindowCom("hABtn")]
        public Button ReduceABtn;

        [AWindowCom("atttributeBtn")]
        public Button attributeBtn;
    }

    public class WindowItem : AWindow
    {


        [AWindowCom("content")]
        public Transform childTra;
    }

    public class WindowChildItem : AWindow
    {
        [AWindowCom("childItemImage")]
        public Image itemImg;
    }

    public class WindowRoleStatic
    {
        public static WindowNodeType<WindowChildItem, ItemState, ItemInfo> itemNode = new WindowNodeType<WindowChildItem, ItemState, ItemInfo>(
            "Item",
            fillProps: (state, window, store, prop) => {
              
                    if (!prop.isUnlock)
                    {
                        Sprite sprite = Resources.Load<Sprite>("UnlockIcon");
                    }
                    else
                    {
                        if (prop.iconName != null)
                        {
                            Sprite sprite = Resources.Load<Sprite>(prop.iconName);
                            window.itemImg.sprite = sprite;
                        }                      
                    }
            }
            );


        public static RoleItemCantainerType<WindowItem, ContentContainerState, ItemInfo> contenCantainer = new RoleItemCantainerType<WindowItem, ContentContainerState, ItemInfo>(
            "ContentCantainer",
           containerCreator: (window) =>
           {
               List<Transform> containerList = PoolMgr.Ins.GetList<Transform>().Pop();
               containerList.Add(window.childTra);
               return containerList;
           },
            childNodeCreator: (state) =>
            {
              
                /*f (state != null)
                {*/
                 List<List<WindowNode>> childNodeGroup = PoolMgr.Ins.GetList<List<WindowNode>>().Pop();
                    List<WindowNode> childNodeList1 = PoolMgr.Ins.GetList<WindowNode>().Pop();

                //   
                /*       for (int i = 0; i < itemList.Count; i++)
                     {
                           childNodeList1.Add(WindowRoleStatic.itemNode.CreateWindowNode(state, itemList[i]));
                      }*/
                List<ItemInfo> itemList = state.itemList;
                for (int i = 0; i < state.itemCount; i++)
                    {
                       ItemState windowChildItem = new ItemState();
                        windowChildItem.itemInfo = itemList[i];
                        
                        
                        childNodeList1.Add(WindowRoleStatic.itemNode.CreateWindowNode(windowChildItem, windowChildItem.itemInfo));
                   }
                    childNodeGroup.Add(childNodeList1);
            //    }      
                    return childNodeGroup;
 
             
            },
              fillProps: (state, window, store, prop) =>
              {
            
              }
            );
        public static WindowNodeType<WindowRole, RoleItemCountState> root = new WindowNodeType<WindowRole, RoleItemCountState>(
            "Inventory Panel",
            containerCreator:(window)=>
            {
                List<Transform> containerList = PoolMgr.Ins.GetList<Transform>().Pop();
                containerList.Add(window.itemContain);
                return containerList;
            },
            childNodeCreator: (state) => {
                List<List<WindowNode>> childNodeGroup = PoolMgr.Ins.GetList<List<WindowNode>>().Pop();
                List<WindowNode> childNodeList1 = PoolMgr.Ins.GetList<WindowNode>().Pop();

                ContentContainerState containerState = new ContentContainerState();

                containerState.itemList = state.itemList;
                containerState.itemCount = state.itemCount;
                containerState.unLockitemCount = state.unLockitemCount;


                 childNodeList1.Add(contenCantainer.CreateWindowNode(containerState));
               

                childNodeGroup.Add(childNodeList1);
                return childNodeGroup;
            },
            fillProps: (state, window, store, prop) => {
                RoleItemCountState state1 = state as RoleItemCountState;
                window.attckTxt.text = state1.Attack.ToString();
                window.defenseTxt.text = state1.Defense.ToString();
                window.healthTxt.text = state1.Health.ToString();

                window.addDBtn.onClick.AddListener(() => { store.DisPatch(RoleReducer.RoleducerMethodType.AddItem, new ItemChange("Test01",1)); });
                window.ReduceABtn.onClick.AddListener(() => { store.DisPatch(RoleReducer.RoleducerMethodType.ReduceItem, default); });
           
            }
            );
        public static WindowNodeType<WindowItem, RoleItemCountState> item = new WindowNodeType<WindowItem, RoleItemCountState>("WindownItem",
         fillProps: (state, window, store, prop) =>
         {
             Debug.LogWarning($"{state} = {window} = {store}");
         });
  
    }
}

