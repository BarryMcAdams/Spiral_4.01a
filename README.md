  # Spiral_4.01a AutoCAD Plug-in

  CadcoLabs.com creates spiral staircases in AutoCAD 2024/2025 with center pole duplication.

  ## Requirements
  - AutoCAD 2024 or 2025 (64-bit, Windows 10/11).
  - AutoCAD VBA Enabler (~58 MB, free) for VBA script execution.
  - Download from: [Autodesk VBA Module](https://www.autodesk.com/support/technical/article/caas/tsarticles/ts/3kxk0RyvfWTfSfAIrcmsLQ.html)
  - Install: Run the EXE, unzip, follow prompts (admin rights required).

  ## Installation
  1. Copy `Spiral_4.01a.dll` and `Spiral_v4.01f.dvb` to `C:\AutoCADPlugins\`.
  2. In AutoCAD, run `NETLOAD` and select `Spiral_4.01a.dll`.
  3. Run `CREATESPIRAL` and enter parameters (e.g., center pole diameter: 6, height: 144, outside diameter: 60, rotation: 450).

  ## Features
  - Generates spiral staircase with center pole, treads, landings, and data text.
  - Duplicates the center pole in-place for post-creation testing.
  - Exports staircase details to CSV (`C:\Users\<YourUsername>\Desktop\SpiralStaircaseDetails.csv`).

  ## Support
  - Contact: [info@CADcoLabs.com]