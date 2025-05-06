# ConfigurationTool

## Overview

**ConfigurationTool** is a custom tool developed for quick and easy access to configuration settings. It aims to streamline the process of managing and modifying configuration files, enhancing efficiency for developers and system administrators.

## Features
- 📂 Multi-file configuration support
- 🔄 Automatic reload on file changes
- 🏷 Strongly typed configuration classes
- 🏭 Clean factory pattern access
- 🛡 Built-in error handling
- 🧩 Modular configuration organization

## Getting Started

### Prerequisites

- [.NET Framework](https://dotnet.microsoft.com/) installed on your system
- Compatible operating system (e.g., Windows 10 or later)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/Edahr/ConfigurationTool.git
   ```

2. Navigate to the project directory:

   ```bash
   cd ConfigurationTool
   ```

3. Open the solution file `ConfigurationTool.sln` in Visual Studio.

4. Change the value of `ConfigurationPath` in `appsettings.json` to match the location of your actual configuration file.

5. Build the solution to restore dependencies and compile the application.

### Usage

1. Run the application from Visual Studio or execute the compiled binary.

2. Use the interface to test the dummy `GetConnectionStringSettings` endpoint.

3. The configuration classes were added to the Common Project since that would be refered to by every other project in the solution. 
