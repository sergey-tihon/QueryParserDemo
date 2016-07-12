module LexerTests

open NUnit.Framework
open TestAPI
open Ast

let [<Test>]``"describe: a and b(c)"`` () =
    "\"describe: a and b(c)\""
    |> shouldBeEqualTo
      (SearchQuery(
        Expr1(Condition(Query(Phrase "describe: a and b(c)")))
      ))

let [<Test>]``a-b`` () =
    "a-b"
    |> shouldBeEqualTo
      (SearchQuery(
        Expr1(Condition(Query(Word "a-b")))
      ))