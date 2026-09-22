using RiseOn.Utils;

namespace RiseOn.Propositions {
    public abstract class PropositionComp : MonoBehaviourExt, IProposition {
        public abstract bool Evaluate();
    }
}