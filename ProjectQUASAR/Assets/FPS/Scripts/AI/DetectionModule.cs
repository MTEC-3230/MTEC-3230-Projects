using System.Linq;
using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.Events;

namespace Unity.FPS.AI
{
    public class DetectionModule : MonoBehaviour
    {
        [Tooltip("The point representing the source of target-detection raycasts for the enemy AI")]
        public Transform DetectionSourcePoint;

        [Tooltip("The max distance at which the enemy can see targets")]
        public float DetectionRange = 20f;

        [Tooltip("The max distance at which the enemy can attack its target")]
        public float AttackRange = 10f;

        [Tooltip("Time before an enemy abandons a known target that it can't see anymore")]
        public float KnownTargetTimeout = 4f;

        [Tooltip("Optional animator for OnShoot animations")]
        public Animator Animator;

        public UnityAction onDetectedTarget;
        public UnityAction onLostTarget;

        //[SerializeField]
        private GameObject m_KnownDetectedTarget;

        public GameObject KnownDetectedTarget
        {
            get
            { return m_KnownDetectedTarget; }
            set
            {
                m_KnownDetectedTarget = value;
            }
        }


        public bool IsTargetInAttackRange { get; private set; }

        public bool IsSeeingTarget { get; private set; }
        public bool HadKnownTarget { get; private set; }

        protected float TimeLastSeenTarget = Mathf.NegativeInfinity;

        ActorsManager m_ActorsManager;

        const string k_AnimAttackParameter = "Attack";
        const string k_AnimOnDamagedParameter = "OnDamaged";

        protected virtual void Start()
        {
            m_ActorsManager = FindObjectOfType<ActorsManager>();
            DebugUtility.HandleErrorIfNullFindObject<ActorsManager, DetectionModule>(m_ActorsManager, this);
        }

        public virtual void HandleTargetDetection(Actor actor, Collider[] selfColliders)
        {
            // Handle known target detection timeout
            /// FIXME
            //if (KnownDetectedTarget && !IsSeeingTarget && (Time.time - TimeLastSeenTarget) > KnownTargetTimeout)
            //{
            //    KnownDetectedTarget = null;
            //}

            // Find the closest visible hostile actor
            float sqrDetectionRange = DetectionRange * DetectionRange;
            IsSeeingTarget = false;
            float closestSqrDistance = Mathf.Infinity;
            foreach (Actor otherActor in m_ActorsManager.Actors)
            {
                if (otherActor.Affiliation != actor.Affiliation)
                {
                    float sqrDistance = (otherActor.transform.position - DetectionSourcePoint.position).sqrMagnitude;
                    if (sqrDistance < sqrDetectionRange && sqrDistance < closestSqrDistance)
                    {
                        // Check for obstructions
                        RaycastHit[] hits = Physics.RaycastAll(DetectionSourcePoint.position,
                            (otherActor.AimPoint.position - DetectionSourcePoint.position).normalized, DetectionRange,
                            -1, QueryTriggerInteraction.Ignore);


                        // Testing
                        //int layer = 9;
                        //int layerMask = 1 << layer;
                        //layerMask = ~layerMask;
                        //layer = -1; 
                        //RaycastHit[] hits = Physics.RaycastAll(DetectionSourcePoint.position, (otherActor.AimPoint.position - DetectionSourcePoint.position).normalized, DetectionRange, layerMask, QueryTriggerInteraction.Ignore);


                        RaycastHit closestValidHit = new RaycastHit();
                        closestValidHit.distance = Mathf.Infinity;
                        bool foundValidHit = false;
                        foreach (var hit in hits)
                        {
                            if (!selfColliders.Contains(hit.collider) && hit.distance < closestValidHit.distance)
                            {
                                closestValidHit = hit;
                                foundValidHit = true;
                            }
                        }

                        if (foundValidHit)
                        {

                            Debug.Log("Found Valid Hit!" + closestValidHit.collider.gameObject.transform.parent.name);

                            Actor hitActor = closestValidHit.collider.GetComponentInParent<Actor>();
                            if(hitActor == null)
                                hitActor = closestValidHit.collider.GetComponentInChildren<Actor>();

                            if (hitActor == null) Debug.Log("No Actor component on hitActor!");

                            if (hitActor == otherActor)
                            {
                                IsSeeingTarget = true;
                                closestSqrDistance = sqrDistance;

                                TimeLastSeenTarget = Time.time;
                                KnownDetectedTarget = otherActor.AimPoint.gameObject;
                                if (hitActor != null) Debug.Log("Found Valid Hit!" + hitActor.gameObject.name + " hit target : " + KnownDetectedTarget.gameObject.name);


                            }
                        }
                    }
                }
            }

            IsTargetInAttackRange = KnownDetectedTarget != null &&
                                    Vector3.Distance(transform.position, KnownDetectedTarget.transform.position) <=
                                    AttackRange;

            // KnownDetectedTarget is null for VRPlayer
            //Debug.Log("IsTargetInAttackRange : " + KnownDetectedTarget + " hit target : " + KnownDetectedTarget.gameObject.name);

            if(KnownDetectedTarget != null) 
                Debug.Log("Found Valid Hit!  " + "KnownDetectedTarget: " + KnownDetectedTarget.gameObject.name + " IsSeeingTarget: " + IsSeeingTarget + " IsTargetInAttackRange: " + IsTargetInAttackRange);

            // Detection events
            if (!HadKnownTarget &&
                KnownDetectedTarget != null)
            {
                Debug.Log("OnDetect");
                OnDetect();
            }

            if (HadKnownTarget &&
                KnownDetectedTarget == null)
            {
                Debug.Log("OnLostTarget");

                OnLostTarget();
            }

            // Remember if we already knew a target (for next frame)
            HadKnownTarget = KnownDetectedTarget != null;
        }

        public virtual void OnLostTarget() => onLostTarget?.Invoke();

        public virtual void OnDetect() => onDetectedTarget?.Invoke();

        public virtual void OnDamaged(GameObject damageSource)
        {
            TimeLastSeenTarget = Time.time;
            KnownDetectedTarget = damageSource;

            if (Animator)
            {
                Animator.SetTrigger(k_AnimOnDamagedParameter);
            }
        }

        public virtual void OnAttack()
        {
            if (Animator)
            {
                Animator.SetTrigger(k_AnimAttackParameter);
            }
        }
    }
}