# Contributing to ELM Framework

We welcome contributions to the ELM Framework! Whether you're fixing bugs, improving documentation, or proposing new features, your contributions are highly appreciated. This guide will help you understand our development process.

## Table of Contents

1. [Ways to Contribute](#ways-to-contribute)
2. [Development Process](#development-process)
3. [Contribution Guidelines](#contribution-guidelines)
4. [Community Standards](#community-standards)
5. [Getting Help](#getting-help)

## Ways to Contribute

### Reporting Bugs 🐛

When reporting bugs, please create an issue on GitHub with the following information:

**Required Information:**
- Detailed steps to reproduce the bug
- Expected behavior
- Actual behavior
- Environment details:
  - Unity version
  - Operating system
  - ELM Framework version
  - Any relevant project settings

**Example Bug Report:**
```markdown
**Bug:** Event channel not triggering in specific scenario

**Steps to Reproduce:**
1. Create a new StringEventChannel
2. Set up HelloWorldServiceWrapper
3. Configure UI listener
4. Run the scene
5. [Specific action that causes the bug]

**Expected:** Event should trigger and update UI
**Actual:** UI remains unchanged
**Environment:** Unity 2022.3.1f1, Windows 10, ELM Framework v1.2.0
```

### Suggesting Features 💡

Feature suggestions are welcome! When proposing new features:

1. Create an issue with the label `feature request`
2. Include:
   - Clear description of the feature
   - Use cases and benefits
   - Potential implementation approach
   - Impact on existing functionality

### Code Contributions 👨‍💻

## Development Process

### 1. Setting Up Development Environment

1. **Fork the Repository**
   - Visit https://github.com/CodeTeaBooker/Event-driven-Layered-Model
   - Click the "Fork" button to create your own fork

2. **Clone Your Fork**
   ```bash
   # Clone your forked repository
   git clone https://github.com/yourusername/Event-driven-Layered-Model.git
   cd Event-driven-Layered-Model

   # Add the original repository as a remote
   git remote add upstream https://github.com/CodeTeaBooker/Event-driven-Layered-Model.git

   # Create a new branch
   git checkout -b feature/your-feature-name
   ```

### 2. Branch Naming Conventions

Use descriptive branch names following these patterns:
- `feature/description` - For new features
- `fix/issue-number` - For bug fixes
- `docs/description` - For documentation changes
- `refactor/description` - For code refactoring

Examples:
```bash
git checkout -b feature/add-event-validation
git checkout -b fix/issue-123
git checkout -b docs/improve-architecture-section
```

### 3. Coding Standards

#### Style Guidelines
- Follow C# coding conventions
- Use meaningful variable and method names
- Keep methods focused and concise
- Maintain consistent formatting

#### Documentation Requirements
```csharp
/// <summary>
/// Handles the processing of string-based events in the ELM Framework.
/// </summary>
/// <param name="eventData">The string data to be processed</param>
/// <returns>True if the event was successfully processed</returns>
public bool ProcessStringEvent(string eventData)
{
    // Implementation
}
```

#### Testing Requirements
- Write unit tests for new features
- Ensure existing tests pass
- Follow the existing test patterns

## Contribution Guidelines

### Pull Request Process

1. **Before Submitting:**
   - Ensure all tests pass
   - Update documentation if needed
   - Follow coding standards
   - Review your changes

2. **Submitting:**
   ```bash
   git add .
   git commit -m "feat: add event validation system"
   git push origin feature/your-feature-name
   ```

3. **Pull Request Template:**
   ```markdown
   ## Description
   Brief description of changes

   ## Related Issues
   Fixes #123

   ## Type of Change
   - [ ] Bug fix
   - [ ] New feature
   - [ ] Documentation update
   - [ ] Code refactoring

   ## Testing
   - [ ] Added new tests
   - [ ] Existing tests pass
   ```

### Code Review Process

1. Maintainers will review your PR
2. Address any requested changes
3. Once approved, changes will be merged

## Community Standards

### Best Practices
- Check existing issues before creating new ones
- Be respectful and constructive in discussions
- Help others in the community
- Keep discussions focused and productive

### Communication Guidelines
- Use clear and concise language
- Provide context for questions or issues
- Be patient with responses
- Share knowledge and experiences

## Getting Help

- **Questions:** Open a Discussion on GitHub
- **Issues:** Use the issue tracker

---

Thank you for contributing to ELM Framework! Your efforts help make this project better for everyone.