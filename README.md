# ELM Framework Documentation

&#x20;

## Overview

**ELM (Event-driven Layered Model)** is a lightweight architectural framework for Unity applications. Based on a ScriptableObject event system, it implements a layered architecture pattern that helps developers build maintainable, testable, and scalable Unity applications.

- **Four-Layer Architecture**: Separates UI, event mediation, services, and data access.
- **Event-driven Communication**: Decouples communication using a ScriptableObject-based event system.
- **Modular Design**: Shared functionality modules for easy reusability across projects.

## Table of Contents

1. [Installation](#installation)
2. [Quick Start](#quick-start)
3. [Architecture Overview](#architecture-overview)
4. [Core Features](#core-features)
5. [Framework Advantages](#framework-advantages)
6. [Getting Started](#getting-started)
7. [License](#license)

## Installation

To start using the ELM Framework in your Unity project:

1. **Clone or Download**: Clone this repository or download it as a ZIP file.
2. **Import to Unity**: Open Unity (2020.3 or higher) and import the ELM folder into your project.

```bash
# Clone repository
git clone https://github.com/yourusername/ELM-Framework.git
```

## Quick Start

Here's a quick "Hello World" example to get you started with the ELM framework:

1. Create a **ScriptableObject Event Channel** to trigger actions between layers.
2. Implement a **Service** that performs core logic.
3. Bind a **UI Component** to invoke the event.

Example code snippet for an Event Channel:

```csharp
[CreateAssetMenu(menuName = "Events/IntEventChannel")]
public class IntEventChannel : ScriptableObject
{
    public UnityAction<int> OnEventRaised;

    public void RaiseEvent(int value)
    {
        OnEventRaised?.Invoke(value);
    }
}
```

## Architecture Overview

ELM follows a four-layer architecture:

1. **User Interface Layer**: Handles user interaction and visuals.
2. **Event Mediation Layer**: Manages communication between layers via event channels.
3. **Service Layer**: Contains the core business logic.
4. **Data Access Layer**: Manages data persistence and retrieval.

Each application is structured using these four layers, providing clear separation of responsibilities.

### Shared Modules

- **Integration Modules**: For third-party services.
- **Common Libraries**: Utility libraries shared across applications.
- **Shared Functionality Modules**: Common, reusable modules.

<div align="center">
  <img src="Event-driven_Layered_Model.svg" alt="ELM Framework Architecture">
</div>

## Core Features

- **Event System**: Type-safe event channels for decoupled communication.
- **Four-Layer Design**: UI, Event Mediation, Service, and Data Access layers.
- **Modular Design**: Reusable components, integration modules, and shared functionality.
- **Dependency Injection**: Enhances testability, and supports async/await operations.

## Framework Advantages

1. **Maintainability and Testability**: Strict layer separation reduces coupling, and dependency injection and separation of business logic make unit testing straightforward.
2. **Extensibility**: Modular architecture with highly reusable components makes it easy to extend functionalities.
3. **Developer-Friendly**: Visual event connections, deep Unity integration, and support for Test-Driven Development (TDD) improve development experience.

## Getting Started

### Suitable Scenarios

- Medium to large Unity projects. Smaller projects may not benefit as much from the ELM framework, as its complexity may be unnecessary.
- Teams seeking a clear architectural structure.
- Applications with complex business logic and high maintainability requirements.

### Folder Structure

- **Scripts/**: Contains all core logic scripts, separated by layers.
- **Events/**: ScriptableObject event channels.
- **UI/**: UI components and prefab references.

### Example Project

- A sample project is included to demonstrate best practices and provide common use case implementations.

## License

The ELM framework is open source and licensed under the MIT License. Feel free to use it in your personal or commercial projects.

## Community Support

- **Issues**: Report bugs or suggest features via GitHub Issues.
- **Contributing**: Contributions are welcome! Please refer to `CONTRIBUTING.md` for details.
- **Documentation**: Full API reference and user guides are available in the `docs/` folder.

---

Ready to get started? Clone the repository and explore the example project to see ELM in action!

For any questions or suggestions, please open an issue on GitHub.

