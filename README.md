# ELM Framework
![ELM Framework Architecture](Event-driven_Layered_Model.svg)
## Overview

ELM (Event-driven Layered Model) is a lightweight architectural framework designed specifically for Unity applications. Based on a ScriptableObject event system, it implements a layered architecture pattern that helps developers build maintainable, testable, and scalable Unity applications.

## Core Features

ELM provides Unity developers with a suite of efficient tools and methodologies to simplify the development process and enhance application maintainability and scalability.

### Event-Driven Architecture

- Event system based on ScriptableObject
- Decoupled communication between layers
- Type-safe event channels
- Visual event connections within the Unity Editor

### Four-Layer Architecture Design

- **User Interface Layer**: Handles user interactions and display
- **Event Mediation Layer**: Manages cross-layer communication
- **Service Layer**: Contains core business logic
- **Data Access Layer**: Handles data persistence and access

### Modular Design

- Shared functional modules across applications
- Integration modules for third-party services
- Common tools and extension methods
- Reusable components based on Prefabs

### Developer-Friendly

- Clear separation of concerns
- Visual event connection mechanisms
- Comprehensive testing support
- Deep integration with Unity

## Technical Highlights

- Utilize Unity's ScriptableObject for visual event configuration
- Intuitively connect UI and services within the Unity Editor
- Support dependency injection to enhance testability
- Service layer supports async/await asynchronous operations
- Comprehensive unit testing capabilities
- Adheres to clean architecture principles

## Framework Advantages

### Enhances Maintainability and Testability

- Clear architectural boundaries
- Explicit separation of responsibilities
- Reduced coupling between components
- Standardized event communication
- Independent business logic
- Supports Test-Driven Development (TDD)
- Easy to write unit tests
- Testable service layer

### Excellent Extensibility

- Modular architecture
- Highly reusable components
- Easy to extend functionalities
- Flexible event system

### Supports Team Collaboration

- Clear division of responsibilities
- Standardized communication patterns
- Unified project structure
- Visual component connections for better understanding

## Suitable Scenarios

- Medium to large Unity projects
- Teams needing clear architectural guidance
- Applications with complex business logic
- Projects emphasizing code quality and maintainability
- Applications requiring high testability

## Environment Requirements

- Unity 2020.3 or higher
- Basic knowledge of C# and Unity development
- Understanding of event-driven architecture concepts

## Getting Started Quickly

The ELM framework can be easily integrated into new and existing Unity projects, providing:

1. **Clear Project Structure**
   - Preset folder structures
   - Standardized naming conventions
   - Modular organization

2. **Comprehensive Examples**
   - Basic functionality demonstrations
   - Best practice showcases
   - Implementations of common use cases

3. **Detailed Documentation**
   - Architectural explanations
   - API references
   - User guides
   - Test examples

## Core Functionality

### Event System

- Type-safe event channels
- Visual event connections
- Runtime event monitoring

### Service Layer

- Encapsulation of business logic
- Support for dependency injection
- Support for asynchronous operations

### Data Layer

- Abstraction of data access
- Data persistence support
- Caching mechanisms

### UI Layer

- Separation of UI logic from business logic
- Event-driven UI updates
- Reusable UI components

## Open Source License

The ELM framework is licensed under the MIT License and is freely available for personal and commercial projects.

## Community Support

- Issue tracking via GitHub Issues
- Regularly updated example projects
- Continuously maintained technical documentation
- Clear version update plans

---

The ELM framework seamlessly combines event-driven architecture with Unity development, providing a solid foundation for building scalable applications. With its visual event system and clear layered architecture, it significantly enhances development efficiency and code quality. Emphasizing maintainability, testability, and adherence to clean architecture principles, the framework is an ideal choice for teams building professional-grade Unity applications.
