namespace Ast
open System

type Term =
    | Word    of string
    | Phrase  of string

and Field =
    | QuestionField
    | AnswerField

and Condition =
    | FieldQuery of Field * Term
    | Query      of Term

and Expr1 =
    | Not       of Expr1
    | ParenEx   of Expr2
    | Condition of Condition

and Expr2 =
    | And       of Expr2 * Expr1
    | Or        of Expr2 * Expr1
    | Expr1     of Expr1

and SearchQuery =
    | SearchQuery of Expr2
