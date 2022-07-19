# Description
An app simulating First and Best fit placement strategies when adding a record along with the resulting fragmentation.

[1] First Fit
<br/>
![First-Fit](https://user-images.githubusercontent.com/48753857/179852332-e37c6261-7809-40f8-977a-fd61126806a1.gif)

[2] Best Fit
<br/>
![Best-Fit](https://user-images.githubusercontent.com/48753857/179852343-b4f80f74-7e0f-4b03-a0aa-159423d18bb1.gif)

# Installation
Clone the repository.
<br/>
<br/>
Run the app directly.

# Usage
Below are the test cases used.
<br/>
<br/>

| Test Case | Number of operations | List of operations | Fragmentation (First) | Fragmentation (Best)|
| --- | --- | --- | --- | --- |
| 1 | 10 | Add, A, 12 <br/> Add, B, 15 <br/> Add, C, 20 <br/> Delete, B <br/> Add, D, 12 <br/> Add, E, 18 <br/> Delete, D <br/> Add, F, 13 <br/> Delete, C <br/> Add, G,20| 15 | 15 |
| 2 | 10 | Add, L, 5 <br/> Delete, L <br/> Add, M, 10 <br/> Delete, M <br/> Add, N, 15 <br/> Delete, N <br/> Add, O, 20 <br/> Add, P, 5 <br/> Add, Q, 10 <br/> Add, R, 15 <br/>  | 15 | 0 |
| 3 | 10 | Add, L, 30 <br/> Add, M, 20 <br/> Add, N, 10 <br/> Delete, N <br/> Delete, L <br/> Delete, M <br/> Add, P, 25 <br/> Add, Q, 15 <br/> Add, R, 10 <br/> Add, O, 20 <br/> | 10 | 10 |
| 4 | 10 | Add, H, 20 <br/> Delete, H <br/> Add, I, 30 <br/> Delete, I <br/> Add, J, 50 <br/> Delete, J <br/> Add, K, 60 <br/> Add, L, 20 <br/> Add, M, 30 <br/> Add, N, 50 <br/> | 50 | 0 |
| 5 | 10 | Add, S, 6 <br/> Delete, S <br/> Add, T, 18 <br/> Delete, T <br/> Add, U, 32 <br/> Delete, U <br/> Add, V, 20 <br/> Add, W, 5 <br/> Add, X, 10 <br/> Add, Y, 15 <br/> | 31 | 21 |
