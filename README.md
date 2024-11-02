# ELM Framework Documentation

&#x20;

## Overview

**ELM (Event-driven Layered Model)** is a lightweight architectural framework designed to enhance the development of Unity applications. By leveraging a ScriptableObject-based event system, ELM introduces a structured, modular approach that improves maintainability, testability, and scalability across Unity projects.
- **Layered Architecture**: Divides application logic into four distinct layers: UI, event mediation, services, and data access, ensuring a clear separation of responsibilities.
- **Event-Driven Communication**: Uses a ScriptableObject-based event system to enable decoupled communication between layers, simplifying inter-component interactions.
- **Modular Design**: Provides reusable functionality modules, facilitating easy sharing and extension of components across projects.

## Table of Contents

1. [Installation](#installation)
2. [Quick Start](#quick-start)
3. [Architecture Overview](#architecture-overview)
4. [Core Features](#core-features)
5. [Framework Advantages](#framework-advantages)
6. [Getting Started](#getting-started)
7. [License](#license)

## Installation

To start using the ELM Framework, follow these steps to set up the ELM_Example project, which includes a comprehensive set of examples within the main repository.

1. **Clone the Repository**: Clone the Event-driven-Layered-Model repository, which contains the ELM_Example folder as a fully configured Unity project with sample code and assets.
2. **Open the Project in Unity**: Launch Unity (version 2022.3 or higher is required) and open the ELM_Example folder as a project. This project includes examples that demonstrate the core functionalities of the ELM Framework.

```bash
# Clone repository
git clone https://github.com/CodeTeaBooker/Event-driven-Layered-Model.git
```
3. **Explore the Examples**: Inside ELM_Example, you will find organized scripts and assets illustrating best practices and typical use cases for each component within the framework.
### Version Compatibility

The **ELM_Example** project is compatible with Unity version 2022.3 and above.



## Quick Start

Here's a quick "Hello World" example to get you started with the ELM framework:

1. Create a **ScriptableObject Event Channel** to trigger actions between layers.
2. Implement a **Service** that performs core logic.
3. Bind a **UI Component** to invoke the event.

Example code snippet for an Event Channel:

```csharp
using UnityEngine;
namespace ELM_Example.EventSystem
{
    [CreateAssetMenu(fileName = "NewIntEventChannel", menuName = "ELM_Example/EventSystem/IntEventChannel")]
    public class IntEventChannel : EventPublisher<int> { }
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

