using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour 
{
    [SerializeField]
    int lockRange;
    [SerializeField]
    LayerMask lockMask;
    Ilockable target;
    [SerializeField]
    Transform playerTransform;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (target != null && target.isFocusable)
        {
            playerTransform.LookAt(target.focusPoint);
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(target != null)
            {
                target = null;
            }
            else
            {
                GetIlockables();
                if (resultTemp.Count == 0) return;
                target = resultTemp[0];
                Debug.Log("focus on target" + target.focusPoint.name);
            }
            
        }
    }
    //premet de rendre focusable les ennemis en fonction de leur distance
    List<Ilockable> GetIlockables()
    {
        resultTemp.Clear();
        Collider[] hitEnemis = Physics.OverlapSphere(transform.position, lockRange, lockMask);
        foreach (Collider col in hitEnemis)
        {
            Ilockable ilockable = col.gameObject.GetComponent<Ilockable>();
            if(ilockable == null)
            {
                continue;//"return" sort de la fonction, "continue" passe à l'élément suivant
            }
            resultTemp.Add(ilockable);
        }
        return resultTemp;
    }
    List<Ilockable> resultTemp = new List<Ilockable>();
}

public interface Ilockable
{
    Transform focusPoint
    {
        get;
    }
    bool isFocusable
    {
        get;
    }

    void OnFocus();
    void OnUnFocus();
}