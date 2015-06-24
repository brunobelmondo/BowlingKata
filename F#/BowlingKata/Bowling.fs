namespace BowlingKata

module Bowling = 

    type Game = {CurrentFrame:int; Rolls:int List; Score: int}

    let ScoreLastFrame game = 
        match game.Rolls with
        | 10::bonus1::bonus2::[] -> {CurrentFrame=game.CurrentFrame; Rolls=[]; Score=game.Score + 10 + bonus1 + bonus2}
        | roll1::roll2::bonus::[] -> {CurrentFrame=game.CurrentFrame; Rolls=[]; Score=game.Score + 10 + bonus}
        | roll1::roll2::[] -> {CurrentFrame=game.CurrentFrame; Rolls=[]; Score=game.Score + roll1 + roll2}

    let ScoreFrame game = 
        match game.Rolls with
        | 10::bonus1::bonus2::rest -> {CurrentFrame=game.CurrentFrame + 1; Rolls=bonus1::bonus2::rest; Score=game.Score + 10 + bonus1 + bonus2}
        | roll1::roll2::bonus::rest when roll1 + roll2 = 10-> {CurrentFrame=game.CurrentFrame + 1; Rolls=bonus::rest; Score=game.Score + 10 + bonus}
        | roll1::roll2::rest -> {CurrentFrame=game.CurrentFrame + 1; Rolls=rest; Score=game.Score + roll1 + roll2}

    let rec ScoreGame game = 
        match game.CurrentFrame with
        |10 -> ScoreLastFrame game
        |_ ->  ScoreGame (ScoreFrame game) 

    let Score (rolls:int List) = 
        let scoredGame = ScoreGame {CurrentFrame = 1; Rolls = rolls; Score = 0}
        scoredGame.Score
