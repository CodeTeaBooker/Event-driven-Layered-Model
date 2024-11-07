# ELM Framework Documentation

## Overview

**ELM (Event-driven Layered Model)** is a lightweight architectural framework designed to enhance the development of Unity applications. By leveraging a ScriptableObject-based event system, ELM introduces a structured, modular approach that improves maintainability, testability, and scalability across Unity projects.

- **Layered Architecture**: Divides application logic into four distinct layers: UI, event mediation, services, and data access, ensuring a clear separation of responsibilities.
- **Event-Driven Communication**: Uses a ScriptableObject-based event system to enable decoupled communication between layers, simplifying inter-component interactions.
- **Modular Design**: Provides reusable functionality modules, facilitating easy sharing and extension of components across projects.

To understand how ELM Framework achieves these goals, let's first look at its architecture design in detail.

---

## Table of Contents

1. [Architecture Overview](#architecture-overview)
2. [Key Benefits](#key-benefits)
3. [Installation](#installation)
4. [Quick Start](#quick-start)
5. [Getting Started](#getting-started)
7. [Project Structure Guidelines](#project-structure-guidelines)
7. [License](#license)
8. [Community Support](#community-support)

---

## Architecture Overview

The ELM Framework is structured as a four-layer architecture to promote separation of concerns, maintainability, and scalability in Unity applications. Each layer has a distinct role, ensuring that code is modular and easily testable.

 <div align="center">
   <img src="Images\Event-driven_Layered_Model.svg" alt="ELM Framework Architecture">
 </div>

### 1. User Interface (UI) Layer

Handles user interactions and displays data, decoupling UI from core logic.

### 2. Event Mediation Layer

Acts as the central communication hub, enabling decoupled communication between UI and services.

### 3. Service Layer

Contains core application logic, allowing unit testing outside Unity's lifecycle.

### 4. Data Access Layer

Manages data persistence, ensuring other layers remain data-agnostic.

---

## Key Benefits

Understanding the layered architecture above, the ELM Framework supports scalable, maintainable, and testable Unity applications with:

1. **Enhanced Maintainability**: Separation of responsibilities across layers reduces coupling, aiding management.
2. **Simplified Testing**: TDD is supported with test-friendly structures, enabling independent testing.
3. **Extensibility**: Modular design allows for easy feature extensions without affecting existing code.
4. **Developer-Friendly Workflow**: Visual configuration of `ScriptableObject` instances in the Unity Editor.
5. **Flexible Integration**: Components can be added or replaced easily with dependency injection and event-driven communication.

---

## Installation

Before implementing your first ELM application, follow these steps to set up the development environment and example project:

1. **Clone the Repository**: Clone the Event-driven-Layered-Model repository, which contains the ELM_Example folder as a fully configured Unity project with sample code and assets.
2. **Open the Project in Unity**: Launch Unity (version 2022.3 or higher is required) and open the ELM_Example folder as a project. This project includes examples that demonstrate the core functionalities of the ELM Framework.

   ```bash
   # Clone repository
   git clone https://github.com/CodeTeaBooker/Event-driven-Layered-Model.git
   ```

3. **Explore the Examples**: Inside ELM_Example, you will find organized scripts and assets illustrating best practices and typical use cases for each component within the framework.

---

## Quick Start

Now that you understand the architecture and benefits of ELM Framework, let's see how these concepts work together in a simple "Hello World" example. This example demonstrates the interaction between different layers using the event system.

The **Service Layer** in this example is composed of two parts: a `ServiceWrapper` and a `Service`, which handle business logic and event publishing.

### Step 1: Create a ScriptableObject Event Channel

This event channel will serve as a communication bridge between layers, allowing components to interact without tight coupling.

- **Create Event Channel in Unity**: In the Unity Editor, navigate to the Project window, right-click, and select **Create > ELM_Example > EventSystem > StringEventChannel**. This will create a new `StringEventChannel` instance without requiring additional code.

  <div align="center">
    <img src="Images\CreateStringEventChannel.png" width="75%" height="auto">
    <p>Figure 1: Creating a new StringEventChannel in Unity</p>
  </div>

- **Organize Assets**: Save the `StringEventChannel` instance in a designated folder, such as **Assets/ScriptableObjects**. Organizing assets helps maintain a structured project layout.

  <div align="center">
    <img src="Images\StringEventChannelSO.png" width="75%" height="auto">
    <p>Figure 2: Organizing assets for easy access</p>
  </div>

```csharp
using UnityEngine;

namespace ELM_Example.EventSystem
{
    [CreateAssetMenu(fileName = "NewStringEventChannel", menuName = "ELM_Example/EventSystem/StringEventChannel")]
    public class StringEventChannel : EventPublisher<string> { }
}
```

> **Note**: The **StringEventChannel** class defines an event channel for passing string data. By inheriting from `EventPublisher<string>`, it allows type-safe, event-driven communication between components.

### Step 2: Implement the Service Layer

The **Service Layer** in ELM is divided into two components: the `ServiceWrapper` and the `Service`. The `ServiceWrapper` acts as an interface to other layers, while the `Service` contains the core logic.

#### HelloWorldService

This class provides core functionality, such as generating the "Hello World" message.

```csharp
public class HelloWorldService
{
    private const string DefaultMessage = "Hello World"; // Default message

    public string GetHelloWorld()
    {
        return DefaultMessage; // Returns "Hello World" message
    }
}
```

#### HelloWorldServiceWrapper

This wrapper class interacts with the `StringEventChannel` to broadcast the message from `HelloWorldService`.

```csharp
using ELM_Example.EventSystem;
using UnityEngine;

public class HelloWorldServiceWrapper : MonoBehaviour
{
    [SerializeField]
    private StringEventChannel _messageChannel; // Reference to event channel
    private HelloWorldService _helloWorldService = new HelloWorldService();

    private void Start()
    {
        PrintHelloWorld();
    }

    private void PrintHelloWorld()
    {
        // Gets "Hello World" message and raises event
        string message = _helloWorldService.GetHelloWorld();
        _messageChannel?.Raise(message);
    }
}
```

> **Example**: In this setup, `HelloWorldService` encapsulates the core logic to generate the message, while `HelloWorldServiceWrapper` uses the `StringEventChannel` to broadcast it to subscribed components.

> **Note**: `HelloWorldService` is designed without inheriting from `MonoBehaviour`, making it easier to unit test independently of Unity's lifecycle, which supports Test-Driven Development (TDD).

### Step 3: Bind a UI Component to the Event

This UI component listens to the `StringEventChannel` and displays the message using `TextMeshProUGUI`.

```csharp
using TMPro;
using UnityEngine;

public class ExampleUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro; // Reference to TextMeshPro component

    public void DisplayMessage(string message)
    {
        // Updates TextMeshPro text with received message
        _textMeshPro.text = message;
    }
}
```

- **Configure ExampleUI in Unity**:

  - **Attach Script**: Attach the `ExampleUI` script to a GameObject, such as an empty GameObject named "ExampleUI".
  - **Link TextMeshPro**: Assign a `TextMeshProUGUI` component (e.g., a `TextMeshPro` UI element) to the `_textMeshPro` field in the Inspector.
  - **Add StringEventListener**: Add a `StringEventListener` component to the GameObject. In the **Unity Event Response** section, link it to `ExampleUI.DisplayMessage` to display the message when the event is raised.

  <div align="center">
    <img src="Images\ExampleUI.png" width="75%" height="auto">
    <p>Figure 3: Configuring ExampleUI with StringEventListener</p>
  </div>

### Step 4: Configure the Service Wrapper

Attach the `HelloWorldServiceWrapper` script to another GameObject (e.g., "PrintHelloWorldServiceWrapper"). In the Inspector, assign the `PrintHelloWorldEventChannel` instance to the `Message Channel` field of the `HelloWorldServiceWrapper`.

<div align="center">
  <img src="Images\HelloWorldServiceWrapper.png" width="75%" height="auto">
  <p>Figure 4: Configuring HelloWorldServiceWrapper with PrintHelloWorldEventChannel</p>
</div>

---

## Getting Started

1. **Clone the Repository**: Clone the repository containing the `ELM_Example` folder.
   ```bash
   git clone https://github.com/CodeTeaBooker/Event-driven-Layered-Model.git
   ```
2. **Open in Unity**: Launch Unity (version 2022.3 or higher) and open `ELM_Example` as a project.

---

## Project Structure Guidelines

The ELM Framework follows a standardized project structure to ensure consistency and maintainability across different Unity projects. This structure aligns with the framework's layered architecture and promotes clear separation of concerns.

### Directory Structure Overview

```
Assets/
├── _Common/                          # Common/Reusable content
├── _Project/                         # Project-specific content
├── _Packages/                        # Third-party packages
├── Resources/                        # Dynamic loading resources
├── StreamingAssets/                  # Streaming media resources
└── ThirdParty/                       # Third-party plugins
```
### Common Content Structure (_Common/)
This directory contains reusable components and framework core functionality:

```
_Common/
├── Runtime/                          # Runtime content
│   ├── Scripts/                      # Common scripts
│   │   ├── Data/                     # Common data definitions
│   │   │   ├── Constants/            # Common constants and enums
│   │   │   └── Custom/               # Common custom data types
│   │   ├── Services/                 # Common service implementations
│   │   ├── ServiceWrappers/          # Common service wrapper implementations
│   │   ├── BaseEventMediators/       # Base event mediator classes
│   │   ├── UI/                       # Common UI scripts
│   │   ├── DataAccess/               # Common data access implementations
│   │   └── Utils/                    # Utility classes and helpers
│   ├── Art/                          # Common art assets
│   │   ├── 3DModels/                 # 3D model assets and related resources
│   │   ├── UI/                       # UI art assets
│   │   └── VFX/                      # Visual effects
│   ├── Audio/                        # Common audio
│   │   ├── Music/                    # Music
│   │   └── SFX/                      # Sound effects
│   ├── Prefabs/                      # Common prefabs
│   │   ├── 3DModels/                 # 3D model prefabs
│   │   ├── UI/                       # UI prefabs
│   │   └── Systems/                  # System prefabs
├── Editor/                           # Editor-only content
│   ├── Scripts/                      # Editor scripts
│   │   ├── Tools/                    # Custom editor tools
│   │   ├── Inspectors/               # Custom inspectors
│   │   └── Windows/                  # Custom editor windows
│   └── Resources/                    # Editor resources
└── Tests/                            # Test content
    ├── Runtime/                      # Tests for Runtime scripts
    └── Editor/                       # Tests for Editor scripts
```

### Project Content Structure (_Project/)
This directory contains project-specific implementations:

```
_Project/
├── Runtime/                          # Runtime content
│   ├── Scripts/                      # Project scripts
│   │   ├── Data/                     # Project-specific data
│   │   │   ├── Constants/            # Project constants and enums
│   │   │   └── Custom/               # Project-specific custom data
│   │   ├── Services/                 # Project-specific services
│   │   ├── ServiceWrappers/          # Project-specific service wrappers
│   │   ├── UI/                       # Project-specific UI implementations
│   │   ├── ExtensionEventMediators/  # Extended event mediators
│   │   └── DataAccess/               # Project-specific data access
│   ├── Art/                          # Project art assets
│   │   ├── 3DModels/                 # 3D model assets and related resources
│   │   ├── UI/                       # UI art assets
│   │   └── VFX/                      # Visual effects
│   ├── Audio/                        # Project audio
│   │   ├── Music/                    # Project-specific music
│   │   └── SFX/                      # Project-specific SFX
│   ├── Prefabs/                      # Project prefabs
│   │   ├── 3DModels/                 # 3D model prefabs
│   │   ├── UI/                       # UI prefabs
│   │   └── Systems/                  # System prefabs
│   └── ScriptableObjects/            # Project configurations
│       ├── EventChannels/            # Event channel instances
│       ├── Configurations/           # Configuration instances
│       └── DataContainers/           # Data container instances
├── Editor/                           # Project editor tools
│   ├── Scripts/                      # Editor scripts
│   └── Resources/                    # Editor resources
├── Tests/                            # Project tests
│   ├── Runtime/                      # Tests for Runtime scripts
│   └── Editor/                       # Tests for Editor scripts
└── Scenes/                           # Scene files

```

### Structure Guidelines

1. **Layer Separation**
   - Each architectural layer has its dedicated folder within the Scripts directory
   - Services and their wrappers are kept separate but related
   - UI scripts and assets are organized in dedicated UI folders

2. **Resource Organization**
   - Art resources are consistently organized across _Common and _Project:
     * 3DModels folder for 3D content and related resources
     * UI folder for interface assets
     * VFX folder for effects
   - Audio files are split between Music and SFX
   - Prefab organization mirrors Art structure with dedicated folders:
     * 3DModels for model prefabs
     * UI for interface prefabs
     * Systems for system prefabs

3. **Testing Structure**
   - Tests mirror the source code structure
   - Each folder in Tests corresponds to the scripts being tested
   - Runtime/Tests contains tests for Runtime/Scripts
   - Editor/Tests contains tests for Editor/Scripts

4. **ScriptableObject Management**
   - Event channels have a dedicated folder
   - Configuration data is centralized
   - Data containers are organized by purpose

5. **Common vs Project Separation**
   - Reusable components go in _Common
   - Project-specific implementations go in _Project
   - Consistent folder structure between both for easy navigation

### Best Practices

1. **Naming Conventions**
   - Use PascalCase for folders containing scripts
   - Use lowercase for resource folders
   - Prefix private folders with underscore (_Common, _Project)

2. **Asset Organization**
   - Group assets by functional modules (3DModels, UI, VFX)
   - Keep all related resources together within their module
   - Maintain consistent structure between Art and Prefabs directories

3. **Version Control Considerations**
   - Consider using Unity packages for shared content
   - Keep large binary files in appropriate streaming assets
   - Organize meta files consistently

### Integration with ELM Framework

This structure directly supports the ELM Framework's architecture by:

1. **Supporting Layered Architecture**
   - Clear separation of UI, Event Mediation, Service, and Data Access layers
   - Easy to identify and maintain layer boundaries
   - Structured support for dependency injection

2. **Enabling Event-Driven Design**
   - Centralized event channel management
   - Clear organization of event mediators
   - Separated event-related configurations

3. **Facilitating Testing**
   - Tests are structured to match source code organization
   - Each component type has its dedicated test location
   - Support for testing both Runtime and Editor scripts

4. **Promoting Modularity**
   - Clear separation of common and project-specific code
   - Organized module structure
   - Easy to identify and manage dependencies

This structure is designed to scale with your project while maintaining the principles and benefits of the ELM Framework.


---


## License

Licensed under the MIT License. For full details, see the `LICENSE` file in the repository.

---

## Community Support

- **Issues**: Submit bugs or suggestions via GitHub Issues.
- **Contributions**: Refer to `CONTRIBUTING.md` for guidelines.

---