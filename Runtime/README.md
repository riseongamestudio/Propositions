# Lớp nền và luật khi mở rộng

[← RiseOn.Propositions](../README.md)

## Lớp nền

| Lớp | Việc |
|---|---|
| `IProposition` | Chỉ có `bool Evaluate()` |
| `Proposition` | Base cho mệnh đề lưu inline (`[Serializable]`, dùng qua `[SerializeReference]`) |
| `PropositionComp` | Base cho mệnh đề là component trong scene, kế thừa `MonoBehaviour` |
| `PropositionSO` | Base cho mệnh đề là asset, kế thừa `ScriptableObject`; `ASSET_MENU_PATH` là `RiseOn/Propositions/` |

Field nhận một mệnh đề: `[SerializeReference] IProposition` hoặc
`SerRef<IProposition>`. Nhận nhiều: `ListSerRef<IProposition>`, không dùng
`[SerializeReference] List<IProposition>` (lý do ở
[SerRef](https://github.com/riseongamestudio/Serializables/blob/v1.0.0/Runtime/SerRef/README.md#vì-sao-dùng-listserreft)).

## Mở rộng

- **Mệnh đề lá**: kế thừa `Proposition`, gắn `[Serializable]` và
  `[TypeRegistryItem("Tên")]` cho nhãn gọn trong ô chọn type.
- **Phép nối**: cài `IConnective` (`bool Evaluate(IReadOnlyList<IProposition>)`),
  cũng `[Serializable]`.
- **Bản Comp / SO cho mệnh đề khác**: kế thừa `PropositionComp` / `PropositionSO`
  và bọc một field của mệnh đề đó, như `PropositionFormulaComp`.

## Luật

Những điều không suy ra được từ việc đọc từng file.

### `[Serializable]` phải nằm trên từng lớp cụ thể

Attribute này không kế thừa. Thiếu nó thì hậu quả tuỳ chỗ chứa:

- Sau `[SerializeReference]`: Unity vẫn lưu, nhưng ghi warning mỗi lần serialize.
- Trong field `[SerializeField]` thường, như `PropositionFormula` bên trong
  `PropositionFormulaComp` / `PropositionFormulaSO`: field đó **không được lưu**, và
  không có báo gì.

Kể cả lớp rỗng chỉ để đóng một generic, kiểu `HasItem : HasItem<ItemId>`.

### Luật chung của `[SerializeReference]`

Mệnh đề được lưu bằng `[SerializeReference]`, nên theo đủ các luật ở
[SerRef](https://github.com/riseongamestudio/Serializables/blob/v1.0.0/Runtime/SerRef/README.md#luật-của-serializereference):

- Đổi tên lớp, namespace hay assembly là mất dữ liệu đã lưu, trừ khi gắn
  `[MovedFrom]`. Đổi nhãn `[TypeRegistryItem]` thì thoải mái.
- Nhân bản một phần tử tạo hai ô chung một instance.
- Lồng sâu không bị cắt ở 10 tầng.

### Thiếu field bắt buộc thì văng lúc `Evaluate`, cố ý

Không chỗ nào kiểm null. `connective` trống, operand trống, `Not` hay `External`
trống đều `NullReferenceException` ngay khi được evaluate. `External` trỏ vào object
không cài `IProposition` cũng vậy, vì `SerObject.Value` trả null. Cố ý để lỗi cấu
hình lộ ra thay vì âm thầm thành true hay false. `[Required]` chỉ tô đỏ trong
Inspector, lúc chạy không chặn gì.

### Mệnh đề phải là truy vấn thuần

Các phép nối dừng sớm ([Concretes](Concretes/README.md#dừng-sớm)), nên một mệnh đề
có thể không được gọi. Mệnh đề không được đổi trạng thái, cũng không được dựa vào
việc mình được gọi.
