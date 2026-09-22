using UnityEngine;

namespace RiseOn.Propositions {
    [CreateAssetMenu(menuName = ASSET_MENU_PATH + nameof(PropositionFormulaSO))]
    public class PropositionFormulaSO : PropositionSO {
        [SerializeField]
        private PropositionFormula formula;
        
        public override bool Evaluate() {
            return formula.Evaluate();
        }
    }
}