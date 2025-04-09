# Cryptify

## Overview
A simple yet elegant file encryption and decryption tool built with the C# .NET Framework and WinForms. It allows users to securely encrypt and decrypt files using different encryption algorithms, including AES, DES, and TripleDES.

   * **Selectable & customizable algorithm**: Choose between AES, DES, or TripleDES to secure your files.
   * **Simple UI**: An easy to navigate and use interface.
   * **Customizable Encryption**: Easily swap out encryption algorithms or extend the application with new methods.
   * **Modular**: For developers, the encryption system is modular and easy to integrate new algorithms into.
   * **Easily Built**: For developers, the encryption system comes with an easy to use batch file to build it automatically.

## Getting Started

### Prerequisites

Before you begin, make sure you have the following installed on your system:

- [Visual Studio 2022](https://visualstudio.microsoft.com/) (or later) with .NET Desktop Development workload.
- .NET 6.0 or higher (for the latest version of WinForms support).

Do note that because WinForms is an abstraction layer over the Windows GDI, it will **not** function, build, or work under Linux.

### Installation

Either install using the [releases](https://github.com/ryanoutcome20/Cryptify/releases/) tab or install directly via:

1. Cloning the repository:
   ```bash
   git clone https://github.com/ryanoutcome20/cryptify.git
   ```
2. Running the build batch file included in the base of the directory.
3. Running the file generated at: `./src/bin/Release/Cryptify.exe`.

### Usage

1. **Choose an Algorithm**: Select one of the algorithms (AES, DES, or TripleDES) from the dropdown menu.

2. **Select a File**: Click the folder icon or drag-and-drop the file(s) you want to encrypt or decrypt.

## Additional Information

### Contributing

Contributions are welcome! If you find a bug or want to add a new feature or algorithm, feel free to fork the repository and submit a pull request.

## License

This project is licensed under the GNU General Public License v3.0 - see the [LICENSE](./LICENSE) file for more details.
