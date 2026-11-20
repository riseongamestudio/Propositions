# Lịch sử thay đổi

Mọi thay đổi đáng kể của `com.riseon.propositions` được ghi ở đây. Định dạng theo
[Keep a Changelog](https://keepachangelog.com/vi/1.1.0/), đánh số theo
[Semantic Versioning](https://semver.org/lang/vi/).

## [2.0.0] - 2026-11-20

### Đổi

- `PropositionNot.proposition` lưu bằng `[SerializeReference]` trực tiếp thay vì `SerRef<IProposition>`,
  như mọi field giữ một mệnh đề. Dữ liệu `Not` đã lưu không đọc được nữa: trong scene, prefab và asset,
  bỏ một tầng `value:` dưới `proposition:` (`proposition:` → `value:` → `rid:` thành `proposition:` → `rid:`),
  hoặc chọn lại mệnh đề trong Inspector.
- `PropositionComp` và `PropositionSO` thôi là lớp nền trừu tượng: mỗi cái giữ một mệnh đề bất kỳ
  (`[SerializeReference]`), để dùng chung qua `External` mà không phải bọc trong `Formula`.

### Bỏ

- `PropositionFormulaComp`, `PropositionFormulaSO`: thay bằng `PropositionComp`, `PropositionSO`. Component và
  asset cũ mất script; tạo `PropositionComp` hay `PropositionSO` mới rồi dựng lại cây (Formula cũ đặt ở gốc).
- Component hay asset kế thừa `PropositionComp`, `PropositionSO` để tự làm mệnh đề: cài thẳng `IProposition`.

## [1.0.3] - 2026-09-25

### Sửa

- Pack tự dùng Odin nên có assembly `RiseOn.Propositions.Requirements` của riêng nó: thiếu Odin Inspector,
  hoặc thiếu define `ODIN_INSPECTOR` ở nền tảng đang chọn, thì báo một lỗi nói rõ pack này cần Odin.

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
