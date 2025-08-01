# 🎮 Game Arcade Plinko dengan Kontrol Tombol ESP32

Proyek ini merupakan permainan **Plinko (gaya Pachinko)** interaktif yang dibuat menggunakan **Unity**, dikontrol menggunakan **ESP32** melalui tombol fisik dan komunikasi **serial**. Pemain dapat memilih posisi bola (kiri/kanan) sebelum dijatuhkan dan dapat menekan tombol SPACE untuk mempercepat transisi ke scene berikutnya.

---

## 🧩 Deskripsi Proyek

Game ini menggabungkan komponen **hardware** dan **software** untuk menciptakan pengalaman arcade interaktif:

- Pemain menekan tombol fisik (LEFT / RIGHT) untuk memilih posisi bola sebelum dijatuhkan.
- Jika bola jatuh ke slot kemenangan, akan muncul **panel kemenangan**.
- Countdown 15 detik akan dimulai secara otomatis, lalu berpindah ke scene **Registrasi**.
- Pemain juga bisa menekan tombol **SPACE** (push button) untuk skip countdown dan langsung berpindah scene.

---

## 🔌 Rangkaian & Pin ESP32

| Komponen      | Pin ESP32 |
|---------------|-----------|
| Tombol Kiri   | GPIO 25   |
| Tombol Kanan  | GPIO 33   |
| Tombol SPACE  | GPIO 27   |
| LED (opsional)| GPIO 2    |

---

## ⚙️ Spesifikasi Teknis

- **Board**: ESP32 DOIT DevKit V1
- **Komunikasi Serial**: Baud rate `115200`
- **Protokol**: `"LEFT"`, `"RIGHT"`, dan `"SPACE"` dikirim ke Unity
- **Unity** menerima input dan menjalankan logika permainan berdasarkan data serial

---

## 💻 Software yang Digunakan

- Unity 2022.x (untuk game)
- Arduino IDE (untuk pemrograman ESP32)
- ArduinoJson (opsional, jika ingin struktur JSON)
- Komunikasi serial via `SerialPort` di C#

---
