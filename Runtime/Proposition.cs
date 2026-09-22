using System;

namespace RiseOn.Propositions {
    [Serializable]
    public abstract class Proposition : IProposition {
        public abstract bool Evaluate();
    }
}