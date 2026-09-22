using System;
using RiseOn.Serializables;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RiseOn.Propositions {
    [Serializable, TypeRegistryItem("Formula")]
    public class PropositionFormula : Proposition {
        [SerializeReference, Required]
        private IConnective connective;

        [SerializeField, Required]
        private ListSerRef<IProposition> operands;

        public override bool Evaluate() {
            return connective.Evaluate(operands);
        }
    }
}