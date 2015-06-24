namespace BowlingKata

module Bowling = 

    type Game = {CurrentFrame:int; Rolls:int List; Score: int} 

    let CountFrame game remainingRolls frameScore = 
        {CurrentFrame=game.CurrentFrame+1; Rolls=remainingRolls; Score=game.Score + frameScore}

    let ScoreLastFrame game = 
        let countFrameOnGame = CountFrame game []
        match game.Rolls with
        | 10::bonus1::bonus2::[] -> countFrameOnGame (10 + bonus1 + bonus2)
        | roll1::roll2::bonus::[] -> countFrameOnGame (10 + bonus)
        | roll1::roll2::[] -> countFrameOnGame (roll1 + roll2)

    let ScoreFrame game = 
        let countFrameOnGame = CountFrame game
        match game.Rolls with
        | 10::bonus1::bonus2::rest -> countFrameOnGame (bonus1::bonus2::rest) (10 + bonus1 + bonus2)
        | roll1::roll2::bonus::rest when roll1 + roll2 = 10-> countFrameOnGame (bonus::rest) (10 + bonus)
        | roll1::roll2::rest -> countFrameOnGame rest (roll1 + roll2)

    let rec ScoreGame game = 
        match game.CurrentFrame with
        |10 -> ScoreLastFrame game
        |_ ->  ScoreGame (ScoreFrame game) 

    let Score (rolls:int List) = 
        let scoredGame = ScoreGame {CurrentFrame = 1; Rolls = rolls; Score = 0}
        scoredGame.Score
