using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;

namespace RiseOn.Propositions {
    [Serializable, TypeRegistryItem("And")]
    public class ConnectiveAnd : IConnective {
        public bool Evaluate(IReadOnlyList<IProposition> operands) {
            return operands.All(static operand => operand.Evaluate());
        }
    }
}