using System;
using Sirenix.OdinInspector;

namespace RiseOn.Propositions {
    [Serializable, TypeRegistryItem("True")]
    public class PropositionTrue : Proposition {
        public override bool Evaluate() {
            return true;
        }
    }
}