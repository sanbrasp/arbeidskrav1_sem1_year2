_Note to self about cycle:
- a cycle is a loop, a ring
- you come back to a point you've already been to
- if you get back to a place you've already been when traversing a new path, you have a cycle
- if you look at your neighbors, one of them HAS to be the one you just left, and if the
  other ones are marked as `visited`, you have a cycle._

_Note to self about recursive DFS:
- it needs to know the value of `previous` and `current`
- when recursing deeper, the value from `current` needs to be assigned to `previous`, because
  each recursive call's `current` becomes the next call's `previous`
- if neighbor is in `visited` but is not `previous`, do not recurse again