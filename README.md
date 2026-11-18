# Math Interpreter One

A high-precision command-line expression evaluator built in C#. This project implements a full compilation pipeline—**Tokenization**, **Parsing**, and **Visualization/Evaluation**—to process complex mathematical strings.



## 🛠️ Build and Installation
* **Environment:** Visual Studio 2022 or higher (.NET Console Project).
* **Compilation:** Open the `.sln` file and build (**Ctrl+Shift+B**).
* **Testing:** Comprehensive Unit Tests are included to verify operator precedence and edge cases.

## 🚀 Usage & Interaction
The application supports both interactive shell mode and batch processing.
* **Interactive:** Run `MathOne.exe`. Enter expressions line-by-line.
* **Batch:** `MathOne [inputFilePath]` to process a text file of expressions.
* **Exit:** Simply enter an empty line to terminate the session.

## 📐 Technical Architecture
The engine uses a **Recursive Descent Parser** for an **LR(0)** grammar. 

1. **Tokenize():** Lexical analysis breaks strings into typed symbols.
2. **Parse():** Builds a tree based on Left-to-Right associativity and operator precedence.
3. **Visit():** Traverses the tree to compute the final result.

## 🔢 Comprehensive Operator Reference

| Category | Function Codes & Operators |
| :--- | :--- |
| **Arithmetic** | `+`, `-`, `*`, `/`, `%` (Mod), `^` (Power), `@` (Negate), `S` (Sign) |
| **Trigonometry** | `SIN`, `COS`, `TAN`, `ASIN`, `ACOS`, `ATAN`, `DEG` (ToDeg), `RAD` (ToRad) |
| **Algebra** | `A` (Abs), `SR` (Sqrt), `CR` (CubeRt), `RT` (NthRoot), `X2` (Sq), `X3`/`CB` (Cube) |
| **Probability** | `NCR` (Comb), `NPR` (Perm), `FAC` (Fact), `RAN` (RandInt), `RND` (RandDouble) |
| **Distributions**| `PHI`/`CDF` (Normal CDF), `ND` (Normal), `GAU` (Gauss), `STU` (Student-T) |
| **Number Theory**| `GCF` (Greatest Factor), `LCM` (Lowest Multiple), `PD` (Prime Divisor) |
| **Formatting** | `CL` (Ceiling), `FL` (Floor), `RD` (Round), `I` (Integer), `F` (Fraction) |
| **Constants** | `PI` (3.1415...), `EN` (Euler: 2.718...), `TAU` (6.2831...) |

## 📝 Evaluation Examples

* **Order of Operations:** `40 - (1 + 2)` → `37`
* **Trigonometry:** `COS(RAD(45))` → `0.7071067811865476`
* **Nested Negation:** `-(2 * 5)` → `-10`
* **Large Number Theory:** `LCM(13342, 234334)` → `1563242114`
* **Absolute Value:** `A(-5)` → `5`

## 📐 Grammar & Internal Logic

The parser uses a **Recursive Descent** strategy for an **LR(0)** language. The `Eval()` method executes a three-stage pipeline:
1. **Tokenize():** Lexical analysis converts the string into a list of symbols.
2. **Parse():** Converts tokens into an Abstract Syntax Tree (AST) respecting precedence.
3. **Visit():** Recursively evaluates the tree nodes to produce a double-precision result.

## 📚 Credits

1. **James McCaffrey:** "The Normal Cumulative Density Function in C#", 2014. Provided the fundamental logic for the `PHI` and `GAU` distribution functions.
2. **Unit Testing:** Includes a comprehensive suite of tests to verify the accuracy of all 40+ operators and the integrity of the recursive descent parser.

