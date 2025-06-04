
# 🧭 Maze Escape (C# Desktop App)

Maze Runner is a C# desktop application that visually demonstrates how classic pathfinding algorithms like Depth-First Search (DFS) and Breadth-First Search (BFS) solve a maze. It features a colorful, real-time interface that helps users understand how these algorithms work step-by-step.

<p align="center" style="display: flex; justify-content: center; gap: 8px;">
  <img src="https://github.com/SeifMohmmed/Maze-Runner/blob/76f85afd4b25f2458e93063be464e182f724fde8/Screenshot.png" alt="image alt" style="max-width: 100px;" />
  <img src="https://github.com/SeifMohmmed/Maze-Runner/blob/76f85afd4b25f2458e93063be464e182f724fde8/Screenshot%202.png" alt="image alt" style="max-width: 100px;" />
</p>

---

## 🚀 Features

- 🔷 Real-time visualization of DFS and BFS
- 🟥 Start (Robot), 🟩 Goal (Target), 🟦 Frontier nodes, and 🟦 Explored (Closed set)
- 🟨 Final path from start to goal
- 📈 Metrics shown: Nodes Expanded, Steps Taken, and Path Distance
- 🧹 Maze generation and board clearing
- 🔘 Cell shape options (e.g., Square)
- 🎛️ Interactive GUI with buttons and algorithm selection

---

## 🧰 Technologies Used

- **Language:** C#
- **Framework:** .NET (Windows Forms)
- **GUI:** Windows Forms
---

## 🧠 Algorithms

### ✅ Breadth-First Search (BFS)

* Explores all neighbors at the current depth before going deeper.
* Guaranteed to find the shortest path in unweighted mazes.

### 🔄 Depth-First Search (DFS)

* Explores paths as deep as possible before backtracking.
* May not find the shortest path but is easier to implement.

---

## 📊 Example Output (from GUI)

```
Nodes expanded: 176
Steps: 164
Distance: 2,624.0
```

---

## 📌 Controls

* **Maze**: Generate a new maze
* **Clear**: Reset the board
* **Real-Time**: Begin algorithm animation
* **DFS / BFS**: Select the algorithm (one at a time)

---

## 🛠️ Future Improvements

* Add more advanced algorithms like A\* or Dijkstra
* Implement performance tuning (speed slider)
* Save maze or export path data

---

## 🤝 Contributing

Contributions are welcome! Feel free to submit pull requests or suggest new features.




