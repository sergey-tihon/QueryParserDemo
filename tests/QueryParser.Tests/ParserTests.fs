module ParserTests

open NUnit.Framework
open TestAPI
open Ast

let [<Test>]``big AND data`` () =
    "big AND data"
    |> shouldBeEqualTo
      (SearchQuery(
        And(
          Expr1(Condition(Query(Word "big"))),
          Condition(Query(Word "data"))
        )
      ))

let [<Test>]``big data`` () =
    "big data"
    |> shouldBeEqualTo
      (SearchQuery(
        And(
          Expr1(Condition(Query(Word "big"))),
          Condition(Query(Word "data"))
        )
      ))

let [<Test>]``big OR data`` () =
    "big OR data"
    |> shouldBeEqualTo
      (SearchQuery(
        Or(
          Expr1(Condition(Query(Word "big"))),
          Condition(Query(Word "data"))
        )
      ))

let [<Test>]``NOT java`` () =
    "NOT java"
    |> shouldBeEqualTo
        (SearchQuery(
          Expr1(Not(
                 Condition(Query(Word "java"))
          ))
        ))

let [<Test>]``-java`` () =
    "-java"
    |> shouldBeEqualTo
        (SearchQuery(
          Expr1(Not(
                 Condition(Query(Word "java"))
          ))
        ))

let [<Test>]``big (data OR query)`` () =
    "big (data OR query)"
    |> shouldBeEqualTo
      (SearchQuery(
        And(
          Expr1(Condition(Query(Word "big"))),
          ParenEx(
            Or(
              Expr1(Condition(Query(Word "data"))),
              Condition(Query(Word "query"))
            )
          )
        )
      ))

let [<Test>]``"big data"`` () =
    "\"big data\""
    |> shouldBeEqualTo
      (SearchQuery(
        Expr1(
          Condition(
                Query(Phrase "big data")
          )
        )
      ))

let [<Test>]``"big data" OR "project management"`` () =
    "\"big data\" OR \"project management\""
    |> shouldBeEqualTo
      (SearchQuery(
        Or(
          Expr1(Condition(Query(Phrase "big data"))),
          Condition(Query(Phrase "project management"))
        )
      ))

let [<Test>]``Q:"big data"`` () =
    "Q:\"big data\""
    |> shouldBeEqualTo
      (SearchQuery(
        Expr1(
          Condition(
            FieldQuery(
              QuestionField,
              Phrase "big data")
          )
        )
      ))

let [<Test>]``big NOT data`` () =
    "big NOT data"
    |> shouldBeEqualTo
      (SearchQuery(
        And(
          Expr1(Condition(Query(Word "big"))),
          Not(
            Condition(Query(Word "data"))
          )
        )
      ))

let [<Test>]``big -data`` () =
    "big -data"
    |> shouldBeEqualTo
      (SearchQuery(
        And(
          Expr1(Condition(Query(Word "big"))),
          Not(
            Condition(Query(Word "data"))
          )
        )
      ))

let [<Test>]``a OR b NOT (c d)`` () =
    "a OR b NOT (c \"d e\")"
    |> shouldBeEqualTo
      (SearchQuery(
        And(
          Or(
            Expr1(Condition(Query(Word "a"))),
            Condition(Query(Word "b"))
          ),
          Not(
            ParenEx(
              And(
                Expr1(Condition(Query(Word "c"))),
                Condition(Query(Phrase "d e"))
              )
            )
          )
        )
      ))