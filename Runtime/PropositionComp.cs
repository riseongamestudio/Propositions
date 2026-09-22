using UnityEngine;

namespace RiseOn.Propositions {
    public abstract class PropositionComp : MonoBehaviour, IProposition {
        public abstract bool Evaluate();
    }
}