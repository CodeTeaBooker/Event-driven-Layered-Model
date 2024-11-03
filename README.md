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
6. [License](#license)
7. [Community Support](#community-support)

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

## License

Licensed under the MIT License. For full details, see the `LICENSE` file in the repository.

---

## Community Support

- **Issues**: Submit bugs or suggestions via GitHub Issues.
- **Contributions**: Refer to `CONTRIBUTING.md` for guidelines.

---