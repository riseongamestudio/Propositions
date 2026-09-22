using System;
using Sirenix.OdinInspector;

namespace RiseOn.Propositions {
    [Serializable, TypeRegistryItem("False")]
    public class PropositionFalse : Proposition {
        public override bool Evaluate() {
            return false;
        }
    }
}