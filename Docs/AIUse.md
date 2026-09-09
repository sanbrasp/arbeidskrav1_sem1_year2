# Documentation of AI Use in this project

Contains documentation of when, how, and why AI was used in this project.

---

Overview
- [Conceptual Discussions](#conceptual-discussion)
- [Project Name Generation](#project-name-generation)
- [Leftmost Occurrence Algorithm Structure](#leftmost-occurrence-algorithm-structure)
- [Hand Trace of Binary Search With Duplicated Values](#hand-trace-of-binary-search-on-array-with-duplicated-values)
- [Spectre.Console](#spectreconsole-assistance)
- [Break-Even Calculation](#break-even-point-calculation)
- [Git Commands](#git-command-assistance)
- [Stack And Node Assistance](#stack-and-node-assistance)

---

## Conceptual Discussion 
Various discussions about encapsulation, best-practice, brainstorming, quizzing, referencing to readable sources, etc.  
Asked for various explanations regarding `Stack`, how `Stack` relates to DFS, and the core concepts.  
Used `Claude.ai` and `Google NotebookLM` as tutors. Notebook also generated a quiz and a video explainer.  
Discussed the use of `Stack`, and Claude.ai helped me realize I needed a `Node` class as well.  
Walked through some of my code and my interpretations with `Claude.ai` (example: my thought processe of the steps `Push()`
and the very first value of `_top` before even looking at the first node, and the steps of `Pop()` and `Push()`, until it 
clicked and I understood it.) 

---

## Project Name Generation
Per my own set naming convention, I had `Claude.ai` generate the project names so that I could copy and paste 
them as I was building the project structure.

---

## Leftmost Occurrence Algorithm Structure
I identified the problem myself, and thought out the pseudo code for what needed to be done and in what order.  
Claude.ai assisted me with returning my own list of steps in a tidy format, organized some erroneous ordered steps 
for me, and corrected my sentinel value choice for the counter variable. All code was written by me, and none was given 
to me by `Claude.ai` per my own instructions at the top of the 
conversation where I stated: Do not give me any code or any easy answers. Challenge me and make me think.  
It also helped me uncover an increment bug in the third branch of the algorithm - I was incrementing on a branch that made 
no comparisons, and found the bug as I was hand tracing and unable to get the same number of counts as the program 
did.

---

## Hand Trace of Binary Search on Array with Duplicated Values
To ensure a correct read, I had `Claude.ai` assist me with hand tracing the adjusted `BinarySearch()` algorith
(for ensuring the return of the leftmost occurrence of the target), and when I kept making mistakes, I asked 
Claude.ai to show me the steps of the hand trace so that I could study them and see where I went wrong.

---

## Spectre.Console Assistance
Needed some initial help setting up the columns and rows.  
Also watched a youtube video for some inspiration.

---

## Break-Even Point Calculation
`Google Notebook` (Gemini Notebook, NotebookLM) helped me calculate the number of operations using two scenarios 
to find where Linear Search would be more efficient than Binary Search and vice versa.  
The calculation were made from numbers in my own study notes - I lacked the knowledge of the formulas 
and where to insert the data. 

This is a snippet from Google Notebook (also present in [Task 1 README](Task1_LinearSearchAndBinarySearch/README.md).)
lightly rewritten by me as a way of following the steps:
```text
Collection of n = 1000 elements
k number of searches

Scenario 1: k = 2 searches

Strategy A (Linear): k = 2 (searches)
    2 x 1000 = 2000 operations

Strategy B (Sort + Binary):
    Sorting cost: 1000 log2(1000) = roughly 10 000 operations
    Searching cost: 2 x log2(1000) = roughly 20 operations
    Total: 10 000 + 20 = 10 020 operations

Winner: Linear, about 5x faster, the sorting cost was wasted
==================================
Scenario 2: k = 100 searches

Strategy A (Linear): k = 100 searches
    100 x 1000 = 100 000 operations

Strategy B (Sort and Binary): 
    Sorting cost: roughly 10 000 operations
    Searching cost: 100 x 10 = roughly 1000 operations
    Total: 10 000 + 1000 = 11 000 operations

Winner: Binary, 9x faster, the sorting cost paid for itself.
```
It also showed me how to calculate the exact point of searches where the Binary Search + Sort becomes more effective 
than the Linear Search, but since I was not able to follow the algebra and therefore chose not to include that 
in my submission.  
That is however something I will look deeper into on the side of this project, and learn, since it is a very useful skill to have.

---

## GIT Command Assistance
Various git commands that were quicker to find using AI than searching the web.  
Reminders of things I already knew but had forgotten, like `git restore --staged` for files I didn't mean 
to stage, `git push --force` when I accidentally created the repo for the project with an initial README already 
in the repo, and `git rm --cached` to clean up some files that didn't belong in the repo.

---

## Stack And Node Assistance
Pertains to Task 2 where I was supposed to choose a data structure and work with it.  
I chose `Stack` as that seems to be the most abstract and challenging one to me.  
`Claude.ai` and `Gemini Notebook / Google Notebook` was used as assistance.

`Claude.ai` directly helped me with the following:  
- `Stack` pancake analogy and building onto that with Push, Pop and Peek (explain like I am 5-method)
- Helped me realize I needed a separate `CustomNode<T>` class by asking me the right questions
- Explaining the order of the `Push()` method thoroughly until it clicked (the first value to process is when the _top  
  is still empty, then one proceeds to update that field with the first actual "pancake")

`NotebookLM` directly helped me with the following:
- The initial sketch for the `CustomStack` class
- The initial `Push()` method
- A video explainer tying the stack together with the search
- A quiz on `Stack` fundamentals