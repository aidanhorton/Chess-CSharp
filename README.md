# Chess-CSharp
Lightweight chess engine with AI

WIP, currently in the prototyping stage

Todo list:
- FEN log https://www.wikiwand.com/en/Forsyth%E2%80%93Edwards_Notation
- Castling
- En passon
- Don't fallback to castle move if no threat or no good path
- Check/Checkmate logging
- Stalemate logging
- Game can be played any orientation, any colour
- Convert to .NET Core
- Dark Mode
- Online mode

Optimisations:
- Multi-threading
- GetAllMoves for a piece returns an enumeration to allow alpha-beta pruning to happen faster
- Minimax prediction performed - when a move is made, the algorithm has already explored part of the path for the response the player has, so use the previous iteration of the algorithm as a start to reduce execution time
- In GetAllMoves, check in the most likely directions for a good move first (based on position?)
- Don't necessarily have to check ALL possible moves, can do my own optimisations
- Better way for storing and grabbing pieces
- If king is in check from 2 pieces, only valid move is king
- Bit boards, attack board maps
- Calculate pinned pieces
- Bitwise
- Qperft comparison - make a good base for comparisons and board situations
- Kogge-Stone Generators for sliding moves for multiple pieces at the same time
- o^2(o-2r) when calculating moves for individual sliding pieces, using intel PSHUFB instruction to do byte swaps on 128-bit registers to calculate diagonal attacks
- Use dotTrace
- Be able to read board situation files for evaluation
- Hashing
- Unit test suite (with states and timers)
- Judge the level someone is playing at, and stop Minimax when a 'good enough' move is found
- Contiguous memory (ECS) (May not need consideration)
- Object pooling (LOH) (May not need consideration)