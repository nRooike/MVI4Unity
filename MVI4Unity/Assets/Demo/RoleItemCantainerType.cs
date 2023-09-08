using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MVI4Unity
{
    public class RoleItemCantainerType<A, S,P> : WindowNodeType<A, S, P> where A : AWindow where S : AStateBase
    {
        public override AWindow CreateAWindow(Transform container)
        {
            AWindow window = (windowPool ?? PoolMgr.Ins.GetAWindowPool<A>(windowAssetPath)).Pop();
            window.SetParent(container);
           RectTransform rect= window.GameObject.transform as RectTransform;
            RectTransform faterRect = container as RectTransform;

            Debug.Log($"sizeDelta x:{faterRect.sizeDelta.x}  y:{faterRect.sizeDelta.y}");
            Debug.Log($"anchoredPosition x:{faterRect.anchoredPosition.x}   y{faterRect.anchoredPosition.y}" );
            rect.sizeDelta = faterRect.sizeDelta;
            rect.anchoredPosition = faterRect.anchoredPosition;


            return window;
        }
        public RoleItemCantainerType(string windowAssetPath,
          Action<S, A, IStore, P> fillProps,
          Func<A, List<Transform>> containerCreator = null,
          Func<S, List<List<WindowNode>>> childNodeCreator = null,
          PoolType<A> windowPool = null) : base(windowAssetPath, fillProps, containerCreator, childNodeCreator, windowPool)
        {

        }


    }
}