# RiseOn.Propositions

Mệnh đề logic dựng trong Inspector: `IProposition` chỉ có `Evaluate()`, các mệnh đề
lồng nhau thành cây (`Formula`, `Not`, ...) mà không phải viết code. Pack không
biết gì về game; game tự viết các mệnh đề lá đọc trạng thái của mình.

Package `com.riseon.propositions`, namespace `RiseOn.Propositions`.

## Mục lục

- [Yêu cầu](#yêu-cầu)
- [Cài đặt](#cài-đặt)
- [Tổng quan](#tổng-quan)
- [Hướng dẫn nhanh](#hướng-dẫn-nhanh)
- [Thành phần](#thành-phần)
- [Lịch sử thay đổi](#lịch-sử-thay-đổi)
- [Giấy phép](#giấy-phép)

## Yêu cầu

| Phụ thuộc | Cách có | Dùng cho |
|---|---|---|
| Unity 6000.3 | | Bản đang dùng để phát triển |
| [`com.riseon.utils`](https://github.com/riseongamestudio/Utils/tree/main/Core#readme) 1.0.0 | Tự cài theo `package.json` của Serializables | `com.riseon.serializables` cần |
| [`com.riseon.serializables`](https://github.com/riseongamestudio/Serializables#readme) 1.0.0 | Tự cài theo `package.json` | `SerRef`, `ListSerRef`, `SerObject` |
| [Odin Inspector](https://odininspector.com) | Cài tay từ Asset Store | Ô chọn type cho `[SerializeReference]`, `[TypeRegistryItem]`, `[Required]` |
| [DOTween](https://dotween.demigiant.com) | Cài tay từ Asset Store | `com.riseon.utils` cần |

"Tự cài" là khi cài qua OpenUPM; cài bằng git URL thì phải cài các package RiseOn
kia trước. Odin và DOTween không có trên UPM nên phải cài vào project trước.

## Cài đặt

**OpenUPM** (khuyên dùng): thêm registry OpenUPM với scope `com.riseon` vào
`Packages/manifest.json`, rồi thêm package:

```json
{
  "scopedRegistries": [
    {
      "name": "package.openupm.com",
      "url": "https://package.openupm.com",
      "scopes": ["com.riseon"]
    }
  ],
  "dependencies": {
    "com.riseon.propositions": "1.0.0"
  }
}
```

**Git URL**: cài `com.riseon.utils` và `com.riseon.serializables` trước, rồi
*Package Manager → + → Add package from git URL*:

```
https://github.com/riseongamestudio/Propositions.git#v1.0.0
```

**Thư mục local**: `"com.riseon.propositions": "file:D:/path/to/Propositions"`.

## Tổng quan

Cùng một interface `IProposition`, ba dạng lưu:

| Dạng | Dùng khi |
|---|---|
| `Proposition` | Mặc định. Lớp `[Serializable]` thường, nằm inline trong field của chủ |
| `PropositionComp` | Nhiều chỗ trong scene dùng chung một mệnh đề |
| `PropositionSO` | Dùng chung giữa các scene. Asset không trỏ được vào object trong scene |

Mệnh đề có sẵn: `Formula` (một phép nối `And`, `Or`, `AtLeast`, `AtMost` trên danh
sách mệnh đề), `Not`, `True`, `False`, và `External` để nối một Comp hay SO vào cây.

## Hướng dẫn nhanh

1. Viết mệnh đề lá đọc trạng thái game:

   ```csharp
   using System;
   using RiseOn.Propositions;
   using Sirenix.OdinInspector;

   [Serializable, TypeRegistryItem("Has Coins")]
   public class HasCoins : Proposition {
       public int amount;
       public override bool Evaluate() => Wallet.Coins >= amount;
   }
   ```

2. Khai field nhận mệnh đề, dựng cây trong Inspector bằng ô chọn type:

   ```csharp
   [SerializeReference] private IProposition unlockCondition;   // hoặc SerRef<IProposition>
   [SerializeField] private ListSerRef<IProposition> conditions; // nhiều mệnh đề

   if (unlockCondition.Evaluate()) { /* ... */ }
   ```

3. Mệnh đề dùng chung: tạo `PropositionFormulaComp` trong scene hoặc
   `PropositionFormulaSO` (menu *Create → RiseOn → Propositions*), rồi trỏ tới nó
   bằng một `External` trong cây.

Lớp mệnh đề nào cũng phải tự gắn `[Serializable]`, và đổi tên lớp là mất dữ liệu đã
lưu: xem [luật khi mở rộng](Runtime/README.md).

## Thành phần

| Thành phần | Việc | Chi tiết |
|---|---|---|
| Lớp nền | `IProposition`, `Proposition`, `PropositionComp`, `PropositionSO`; cách viết mệnh đề và luật lưu | [Runtime](Runtime/README.md) |
| Mệnh đề có sẵn | `Formula` và các phép nối, `Not`, `True`, `False`, `External` | [Runtime/Concretes](Runtime/Concretes/README.md) |

## Lịch sử thay đổi

Xem [CHANGELOG.md](CHANGELOG.md).

## Giấy phép

MIT, xem [LICENSE.md](LICENSE.md).
