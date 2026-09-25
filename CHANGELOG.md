# Lịch sử thay đổi

Mọi thay đổi đáng kể của `com.riseon.propositions` được ghi ở đây. Định dạng theo
[Keep a Changelog](https://keepachangelog.com/vi/1.1.0/), đánh số theo
[Semantic Versioning](https://semver.org/lang/vi/).

## [1.0.2] - 2026-09-25

### Sửa

- Các assembly dùng Odin có thêm `defineConstraints: ODIN_INSPECTOR`: thiếu Odin thì chúng
  được bỏ qua, và lỗi giải thích nằm ở `RiseOn.Utils.Requirements`.
- Phụ thuộc tối thiểu `com.riseon.serializables` 1.0.1.

## [1.0.1] - 2026-09-25

### Sửa

- `PropositionFormulaSO`, `PropositionFormulaComp`: Formula hiện thẳng trong Inspector, không còn nhãn bọc ngoài.
- `PropositionFormulaComp` ẩn ô Script.

## [1.0.0] - 2026-09-23

### Thêm

- `IProposition` và ba dạng lưu `Proposition`, `PropositionComp`, `PropositionSO`.
- Mệnh đề có sẵn: `Formula` (And, Or, AtLeast, AtMost), `Not`, `True`, `False`, `External`.
- `PropositionFormulaComp`, `PropositionFormulaSO` để dùng chung một Formula.
