using Sirenix.OdinInspector;
using UnityEngine;

namespace RiseOn.Propositions {
    [CreateAssetMenu(menuName = ASSET_MENU_PATH + nameof(PropositionFormulaSO))]
    public class PropositionFormulaSO : PropositionSO {
        [SerializeField, HideLabel]
        private PropositionFormula formula;
        
        public override bool Evaluate() {
            return formula.Evaluate();
        }
    }
}