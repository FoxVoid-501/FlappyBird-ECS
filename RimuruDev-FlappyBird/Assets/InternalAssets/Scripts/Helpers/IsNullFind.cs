using UnityEngine;

namespace RimuruDev.Helpers
{
    public static class IsNullFind<T> where T : MonoBehaviour
    {
        public static T Find(ref T ckeckObj, Component component)
        {
            if (ckeckObj == null)
            {
                ckeckObj = component.GetComponent<T>();

                if (ckeckObj == null)
                    return ckeckObj = GameObject.FindObjectOfType<T>();

                return ckeckObj;
            }

            Debug.Log($"Type({ckeckObj})::Component({component}) == null!");

            return default;
        }

        //public static T Find(ref T ckeckObj)
        //{
        //    var thisComponent = ckeckObj.gameObject;

        //    if (ckeckObj == null)
        //    {
        //        ckeckObj = thisComponent.GetComponent<T>();

        //        if (ckeckObj == null)
        //            return ckeckObj = GameObject.FindObjectOfType<T>();

        //        return ckeckObj;
        //    }

        //    Debug.Log($"Type({ckeckObj})::Component({thisComponent}) == null!");

        //    return default;
        //}
    }
}