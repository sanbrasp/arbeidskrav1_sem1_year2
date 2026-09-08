# Documentation of AI Use in this project

Contains documentation of when, how, and why AI was used in this project.

---

Overview
- [Conceptual Discussions](#conceptual-discussion)
- [Project Name Generation](#project-name-generation)
- [Leftmost Occurrence Algorithm Structure](#leftmost-occurrence-algorithm-structure)
- [Hand Trace of Binary Search With Duplicated Values](#hand-trace-of-binary-search-on-array-with-duplicated-values)
- [Spectre.Console](#spectreconsole-assistance)
- [Git Commands](#git-command-assistance)

---

## Conceptual Discussion
(_Conversations with no direct impact on the project_)
Various discussions about encapsulation, best-practice, brainstorming, quizzing, referencing to readable sources, etc.

---

## Project Name Generation
Per my own set naming convention, I had Claude.ai generate the project names so that I could copy and paste 
them as I was building the project structure.

---

## Leftmost Occurrence Algorithm Structure
I identified the problem myself, and thought out the pseudo code for what needed to be done and in what order.  
Claude.ai assisted me with returning my own list of steps in a tidy format, organized some erroneous ordered steps 
for me, and corrected my sentinel value choice for the counter variable. All code was written by me, and none was given 
to me by Claude.ai per my own instructions at the top of the 
conversation where I stated: Do not give me any code or any easy answers. Challenge me and make me think.  
It also helped me uncover an increment bug in the third branch of the algorithm - I was incrementing on a branch that made 
no comparisons, and found the bug as I was hand tracing and unable to get the same number of counts as the program 
did.

---

## Hand Trace of Binary Search on Array with Duplicated Values
To ensure a correct read, I had Claude.ai assist me with hand tracing the adjusted `BinarySearch()` algorith
(for ensuring the return of the leftmost occurrence of the target), and when I kept making mistakes, I asked 
Claude.ai to show me the steps of the hand trace so that I could study them and see where I went wrong.

---

## Spectre.Console Assistance
Needed some initial help setting up the columns and rows.  
Also watched a youtube video for some inspiration.

---

## GIT Command Assistance
Various git commands that were quicker to find using AI than searching the web.  
Reminders of things I already knew but had forgotten, like `git restore --staged` for files I didn't mean 
to stage, `git push --force` when I accidentally created the repo for the project with an initial README already 
in the repo, and `git rm --cached` to clean up some files that didn't belong in the repo.