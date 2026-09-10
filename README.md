# Arbeidskrav 1
### Advanced Backend Programming

Semester: 1  
Year: 2  
Student: Sandra N. Brattli-Aspvik  

Module 1: Algorithms

---

## Solution Overview
This solution contains tasks 1 - 6, each in their respective projects.
- [Test Suite](Arbeidskrav1_year2_sem1.Tests)
- [Task 1 - Linear and Binary Search](Task1_LinearSearchAndBinarySearch)
- [Task 2 - Custom Generic Data Structure](Task2_CustomGenericDataStructure)
- [Task 3 - Divide And Conquer](Task3_DivideAndConquer)
- [Task 4 - Graph and BFS](Task4_GraphAndBFS)
- [Task 5 - DFS And Comparison to BFS](Task5_DFSAndComparison)
- [Task 6 - Video](Task6_Video) (included in submission ZIP, not in repo)

See each project's own README for task specifics.

---

## Technical Stack

| Component  | Choice          |
|------------|-----------------|
| Framework  | .NET 10         |
| Language   | C#              |
| IDE        | JetBrains Rider |
| Test Suite | xUnit           |


---

## Build and Run
Check .NET version:
```bash
dotnet --version
```
Build project:
```bash
dotnet build
```
Run a specific project (example):
```bash
dotnet run --project Task1_LinearSearchAndBinarySearch
```

---

## Test Overview

[Test Suite xUnit Project containing all tests](Arbeidskrav1_year2_sem1.Tests)

### Contents
**Task 1 Tests**  
 - [LinearSearch Tests](Arbeidskrav1_year2_sem1.Tests/LinearSearchTests.cs)  
 - [BinarySearch Test](Arbeidskrav1_year2_sem1.Tests/BinarySearchTests.cs)  
(_BinarySearchTests include demonstration of instability on unsorted arrays_)  

**Test Cases Task 1**
- `LinearSearch()` and `BinarySearch()` searching task specified arrays for specified targets. Both "Found" and "Not Found".
- `BinarySearch()` on unsorted array, empty array, single element array, target outside of range, duplicate values.
- `LinearSearch()` on empty array, single element array, target outside of range, duplicate values.


**Task 2 Tests**  
  - [CustomStack Tests](Arbeidskrav1_year2_sem1.Tests/CustomStackTests.cs)

**Test Cases Task 2**  
- Normal Use
- Edge Cases
- Data Structure Specific Edge Cases
- Exceptions
- Allowed and disallowed values

**Task 3 Tests**

**Test Cases Task 3**

**Why Test For This**
- To ensure the logic is sound and methods return the expected results

---

## Algorithmic Choices
- Why did I choose "x" instead of "y"
- Trade-offs
- Pros and cons

---

## Results
- Test results
- Outputs from algorithms

---

## Reflection
- What went well?  
- What could've gone better?  
- What did I learn?
- Improvements for next time.

---

## AI Use
- Documented [here](Docs/AIUse.md)

---

