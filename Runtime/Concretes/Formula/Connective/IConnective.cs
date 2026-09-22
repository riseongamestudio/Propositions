using System.Collections.Generic;

namespace RiseOn.Propositions {
    public interface IConnective {
        bool Evaluate(IReadOnlyList<IProposition> operands);
    }
}