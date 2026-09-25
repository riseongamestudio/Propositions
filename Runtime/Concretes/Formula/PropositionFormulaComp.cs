using Sirenix.OdinInspector;
using UnityEngine;

namespace RiseOn.Propositions {
    [HideMonoScript]
    public class PropositionFormulaComp : PropositionComp {
        [SerializeField, HideLabel]
        private PropositionFormula formula;
        
        public override bool Evaluate() {
            return formula.Evaluate();
        }
    }
}