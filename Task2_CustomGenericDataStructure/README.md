# Task 2 - Custom Generic Data Structure

---

## Overview
- [Implementation](#implementation)
- [Tests](#tests)
- [Explanation](#explanation)
  - [Principle](#principle)
  - [Use Cases](#use-cases)
  - [Internal Representation](#internal-representation)
  - [Time Complexity](#complexity)

---

## Implementation

[CustomNode class](Models/CustomNode.cs)  
[CustomStack class](Models/CustomStack.cs)  

**Code implementation**  
`CustomNode<T>` is written as an internal class, following the convention of the rest of the solution.  
It is not `static` because nodes need to be initialized.  
The class is `Generic` so that it can be used by any `type`.  
This is a basic representation of a `node`, that holds a reference to a `Value` and the node's `_next` node.  

The `_next` field is nullable because it represents "what comes after this node". For the bottom of the stack, nothing comes 
"after", in which case `_next is null`. It is a property of an individual node's position.  

The `Value` holds the value of the node. Is not nullable, because a `CustomNode<T>` can only be created through its constructor, 
which requires a real value to be supplied. It is impossible to construct a node that is holding nothing.  
`Next` is encapsulated so that it cannot be manipulated into an invalid state.  
The constructor initializes an object with a `Value` and `_next` set to `null`.
```csharp
namespace Task2_CustomGenericDataStructure.Models;

internal class CustomNode<T>
{
    private CustomNode<T>? _next;
    
    internal T Value { get; }
    
    internal CustomNode<T>? Next
    {
        get => _next;
        set => _next = value;
    }
    
    internal CustomNode(T value)
    {
        Value = value;
        _next = null;
    }
}
```

`CustomStack` is written as an internal class, following the convention of the project.  
It holds a reference to `CustomNode<T>`'s `_top` value so that it can perform its actions.  
`CustomNode<T>? Top` is encapsulated to avoid invalid states, and nullable for when there is nothing at the top (empty).  
The internal bool `IsEmpty` is `true` if `_top` is empty, and allows us to check for that in the methods and tests.  

Method `void Push(T value)` takes a `T` argument.  
It creates a new node for that `value`.  
It then uses the `Next` to see what `value` is up next (and also first).  
It then assigns that value to `_top` (`_top = newNode`)

Method `T Pop()` takes no arguments.  
If first checks whether the `Stack` is empty by using the internal bool `IsEmpty`. If `IsEmpty = true`, it throw 
an `InvalidOperationException` with an error message.  
If the `Stack` is not empty, it continues.  
It creates a variable for storing the value of `_top`.  
It then stores the value of the next node in `var nextNode`, using `node.Next`.  
Then it assigns that value to `_top` (`_top = nextNode`), before returning the `node.Value`.

Method `T Peek()` takes no arguments.  
It first checks whether the `Stack` is empty, using the same logic as `T Pop()`, and throws the 
same exception if `IsEmpty = true`.  
It then simply returns `_top.Value` directly, with no need for storing anything prior.  
It changes nothing, it only reads the value of the top element in the `Stack`, and therefore doesn't need 
to do any other operations than returning the value.

```csharp
using Task2_CustomGenericDataStructure.Models;

namespace Task2_CustomGenericDataStructure.Models;

internal class CustomStack<T>
{
    private CustomNode<T>? _top = null;
    
    internal CustomNode<T>? Top => _top;
    
    internal bool IsEmpty => _top == null;
    
    internal void Push(T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }
        var newNode = new CustomNode<T>(value); // store the node's value in newNode
        newNode.Next = _top; // assign the next value in the currently empty _top
        _top = newNode; // assign newNode to _top
    }
    
    internal T Pop()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        var node = _top;
        var nextNode = node.Next;
        _top = nextNode;
        
        return node.Value;
    }
    
    internal T Peek()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        
        return _top.Value;
    }
}
```

**Choices**  
During the work on this task, it took me a while to understand that I needed a separate `Node` class in order 
to be able to write and demonstrate the `Stack` class.  
For encapsulation and consistency, I opted to follow the rules from Task 1 and use mostly `internal` access modifiers, 
and `private` where nothing looser was needed.  
To allow controlled access, the `test suite` has a reference to the `Task 2` project, and the `Task 2` project 
shows its internals to the `test suite`.

I decided to go with a `node-based` `Stack` for this task, simply because that's the one I find most challenging to understand.  
Choosing this gave me a great opportunity to learn more about something I found difficult to wrap my head around, and during 
the development I have been able to learn a lot more than I would if I had chosen something that seemed simpler to me.  
This was a calculated risk from my end, and what offered the most learning value.

I also opted to use one collective `xUnit` `test suite` for the entire solution.  
The test collections are named in a non-ambiguous way so that they are respectively easy to locate both by file name 
and test names naming convention (`BinarySearchTests`, `CustomNodeTests`, etc).

For method `T Push()` I added a guard clause for null values. This guard clause can only be triggered if `T` is a reference type, 
as value types will not be able to trigger it because they cannot be null by nature. The value `0` is allowed, however.  

I also decided against writing a unit test for the edge case where `Maximum Memory Limit` triggers. It would be impractical 
to add a test that exhausts both my own system and the grader's, so I will note it down in the readme instead.  
The `Max Memory Limit` case happens when the constrained allocated memory runs out during operations, like `Push`.  
If it has no upper bounds, it will keep pushing until there is no more memory left and the system crashes.  
This is a trade-off for the `node-based` design.

---

## Tests
**Test names**  
    - `CustomStack_AllowsValueTypeNode_OfValueZero()`
    - `CustomStack_CatchesInvalidOperationException_OnPeek_WhenStackIsEmpty()`
    - `CustomStack_CatchesInvalidOperationException_OnPop_WhenStackIsEmpty()`
    - `CustomStack_ConfirmsCorrectState_AfterTangledHistory()`
    - `CustomStack_IsEmpty_ReflectsCorrectState_BeforePushing_And_AfterPopping()`
    - `CustomStack_PushFollowedByPeek_ReturnsTheCorrectValue()`
    - `CustomStack_PushFollowedByPop_ConfirmsCorrectLifoOrder()`
    - `CustomStack_ThrowsArgumentNullException_OnPushNull()`

**Tests Run Successfully**  
![img.png](Images/img.png)

**Test cases**  
- Normal use
- Empty structure handling
- LIFO order
- Exception handling
- `IsEmpty` correct state tracking between `Push()` and `Pop()`
- `null` values for reference types handled
- "Tangled" history state (`Push, Push, Pop, Peek, Push, Push, Pop, Peek`)
- Value `0` allowed

**Why**  
These tests are written to ensure the code works as intended, handles edge cases, catches exceptions, 
and allows values that are valid. 

---

## Explanation
### Principle:
  - The `Stack` uses `LIFO`, which means `Last in, first out`. It can be visualized by a stack of pancakes: 
    First the tray is empty. Then you put (`Push`) one pancake on the tray. Then let's say you put (`Push`) another pancake on `top` 
    of the first one. The last pancake is now on `top`. When you want to eat one, you grab (`Pop`) the pancake that is on `top`.  
    If you look (`Peek`) at the tray of pancakes after grabbing one from the `top`, the pancake under the one you grabbed is 
    now on `top` and is the `Next` one up for grabs (`Pop`).  
    The `Stack` works with the opposite order of a `Queue`, where `FIFO` rules (first one in, first one out, like in a line 
    at the grocery store).


### Use Cases:
  - `DFS`, which relies on a `Stack` and `LIFO` ordering for backtracking, and is able to find "all possible paths" by
    using this mechanism, which makes it useful when solving various tasks that have more than one possible path to solution. 
    For example finding every possible move in a game of Chess, or solving a Sudoku puzzle.  


### Internal representation:
`Node Based` (see [Implementation](#implementation) for details)


### Complexity:
  - `void Push()` has Constant Time Complexity, `O(1)`, because every step it performs happens only once with 
    a fixed and unchanging amount of work. It is independent of how many items are already in the stack because it doesn't
    have to do anything about those.
  - `T Pop()` also has Constant Time Complexity, `O(1)`, for the same reason that `Push()` does:  
    every step is fixed and unchanged, it happens exactly once, regardless of the elements in the `Stack`.
  - `T Peek()` follows suit with Constant Time Complexity, `O(1)`, running its steps only once independently of 
    the contents of the `Stack`. It only does a check (once), and returns a value (once).

---