# Documentation of AI Use in this project

Contains documentation of when, how, and why AI was used in this project.

---

Overview
- [How AI Has Been Used](#how-ai-has-been-used)
- [Conceptual Discussions](#conceptual-discussion)
- [Project Name Generation](#project-name-generation)
- [Leftmost Occurrence Algorithm Structure](#leftmost-occurrence-algorithm-structure)
- [Hand Trace of Binary Search With Duplicated Values](#hand-trace-of-binary-search-on-array-with-duplicated-values)
- [Spectre.Console](#spectreconsole-assistance)
- [Break-Even Calculation](#break-even-point-calculation)
- [Git Commands](#git-command-assistance)
- [Stack And Node Assistance](#stack-and-node-assistance)
- [CustomStack Demo](#custom-stack-demo)
- [Assert.Throws Syntax](#assertthrows-syntax)
- [Maximum Memory Limit](#maximum-memory-limit)
- [MergeSort Tutoring](#merge-sort-tutoring)

---

## How AI Has Been Used
`Claude.ai` has been used as a tutor through much of this project, where it has been initially (and repeatedly) instructed
to not provide any "free-answers" or code, and instead ask the questions needed for me to find the answer myself.  
Only when I have not been able to find the answer, having tried and failed several times, have I ended up asking for a
suggestion with detailed explanations that I have then practiced at length until I could safely say I understood.

`Google Notebook LM` / `Gemini Notebook` has been used as a "quizmaster", and it has generated video explainers, flashcards, 
and other helpful media based on my own notes from lectures and studies.

_AI has not been used as a code generator or project architect. It has been used as a tutor and learning tool, and it has 
also been used for boilerplate tasks such as name generation for projects, translation of assignments, creating bullet lists of 
what was already in the assignment text, and things of that nature.  
Whenever AI has directly affected code or the project is documented in this file._

---

## Conceptual Discussion 
Various discussions about encapsulation, best-practice, brainstorming, quizzing, referencing to readable sources, etc.  
Asked for various explanations regarding `Stack`, how `Stack` relates to DFS, and the core concepts.  
Used `Claude.ai` and `Google NotebookLM` as tutors. Notebook also generated a quiz and a video explainer.  
Discussed the use of `Stack`, and Claude.ai helped me realize I needed a `Node` class as well.  
Walked through some of my code and my interpretations with `Claude.ai` (example: my thought processe of the steps `Push()`
and the very first value of `_top` before even looking at the first node, and the steps of `Pop()` and `Push()`, until it 
clicked and I understood it.)   
`Claude.ai` has also been used to proof-read (find typos and suggest better wording), and for code-reviews after 
I have written the code myself.  

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
Task 1: Needed some initial help setting up the columns and rows.  
Also watched a youtube video for some inspiration.  
Task 2: Decided to give the console some flair, but accidentally installed the wrong NuGet package
(`Spectre.Console.Ansi` instead of `Spectre.Console`). `Claude.ai` pointed me towards checking the 
`.csproj` file for the actual installed package name, which solved my problem and allowed me to install the 
correct package instead. It also showed me some examples for text display variations like `FigletText`, `Rule` 
and `Panel`, which allowed me to choose a display style that worked for me. I landed on `Panel` for the header, 
and basic text colors and boldness for the demonstration output. I also asked `Claude.ai` to provide me with a 
linked YouTube video that I could watch for some inspiration, which ultimately led me to the decision of very basic 
formatting of the output.

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

---

## Custom Stack Demo
I had written a demo that was a little more extensive than the assignment was really asking for.  
Initially I wrote an entire graph traversal where I used my Custom Stack class.  
`Claude.ai` suggested a rewrite and shaved down version, demonstating only the methods of the class directly, 
instead of also implementing the graph traversal. It supplied the initial shape with code suggestion, which I then edited and rewrote 
to be suitable for my class and to my own liking. Final structure, variable choices, message wording, empty stack guarding 
and so on, are my own creation.

---

## Assert.Throws Syntax
I had forgotten the syntax for Asserting an exception to be thrown, and `Claude.ai` reminded me of it.  
This was quicker than a google-search.

---

## Wording Assistance for Nullability
In the `Task 2` Readme, I had not been able to clearly state the reason for the `nullable` "Next" and 
"Value" members of the `CustomNode` class properly. I asked `Claude.ai` for a suggestion rewrite, and edited that 
rewrite into my own words before including it into the Readme. The rewrite clarifies the node-level versus stack-level 
emptiness in a more comprehensible way.

---

## Maximum Memory Limit
I was considering how I should articulate this edge case, and whether it would make any sense writing a 
unit test for it. I had a discussion with `Claude.ai` about this, and I reasoned that it would not be 
very practical to add this as a running unit test that would drain both my own device's memory as well as the grader's, 
which then led to the decision of adding a note about it to the Readme for `Task 2`.

---

## Merge Sort Tutoring
`Gemini Notebook` was used to generate video explainers breaking down MergeSort and the Merge operation, and the 
general idea of MergeSort itself, based on my own lecture and study notes.

`Claude.ai` was used as an interactive tutor for where the explainers from `Notebook` had gaps.  
It helped me understand (remember) the range operator's exclusive-end behavior that I had completely forgotten about, 
reminded me of the trunctation rounding for dividing integers (rounds down, not up), and assisted me with the debugging 
I had to do because of those one-off and slice bugs I had created prior, which are also explained in more detail in the 
[Task 3 README](../Task3_DivideAndConquer/README.md).

---