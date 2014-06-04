module GradeSchoolTest

open NUnit.Framework
open School

[<TestFixture>]
type GradeSchoolTest() =

    [<Test>]
    member tests.New_school_has_an_empty_roster() =
        let grades = School()

        Assert.That(grades.Roster, Has.Count.EqualTo(0))

    [<Test>]
    member tests.Adding_a_student_adds_them_to_the_roster_for_the_given_grade() =
        let grades = School()

        grades.add(2, "Aimee")

        Assert.That(grades.Roster.[2], Is.EqualTo(["Aimee"]))

    [<Test>]
    member tests.Adding_more_students_to_the_same_grade_adds_them_to_the_roster() =
        let grades = School()

        grades.add(2, "Blair")
        grades.add(2, "James")
        grades.add(2, "Paul")

        Assert.That(grades.Roster.[2], Is.EqualTo(["Blair"; "James"; "Paul";]))

    [<Test>]
    member tests.Adding_students_to_different_grades_adds_them_to_the_roster() =
        let grades = School()

        grades.add(3, "Chelsea")
        grades.add(7, "Logan")

        Assert.That(grades.Roster.[3], Is.EqualTo(["Chelsea"]))
        Assert.That(grades.Roster.[7], Is.EqualTo(["Logan"]))

    [<Test>]
    member tests.Grade_returns_the_students_in_that_grade_in_alphabetical_order() =
        let grades = School()

        grades.add(5, "Franklin")
        grades.add(5, "Bradley")
        grades.add(1, "Jeff")

        Assert.That(grades.grade(5), Is.EqualTo(["Bradley"; "Franklin"]))

    [<Test>]
    member tests.Grade_returns_an_empty_list_if_there_are_no_students_in_that_grade() =
        let grades = School()

        Assert.That(grades.grade(1), Is.EqualTo([]))

    [<Test>]
    member tests.Student_names_in_each_grade_in_roster_are_sorted() =
        let grades = School()

        grades.add(4, "Jennifer");
        grades.add(6, "Kareem");
        grades.add(4, "Christopher");
        grades.add(3, "Kyle");

        Assert.That(grades.Roster.[3], Is.EqualTo(["Kyle"]))
        Assert.That(grades.Roster.[4], Is.EqualTo(["Christopher"; "Jennifer"]))
        Assert.That(grades.Roster.[6], Is.EqualTo(["Kareem"]))