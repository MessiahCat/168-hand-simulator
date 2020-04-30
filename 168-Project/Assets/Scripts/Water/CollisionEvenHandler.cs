using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
[RequireComponent(typeof(ObiSolver))]
public class CollisionEvenHandler : MonoBehaviour
{
    // Start is called before the first frame update
    ObiSolver solver;

    [SerializeField]
    public Collider killer;

    void Awake()
    {
        solver = GetComponent<Obi.ObiSolver>();
    }

    void OnEnable()
    {
        solver.OnCollision += Solver_OnCollision;
    }

    void OnDisable()
    {
        solver.OnCollision -= Solver_OnCollision;
    }

    void Solver_OnCollision(object sender, Obi.ObiSolver.ObiCollisionEventArgs e)
    {
        for (int i = 0; i < e.contacts.Count; ++i)
        {
            if (e.contacts[i].distance < 0.001f)
            {

                Component collider;
                if (ObiCollider.idToCollider.TryGetValue(e.contacts[i].other, out collider))
                {

                    if (collider == killer)
                    {

                        ObiSolver.ParticleInActor pa = solver.particleToActor[e.contacts[i].particle];
                        ObiEmitter emitter = pa.actor as ObiEmitter;

                        if (emitter != null)
                            emitter.life[pa.indexInActor] = 0;

                    }
                }
            }
        }
    }
}
