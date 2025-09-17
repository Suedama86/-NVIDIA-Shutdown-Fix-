# NVIDIA Shutdown Fix

This utility disables NVIDIA telemetry and display services to prevent TDR (Timeout Detection and Recovery) errors during shutdown in Windows virtual machines (VMs) with GPU passthrough. It cleanly stops services, sets them to disabled, and logs actions—all fully automated.

---

## Features
- Stops NVIDIA telemetry and display container services.
- Sets their startup type to **Disabled**, preventing them from restarting on boot.
- Logs all actions performed.
- Runs silently and requires no user interaction.
- Automatically requests administrator privileges via manifest.

---

## Purpose
This utility addresses an issue where NVIDIA services cause driver timeout errors (TDR) during shutdown in Windows 11 virtual machines using full GPU passthrough (e.g., KVM/QEMU). By disabling these non-essential services, you can:

- Prevent Event ID 153 errors.
- Ensure smoother shutdown operations.

---

## Why It Matters
Many users running Windows as a guest OS in virtualized environments experience issues caused by NVIDIA services attempting to release resources during shutdown. These errors can lead to instability and unnecessary logs.

---

## Safe for Gamers and Everyday Users
Disabling these services does not impact:
- Gaming performance.
- Graphics rendering.
- Core driver functionality.

However, features like GeForce Experience, ShadowPlay, or automatic updates may be limited. This trade-off ensures a stable and error-free shutdown process in virtualized environments.

---

## 🔍 VirusTotal Scan Result
[View VirusTotal Scan Result](https://www.virustotal.com/gui/file/364f83c1be3d733a81963229c175ec6321b69b2a2f8a7d50949614c5b19dc588) — verified clean and safe to run.