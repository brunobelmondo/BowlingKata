namespace BowlingKata

open NUnit.Framework
open Bowling

[<TestFixture>]
type BowlingTests() = 
    let EmptyFrame = [0;0]
    let EmptyFrames number = List.replicate number EmptyFrame 
    let EmptyGame number = List.concat (EmptyFrames number)

    [<Test>]
    member x.Should_score_be_0_when_empty_game() =
        Assert.AreEqual(0, EmptyGame 10 |> Score)

    [<Test>]
    member x.Should_score_be_sum_of_pins_when_last_frame() =
        let game = {CurrentFrame = 10; Rolls=[4;5]; Score=0}
        let scoredGame = ScoreGame game
        Assert.AreEqual(9, scoredGame.Score)

    [<Test>]
    member x.Should_score_be_sum_of_pins_and_bonus_when_spare_on_last_frame() =
        let game = {CurrentFrame = 10; Rolls=[5;5;4]; Score=0}
        let scoredGame = ScoreGame game
        Assert.AreEqual(14, scoredGame.Score)

    [<Test>]
    member x.Should_score_be_sum_of_pins_and_bonus_when_strike_on_last_frame() =
        let game = {CurrentFrame = 10; Rolls=[10;5;4]; Score=0}
        let scoredGame = ScoreGame game
        Assert.AreEqual(19, scoredGame.Score)

    [<Test>]
    member x.Should_score_be_sum_of_pins_when_normal_frame() =
        let game = {CurrentFrame = 9; Rolls=[5;4;0;0]; Score=0}
        let scoredGame = ScoreGame game
        Assert.AreEqual(9, scoredGame.Score)

