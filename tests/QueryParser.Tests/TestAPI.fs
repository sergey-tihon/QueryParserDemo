module TestAPI

open NUnit.Framework
open FsUnitTyped

open Microsoft.FSharp.Text.Lexing
open Ast
open Lexer
open Parser

let shouldBeEqualTo expectedTree expr =
    printfn "Expected: %A\n" expectedTree
    let lexbuff = LexBuffer<char>.FromString(expr)
    let equation = Parser.start Lexer.tokenize lexbuff
    printfn "Results: %A" equation
    equation |> shouldEqual expectedTree