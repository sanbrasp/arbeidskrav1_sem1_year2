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
- [Task 6 - Video](Task6_Video)  
(included in submission ZIP, not in repo)

See each project's own README for task specifics.

_Readme's:  
[Task 1 README](Task1_LinearAndBinarySearch/README.md)  
[Task 2 README](Task2_CustomGenericDataStructure/README.md)  
[Task 3 README](Task3_DivideAndConquer/README.md)  
[Task 4 README](Task4_GraphAndBFS/README.md)  
[Task 5 README](Task5_DFSAndComparison/README.md)  
[Task 6 README](Task6_Video/README.md)_

_Commit History:_  
[Commit History Document](Docs/CommitHistory.md)
 
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

**Task 2 Tests**  
  - [CustomStack Tests](Arbeidskrav1_year2_sem1.Tests/CustomStackTests.cs)

**Task 3 Tests**  
  - [MergeSort Tests](Arbeidskrav1_year2_sem1.Tests/MergeSortTests.cs)

**Task 4 Tests**
  - [BFS Tests](Arbeidskrav1_year2_sem1.Tests/BfsTests.cs)

**Task 5 Tests**
  - [DFS Tests](Arbeidskrav1_year2_sem1.Tests/DfsTests.cs)

---


## AI Use
- Documented [here](Docs/AIUse.md)

---

