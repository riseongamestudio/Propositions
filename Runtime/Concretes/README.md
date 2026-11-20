# Mệnh đề có sẵn

[← RiseOn.Propositions](../../README.md)

| Mệnh đề | Nhãn trong ô chọn type | Việc |
|---|---|---|
| `PropositionFormula` | Formula | Một phép nối (`connective`) áp lên danh sách `operands` |
| `PropositionNot` | Not | Đảo kết quả của một mệnh đề |
| `PropositionTrue`, `PropositionFalse` | True, False | Hằng |
| `PropositionExternal` | External | Lấy kết quả của một `UnityEngine.Object` cài `IProposition`, qua `source` kiểu `SerObject<IProposition>`: thường là `PropositionComp` hay `PropositionSO` |

## Formula và phép nối

| Phép nối | Nhãn | Đúng khi |
|---|---|---|
| `ConnectiveAnd` | And | Mọi operand đúng |
| `ConnectiveOr` | Or | Có ít nhất một operand đúng |
| `ConnectiveAtLeast` | At Least | Ít nhất `count` operand đúng (`count` mặc định 1) |
| `ConnectiveAtMost` | At Most | Nhiều nhất `count` operand đúng |

Danh sách rỗng: `And` đúng, `Or` sai, `AtLeast(0)` đúng, `AtMost` luôn đúng.

### Dừng sớm

`And` dừng ở operand sai đầu tiên, `Or` ở operand đúng đầu tiên, `AtLeast` khi đã đủ
`count`, `AtMost` khi đã vượt `count`. Hai hệ quả:

- Operand phía sau có thể không được evaluate, nên một operand trống chỉ văng lỗi
  khi tới lượt nó. Test đủ nhánh.
- Mệnh đề phải là truy vấn thuần: không đổi trạng thái, không dựa vào việc mình
  được gọi.

## Dùng chung một mệnh đề

| Lớp | Việc |
|---|---|
| `PropositionComp` | Component trong scene giữ một mệnh đề bất kỳ |
| `PropositionSO` | Asset giữ một mệnh đề bất kỳ, tạo từ *Create → RiseOn → Propositions* |

Nối chúng vào cây của chỗ khác bằng `PropositionExternal`.
