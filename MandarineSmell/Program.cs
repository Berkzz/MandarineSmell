using MandarineSmell;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

var window = new RenderWindow(new VideoMode(1280, 720), "Mandarine Smell");
var world = new World();

var player = new Player(world);
var lastX = 0;
var lastY = 0;

var keys = new Dictionary<Keyboard.Key, Action>
{
    { Keyboard.Key.W, () => player.MoveForward(0.1f) },
    { Keyboard.Key.S, () => player.MoveForward(-0.1f) },
    { Keyboard.Key.D, () => player.MoveSide(0.1f) },
    { Keyboard.Key.A, () => player.MoveSide(-0.1f) },
    { Keyboard.Key.LShift, () => player.Y -= player.Speed },
    { Keyboard.Key.Space, () => player.Y += player.Speed },
};

window.Closed += Window_Closed;
window.KeyPressed += Key_Pressed;
window.MouseMoved += Mouse_Moved;

void Mouse_Moved(object? sender, MouseMoveEventArgs e)
{
    var dX = lastX - e.X;
    var dY = lastY - e.Y;
    lastX = e.X;
    lastY = e.Y;
    player.ChangeYaw(dX);
    player.ChangePitch(dY);
}

void Key_Pressed(object? sender, KeyEventArgs e)
{
    if(keys.ContainsKey(e.Code))
    {
        keys[e.Code]();
    }
}

void Window_Closed(object? sender, EventArgs e)
{
    window.Close();
}


VertexArray array = new VertexArray(PrimitiveType.Quads, 5);
array[0] = new Vertex(new Vector2f(0, 50), Color.White);
array[1] = new Vertex(new Vector2f(0, 0), Color.White);
array[2] = new Vertex(new Vector2f(50, 0), Color.White);
array[3] = new Vertex(new Vector2f(50, 50), Color.White);

while (true)
{
    window.DispatchEvents();
    window.Clear();
    window.Draw(array);
    window.Display();
}