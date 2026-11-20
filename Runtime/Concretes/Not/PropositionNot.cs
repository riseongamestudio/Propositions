using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RiseOn.Propositions {
    [Serializable, TypeRegistryItem("Not")]
    public class PropositionNot : Proposition {
        [SerializeReference, Required]
        private IProposition proposition;

        public override bool Evaluate() {
            return !proposition.Evaluate();
        }
    }
}