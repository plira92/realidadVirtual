using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceAnimator : MonoBehaviour
{

    List<Animator> m_animators;

    // Start is called before the first frame update
    void Start()
    {
        m_animators = new List<Animator>(GetComponentsInChildren<Animator>());

        StartCoroutine(DoAnimation());
    }

    IEnumerator DoAnimation(){
        while(true){
            foreach (var animator in m_animators)
            {
                animator.SetTrigger("DoAnimation");
                yield return new WaitForSeconds(2f);
            }
        }

    }

}
