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
        public Button healthDBtn;

        [AWindowCom("hABtn")]
        public Button healthABtn;

        [AWindowCom("atttributeBtn")]
        public Button attributeBtn;
    }

    public class WindowItem : AWindow
    {
        [AWindowCom("imageItem")]
        public Image bkImg;

        [AWindowCom("childItem")]
        public Transform childTra;
    }

    public class WindowChildItem : AWindow
    {
        [AWindowCom("childItemImage")]
        public Image itemImg;
    }

    public class WindowRoleStatic
    {
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

                for (int i = 0; i < state.Count; i++)
                {
                    childNodeList1.Add(item.CreateWindowNode(state));
                }

                childNodeGroup.Add(childNodeList1);
                return childNodeGroup;
            },
            fillProps: (state, window, store, prop) => {
                window.attckTxt.text = state.Attack.ToString();
                window.defenseTxt.text = state.Defense.ToString();
                window.healthTxt.text = state.Health.ToString();

                window.healthDBtn.onClick.AddListener(() => { store.DisPatch(RoleReducer.RoleducerMethodType.Func01, default); });
                window.healthABtn.onClick.AddListener(() => { store.DisPatch(RoleReducer.RoleducerMethodType.Func02, default); });
                window.attributeBtn.onClick.AddListener(() => { store.DisPatch(RoleReducer.RoleducerMethodType.Func03, default);  });
            }
            );
        public static WindowNodeType<WindowItem, RoleItemCountState> item = new WindowNodeType<WindowItem, RoleItemCountState>("WindownItem",
         fillProps: (state, window, store, prop) =>
         {
             Debug.LogWarning($"{state} = {window} = {store}");
         });
  
    }
}

