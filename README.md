# -NVIDIA-Shutdown-Fix-
Disables NVIDIA telemetry and display services to prevent TDR errors during shutdown in Windows VMs with GPU passthrough. Stops services, sets them to disabled, and logs actions—fully automated and safe for gaming.
   
* NVIDIA Service Shutdown Fix for Windows VMs with GPU Passthrough
Purpose:
This utility cleanly disables two non-essential NVIDIA services —  and  — to prevent driver timeout errors (TDR) during shutdown in Windows 11 virtual machines using full GPU passthrough (e.g. via Proxmox).
Why it matters:
Many users running Windows as a guest OS in virtualized environments experience Event ID 153 errors from , especially during shutdown. These errors are caused by NVIDIA services attempting to release GPU control in ways that conflict with passthrough configurations. This fix prevents those errors by stopping and disabling the services before they can interfere.

* What this tool does
• 	Stops NVIDIA telemetry and display container services
• 	Sets their startup type to Disabled, preventing them from restarting on boot
• 	Logs all actions to 
• 	Runs silently and requires no user interaction
• 	Automatically requests administrator privileges via manifest

* Safe for gamers and everyday users
Disabling these services does not affect gaming performance, graphics rendering, or core driver functionality. Features like GeForce Experience, ShadowPlay, or automatic updates may be limited — but for VM users focused on stability and passthrough integrity, this tradeoff is often preferred.
