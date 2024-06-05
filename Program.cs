using patterns_2;

//1
{
    var singleton1 = Singleton.Instance;
    var singleton2 = Singleton.Instance;
    Console.WriteLine(singleton1.GetHashCode());
    Console.WriteLine(singleton2.GetHashCode());
}

Console.WriteLine(new string('*', 10));

//2
{
    Adaptee adaptee = new Adaptee();
    ITarget target = new Adapter(adaptee);

    Console.WriteLine(target.GetRequest());
}

Console.WriteLine(new string('*', 10));

//3
{
    var editor = new Editor("Test");
    var snapshot1 = editor.CreateSnapshot();
    Console.WriteLine($"1: \"{editor.Text}\" | {editor.CursotPos}");

    editor.MoveCursorRight();
    editor.MoveCursorRight();
    editor.MoveCursorRight();
    editor.Del();
    var snapshot2 = editor.CreateSnapshot();
    Console.WriteLine($"2: \"{editor.Text}\" | {editor.CursotPos}");

    editor.MoveCursorRight();
    editor.Del();
    var snapshot3 = editor.CreateSnapshot();
    Console.WriteLine($"3: \"{editor.Text}\" | {editor.CursotPos}");

    snapshot1.Restore();
    Console.WriteLine($"4: \"{editor.Text}\" | {editor.CursotPos}");

    snapshot2.Restore();
    Console.WriteLine($"5: \"{editor.Text}\" | {editor.CursotPos}");

    snapshot3.Restore();
    Console.WriteLine($"6: \"{editor.Text}\" | {editor.CursotPos}");
}