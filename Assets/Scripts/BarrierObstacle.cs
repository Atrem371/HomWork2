using UnityEngine;

public class BarrierObstacle : MonoBehaviour {
    [SerializeField] private Animator animator;

    public void Hit() {
        animator.SetTrigger("IsHit");
    }
}

