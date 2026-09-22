using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;

namespace RiseOn.Propositions {
    [Serializable, TypeRegistryItem("Or")]
    public class ConnectiveOr : IConnective {
        public bool Evaluate(IReadOnlyList<IProposition> operands) {
            return operands.Any(static operand => operand.Evaluate());
        }
    }
}