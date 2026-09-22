using UnityEngine;

namespace RiseOn.Propositions {
    public class PropositionFormulaComp : PropositionComp {
        [SerializeField]
        private PropositionFormula formula;
        
        public override bool Evaluate() {
            return formula.Evaluate();
        }
    }
}